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
                // Join yaparak varyant sayısını da getirebiliriz ama şimdilik basitten gidelim
                string sql = "SELECT * FROM Urunler ORDER BY Id DESC";
                using (var da = new SQLiteDataAdapter(sql, con))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        // 2. Yeni Ürün Kaydet (Transaction kullanarak: Hem ürün hem varyantlar tek seferde)
        public void UrunEkle(string model, string tur, string hammadde, List<GeciciVaryant> varyantlar)
        {
            using (var con = Veritabani.BaglantiGetir())
            {
                using (var transaction = con.BeginTransaction())
                {
                    try
                    {
                        // A) Ana Ürünü Ekle
                        string sqlUrun = "INSERT INTO Urunler (ModelAd, Tur, AnaHammadde) VALUES (@model, @tur, @ham); SELECT last_insert_rowid();";
                        long yeniUrunId;

                        using (var cmd = new SQLiteCommand(sqlUrun, con))
                        {
                            cmd.Parameters.AddWithValue("@model", model);
                            cmd.Parameters.AddWithValue("@tur", tur);
                            cmd.Parameters.AddWithValue("@ham", hammadde);
                            yeniUrunId = (long)cmd.ExecuteScalar(); // Eklenen ID'yi al
                        }

                        // B) Varyantları (Renkleri) Ekle
                        string sqlVaryant = "INSERT INTO UrunVaryant (UrunId, Renk, Resim) VALUES (@uid, @renk, @resim)";
                        foreach (var item in varyantlar)
                        {
                            using (var cmdVar = new SQLiteCommand(sqlVaryant, con))
                            {
                                cmdVar.Parameters.AddWithValue("@uid", yeniUrunId);
                                cmdVar.Parameters.AddWithValue("@renk", item.Renk);
                                cmdVar.Parameters.AddWithValue("@resim", item.ResimData);
                                cmdVar.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit(); // Hata yoksa onayla
                    }
                    catch (Exception)
                    {
                        transaction.Rollback(); // Hata varsa iptal et
                        throw; // Hatayı forma fırlat
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