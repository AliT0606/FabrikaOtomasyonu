namespace Fabrika_Otomasyonu
{
    partial class LoginScreen
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginScreen));
            this.pnlUstToggles = new DevExpress.XtraEditors.PanelControl();
            this.btnSecimMusteri = new DevExpress.XtraEditors.SimpleButton();
            this.btnSecimYonetici = new DevExpress.XtraEditors.SimpleButton();
            this.navFrameLogin = new DevExpress.XtraBars.Navigation.NavigationFrame();
            this.pageYonetici = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.groupYonetici = new DevExpress.XtraEditors.GroupControl();
            this.btnSifreGoster = new DevExpress.XtraEditors.SimpleButton();
            this.txtYoneticiSifre = new DevExpress.XtraEditors.TextEdit();
            this.txtYoneticiAdi = new DevExpress.XtraEditors.TextEdit();
            this.peYoneticiIcon = new DevExpress.XtraEditors.PictureEdit();
            this.pageMusteri = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.groupMusteri = new DevExpress.XtraEditors.GroupControl();
            this.txtMusteriTelefon = new DevExpress.XtraEditors.TextEdit();
            this.txtMusteriAd = new DevExpress.XtraEditors.TextEdit();
            this.peMusteriIcon = new DevExpress.XtraEditors.PictureEdit();
            this.btnGirisYap = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.pnlUstToggles)).BeginInit();
            this.pnlUstToggles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navFrameLogin)).BeginInit();
            this.navFrameLogin.SuspendLayout();
            this.pageYonetici.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupYonetici)).BeginInit();
            this.groupYonetici.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtYoneticiSifre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtYoneticiAdi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.peYoneticiIcon.Properties)).BeginInit();
            this.pageMusteri.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupMusteri)).BeginInit();
            this.groupMusteri.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMusteriTelefon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMusteriAd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.peMusteriIcon.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlUstToggles
            // 
            this.pnlUstToggles.Appearance.BackColor = System.Drawing.Color.MidnightBlue;
            this.pnlUstToggles.Appearance.Options.UseBackColor = true;
            this.pnlUstToggles.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlUstToggles.Controls.Add(this.btnSecimMusteri);
            this.pnlUstToggles.Controls.Add(this.btnSecimYonetici);
            this.pnlUstToggles.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlUstToggles.Location = new System.Drawing.Point(0, 0);
            this.pnlUstToggles.Name = "pnlUstToggles";
            this.pnlUstToggles.Padding = new System.Windows.Forms.Padding(10);
            this.pnlUstToggles.Size = new System.Drawing.Size(450, 80);
            this.pnlUstToggles.TabIndex = 0;
            // 
            // btnSecimMusteri
            // 
            this.btnSecimMusteri.Appearance.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnSecimMusteri.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSecimMusteri.Appearance.ForeColor = System.Drawing.Color.DarkGray;
            this.btnSecimMusteri.Appearance.Options.UseBackColor = true;
            this.btnSecimMusteri.Appearance.Options.UseFont = true;
            this.btnSecimMusteri.Appearance.Options.UseForeColor = true;
            this.btnSecimMusteri.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSecimMusteri.Location = new System.Drawing.Point(230, 10);
            this.btnSecimMusteri.Name = "btnSecimMusteri";
            this.btnSecimMusteri.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnSecimMusteri.Size = new System.Drawing.Size(210, 60);
            this.btnSecimMusteri.TabIndex = 1;
            this.btnSecimMusteri.Text = "MÜŞTERİ";
            this.btnSecimMusteri.Click += new System.EventHandler(this.btnSecimMusteri_Click_New);
            // 
            // btnSecimYonetici
            // 
            this.btnSecimYonetici.Appearance.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnSecimYonetici.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSecimYonetici.Appearance.ForeColor = System.Drawing.Color.Cyan;
            this.btnSecimYonetici.Appearance.Options.UseBackColor = true;
            this.btnSecimYonetici.Appearance.Options.UseFont = true;
            this.btnSecimYonetici.Appearance.Options.UseForeColor = true;
            this.btnSecimYonetici.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSecimYonetici.Location = new System.Drawing.Point(10, 10);
            this.btnSecimYonetici.Name = "btnSecimYonetici";
            this.btnSecimYonetici.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnSecimYonetici.Size = new System.Drawing.Size(210, 60);
            this.btnSecimYonetici.TabIndex = 0;
            this.btnSecimYonetici.Text = "YÖNETİCİ";
            this.btnSecimYonetici.Click += new System.EventHandler(this.btnSecimYonetici_Click_New);
            // 
            // navFrameLogin
            // 
            this.navFrameLogin.Appearance.BackColor = System.Drawing.Color.MidnightBlue;
            this.navFrameLogin.Appearance.Options.UseBackColor = true;
            this.navFrameLogin.Controls.Add(this.pageYonetici);
            this.navFrameLogin.Controls.Add(this.pageMusteri);
            this.navFrameLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navFrameLogin.Location = new System.Drawing.Point(0, 80);
            this.navFrameLogin.Name = "navFrameLogin";
            this.navFrameLogin.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.pageYonetici,
            this.pageMusteri});
            this.navFrameLogin.SelectedPage = this.pageYonetici;
            this.navFrameLogin.Size = new System.Drawing.Size(450, 410);
            this.navFrameLogin.TabIndex = 1;
            // 
            // pageYonetici
            // 
            this.pageYonetici.Appearance.BackColor = System.Drawing.Color.MidnightBlue;
            this.pageYonetici.Appearance.Options.UseBackColor = true;
            this.pageYonetici.Caption = "pageYonetici";
            this.pageYonetici.Controls.Add(this.groupYonetici);
            this.pageYonetici.Name = "pageYonetici";
            this.pageYonetici.Size = new System.Drawing.Size(450, 410);
            // 
            // groupYonetici
            // 
            this.groupYonetici.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.groupYonetici.Appearance.Options.UseBackColor = true;
            this.groupYonetici.AppearanceCaption.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupYonetici.AppearanceCaption.ForeColor = System.Drawing.Color.Cyan;
            this.groupYonetici.AppearanceCaption.Options.UseFont = true;
            this.groupYonetici.AppearanceCaption.Options.UseForeColor = true;
            this.groupYonetici.AppearanceCaption.Options.UseTextOptions = true;
            this.groupYonetici.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.groupYonetici.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupYonetici.Controls.Add(this.btnSifreGoster);
            this.groupYonetici.Controls.Add(this.txtYoneticiSifre);
            this.groupYonetici.Controls.Add(this.txtYoneticiAdi);
            this.groupYonetici.Controls.Add(this.peYoneticiIcon);
            this.groupYonetici.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupYonetici.GroupStyle = DevExpress.Utils.GroupStyle.Title;
            this.groupYonetici.Location = new System.Drawing.Point(0, 0);
            this.groupYonetici.Name = "groupYonetici";
            this.groupYonetici.Padding = new System.Windows.Forms.Padding(40);
            this.groupYonetici.Size = new System.Drawing.Size(450, 410);
            this.groupYonetici.TabIndex = 0;
            this.groupYonetici.Text = "Yönetici Girişi";
            // 
            // btnSifreGoster
            // 
            this.btnSifreGoster.ImageOptions.SvgImage = global::Fabrika_Otomasyonu.Properties.Resources.RedEye1;
            this.btnSifreGoster.Location = new System.Drawing.Point(370, 260);
            this.btnSifreGoster.Name = "btnSifreGoster";
            this.btnSifreGoster.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnSifreGoster.Size = new System.Drawing.Size(35, 30);
            this.btnSifreGoster.TabIndex = 3;
            this.btnSifreGoster.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnSifreGoster_MouseDown_New);
            this.btnSifreGoster.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnSifreGoster_MouseUp_New);
            // 
            // txtYoneticiSifre
            // 
            this.txtYoneticiSifre.Location = new System.Drawing.Point(50, 260);
            this.txtYoneticiSifre.Name = "txtYoneticiSifre";
            this.txtYoneticiSifre.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtYoneticiSifre.Properties.Appearance.Options.UseFont = true;
            this.txtYoneticiSifre.Properties.AutoHeight = false;
            this.txtYoneticiSifre.Properties.NullValuePrompt = "Şifre";
            this.txtYoneticiSifre.Properties.UseSystemPasswordChar = true;
            this.txtYoneticiSifre.Size = new System.Drawing.Size(320, 35);
            this.txtYoneticiSifre.TabIndex = 2;
            // 
            // txtYoneticiAdi
            // 
            this.txtYoneticiAdi.Location = new System.Drawing.Point(50, 210);
            this.txtYoneticiAdi.Name = "txtYoneticiAdi";
            this.txtYoneticiAdi.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtYoneticiAdi.Properties.Appearance.Options.UseFont = true;
            this.txtYoneticiAdi.Properties.AutoHeight = false;
            this.txtYoneticiAdi.Properties.NullValuePrompt = "Kullanıcı Adı";
            this.txtYoneticiAdi.Size = new System.Drawing.Size(350, 35);
            this.txtYoneticiAdi.TabIndex = 1;
            // 
            // peYoneticiIcon
            // 
            this.peYoneticiIcon.Dock = System.Windows.Forms.DockStyle.Top;
            this.peYoneticiIcon.EditValue = ((object)(resources.GetObject("peYoneticiIcon.EditValue")));
            this.peYoneticiIcon.Location = new System.Drawing.Point(40, 40);
            this.peYoneticiIcon.Name = "peYoneticiIcon";
            this.peYoneticiIcon.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.peYoneticiIcon.Properties.Appearance.Options.UseBackColor = true;
            this.peYoneticiIcon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.peYoneticiIcon.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.peYoneticiIcon.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.peYoneticiIcon.Size = new System.Drawing.Size(370, 150);
            this.peYoneticiIcon.TabIndex = 0;
            // 
            // pageMusteri
            // 
            this.pageMusteri.Appearance.BackColor = System.Drawing.Color.MidnightBlue;
            this.pageMusteri.Appearance.Options.UseBackColor = true;
            this.pageMusteri.Caption = "pageMusteri";
            this.pageMusteri.Controls.Add(this.groupMusteri);
            this.pageMusteri.Name = "pageMusteri";
            this.pageMusteri.Size = new System.Drawing.Size(450, 410);
            // 
            // groupMusteri
            // 
            this.groupMusteri.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.groupMusteri.Appearance.Options.UseBackColor = true;
            this.groupMusteri.AppearanceCaption.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupMusteri.AppearanceCaption.ForeColor = System.Drawing.Color.Cyan;
            this.groupMusteri.AppearanceCaption.Options.UseFont = true;
            this.groupMusteri.AppearanceCaption.Options.UseForeColor = true;
            this.groupMusteri.AppearanceCaption.Options.UseTextOptions = true;
            this.groupMusteri.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.groupMusteri.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupMusteri.Controls.Add(this.txtMusteriTelefon);
            this.groupMusteri.Controls.Add(this.txtMusteriAd);
            this.groupMusteri.Controls.Add(this.peMusteriIcon);
            this.groupMusteri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupMusteri.GroupStyle = DevExpress.Utils.GroupStyle.Title;
            this.groupMusteri.Location = new System.Drawing.Point(0, 0);
            this.groupMusteri.Name = "groupMusteri";
            this.groupMusteri.Padding = new System.Windows.Forms.Padding(40);
            this.groupMusteri.Size = new System.Drawing.Size(450, 410);
            this.groupMusteri.TabIndex = 1;
            this.groupMusteri.Text = "Müşteri Girişi (Misafir)";
            // 
            // txtMusteriTelefon
            // 
            this.txtMusteriTelefon.Location = new System.Drawing.Point(50, 260);
            this.txtMusteriTelefon.Name = "txtMusteriTelefon";
            this.txtMusteriTelefon.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtMusteriTelefon.Properties.Appearance.Options.UseFont = true;
            this.txtMusteriTelefon.Properties.AutoHeight = false;
            this.txtMusteriTelefon.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.SimpleMaskManager));
            this.txtMusteriTelefon.Properties.MaskSettings.Set("mask", "0000000000");
            this.txtMusteriTelefon.Properties.NullValuePrompt = "Telefon Numarası";
            this.txtMusteriTelefon.Size = new System.Drawing.Size(350, 35);
            this.txtMusteriTelefon.TabIndex = 2;
            // 
            // txtMusteriAd
            // 
            this.txtMusteriAd.Location = new System.Drawing.Point(50, 210);
            this.txtMusteriAd.Name = "txtMusteriAd";
            this.txtMusteriAd.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtMusteriAd.Properties.Appearance.Options.UseFont = true;
            this.txtMusteriAd.Properties.AutoHeight = false;
            this.txtMusteriAd.Properties.NullValuePrompt = "Adınız Soyadınız";
            this.txtMusteriAd.Size = new System.Drawing.Size(350, 35);
            this.txtMusteriAd.TabIndex = 1;
            // 
            // peMusteriIcon
            // 
            this.peMusteriIcon.Dock = System.Windows.Forms.DockStyle.Top;
            this.peMusteriIcon.EditValue = ((object)(resources.GetObject("peMusteriIcon.EditValue")));
            this.peMusteriIcon.Location = new System.Drawing.Point(40, 40);
            this.peMusteriIcon.Name = "peMusteriIcon";
            this.peMusteriIcon.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.peMusteriIcon.Properties.Appearance.Options.UseBackColor = true;
            this.peMusteriIcon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.peMusteriIcon.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.peMusteriIcon.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.peMusteriIcon.Size = new System.Drawing.Size(370, 150);
            this.peMusteriIcon.TabIndex = 0;
            // 
            // btnGirisYap
            // 
            this.btnGirisYap.Appearance.BackColor = System.Drawing.Color.Cyan;
            this.btnGirisYap.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnGirisYap.Appearance.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnGirisYap.Appearance.Options.UseBackColor = true;
            this.btnGirisYap.Appearance.Options.UseFont = true;
            this.btnGirisYap.Appearance.Options.UseForeColor = true;
            this.btnGirisYap.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.btnGirisYap.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnGirisYap.Location = new System.Drawing.Point(0, 490);
            this.btnGirisYap.Name = "btnGirisYap";
            this.btnGirisYap.Size = new System.Drawing.Size(450, 60);
            this.btnGirisYap.TabIndex = 2;
            this.btnGirisYap.Text = "GİRİŞ YAP";
            this.btnGirisYap.Click += new System.EventHandler(this.btnGirisYap_Click_New);
            // 
            // LoginScreen
            // 
            this.Appearance.BackColor = System.Drawing.Color.MidnightBlue;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 550);
            this.Controls.Add(this.navFrameLogin);
            this.Controls.Add(this.btnGirisYap);
            this.Controls.Add(this.pnlUstToggles);
            this.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.None;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IconOptions.ShowIcon = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fabrika Giriş";
            this.Load += new System.EventHandler(this.LoginScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlUstToggles)).EndInit();
            this.pnlUstToggles.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.navFrameLogin)).EndInit();
            this.navFrameLogin.ResumeLayout(false);
            this.pageYonetici.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupYonetici)).EndInit();
            this.groupYonetici.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtYoneticiSifre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtYoneticiAdi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.peYoneticiIcon.Properties)).EndInit();
            this.pageMusteri.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupMusteri)).EndInit();
            this.groupMusteri.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtMusteriTelefon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMusteriAd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.peMusteriIcon.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlUstToggles;
        private DevExpress.XtraEditors.SimpleButton btnSecimMusteri;
        private DevExpress.XtraEditors.SimpleButton btnSecimYonetici;
        private DevExpress.XtraBars.Navigation.NavigationFrame navFrameLogin;
        private DevExpress.XtraBars.Navigation.NavigationPage pageYonetici;
        private DevExpress.XtraBars.Navigation.NavigationPage pageMusteri;
        private DevExpress.XtraEditors.SimpleButton btnGirisYap;
        private DevExpress.XtraEditors.GroupControl groupYonetici;
        private DevExpress.XtraEditors.PictureEdit peYoneticiIcon;
        private DevExpress.XtraEditors.TextEdit txtYoneticiSifre;
        private DevExpress.XtraEditors.TextEdit txtYoneticiAdi;
        private DevExpress.XtraEditors.GroupControl groupMusteri;
        private DevExpress.XtraEditors.TextEdit txtMusteriTelefon;
        private DevExpress.XtraEditors.TextEdit txtMusteriAd;
        private DevExpress.XtraEditors.PictureEdit peMusteriIcon;
        private DevExpress.XtraEditors.SimpleButton btnSifreGoster;
    }
}