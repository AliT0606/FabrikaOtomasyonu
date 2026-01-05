using System;
using System.Data;
using System.Data.SQLite;

namespace Fabrika_Otomasyonu
{
    /// <summary>
    /// Müşteri vitrin ekranında ürünlerin listelenmesi ve detaylarını yönetir.
    /// </summary>
    public class VitrinYonetimi
    {
        /// <summary>
        /// Tüm ürünleri filtre olmadan getirir.
        /// </summary>
        public DataTable VitrinListesiGetir()
        {
            return KategoriyeGoreGetir("Tümü");
        }

        /// <summary>
        /// Ürünleri kategorisine (Türü) göre filtreler.
        /// Her ürünün ilk varyant resmini 'Kapak Resmi' olarak seçer.
        /// </summary>
        public DataTable KategoriyeGoreGetir(string kategori)
        {
            using (var con = Veritabani.BaglantiGetir())
            {
                string sql = "";

                // Not: (SELECT ... LIMIT 1) alt sorgusu, ürüne ait ilk resmi kapak resmi yapar.
                if (kategori == "Tümü")
                {
                    sql = @"SELECT u.Id, u.ModelAd, u.Tur, u.Fiyat, u.AnaHammadde,
                           (SELECT v.Resim FROM UrunVaryant v WHERE v.UrunId = u.Id LIMIT 1) as KapakResmi
                           FROM Urunler u ORDER BY u.Id DESC";
                }
                else
                {
                    sql = @"SELECT u.Id, u.ModelAd, u.Tur, u.Fiyat, u.AnaHammadde,
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

        /// <summary>
        /// Seçilen ürünün detay sayfasında göstermek üzere renk ve resim varyantlarını getirir.
        /// </summary>
        public DataTable UrunDetaylariniGetir(int urunId)
        {
            using (var con = Veritabani.BaglantiGetir())
            {
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