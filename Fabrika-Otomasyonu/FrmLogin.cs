using FabrikaOtomasyonu;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fabrika_Otomasyonu
{

    public partial class LoginScreen : Form
    {
        public static string GirisYapanAd = "";
        public static string GirisYapanTelefon = "";
        public static string GirisYapanRol = "";
        public LoginScreen()
        {
            InitializeComponent();
        }

        private void btnSecimYonetici_Click(object sender, EventArgs e)
        {
            pnlMusteri.Visible = false;  
            pnlYonetici.Visible = true;  

            
            btnSecimMusteri.Appearance.BackColor = System.Drawing.Color.Cyan;
            btnSecimYonetici.Appearance.BackColor = System.Drawing.Color.DarkBlue;
        }

        private void btnSecimMusteri_Click(object sender, EventArgs e)
        {
            pnlMusteri.Visible = true;
            pnlYonetici.Visible = false;


            btnSecimMusteri.Appearance.BackColor = System.Drawing.Color.DarkBlue;
            btnSecimYonetici.Appearance.BackColor = System.Drawing.Color.Cyan;
        }

        private void btnSifreGoster_MouseDown(object sender, MouseEventArgs e)
        {
            txtYoneticiSifre.Properties.UseSystemPasswordChar = false;
        }

        private void btnSifreGoster_MouseUp(object sender, MouseEventArgs e)
        {
            txtYoneticiSifre.Properties.UseSystemPasswordChar = true;

        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            if (pnlMusteri.Visible == true)
            {
                // 1. Sadece kutular boş mu diye bakıyoruz (DB Kaydı YOK)
                if (txtMusteriTelefon.Text.Trim() == "" || txtMusteriAd.Text.Trim() == "")
                {
                    MessageBox.Show("Sipariş verebilmek için isminizi ve telefonunuzu girmelisiniz.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 2. Bilgileri "Cebimize" (Static değişkenlere) atıyoruz
                GirisYapanAd = txtMusteriAd.Text.Trim();
                GirisYapanTelefon = txtMusteriTelefon.Text.Trim();
                GirisYapanRol = "Musteri";

                // 3. Direkt içeri alıyoruz (Kayıt mayıt yok henüz)
                MessageBox.Show($"Hoş Geldiniz {GirisYapanAd}, ürünlere bakabilirsiniz.", "Giriş Başarılı");

                FrmMusteri frm = new FrmMusteri(); 
                frm.Show();
                this.Hide();
            }

            // --- SENARYO 2: YÖNETİCİ GİRİŞİ (Burası Mecburen DB Kontrollü) ---
            else
            {
                using (SQLiteConnection baglanti = Veritabani.BaglantiGetir())
                {
                    baglanti.Open();
                    string sorgu = "SELECT * FROM Kullanicilar WHERE KullaniciAdi=@kadi AND Sifre=@sifre AND Rol='Yonetici'";
                    SQLiteCommand komut = new SQLiteCommand(sorgu, baglanti);
                    komut.Parameters.AddWithValue("@kadi", txtYoneticiAdi.Text.Trim());
                    komut.Parameters.AddWithValue("@sifre", txtYoneticiSifre.Text.Trim());

                    SQLiteDataReader oku = komut.ExecuteReader();

                    if (oku.Read())
                    {
                        GirisYapanAd = oku["AdSoyad"].ToString();
                        GirisYapanRol = "Yonetici";

                        MessageBox.Show("Yönetici girişi onaylandı. Panel açılıyor...", "Başarılı");

                        FrmYonetici frm = new FrmYonetici(); // ---> Yeni yaptığımız form
                        frm.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Hatalı Kullanıcı Adı veya Şifre!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
          }
    }
}
