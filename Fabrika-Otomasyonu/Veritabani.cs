using System;
using System.Data;
using System.Data.SQLite;
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
            // Dosya yoksa oluşturur
            if (!File.Exists(dosyaAdi))
            {
                SQLiteConnection.CreateFile(dosyaAdi);
            }

            using (var con = BaglantiGetir())
            {
                using (var cmd = new SQLiteCommand(con))
                {
                    // A) KULLANICILAR (Yönetici ve Müşteri)
                    cmd.CommandText = @"
                        CREATE TABLE IF NOT EXISTS Kullanicilar (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            AdSoyad TEXT,
                            KullaniciAdi TEXT, -- Yönetici için
                            Sifre TEXT,        -- Yönetici için
                            Telefon TEXT,      -- Müşteri için
                            Rol TEXT           -- 'Yonetici' veya 'Musteri'
                        );";
                    cmd.ExecuteNonQuery();

                    // B) ÜRÜNLER (Master Tablo)
                    cmd.CommandText = @"
                        CREATE TABLE IF NOT EXISTS Urunler (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            ModelAd TEXT NOT NULL,
                            Tur TEXT,          -- Bot, Klasik, Spor
                            AnaHammadde TEXT,  -- Deri, Süet vb.
                            Fiyat REAL DEFAULT 0
                        );";
                    cmd.ExecuteNonQuery();

                    // C) ÜRÜN VARYANTLARI (Detay Tablo - Resimler Burada)
                    // FOREIGN KEY: Urunler tablosundaki Id silinirse buradakiler de silinsin (CASCADE)
                    cmd.CommandText = @"
                        CREATE TABLE IF NOT EXISTS UrunVaryant (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            UrunId INTEGER,
                            Renk TEXT,
                            Resim BLOB, 
                            FOREIGN KEY(UrunId) REFERENCES Urunler(Id) ON DELETE CASCADE
                        );";
                    cmd.ExecuteNonQuery();

                    // D) HAMMADDELER (Stok Takibi)
                    cmd.CommandText = @"
                        CREATE TABLE IF NOT EXISTS Hammaddeler (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Tur TEXT,     -- Ayakkabı Hammaddesi / Taban
                            Birim TEXT,   -- m2 / Adet
                            Miktar REAL DEFAULT 0
                        );";
                    cmd.ExecuteNonQuery();

                    // E) MAKİNELER (Arıza Takibi)
                    cmd.CommandText = @"
                        CREATE TABLE IF NOT EXISTS Makineler (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            MakineAd TEXT,
                            Durum TEXT DEFAULT 'Aktif', -- Aktif, Arızalı, Bakımda
                            ArizaMesaji TEXT
                        );";
                    cmd.ExecuteNonQuery();

                    // F) SİPARİŞLER
                    cmd.CommandText = @"
                        CREATE TABLE IF NOT EXISTS Siparisler (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            MusteriId INTEGER,
                            UrunVaryantId INTEGER, -- Hangi renk sipariş edildi?
                            Adet INTEGER,
                            Tarih DATETIME DEFAULT CURRENT_TIMESTAMP,
                            Durum TEXT DEFAULT 'Hazırlanıyor'
                        );";
                    cmd.ExecuteNonQuery();
                }

                // Tablolar oluştuysa varsayılan verileri ekleyelim (Admin vb.)
                VarsayilanVeriEkle(con);
            }
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