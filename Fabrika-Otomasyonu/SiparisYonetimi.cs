using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Windows.Forms;

namespace Fabrika_Otomasyonu
{
    /// <summary>
    /// Sipariş oluşturma, listeleme, durum güncelleme ve stok/termin hesaplamalarını yöneten sınıf.
    /// </summary>
    public class SiparisYonetimi
    {
        // =============================================================
        // BÖLÜM 1: OKUMA İŞLEMLERİ (GETİR)
        // =============================================================

        /// <summary>
        /// Yönetici ekranı için tüm siparişleri listeler.
        /// Sıralama Önceliği: Onay Bekliyor > Hazırlanıyor > Diğerleri.
        /// </summary>
        public DataTable SiparisleriGetir()
        {
            using (var con = Veritabani.BaglantiGetir())
            {
                // CASE WHEN ile özel sıralama yapılıyor: Acil olanlar en üste.
                string sql = @"SELECT * FROM Siparisler 
                               ORDER BY CASE 
                                   WHEN Durum = 'Onay Bekliyor' THEN 1 
                                   WHEN Durum = 'Hazırlanıyor' THEN 2 
                                   ELSE 3 
                               END, Id DESC";
                using (var da = new SQLiteDataAdapter(sql, con))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        /// <summary>
        /// Belirli bir müşterinin sipariş geçmişini getirir (Müşteri Paneli).
        /// </summary>
        public DataTable MusteriSiparisleriniGetir(string telefon)
        {
            using (var con = Veritabani.BaglantiGetir())
            {
                string sql = "SELECT UrunAdi, Adet, Tutar, Durum, TahminiTarih FROM Siparisler WHERE Telefon = @tel ORDER BY Id DESC";
                using (var da = new SQLiteDataAdapter(sql, con))
                {
                    da.SelectCommand.Parameters.AddWithValue("@tel", telefon);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        // =============================================================
        // BÖLÜM 2: YAZMA İŞLEMLERİ (EKLE / GÜNCELLE)
        // =============================================================

        /// <summary>
        /// Yeni bir sipariş kaydı oluşturur. Başlangıç durumu: 'Onay Bekliyor'.
        /// </summary>
        public void SiparisOlustur(string musteriAdi, string telefon, string urunAdi, int adet, decimal birimFiyat, string adres, string siparisKodu)
        {
            using (var con = Veritabani.BaglantiGetir())
            {
                decimal toplamTutar = adet * birimFiyat;

                string sql = "INSERT INTO Siparisler (MusteriAdi, Telefon, UrunAdi, Adet, Tutar, Adres, SiparisKodu, Durum, Tarih) VALUES (@musteri, @tel, @urun, @adet, @tutar, @adres, @kod, 'Onay Bekliyor', @tarih)";

                using (var cmd = new SQLiteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@musteri", musteriAdi);
                    cmd.Parameters.AddWithValue("@tel", telefon);
                    cmd.Parameters.AddWithValue("@urun", urunAdi);
                    cmd.Parameters.AddWithValue("@adet", adet);
                    cmd.Parameters.AddWithValue("@tutar", toplamTutar);
                    cmd.Parameters.AddWithValue("@adres", adres);
                    cmd.Parameters.AddWithValue("@kod", siparisKodu);
                    cmd.Parameters.AddWithValue("@tarih", DateTime.Now.ToString("yyyy-MM-dd HH:mm"));
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Tek bir siparişin durumunu günceller (Örn: Kargoya Verildi).
        /// </summary>
        public void DurumDegistir(int id, string yeniDurum)
        {
            using (var con = Veritabani.BaglantiGetir())
            {
                string sql = "UPDATE Siparisler SET Durum=@durum WHERE Id=@id";
                using (var cmd = new SQLiteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@durum", yeniDurum);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Aynı sipariş koduna sahip (sepet mantığı) tüm ürünlerin durumunu toplu günceller.
        /// </summary>
        public void DurumDegistirGrup(string siparisKodu, string yeniDurum)
        {
            using (var con = Veritabani.BaglantiGetir())
            {
                string sql = "UPDATE Siparisler SET Durum=@durum WHERE SiparisKodu=@kod";
                using (var cmd = new SQLiteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@durum", yeniDurum);
                    cmd.Parameters.AddWithValue("@kod", siparisKodu);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // =============================================================
        // BÖLÜM 3: İŞ MANTIĞI (ONAY VE HESAPLAMALAR)
        // =============================================================

        /// <summary>
        /// Siparişi onaylamadan önce stok kontrolü yapar. 
        /// Yeterli hammadde varsa stoktan düşer ve durumu 'Hazırlanıyor' yapar.
        /// </summary>
        /// <returns>İşlem başarılıysa true, stok yetersizse false döner.</returns>
        public bool SiparisiOnaylaVeStokDus(string siparisKodu)
        {
            using (var con = Veritabani.BaglantiGetir())
            {
                // 1. Siparişteki ürünleri çek
                string sqlSiparisler = "SELECT UrunAdi, Adet FROM Siparisler WHERE SiparisKodu=@kod";
                DataTable dtUrunler = new DataTable();
                using (var da = new SQLiteDataAdapter(sqlSiparisler, con))
                {
                    da.SelectCommand.Parameters.AddWithValue("@kod", siparisKodu);
                    da.Fill(dtUrunler);
                }

                // 2. İhtiyaç listesini hesapla (Hangi maddeden ne kadar lazım?)
                Dictionary<string, double> ihtiyacListesi = new Dictionary<string, double>();

                foreach (DataRow row in dtUrunler.Rows)
                {
                    string urunTamAdi = row["UrunAdi"].ToString();
                    int adet = Convert.ToInt32(row["Adet"]);
                    string modelAdi = urunTamAdi.Split('(')[0].Trim();

                    // Ürünün hammadde türünü bul
                    string sqlUrun = "SELECT Tur, AnaHammadde FROM Urunler WHERE ModelAd=@model";
                    string tur = "", anaHammadde = "";

                    using (var cmd = new SQLiteCommand(sqlUrun, con))
                    {
                        cmd.Parameters.AddWithValue("@model", modelAdi);
                        using (var dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                tur = dr["Tur"].ToString();
                                anaHammadde = dr["AnaHammadde"].ToString();
                            }
                        }
                    }

                    // Katsayı hesapları (Taban ve Deri/Kumaş)
                    double tabanGereken = adet * 16;
                    double deriKatsayi = (tur == "Bot" ? 0.2 : (tur == "Spor" ? 0.15 : 0.1)) * 10;
                    double deriGereken = adet * deriKatsayi;

                    // Listeye Ekle veya Güncelle
                    if (ihtiyacListesi.ContainsKey("Taban")) ihtiyacListesi["Taban"] += tabanGereken;
                    else ihtiyacListesi.Add("Taban", tabanGereken);

                    if (ihtiyacListesi.ContainsKey(anaHammadde)) ihtiyacListesi[anaHammadde] += deriGereken;
                    else ihtiyacListesi.Add(anaHammadde, deriGereken);
                }

                // 3. Stok Kontrolü (Yeterli mi?)
                string eksikMalzemeler = "";
                bool stokYeterliMi = true;

                foreach (var item in ihtiyacListesi)
                {
                    double mevcutStok = StokMiktariGetir(con, item.Key); // Yardımcı metod kullanıldı

                    if (mevcutStok < item.Value)
                    {
                        stokYeterliMi = false;
                        eksikMalzemeler += $"- {item.Key}: Mevcut {mevcutStok}, Gereken {item.Value}\n";
                    }
                }

                // 4. Karar Anı
                if (!stokYeterliMi)
                {
                    XtraMessageBox.Show("Yetersiz Stok!\n\n" + eksikMalzemeler, "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                // 5. Stok Düşme İşlemi (Commit)
                foreach (var item in ihtiyacListesi)
                {
                    StokGuncelle(con, item.Key, -item.Value); // Yardımcı metod ile çıkarma işlemi (negatif değer)
                }

                // Durumu güncelle
                DurumDegistirGrup(siparisKodu, "Hazırlanıyor");
                return true;
            }
        }

        /// <summary>
        /// Tüm siparişlerin tahmini bitiş sürelerini, üretim sırası ve arıza durumlarına göre yeniden hesaplar.
        /// </summary>
        public void TumTarihleriGuncelle()
        {
            using (var con = Veritabani.BaglantiGetir())
            {
                // 1. Arıza Bildirimi Kontrolü
                int arizaGecikmesi = 0;
                using (var cmd = new SQLiteCommand("SELECT Mesaj FROM Bildirimler WHERE AktifMi=1 AND Baslik LIKE '%Arıza%'", con))
                {
                    var sonuc = cmd.ExecuteScalar();
                    if (sonuc != null)
                    {
                        string mesaj = sonuc.ToString();
                        if (mesaj.Contains("1 Gün")) arizaGecikmesi = 1;
                        else if (mesaj.Contains("3 Gün")) arizaGecikmesi = 3;
                        else if (mesaj.Contains("1 Hafta")) arizaGecikmesi = 7;
                    }
                }

                // 2. Bekleyen işleri sırayla çek
                string sql = @"SELECT S.Id, S.SiparisKodu, S.Adet, U.UretimGunu 
                               FROM Siparisler S 
                               JOIN Urunler U ON S.UrunAdi LIKE U.ModelAd || '%' 
                               WHERE S.Durum IN ('Onay Bekliyor', 'Hazırlanıyor') 
                               ORDER BY S.Id ASC";

                DataTable dt = new DataTable();
                using (var da = new SQLiteDataAdapter(sql, con)) da.Fill(dt);

                // 3. Hesaplama Motoru Başlangıcı
                DateTime hatBitisZamani = DateTime.Now;
                if (arizaGecikmesi > 0) hatBitisZamani = hatBitisZamani.AddDays(arizaGecikmesi);

                // Grupları (Sepetleri) ayıkla
                var grupKodlari = dt.AsEnumerable()
                                    .Select(r => r["SiparisKodu"].ToString())
                                    .Distinct()
                                    .ToList();

                foreach (string kod in grupKodlari)
                {
                    var grupSatirlari = dt.Select($"SiparisKodu = '{kod}'");
                    double buGrubunToplamSuresi = 0;

                    // Bu sepetin toplam süresini bul
                    foreach (var row in grupSatirlari)
                    {
                        int adet = Convert.ToInt32(row["Adet"]);
                        double birimSure = row["UretimGunu"] != DBNull.Value ? Convert.ToDouble(row["UretimGunu"]) : 0.1;
                        buGrubunToplamSuresi += (adet * birimSure);
                    }

                    // Genel hattı bu kadar ötele
                    hatBitisZamani = hatBitisZamani.AddDays(buGrubunToplamSuresi);

                    // Bu sepetteki TÜM ürünlere AYNI bitiş tarihini bas
                    foreach (var row in grupSatirlari)
                    {
                        int id = Convert.ToInt32(row["Id"]);
                        string updateSql = "UPDATE Siparisler SET TahminiTarih = @tarih WHERE Id = @id";
                        using (var cmd = new SQLiteCommand(updateSql, con))
                        {
                            cmd.Parameters.AddWithValue("@tarih", hatBitisZamani);
                            cmd.Parameters.AddWithValue("@id", id);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        // =============================================================
        // BÖLÜM 4: YARDIMCI METODLAR (PRIVATE)
        // =============================================================

        private double StokMiktariGetir(SQLiteConnection con, string tur)
        {
            using (var cmd = new SQLiteCommand("SELECT Miktar FROM Hammaddeler WHERE Tur=@tur", con))
            {
                cmd.Parameters.AddWithValue("@tur", tur);
                object result = cmd.ExecuteScalar();
                return result != null ? Convert.ToDouble(result) : 0;
            }
        }

        private void StokGuncelle(SQLiteConnection con, string tur, double miktar)
        {
            // Miktar pozitifse ekler, negatifse çıkarır
            using (var cmd = new SQLiteCommand("UPDATE Hammaddeler SET Miktar = Miktar + @mik WHERE Tur=@tur", con))
            {
                cmd.Parameters.AddWithValue("@mik", miktar);
                cmd.Parameters.AddWithValue("@tur", tur);
                cmd.ExecuteNonQuery();
            }
        }
    }
}