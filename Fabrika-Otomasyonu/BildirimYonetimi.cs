using System;
using System.Data.SQLite;

namespace Fabrika_Otomasyonu
{
    public class BildirimYonetimi
    {
        // Mesajı Veritabanına Kaydeder
        public void BildirimGonder(string baslik, string icerik)
        {
            // Veritabanı bağlantısını al
            using (var con = Veritabani.BaglantiGetir())
            {
                // SQL komutu: Mesajlar tablosuna ekle
                // OkunduMu = 0 (Hayır) olarak işaretliyoruz
                string sql = "INSERT INTO Mesajlar (Baslik, Icerik, OkunduMu, Tarih) VALUES (@baslik, @icerik, 0, @tarih)";

                using (var cmd = new SQLiteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@baslik", baslik);
                    cmd.Parameters.AddWithValue("@icerik", icerik);
                    cmd.Parameters.AddWithValue("@tarih", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}