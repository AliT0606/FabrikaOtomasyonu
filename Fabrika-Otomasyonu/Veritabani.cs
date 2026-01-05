using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;

namespace Fabrika_Otomasyonu
{
    public class Veritabani
    {
        // Dosya yolu: Projenin çalıştığı klasör (bin/Debug) içinde oluşur.
        private static string dosyaAdi = "FabrikaDb.sqlite";
        private static string baglantiString = $"Data Source={dosyaAdi};Version=3;";

        // -----------------------------------------------------------
        // 1. BAĞLANTIYI GETİR (HER ZAMAN BURAYI KULLANACAĞIZ)
        // -----------------------------------------------------------
        public static SQLiteConnection BaglantiGetir()
        {
            var con = new SQLiteConnection(baglantiString);
            if (con.State != ConnectionState.Open)
            {
                con.Open();

                // ÇOK ÖNEMLİ: SQLite'da İlişkisel bütünlüğü (Cascade Delete) aktif eder.
                // Bu olmazsa ürünü silince varyantları veritabanında çöp olarak kalır.
                using (var cmd = new SQLiteCommand("PRAGMA foreign_keys = ON;", con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
            return con;
        }

        // -----------------------------------------------------------
        // 2. TABLOLARI OLUŞTUR (KURULUM)
        // -----------------------------------------------------------
        public static void TablolariKur()
        {
            if (!File.Exists(dosyaAdi)) SQLiteConnection.CreateFile(dosyaAdi);

            using (var con = BaglantiGetir())
            {
                using (var cmd = new SQLiteCommand(con))
                {
                    // Tabloları oluştur (Standart kodlar)
                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS Kullanicilar (Id INTEGER PRIMARY KEY AUTOINCREMENT, AdSoyad TEXT, KullaniciAdi TEXT, Sifre TEXT, Telefon TEXT, Rol TEXT);";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS Urunler (Id INTEGER PRIMARY KEY AUTOINCREMENT, ModelAd TEXT NOT NULL, Tur TEXT, AnaHammadde TEXT, Fiyat REAL DEFAULT 0);";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS UrunVaryant (Id INTEGER PRIMARY KEY AUTOINCREMENT, UrunId INTEGER, Renk TEXT, Resim BLOB, FOREIGN KEY(UrunId) REFERENCES Urunler(Id) ON DELETE CASCADE);";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS Hammaddeler (Id INTEGER PRIMARY KEY AUTOINCREMENT, Tur TEXT, Birim TEXT, Miktar REAL DEFAULT 0);";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS Makineler (Id INTEGER PRIMARY KEY AUTOINCREMENT, MakineAd TEXT, Durum TEXT DEFAULT 'Aktif', ArizaMesaji TEXT);";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS Siparisler (Id INTEGER PRIMARY KEY AUTOINCREMENT, MusteriAdi TEXT, Telefon TEXT, UrunAdi TEXT, Adet INTEGER, Tutar DECIMAL, Adres TEXT, Durum TEXT DEFAULT 'Hazırlanıyor', Tarih DATETIME DEFAULT CURRENT_TIMESTAMP);";
                    cmd.ExecuteNonQuery();
                    
                    cmd.CommandText = @"CREATE TABLE IF NOT EXISTS Bildirimler (Id INTEGER PRIMARY KEY AUTOINCREMENT, Baslik TEXT, Mesaj TEXT, Tarih DATETIME DEFAULT CURRENT_TIMESTAMP, AktifMi INTEGER DEFAULT 1);";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS OkunanBildirimler (Id INTEGER PRIMARY KEY AUTOINCREMENT, Telefon TEXT, BildirimId INTEGER);";
                    cmd.ExecuteNonQuery();
                }

                // --- YAMA BÖLÜMÜ (Sütun Eksikse Ekle) ---
                try { using (var c = new SQLiteCommand("ALTER TABLE Siparisler ADD COLUMN Telefon TEXT", con)) c.ExecuteNonQuery(); } catch { }
                try { using (var c = new SQLiteCommand("ALTER TABLE Siparisler ADD COLUMN MusteriAdi TEXT", con)) c.ExecuteNonQuery(); } catch { }
                try { using (var c = new SQLiteCommand("ALTER TABLE Siparisler ADD COLUMN Durum TEXT DEFAULT 'Onay Bekliyor'", con)) c.ExecuteNonQuery(); } catch { }
                try { using (var c = new SQLiteCommand("ALTER TABLE Kullanicilar ADD COLUMN Adres TEXT", con)) c.ExecuteNonQuery(); } catch { }
                // Ürünlere 'Birim Üretim Süresi' (1 takım kaç gün?) ekle
                try { using (var c = new SQLiteCommand("ALTER TABLE Urunler ADD COLUMN UretimGunu REAL DEFAULT 0.1", con)) c.ExecuteNonQuery(); } catch { }

                // Siparişlere 'Tahmini Bitiş Tarihi' ekle
                try { using (var c = new SQLiteCommand("ALTER TABLE Siparisler ADD COLUMN TahminiTarih DATETIME", con)) c.ExecuteNonQuery(); } catch { }
                try { using (var c = new SQLiteCommand("ALTER TABLE Siparisler ADD COLUMN SiparisKodu TEXT", con)) c.ExecuteNonQuery(); } catch { }


                // YENİ EKLENEN: ADRES SÜTUNU
                try { using (var c = new SQLiteCommand("ALTER TABLE Siparisler ADD COLUMN Adres TEXT", con)) c.ExecuteNonQuery(); } catch { }
                //bildirim süresi
                try { using (var c = new SQLiteCommand("ALTER TABLE Bildirimler ADD COLUMN SureGun INTEGER DEFAULT 3", con)) c.ExecuteNonQuery(); } catch { }

                VarsayilanVeriEkle(con);
            }
            // Kullanicilar tablosuna Adres sütunu ekle (Eksikse)
        }

        // -----------------------------------------------------------
        // 3. VARSAYILAN VERİLER (ADMIN GİRİŞİ İÇİN)
        // -----------------------------------------------------------
        private static void VarsayilanVeriEkle(SQLiteConnection con)
        {
            // Önce yönetici var mı kontrol et
            string kontrolSql = "SELECT COUNT(*) FROM Kullanicilar WHERE Rol='Yonetici'";
            using (var cmd = new SQLiteCommand(kontrolSql, con))
            {
                long sayi = (long)cmd.ExecuteScalar();

                // Eğer hiç yönetici yoksa ekle
                if (sayi == 0)
                {
                    string ekleSql = @"
                        INSERT INTO Kullanicilar (AdSoyad, KullaniciAdi, Sifre, Rol) 
                        VALUES ('Fabrika Admin', 'admin', '1234', 'Yonetici');
                        
                        INSERT INTO Makineler (MakineAd, Durum) VALUES ('Kesim Makinesi', 'Aktif');
                        INSERT INTO Makineler (MakineAd, Durum) VALUES ('Dikiş Makinesi-1', 'Aktif');
                        INSERT INTO Makineler (MakineAd, Durum) VALUES ('Pres Makinesi', 'Arızalı');
                    ";
                    using (var insertCmd = new SQLiteCommand(ekleSql, con))
                    {
                        insertCmd.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}