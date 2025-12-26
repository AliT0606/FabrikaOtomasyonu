using System;
using System.Data;
using System.Data.SQLite;

namespace Fabrika_Otomasyonu
{
    public class SiparisYonetimi
    {
        // 1. Siparişleri Listele (Yönetici Paneli için)
        public DataTable SiparisleriGetir()
        {
            using (var con = Veritabani.BaglantiGetir())
            {
                // Tablo yoksa oluştur (Garanti olsun)
                TabloyuKontrolEt(con);

                string sql = "SELECT * FROM Siparisler ORDER BY Id DESC";
                using (var da = new SQLiteDataAdapter(sql, con))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        // 2. Yeni Sipariş Oluştur (Müşteri Paneli için)
        public void SiparisOlustur(string musteriAdi, string urunAdi, int adet, decimal birimFiyat)
        {
            using (var con = Veritabani.BaglantiGetir())
            {
                TabloyuKontrolEt(con); // Tablo yoksa hata vermesin diye kontrol

                decimal toplamTutar = adet * birimFiyat;

                string sql = "INSERT INTO Siparisler (MusteriAdi, UrunAdi, Adet, Tutar, Durum, Tarih) VALUES (@musteri, @urun, @adet, @tutar, 'Onay Bekliyor', @tarih)";

                using (var cmd = new SQLiteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@musteri", musteriAdi);
                    cmd.Parameters.AddWithValue("@urun", urunAdi);
                    cmd.Parameters.AddWithValue("@adet", adet);
                    cmd.Parameters.AddWithValue("@tutar", toplamTutar);
                    cmd.Parameters.AddWithValue("@tarih", DateTime.Now.ToString("yyyy-MM-dd HH:mm"));

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // 3. Durum Güncelle (Yönetici Paneli: Hazırlanıyor, Kargolandı vb.)
        public void DurumGuncelle(int siparisId, string yeniDurum)
        {
            using (var con = Veritabani.BaglantiGetir())
            {
                string sql = "UPDATE Siparisler SET Durum=@durum WHERE Id=@id";
                using (var cmd = new SQLiteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@durum", yeniDurum);
                    cmd.Parameters.AddWithValue("@id", siparisId);
                    cmd.ExecuteNonQuery();
                }   
            }
        }

        // 4. Test Amaçlı Rastgele Sipariş Ekle
        public void TestSiparisEkle()
        {
            SiparisOlustur("Test Müşteri", "Deneme Bot (42)", 1, 1500);
        }

        // Yardımcı Metod: Tablo Yoksa Oluşturur
        private void TabloyuKontrolEt(SQLiteConnection con)
        {
            string tabloSql = @"CREATE TABLE IF NOT EXISTS Siparisler (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    MusteriAdi TEXT,
                    UrunAdi TEXT,
                    Adet INTEGER,
                    Tutar DECIMAL,
                    Durum TEXT,
                    Tarih TEXT
                )";
            using (var cmd = new SQLiteCommand(tabloSql, con)) { cmd.ExecuteNonQuery(); }
        }
    }
}