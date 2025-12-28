using System;
using System.Data;
using System.Data.SQLite;

namespace Fabrika_Otomasyonu
{
    public class BildirimYonetimi
    {
        // 1. YENİ BİLDİRİM YAYINLA (Yönetici İçin)
        public void BildirimGonder(string baslik, string mesaj)
        {
            using (var con = Veritabani.BaglantiGetir())
            {
                // Önce eski aktif bildirimleri pasif yap (Sadece en sonuncusu görünsün)
                string pasifSql = "UPDATE Bildirimler SET AktifMi = 0";
                using (var cmd = new SQLiteCommand(pasifSql, con)) cmd.ExecuteNonQuery();

                // Yeni bildirimi ekle
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

        // 2. SON AKTİF BİLDİRİMİ GETİR (Müşteri İçin)
        // Dönüş Tipi: string array [Baslik, Mesaj]
        public string[] SonBildirimiGetir()
        {
            using (var con = Veritabani.BaglantiGetir())
            {
                // Son 24 saat içinde atılmış aktif bir mesaj var mı?
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
            return null; // Bildirim yoksa null döner
        }
    }
}