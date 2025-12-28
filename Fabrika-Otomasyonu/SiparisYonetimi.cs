using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Windows.Forms;

namespace Fabrika_Otomasyonu
{
    public class SiparisYonetimi
    {
        // 1. SİPARİŞ LİSTESİ (YÖNETİCİ)
        public DataTable SiparisleriGetir()
        {
            using (var con = Veritabani.BaglantiGetir())
            {
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

        // 2. MÜŞTERİ SİPARİŞLERİ
        public DataTable MusteriSiparisleriniGetir(string telefon)
        {
            using (var con = Veritabani.BaglantiGetir())
            {
                // TahminiTarih sütununu da çekiyoruz
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

        // 3. SİPARİŞ OLUŞTUR 
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
                    cmd.Parameters.AddWithValue("@kod", siparisKodu); // <-- AYNI KOD KAYDEDİLİYOR
                    cmd.Parameters.AddWithValue("@tarih", DateTime.Now.ToString("yyyy-MM-dd HH:mm"));
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // 4. DURUM GÜNCELLEME (Kargoya Verildi vs.)
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

        // 5. YÖNETİCİ ONAYI VE STOK DÜŞME (KRİTİK KISIM)
        // --- GRUP BAZLI ONAY VE STOK DÜŞME ---
        public bool SiparisiOnaylaVeStokDus(string siparisKodu)
        {
            using (var con = Veritabani.BaglantiGetir())
            {
                // 1. SİPARİŞTEKİ ÜRÜNLERİ ÇEK
                string sqlSiparisler = "SELECT UrunAdi, Adet FROM Siparisler WHERE SiparisKodu=@kod";
                DataTable dtUrunler = new DataTable();
                using (var da = new SQLiteDataAdapter(sqlSiparisler, con))
                {
                    da.SelectCommand.Parameters.AddWithValue("@kod", siparisKodu);
                    da.Fill(dtUrunler);
                }

                // 2. İHTİYAÇ LİSTESİNİ HESAPLA (Hangi maddeden ne kadar lazım?)
                // Dictionary kullanıyoruz: "Hammadde Adı" -> "Gereken Miktar"
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

                    // Miktar Hesapları (Senin verdiğin katsayılara göre)
                    // Taban: Her çift için sabit (Örn: 16 birim)
                    double tabanGereken = adet * 16;

                    // Deri: Türüne göre değişiyor (m2 veya birim hesabı)
                    double deriKatsayi = (tur == "Bot" ? 0.2 : (tur == "Spor" ? 0.15 : 0.1)) * 10;
                    double deriGereken = adet * deriKatsayi;

                    // Listeye Ekle (Varsa üstüne topla, yoksa yeni ekle)
                    if (ihtiyacListesi.ContainsKey("Taban")) ihtiyacListesi["Taban"] += tabanGereken;
                    else ihtiyacListesi.Add("Taban", tabanGereken);

                    if (ihtiyacListesi.ContainsKey(anaHammadde)) ihtiyacListesi[anaHammadde] += deriGereken;
                    else ihtiyacListesi.Add(anaHammadde, deriGereken);
                }

                // 3. STOK KONTROLÜ (Veritabanında yeterli mal var mı?)
                string eksikMalzemeler = "";
                bool stokYeterliMi = true;

                foreach (var item in ihtiyacListesi)
                {
                    string hammaddeAdi = item.Key;
                    double gerekenMiktar = item.Value;
                    double mevcutStok = 0;

                    using (var cmd = new SQLiteCommand("SELECT Miktar FROM Hammaddeler WHERE Tur=@tur", con))
                    {
                        cmd.Parameters.AddWithValue("@tur", hammaddeAdi);
                        object sonuc = cmd.ExecuteScalar();
                        if (sonuc != null) mevcutStok = Convert.ToDouble(sonuc);
                    }

                    // KONTROL ANI
                    if (mevcutStok < gerekenMiktar)
                    {
                        stokYeterliMi = false;
                        eksikMalzemeler += $"- {hammaddeAdi}: Mevcut {mevcutStok}, Gereken {gerekenMiktar}\n";
                    }
                }

                // 4. KARAR ANI: EĞER EKSİK VARSA DUR!
                if (!stokYeterliMi)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(
                        "Bu siparişi onaylamak için yeterli hammadde yok!\n\nEksik Listesi:\n" + eksikMalzemeler,
                        "Stok Yetersiz",
                        System.Windows.Forms.MessageBoxButtons.OK,
                        System.Windows.Forms.MessageBoxIcon.Warning
                    );
                    return false; // İşlemi iptal et
                }

                // 5. STOK DÜŞME VE ONAYLAMA (Sadece stok yeterliyse buraya gelir)
                foreach (var item in ihtiyacListesi)
                {
                    using (var cmd = new SQLiteCommand("UPDATE Hammaddeler SET Miktar = Miktar - @miktar WHERE Tur=@tur", con))
                    {
                        cmd.Parameters.AddWithValue("@miktar", item.Value);
                        cmd.Parameters.AddWithValue("@tur", item.Key);
                        cmd.ExecuteNonQuery();
                    }
                }

                // Durumu güncelle
                DurumDegistirGrup(siparisKodu, "Hazırlanıyor");

                return true; // İşlem başarılı
            }
        }

        // Yardımcı Metod: Stok Sorgula
        private double StokMiktariGetir(SQLiteConnection con, string tur)
        {
            using (var cmd = new SQLiteCommand("SELECT Miktar FROM Hammaddeler WHERE Tur=@tur", con))
            {
                cmd.Parameters.AddWithValue("@tur", tur);
                object result = cmd.ExecuteScalar();
                return result != null ? Convert.ToDouble(result) : 0;
            }
        }

        // Yardımcı Metod: Stok Güncelle (+ ekler, - çıkarır)
        private void StokGuncelle(SQLiteConnection con, string tur, double miktar)
        {
            using (var cmd = new SQLiteCommand("UPDATE Hammaddeler SET Miktar = Miktar + @mik WHERE Tur=@tur", con))
            {
                cmd.Parameters.AddWithValue("@mik", miktar);
                cmd.Parameters.AddWithValue("@tur", tur);
                cmd.ExecuteNonQuery();
            }
        }
        // --- SİPARİŞ KUYRUĞU VE TERMİN HESAPLAMA ---
        // --- GRUP BAZLI AKILLI TARİH HESAPLAMA ---
        public void TumTarihleriGuncelle()
        {
            using (var con = Veritabani.BaglantiGetir())
            {
                // 1. Arıza Gecikmesi Var mı?
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

                // 2. Bekleyen İşleri GRUPLU Çek
                // Aynı sipariş koduna sahip ürünleri, ID sırasına göre getirir
                string sql = @"SELECT S.Id, S.SiparisKodu, S.Adet, U.UretimGunu 
                       FROM Siparisler S 
                       JOIN Urunler U ON S.UrunAdi LIKE U.ModelAd || '%' 
                       WHERE S.Durum IN ('Onay Bekliyor', 'Hazırlanıyor') 
                       ORDER BY S.Id ASC";

                DataTable dt = new DataTable();
                using (var da = new SQLiteDataAdapter(sql, con)) da.Fill(dt);

                // 3. Hesaplama Motoru
                DateTime hatBitisZamani = DateTime.Now;
                if (arizaGecikmesi > 0) hatBitisZamani = hatBitisZamani.AddDays(arizaGecikmesi);

                // Grupları takip etmek için
                string suankiGrupKodu = "";
                double grupToplamSure = 0;
                DateTime grupBaslangicZamani = hatBitisZamani;

                // -- ÖN HAZIRLIK: LİSTEYİ GRUPLARA AYIRIP TARİH DAĞITACAĞIZ --

                // Bu kısımda mantığı basit tutuyoruz:
                // Her satırı dön, o satırın süresini hesapla ve genel hatta ekle.
                // FAKAT: Aynı gruptaki ürünlerin bitiş tarihi, grubun EN SONUNDAKİ tarih olmalı.

                // Basit yöntem: Önce süreleri hesapla, sonra aynı koda sahip olanlara aynı tarihi bas.
                // Ama sıra kaymaması lazım. Şöyle yapalım:

                // Distinct (Benzersiz) Grup Kodlarını Sırayla Alalım
                var grupKodlari = dt.AsEnumerable()
                                    .Select(r => r["SiparisKodu"].ToString())
                                    .Distinct()
                                    .ToList();

                foreach (string kod in grupKodlari)
                {
                    // Bu gruba ait satırları bul
                    var grupSatirlari = dt.Select($"SiparisKodu = '{kod}'");

                    double buGrubunToplamSuresi = 0;

                    // Grubun toplam süresini hesapla
                    foreach (var row in grupSatirlari)
                    {
                        int adet = Convert.ToInt32(row["Adet"]);
                        double birimSure = row["UretimGunu"] != DBNull.Value ? Convert.ToDouble(row["UretimGunu"]) : 0.1;
                        buGrubunToplamSuresi += (adet * birimSure);
                    }

                    // Genel Hat Zamanını İlerlet
                    hatBitisZamani = hatBitisZamani.AddDays(buGrubunToplamSuresi);

                    // Bu gruptaki TÜM satırlara AYNI BİTİŞ TARİHİNİ yaz
                    foreach (var row in grupSatirlari)
                    {
                        int id = Convert.ToInt32(row["Id"]);
                        string updateSql = "UPDATE Siparisler SET TahminiTarih = @tarih WHERE Id = @id";
                        using (var cmd = new SQLiteCommand(updateSql, con))
                        {
                            cmd.Parameters.AddWithValue("@tarih", hatBitisZamani); // Hepsi paket bitince gider
                            cmd.Parameters.AddWithValue("@id", id);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
        }
        // GRUP BAZLI DURUM GÜNCELLEME
        public void DurumDegistirGrup(string siparisKodu, string yeniDurum)
        {
            using (var con = Veritabani.BaglantiGetir())
            {
                // ID yerine SiparisKodu kullanıyoruz
                string sql = "UPDATE Siparisler SET Durum=@durum WHERE SiparisKodu=@kod";
                using (var cmd = new SQLiteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@durum", yeniDurum);
                    cmd.Parameters.AddWithValue("@kod", siparisKodu);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}   