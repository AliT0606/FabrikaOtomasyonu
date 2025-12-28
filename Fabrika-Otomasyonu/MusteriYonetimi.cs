using System;
using System.Data.SQLite;

namespace Fabrika_Otomasyonu
{
    public class MusteriYonetimi
    {
        // 1. Müşterinin Kayıtlı Adresini Getir
        public string AdresGetir(string telefon)
        {
            using (var con = Veritabani.BaglantiGetir())
            {
                string sql = "SELECT Adres FROM Kullanicilar WHERE Telefon = @tel";
                using (var cmd = new SQLiteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@tel", telefon);
                    object sonuc = cmd.ExecuteScalar();
                    return sonuc != null ? sonuc.ToString() : "";
                }
            }
        }

        // 2. Müşteriyi Kaydet veya Adresini Güncelle
        public void MusteriKaydetVeyaGuncelle(string adSoyad, string telefon, string adres)
        {
            using (var con = Veritabani.BaglantiGetir())
            {
                // Önce var mı bak
                string kontrolSql = "SELECT Count(*) FROM Kullanicilar WHERE Telefon = @tel";
                int sayi = 0;
                using (var cmd = new SQLiteCommand(kontrolSql, con))
                {
                    cmd.Parameters.AddWithValue("@tel", telefon);
                    sayi = Convert.ToInt32(cmd.ExecuteScalar());
                }

                if (sayi > 0)
                {
                    // VARSA: Sadece Adresini Güncelle (Son girdiği adresi kaydedelim)
                    string guncelleSql = "UPDATE Kullanicilar SET Adres = @adres WHERE Telefon = @tel";
                    using (var cmd = new SQLiteCommand(guncelleSql, con))
                    {
                        cmd.Parameters.AddWithValue("@adres", adres);
                        cmd.Parameters.AddWithValue("@tel", telefon);
                        cmd.ExecuteNonQuery();
                    }
                }
                else
                {
                    // YOKSA: Yeni Kayıt Ekle
                    string ekleSql = "INSERT INTO Kullanicilar (AdSoyad, Telefon, Rol, Adres) VALUES (@ad, @tel, 'Musteri', @adres)";
                    using (var cmd = new SQLiteCommand(ekleSql, con))
                    {
                        cmd.Parameters.AddWithValue("@ad", adSoyad);
                        cmd.Parameters.AddWithValue("@tel", telefon);
                        cmd.Parameters.AddWithValue("@adres", adres);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}