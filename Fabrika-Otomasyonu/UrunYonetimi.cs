using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Drawing; // Resim çevirme için
using System.IO;

namespace Fabrika_Otomasyonu
{
    // Varyantları geçici tutmak için küçük bir model
    public class GeciciVaryant
    {
        public string Renk { get; set; }
        public byte[] ResimData { get; set; } // Resmi byte dizisi olarak tutacağız
        public Image GorselResim { get; set; } // ListBox'ta göstermek vs için
    }

    public class UrunYonetimi
    {
        // 1. Ürünleri Listele (GridControl için DataTable döndürür)
        public DataTable UrunleriGetir()
        {
            using (var con = Veritabani.BaglantiGetir())
            {
                // YENİ SQL: Varyant tablosuyla birleştirip renkleri yan yana yazar (Örn: Siyah, Beyaz)
                string sql = @"
            SELECT u.Id, u.ModelAd, u.Tur, u.AnaHammadde, u.Fiyat, 
            IFNULL(GROUP_CONCAT(v.Renk, ', '), 'Renk Yok') as Renkler
            FROM Urunler u
            LEFT JOIN UrunVaryant v ON u.Id = v.UrunId
            GROUP BY u.Id
            ORDER BY u.Id DESC";

                using (var da = new SQLiteDataAdapter(sql, con))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        // 2. Yeni Ürün Kaydet (Transaction kullanarak: Hem ürün hem varyantlar tek seferde)
        // GÜNCELLENMİŞ URUN EKLEME (Kapasiteye Göre Süre Hesabı)
        public void UrunEkle(string model, string tur, string hammadde, decimal fiyat, List<GeciciVaryant> varyantlar)
        {
            // ÜRETİM SÜRELERİNİ NET OLARAK VERİYORUZ 
            double birimSure = 0.1; // Varsayılan

            if (tur == "Klasik")
                birimSure = 0.1;    // 10 Takım/Gün (1 / 10 = 0.10)
            else if (tur == "Spor")
                birimSure = 0.150;  // <-- SENİN İSTEDİĞİN YENİ DEĞER (Yaklaşık 6.6 Takım/Gün)
            else if (tur == "Bot")
                birimSure = 0.2;    // 5 Takım/Gün (1 / 5 = 0.20)

            using (var con = Veritabani.BaglantiGetir())
            {
                string sql = "INSERT INTO Urunler (ModelAd, Tur, AnaHammadde, Fiyat, UretimGunu) VALUES (@model, @tur, @ham, @fiyat, @sure)";
                long urunId;
                using (var cmd = new SQLiteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@model", model);
                    cmd.Parameters.AddWithValue("@tur", tur);
                    cmd.Parameters.AddWithValue("@ham", hammadde);
                    cmd.Parameters.AddWithValue("@fiyat", fiyat);
                    cmd.Parameters.AddWithValue("@sure", birimSure); // <-- Net değer kaydediliyor
                    cmd.ExecuteNonQuery();
                    urunId = con.LastInsertRowId;
                }

                // Varyantları kaydetme (Aynı kalıyor)
                foreach (var v in varyantlar)
                {
                    string vSql = "INSERT INTO UrunVaryant (UrunId, Renk, Resim) VALUES (@uid, @renk, @resim)";
                    using (var cmd = new SQLiteCommand(vSql, con))
                    {
                        cmd.Parameters.AddWithValue("@uid", urunId);
                        cmd.Parameters.AddWithValue("@renk", v.Renk);
                        cmd.Parameters.AddWithValue("@resim", v.ResimData);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        // 3. Ürün Sil
        public void UrunSil(int urunId)
        {
            using (var con = Veritabani.BaglantiGetir())
            {
                // Cascade olduğu için varyantlar da otomatik silinir (Tablo yapısına bağlı)
                // Garanti olsun diye kodla da silebiliriz ama Delete Cascade tanımladık.
                string sql = "DELETE FROM Urunler WHERE Id=@id";
                using (var cmd = new SQLiteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@id", urunId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Yardımcı Metot: Resmi Byte Dizisine Çevir
        public byte[] ResimToByte(Image img)
        {
            if (img == null) return null;
            using (var ms = new MemoryStream())
            {
                // Formatı png veya jpeg yapabilirsin
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }
        // ... (Mevcut kodların aynen kalsın, bu metodları sınıfın içine ekle)
    
        
    }
}