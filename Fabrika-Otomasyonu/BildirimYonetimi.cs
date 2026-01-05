using System;
using System.Data.SQLite;

namespace Fabrika_Otomasyonu
{
    public class BildirimYonetimi
    {
        // GÜNCELLEME 1: Metoda 'sureGun' parametresi ekledik.
        // Varsayılan olarak 3 gün olsun, istersen parametre olarak farklı gönderebilirsin.
        public void BildirimGonder(string baslik, string mesaj, int sureGun = 3)
        {
            using (var con = Veritabani.BaglantiGetir())
            {
                // Önceki aktifleri pasife çek
                string pasifSql = "UPDATE Bildirimler SET AktifMi = 0";
                using (var cmd = new SQLiteCommand(pasifSql, con)) cmd.ExecuteNonQuery();

                // Yeni bildirimi SÜRESİ (SureGun) ile birlikte kaydet
                string ekleSql = "INSERT INTO Bildirimler (Baslik, Mesaj, AktifMi, Tarih, SureGun) VALUES (@baslik, @mesaj, 1, @tarih, @sure)";
                using (var cmd = new SQLiteCommand(ekleSql, con))
                {
                    cmd.Parameters.AddWithValue("@baslik", baslik);
                    cmd.Parameters.AddWithValue("@mesaj", mesaj);
                    cmd.Parameters.AddWithValue("@tarih", DateTime.Now.ToString("yyyy-MM-dd HH:mm"));
                    cmd.Parameters.AddWithValue("@sure", sureGun); // <-- Yeni Parametre
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public string[] SonBildirimiGetir()
        {
            using (var con = Veritabani.BaglantiGetir())
            {
                // Tarih ve SureGun bilgisini de çekiyoruz
                string sql = "SELECT Id, Baslik, Mesaj, Tarih, SureGun FROM Bildirimler WHERE AktifMi = 1 ORDER BY Id DESC LIMIT 1";

                using (var cmd = new SQLiteCommand(sql, con))
                {
                    using (var dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            // --- KRİTİK TARİH KONTROLÜ BURADA ---

                            string tarihStr = dr["Tarih"].ToString();
                            int sure = dr["SureGun"] != DBNull.Value ? Convert.ToInt32(dr["SureGun"]) : 3;

                            // Veritabanındaki tarihi DateTime formatına çevir
                            if (DateTime.TryParse(tarihStr, out DateTime olusturmaTarihi))
                            {
                                // Bitiş tarihini hesapla (Oluşturma + Süre)
                                DateTime bitisTarihi = olusturmaTarihi.AddDays(sure);

                                // EĞER BUGÜN BİTİŞ TARİHİNİ GEÇTİYSE -> GÖSTERME (Null dön)
                                if (DateTime.Now > bitisTarihi)
                                {
                                    // İsteğe bağlı: Veritabanında da pasife çekebilirsin ama şart değil, göstermemek yeterli.
                                    return null;
                                }
                            }

                            // Süresi dolmamışsa verileri döndür
                            return new string[] {
                                dr["Id"].ToString(),
                                dr["Baslik"].ToString(),
                                dr["Mesaj"].ToString()
                            };
                        }
                    }
                }
            }
            return null;
        }

        // ... (OkunduMu ve OkunduIsaretle metodları aynen kalacak) ...
        public bool OkunduMu(string telefon, int bildirimId)
        {
            using (var con = Veritabani.BaglantiGetir())
            {
                string sql = "SELECT COUNT(*) FROM OkunanBildirimler WHERE Telefon=@tel AND BildirimId=@bid";
                using (var cmd = new SQLiteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@tel", telefon);
                    cmd.Parameters.AddWithValue("@bid", bildirimId);
                    int sayi = Convert.ToInt32(cmd.ExecuteScalar());
                    return sayi > 0;
                }
            }
        }

        public void OkunduIsaretle(string telefon, int bildirimId)
        {
            using (var con = Veritabani.BaglantiGetir())
            {
                string sql = "INSERT INTO OkunanBildirimler (Telefon, BildirimId) VALUES (@tel, @bid)";
                using (var cmd = new SQLiteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@tel", telefon);
                    cmd.Parameters.AddWithValue("@bid", bildirimId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}