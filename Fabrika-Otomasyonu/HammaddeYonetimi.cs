using System;
using System.Data;
using System.Data.SQLite;

namespace Fabrika_Otomasyonu
{
    /// <summary>
    /// Hammadde stok takibi ve güncelleme işlemlerini yönetir.
    /// </summary>
    public class HammaddeYonetimi
    {
        /// <summary>
        /// Tüm hammadde stok durumunu listeler.
        /// </summary>
        public DataTable HammaddeleriGetir()
        {
            using (var con = Veritabani.BaglantiGetir())
            {
                string sql = "SELECT * FROM Hammaddeler ORDER BY Tur ASC";
                using (var da = new SQLiteDataAdapter(sql, con))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        /// <summary>
        /// Stok Ekleme Mantığı:
        /// - Malzeme veritabanında varsa üzerine ekler (UPDATE).
        /// - Yoksa yeni kayıt oluşturur (INSERT).
        /// </summary>
        /// <param name="eklenecekMiktar">Eklenecek miktar (Negatif gönderilirse stok düşer)</param>
        public void HammaddeStokEkle(string tur, string birim, double eklenecekMiktar)
        {
            using (var con = Veritabani.BaglantiGetir())
            {
                // 1. Kontrol: Bu malzeme daha önce kaydedilmiş mi?
                string kontrolSql = "SELECT Id, Miktar FROM Hammaddeler WHERE Tur=@tur";
                int id = 0;
                double mevcutMiktar = 0;
                bool kayitVarMi = false;

                using (var cmd = new SQLiteCommand(kontrolSql, con))
                {
                    cmd.Parameters.AddWithValue("@tur", tur);
                    using (var dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            kayitVarMi = true;
                            id = Convert.ToInt32(dr["Id"]);
                            mevcutMiktar = Convert.ToDouble(dr["Miktar"]);
                        }
                    }
                }

                // 2. İşlem: Duruma göre güncelle veya ekle
                if (kayitVarMi)
                {
                    string updateSql = "UPDATE Hammaddeler SET Miktar=@yeniMiktar WHERE Id=@id";
                    using (var cmd = new SQLiteCommand(updateSql, con))
                    {
                        cmd.Parameters.AddWithValue("@yeniMiktar", mevcutMiktar + eklenecekMiktar);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                else
                {
                    string insertSql = "INSERT INTO Hammaddeler (Tur, Birim, Miktar) VALUES (@tur, @birim, @miktar)";
                    using (var cmd = new SQLiteCommand(insertSql, con))
                    {
                        cmd.Parameters.AddWithValue("@tur", tur);
                        cmd.Parameters.AddWithValue("@birim", birim);
                        cmd.Parameters.AddWithValue("@miktar", eklenecekMiktar);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}   