using System;
using System.Data.SQLite;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Fabrika_Otomasyonu
{
    public partial class LoginScreen : DevExpress.XtraEditors.XtraForm
    {
        public LoginScreen()
        {
            InitializeComponent();
        }

        private void LoginScreen_Load(object sender, EventArgs e)
        {
            // Şifre kutusunun karakterini gizle (● şeklinde görünür)
            txtYoneticiSifre.Properties.UseSystemPasswordChar = true;
        }

        // ============================================================
        // BUTON OLAYLARI (GİRİŞ İŞLEMLERİ)
        // ============================================================

        private void btnGirisYap_Click_New(object sender, EventArgs e)
        {
            // SENARYO 1: YÖNETİCİ GİRİŞİ
            if (navFrameLogin.SelectedPage == pageYonetici)
            {
                string kadi = txtYoneticiAdi.Text.Trim();
                string sifre = txtYoneticiSifre.Text.Trim();

                if (string.IsNullOrEmpty(kadi) || string.IsNullOrEmpty(sifre))
                {
                    XtraMessageBox.Show("Lütfen kullanıcı adı ve şifreyi giriniz.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Giriş kontrolünü yardımcı metoda yaptırıyoruz
                if (YoneticiGirisKontrol(kadi, sifre, out string adSoyad))
                {
                    XtraMessageBox.Show($"Hoşgeldin {adSoyad}", "Giriş Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    FrmYonetici frm = new FrmYonetici();
                    frm.Show();
                    this.Hide();
                }
                else
                {
                    XtraMessageBox.Show("Hatalı Kullanıcı Adı veya Şifre!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            // SENARYO 2: MÜŞTERİ GİRİŞİ
            else if (navFrameLogin.SelectedPage == pageMusteri)
            {
                MusteriGirisYap();
            }
        }

        // ============================================================
        // YARDIMCI METOTLAR (İŞ MANTIĞI)
        // ============================================================

        /// <summary>
        /// Veritabanından yönetici bilgilerini kontrol eder.
        /// </summary>
        private bool YoneticiGirisKontrol(string kadi, string sifre, out string adSoyad)
        {
            adSoyad = "";
            try
            {
                using (var baglanti = Veritabani.BaglantiGetir())
                {
                    string sql = "SELECT AdSoyad FROM Kullanicilar WHERE KullaniciAdi=@p1 AND Sifre=@p2 AND Rol='Yonetici'";
                    using (var komut = new SQLiteCommand(sql, baglanti))
                    {
                        komut.Parameters.AddWithValue("@p1", kadi);
                        komut.Parameters.AddWithValue("@p2", sifre);

                        object sonuc = komut.ExecuteScalar();
                        if (sonuc != null)
                        {
                            adSoyad = sonuc.ToString();
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Veritabanı hatası: " + ex.Message);
            }
            return false;
        }

        private void MusteriGirisYap()
        {
            string ad = txtMusteriAd.Text.Trim();
            string tel = txtMusteriTelefon.Text.Trim();

            if (string.IsNullOrEmpty(ad) || string.IsNullOrEmpty(tel))
            {
                XtraMessageBox.Show("Lütfen adınızı ve telefon numaranızı giriniz.", "Eksik Bilgi");
                return;
            }

            MusteriYonetimi mYonetim = new MusteriYonetimi();
            string kayitliAdres = mYonetim.AdresGetir(tel);

            FrmMusteri fr = new FrmMusteri(ad, tel, kayitliAdres);
            fr.Show();
            this.Hide();
        }

        // ============================================================
        // GÖRSEL EFEKTLER VE GEÇİŞLER
        // ============================================================

        private void btnSifreGoster_MouseDown_New(object sender, MouseEventArgs e)
        {
            txtYoneticiSifre.Properties.UseSystemPasswordChar = false; // Şifreyi göster
        }

        private void btnSifreGoster_MouseUp_New(object sender, MouseEventArgs e)
        {
            txtYoneticiSifre.Properties.UseSystemPasswordChar = true; // Şifreyi gizle
        }

        private void btnSecimYonetici_Click_New(object sender, EventArgs e)
        {
            SayfaDegistir(pageYonetici, btnSecimYonetici, btnSecimMusteri);
        }

        private void btnSecimMusteri_Click_New(object sender, EventArgs e)
        {
            SayfaDegistir(pageMusteri, btnSecimMusteri, btnSecimYonetici);
        }

        private void SayfaDegistir(DevExpress.XtraBars.Navigation.NavigationPage sayfa, SimpleButton aktifButon, SimpleButton pasifButon)
        {
            navFrameLogin.SelectedPage = sayfa;
            aktifButon.Appearance.ForeColor = System.Drawing.Color.Cyan;
            pasifButon.Appearance.ForeColor = System.Drawing.Color.DarkGray;
        }
    }
}