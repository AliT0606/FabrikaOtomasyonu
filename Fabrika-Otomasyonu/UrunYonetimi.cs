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
        public void UrunEkle(string model, string tur, string hammadde, decimal fiyat, List<GeciciVaryant> varyantlar)
        {
            using (var con = Veritabani.BaglantiGetir())
            {
                using (var transaction = con.BeginTransaction())
                {
                    try
                    {
                        // Fiyatı da ekliyoruz
                        string sqlUrun = "INSERT INTO Urunler (ModelAd, Tur, AnaHammadde, Fiyat) VALUES (@model, @tur, @ham, @fiyat); SELECT last_insert_rowid();";
                        long yeniUrunId;

                        using (var cmd = new SQLiteCommand(sqlUrun, con))
                        {
                            cmd.Parameters.AddWithValue("@model", model);
                            cmd.Parameters.AddWithValue("@tur", tur);
                            cmd.Parameters.AddWithValue("@ham", hammadde);
                            cmd.Parameters.AddWithValue("@fiyat", fiyat); // Fiyat parametresi
                            yeniUrunId = (long)cmd.ExecuteScalar();
                        }

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
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
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