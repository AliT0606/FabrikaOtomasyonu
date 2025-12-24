using System;
using System.Data;
using System.Data.SQLite;

namespace Fabrika_Otomasyonu
{
    public class HammaddeYonetimi
    {
        // 1. Stok Listesini Getir
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

        // 2. Akıllı Stok Ekleme (Varsa üzerine ekle, yoksa yeni oluştur)
        public void HammaddeStokEkle(string tur, string birim, double eklenecekMiktar)
        {
            using (var con = Veritabani.BaglantiGetir())
            {
                // A) Önce bu malzeme var mı diye kontrol et
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

                // B) Duruma göre işlem yap
                if (kayitVarMi)
                {
                    // Varsa: Üstüne Ekle (UPDATE)
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
                    // Yoksa: Yeni Ekle (INSERT)
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