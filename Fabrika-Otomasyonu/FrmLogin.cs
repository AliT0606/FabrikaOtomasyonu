using System;
using System.Data.SQLite; // SQLite kütüphanesini eklemeyi unutma
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

        // Form Yüklendiğinde
        private void LoginScreen_Load(object sender, EventArgs e)
        {
            // Şifre kutusunun karakterini gizle
            txtYoneticiSifre.Properties.UseSystemPasswordChar = true;
        }

        // GİRİŞ YAP BUTONU
        private void btnGirisYap_Click_New(object sender, EventArgs e)
        {
            // 1. Yönetici Girişi mi Seçili? (NavFrame kontrolü)
            if (navFrameLogin.SelectedPage == pageYonetici)
            {
                string kadi = txtYoneticiAdi.Text.Trim();
                string sifre = txtYoneticiSifre.Text.Trim();

                if (string.IsNullOrEmpty(kadi) || string.IsNullOrEmpty(sifre))
                {
                    XtraMessageBox.Show("Lütfen kullanıcı adı ve şifreyi giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    // VERİTABANI KONTROLÜ
                    using (var baglanti = Veritabani.BaglantiGetir())
                    {
                        // Bağlantı zaten açık geliyor (Veritabani sınıfında açmıştık), tekrar açmaya gerek yok.

                        string sql = "SELECT * FROM Kullanicilar WHERE KullaniciAdi=@p1 AND Sifre=@p2 AND Rol='Yonetici'";
                        using (var cmd = new SQLiteCommand(sql, baglanti))
                        {
                            cmd.Parameters.AddWithValue("@p1", kadi);
                            cmd.Parameters.AddWithValue("@p2", sifre);

                            using (var dr = cmd.ExecuteReader())
                            {
                                if (dr.Read())
                                {
                                    // Giriş Başarılı!
                                    XtraMessageBox.Show($"Hoşgeldin {dr["AdSoyad"]}", "Giriş Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    // Yönetici Ekranını Aç
                                    FrmYonetici frm = new FrmYonetici();
                                    frm.Show();

                                    // Login ekranını gizle
                                    this.Hide();
                                }
                                else
                                {
                                    XtraMessageBox.Show("Hatalı Kullanıcı Adı veya Şifre!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("Veritabanı hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            // 2. Müşteri Girişi mi? (Şimdilik boş geçebiliriz veya basit kontrol)
            else if (navFrameLogin.SelectedPage == pageMusteri)
            {
                FrmMusteri fr = new FrmMusteri(); // Müşteri panelini oluştur
                fr.Show();                        // Ekrana getir
                this.Hide();
            }
        }

        // Şifre Göster/Gizle Butonu (Göz İkonu)
        private void btnSifreGoster_MouseDown_New(object sender, MouseEventArgs e)
        {
            txtYoneticiSifre.Properties.UseSystemPasswordChar = false;
        }

        private void btnSifreGoster_MouseUp_New(object sender, MouseEventArgs e)
        {
            txtYoneticiSifre.Properties.UseSystemPasswordChar = true;
        }

        // Üst butonlar (Geçişler)
        private void btnSecimYonetici_Click_New(object sender, EventArgs e)
        {
            navFrameLogin.SelectedPage = pageYonetici;
            btnSecimYonetici.Appearance.ForeColor = System.Drawing.Color.Cyan;
            btnSecimMusteri.Appearance.ForeColor = System.Drawing.Color.DarkGray;
        }

        private void btnSecimMusteri_Click_New(object sender, EventArgs e)
        {
            navFrameLogin.SelectedPage = pageMusteri;
            btnSecimMusteri.Appearance.ForeColor = System.Drawing.Color.Cyan;
            btnSecimYonetici.Appearance.ForeColor = System.Drawing.Color.DarkGray;
        }
    }
}