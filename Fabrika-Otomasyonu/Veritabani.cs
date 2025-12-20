using System;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace FabrikaOtomasyonu
{
    public class Veritabani
    {
        // Dosya ismi ve bağlantı ayarı
        public static string dbDosyaAdi = "FabrikaDb.sqlite";
        public static string baglantiCumlesi = $"Data Source={dbDosyaAdi};Version=3;";

        public static void KurulumYap()
        {
            // Dosya zaten varsa tekrar oluşturma, çık.
            if (File.Exists(dbDosyaAdi)) return;

            try
            {
                SQLiteConnection.CreateFile(dbDosyaAdi);

                using (SQLiteConnection baglanti = new SQLiteConnection(baglantiCumlesi))
                {
                    baglanti.Open();

                    // 1. Tabloları Oluşturuyoruz
                    string sqlTablolar = @"
                        CREATE TABLE Kullanicilar (
                            ID INTEGER PRIMARY KEY AUTOINCREMENT,
                            AdSoyad TEXT,
                            Telefon TEXT,       -- Müşteri Girişi İçin
                            KullaniciAdi TEXT,  -- Yönetici Girişi İçin
                            Sifre TEXT,         -- Yönetici Şifresi
                            Rol TEXT            -- 'Yonetici' veya 'Musteri'
                        );

                        CREATE TABLE Urunler (
                            ID INTEGER PRIMARY KEY AUTOINCREMENT,
                            ModelKodu TEXT,
                            UrunAdi TEXT,
                            Kategori TEXT,
                            Fiyat REAL,
                            SureGun INTEGER
                        );

                        CREATE TABLE Siparisler (
                            ID INTEGER PRIMARY KEY AUTOINCREMENT,
                            MusteriID INTEGER,
                            UrunID INTEGER,
                            Adet INTEGER,
                            Tarih DATETIME,
                            TeslimTarihi DATETIME,
                            Durum TEXT
                        );
                    ";

                    using (SQLiteCommand cmd = new SQLiteCommand(sqlTablolar, baglanti))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    // 2. İçine Örnek Veri Ekliyoruz
                    string sqlVeriler = @"
                        -- Yönetici (Kullanıcı Adı: Admin, Şifre: Admin1453)
                        INSERT INTO Kullanicilar (AdSoyad, KullaniciAdi, Sifre, Rol) 
                        VALUES ('Fabrika Müdürü', 'Admin', 'Admin1453', 'Yonetici');

                        -- Müşteri (Telefon: 555, Şifresiz)
                        INSERT INTO Kullanicilar (AdSoyad, Telefon, Rol) 
                        VALUES ('Ahmet Yılmaz', '555', 'Musteri');

                        -- Birkaç Ayakkabı Modeli
                        INSERT INTO Urunler (ModelKodu, UrunAdi, Kategori, Fiyat, SureGun) VALUES ('B-100', 'Kışlık Bot', 'Bot', 2500, 3);
                        INSERT INTO Urunler (ModelKodu, UrunAdi, Kategori, Fiyat, SureGun) VALUES ('S-200', 'Yazlık Spor', 'Spor', 1500, 1);
                    ";

                    using (SQLiteCommand cmd = new SQLiteCommand(sqlVeriler, baglanti))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Veritabanı Başarıyla Oluşturuldu!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        public static SQLiteConnection BaglantiGetir()
        {
            return new SQLiteConnection(baglantiCumlesi);
        }
    }
}
