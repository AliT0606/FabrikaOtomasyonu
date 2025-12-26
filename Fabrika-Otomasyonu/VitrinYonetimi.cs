using System;
using System.Data;
using System.Data.SQLite;

namespace Fabrika_Otomasyonu
{
    public class VitrinYonetimi
    {
        // 1. Vitrin Listesi (Kapak Resimli)
        public DataTable VitrinListesiGetir()
        {
            return KategoriyeGoreGetir("Tümü");
        }

        // 2. Kategori Filtreleme ve Listeleme
        public DataTable KategoriyeGoreGetir(string kategori)
        {
            using (var con = Veritabani.BaglantiGetir())
            {
                string sql = "";

                // Alt sorgu ile (SELECT ... LIMIT 1) her ürünün ilk varyant resmini 'KapakResmi' olarak çekiyoruz
                if (kategori == "Tümü")
                {
                    sql = @"SELECT u.Id, u.ModelAd, u.Tur, u.Fiyat,
                           (SELECT v.Resim FROM UrunVaryant v WHERE v.UrunId = u.Id LIMIT 1) as KapakResmi
                           FROM Urunler u ORDER BY u.Id DESC";
                }
                else
                {
                    sql = @"SELECT u.Id, u.ModelAd, u.Tur, u.Fiyat,
                           (SELECT v.Resim FROM UrunVaryant v WHERE v.UrunId = u.Id LIMIT 1) as KapakResmi
                           FROM Urunler u 
                           WHERE u.Tur = @tur
                           ORDER BY u.Id DESC";
                }

                using (var da = new SQLiteDataAdapter(sql, con))
                {
                    if (kategori != "Tümü") da.SelectCommand.Parameters.AddWithValue("@tur", kategori);

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        // 3. SEÇİLEN ÜRÜNÜN DETAYLARI (RENK VE RESİMLER)
        // Sorun muhtemelen buradaydı, burayı sağlama aldık.
        public DataTable UrunDetaylariniGetir(int urunId)
        {
            using (var con = Veritabani.BaglantiGetir())
            {
                // Sadece Renk ve Resim sütunlarını çekiyoruz
                // Resim sütunu BLOB olduğu için DataTable bunu byte[] olarak algılar.
                string sql = "SELECT Renk, Resim FROM UrunVaryant WHERE UrunId = @id";

                using (var da = new SQLiteDataAdapter(sql, con))
                {
                    da.SelectCommand.Parameters.AddWithValue("@id", urunId);

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
    }
}