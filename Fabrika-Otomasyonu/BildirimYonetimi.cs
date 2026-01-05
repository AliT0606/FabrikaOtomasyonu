using System;
using System.Data;
using System.Data.SQLite;

namespace Fabrika_Otomasyonu
{
    /// <summary>
    /// Yönetici ve müşteriler arasındaki duyuru/bildirim sistemini yönetir.
    /// </summary>
    public class BildirimYonetimi
    {
        /// <summary>
        /// Yeni bir duyuru yayınlar. 
        /// ÖNEMLİ: Aynı anda sadece bir aktif duyuru olabilir. Eskiler pasife çekilir.
        /// </summary>
        public void BildirimGonder(string baslik, string mesaj)
        {
            using (var con = Veritabani.BaglantiGetir())
            {
                // 1. Önceki aktif bildirimleri temizle (Arşivle)
                string pasifSql = "UPDATE Bildirimler SET AktifMi = 0";
                using (var cmd = new SQLiteCommand(pasifSql, con)) cmd.ExecuteNonQuery();

                // 2. Yeni bildirimi 'Aktif' olarak ekle
                string ekleSql = "INSERT INTO Bildirimler (Baslik, Mesaj, AktifMi, Tarih) VALUES (@baslik, @mesaj, 1, @tarih)";
                using (var cmd = new SQLiteCommand(ekleSql, con))
                {
                    cmd.Parameters.AddWithValue("@baslik", baslik);
                    cmd.Parameters.AddWithValue("@mesaj", mesaj);
                    cmd.Parameters.AddWithValue("@tarih", DateTime.Now.ToString("yyyy-MM-dd HH:mm"));
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Müşteri ekranında gösterilecek son aktif bildirimi çeker.
        /// </summary>
        /// <returns>Dizi: [0] Başlık, [1] Mesaj. Yoksa null döner.</returns>
        public string[] SonBildirimiGetir()
        {
            using (var con = Veritabani.BaglantiGetir())
            {
                string sql = "SELECT Baslik, Mesaj FROM Bildirimler WHERE AktifMi = 1 ORDER BY Id DESC LIMIT 1";

                using (var cmd = new SQLiteCommand(sql, con))
                {
                    using (var dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            return new string[] { dr["Baslik"].ToString(), dr["Mesaj"].ToString() };
                        }
                    }
                }
            }
            return null;
        }
    }
}