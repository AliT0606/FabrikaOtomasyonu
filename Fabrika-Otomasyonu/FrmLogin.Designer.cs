namespace Fabrika_Otomasyonu
{
    partial class LoginScreen
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginScreen));
            this.txtMusteriAd = new DevExpress.XtraEditors.TextEdit();
            this.txtMusteriTelefon = new DevExpress.XtraEditors.TextEdit();
            this.txtYoneticiSifre = new DevExpress.XtraEditors.TextEdit();
            this.txtYoneticiAdi = new DevExpress.XtraEditors.TextEdit();
            this.btnSifreGoster = new DevExpress.XtraEditors.SimpleButton();
            this.pnlMusteri = new System.Windows.Forms.Panel();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.pnlYonetici = new System.Windows.Forms.Panel();
            this.pictureEdit2 = new DevExpress.XtraEditors.PictureEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnSecimYonetici = new DevExpress.XtraEditors.SimpleButton();
            this.btnSecimMusteri = new DevExpress.XtraEditors.SimpleButton();
            this.btnGiris = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.txtMusteriAd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMusteriTelefon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtYoneticiSifre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtYoneticiAdi.Properties)).BeginInit();
            this.pnlMusteri.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            this.pnlYonetici.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit2.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMusteriAd
            // 
            this.txtMusteriAd.Location = new System.Drawing.Point(25, 150);
            this.txtMusteriAd.Name = "txtMusteriAd";
            this.txtMusteriAd.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.txtMusteriAd.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtMusteriAd.Properties.Appearance.Options.UseBackColor = true;
            this.txtMusteriAd.Properties.Appearance.Options.UseFont = true;
            this.txtMusteriAd.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtMusteriAd.Properties.NullValuePrompt = "Adınız Soyadınız...";
            this.txtMusteriAd.Size = new System.Drawing.Size(200, 26);
            this.txtMusteriAd.TabIndex = 4;
            // 
            // txtMusteriTelefon
            // 
            this.txtMusteriTelefon.Location = new System.Drawing.Point(25, 120);
            this.txtMusteriTelefon.Name = "txtMusteriTelefon";
            this.txtMusteriTelefon.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.txtMusteriTelefon.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtMusteriTelefon.Properties.Appearance.Options.UseBackColor = true;
            this.txtMusteriTelefon.Properties.Appearance.Options.UseFont = true;
            this.txtMusteriTelefon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtMusteriTelefon.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.SimpleMaskManager));
            this.txtMusteriTelefon.Properties.MaskSettings.Set("MaskManagerSignature", "ignoreMaskBlank=True");
            this.txtMusteriTelefon.Properties.MaskSettings.Set("mask", "0000000000");
            this.txtMusteriTelefon.Properties.NullValuePrompt = "Telefon Numaranız...";
            this.txtMusteriTelefon.Size = new System.Drawing.Size(200, 26);
            this.txtMusteriTelefon.TabIndex = 1;
            // 
            // txtYoneticiSifre
            // 
            this.txtYoneticiSifre.Location = new System.Drawing.Point(25, 150);
            this.txtYoneticiSifre.Name = "txtYoneticiSifre";
            this.txtYoneticiSifre.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.txtYoneticiSifre.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.txtYoneticiSifre.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtYoneticiSifre.Properties.Appearance.Options.UseBackColor = true;
            this.txtYoneticiSifre.Properties.Appearance.Options.UseFont = true;
            this.txtYoneticiSifre.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtYoneticiSifre.Properties.NullValuePrompt = "Şifre...";
            this.txtYoneticiSifre.Properties.UseSystemPasswordChar = true;
            this.txtYoneticiSifre.Size = new System.Drawing.Size(200, 26);
            this.txtYoneticiSifre.TabIndex = 8;
            // 
            // txtYoneticiAdi
            // 
            this.txtYoneticiAdi.Location = new System.Drawing.Point(25, 120);
            this.txtYoneticiAdi.Name = "txtYoneticiAdi";
            this.txtYoneticiAdi.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.txtYoneticiAdi.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.txtYoneticiAdi.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtYoneticiAdi.Properties.Appearance.Options.UseBackColor = true;
            this.txtYoneticiAdi.Properties.Appearance.Options.UseFont = true;
            this.txtYoneticiAdi.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtYoneticiAdi.Properties.NullValuePrompt = "Kullanıcı Adı...";
            this.txtYoneticiAdi.Size = new System.Drawing.Size(200, 26);
            this.txtYoneticiAdi.TabIndex = 5;
            // 
            // btnSifreGoster
            // 
            this.btnSifreGoster.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSifreGoster.Appearance.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnSifreGoster.Appearance.Options.UseFont = true;
            this.btnSifreGoster.Appearance.Options.UseForeColor = true;
            this.btnSifreGoster.Location = new System.Drawing.Point(145, 180);
            this.btnSifreGoster.Name = "btnSifreGoster";
            this.btnSifreGoster.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnSifreGoster.Size = new System.Drawing.Size(80, 20);
            this.btnSifreGoster.TabIndex = 9;
            this.btnSifreGoster.Text = "şifre göster";
            this.btnSifreGoster.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnSifreGoster_MouseDown);
            this.btnSifreGoster.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnSifreGoster_MouseUp);
            // 
            // pnlMusteri
            // 
            this.pnlMusteri.Controls.Add(this.pictureEdit1);
            this.pnlMusteri.Controls.Add(this.txtMusteriTelefon);
            this.pnlMusteri.Controls.Add(this.txtMusteriAd);
            this.pnlMusteri.Controls.Add(this.labelControl1);
            this.pnlMusteri.Location = new System.Drawing.Point(75, 75);
            this.pnlMusteri.Name = "pnlMusteri";
            this.pnlMusteri.Size = new System.Drawing.Size(250, 210);
            this.pnlMusteri.TabIndex = 10;
            this.pnlMusteri.Visible = false;
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.EditValue = ((object)(resources.GetObject("pictureEdit1.EditValue")));
            this.pictureEdit1.Location = new System.Drawing.Point(100, 50);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.pictureEdit1.Size = new System.Drawing.Size(50, 50);
            this.pictureEdit1.TabIndex = 11;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.MediumTurquoise;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(68, 100);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(111, 19);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Müşteri Girişi";
            // 
            // pnlYonetici
            // 
            this.pnlYonetici.Controls.Add(this.pictureEdit2);
            this.pnlYonetici.Controls.Add(this.labelControl2);
            this.pnlYonetici.Controls.Add(this.btnSifreGoster);
            this.pnlYonetici.Controls.Add(this.txtYoneticiAdi);
            this.pnlYonetici.Controls.Add(this.txtYoneticiSifre);
            this.pnlYonetici.Location = new System.Drawing.Point(75, 75);
            this.pnlYonetici.Name = "pnlYonetici";
            this.pnlYonetici.Size = new System.Drawing.Size(250, 210);
            this.pnlYonetici.TabIndex = 12;
            // 
            // pictureEdit2
            // 
            this.pictureEdit2.EditValue = ((object)(resources.GetObject("pictureEdit2.EditValue")));
            this.pictureEdit2.Location = new System.Drawing.Point(100, 50);
            this.pictureEdit2.Name = "pictureEdit2";
            this.pictureEdit2.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit2.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit2.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit2.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.pictureEdit2.Size = new System.Drawing.Size(50, 50);
            this.pictureEdit2.TabIndex = 11;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.MediumTurquoise;
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.Location = new System.Drawing.Point(68, 100);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(114, 19);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Yönetici Girişi";
            // 
            // btnSecimYonetici
            // 
            this.btnSecimYonetici.Appearance.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.btnSecimYonetici.Appearance.ForeColor = System.Drawing.Color.Cyan;
            this.btnSecimYonetici.Appearance.Options.UseFont = true;
            this.btnSecimYonetici.Appearance.Options.UseForeColor = true;
            this.btnSecimYonetici.Location = new System.Drawing.Point(75, 40);
            this.btnSecimYonetici.Name = "btnSecimYonetici";
            this.btnSecimYonetici.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnSecimYonetici.Size = new System.Drawing.Size(125, 30);
            this.btnSecimYonetici.TabIndex = 13;
            this.btnSecimYonetici.Text = "Yönetici Giriş";
            this.btnSecimYonetici.Click += new System.EventHandler(this.btnSecimYonetici_Click);
            // 
            // btnSecimMusteri
            // 
            this.btnSecimMusteri.Appearance.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.btnSecimMusteri.Appearance.ForeColor = System.Drawing.Color.Cyan;
            this.btnSecimMusteri.Appearance.Options.UseFont = true;
            this.btnSecimMusteri.Appearance.Options.UseForeColor = true;
            this.btnSecimMusteri.Location = new System.Drawing.Point(200, 40);
            this.btnSecimMusteri.Name = "btnSecimMusteri";
            this.btnSecimMusteri.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnSecimMusteri.Size = new System.Drawing.Size(125, 30);
            this.btnSecimMusteri.TabIndex = 14;
            this.btnSecimMusteri.Text = "Müşteri Girişi";
            this.btnSecimMusteri.Click += new System.EventHandler(this.btnSecimMusteri_Click);
            // 
            // btnGiris
            // 
            this.btnGiris.BackColor = System.Drawing.Color.DarkBlue;
            this.btnGiris.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnGiris.ForeColor = System.Drawing.Color.Aquamarine;
            this.btnGiris.Location = new System.Drawing.Point(125, 300);
            this.btnGiris.Name = "btnGiris";
            this.btnGiris.Size = new System.Drawing.Size(150, 40);
            this.btnGiris.TabIndex = 15;
            this.btnGiris.Text = "Giriş Yap";
            this.btnGiris.UseVisualStyleBackColor = false;
            this.btnGiris.Click += new System.EventHandler(this.btnGiris_Click);
            // 
            // LoginScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(400, 400);
            this.Controls.Add(this.btnGiris);
            this.Controls.Add(this.btnSecimMusteri);
            this.Controls.Add(this.btnSecimYonetici);
            this.Controls.Add(this.pnlYonetici);
            this.Controls.Add(this.pnlMusteri);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.ForeColor = System.Drawing.Color.DarkBlue;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginScreen";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.txtMusteriAd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMusteriTelefon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtYoneticiSifre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtYoneticiAdi.Properties)).EndInit();
            this.pnlMusteri.ResumeLayout(false);
            this.pnlMusteri.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            this.pnlYonetici.ResumeLayout(false);
            this.pnlYonetici.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit2.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.TextEdit txtMusteriTelefon;
        private DevExpress.XtraEditors.TextEdit txtMusteriAd;
        private DevExpress.XtraEditors.TextEdit txtYoneticiSifre;
        private DevExpress.XtraEditors.TextEdit txtYoneticiAdi;
        private DevExpress.XtraEditors.SimpleButton btnSifreGoster;
        private System.Windows.Forms.Panel pnlMusteri;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private System.Windows.Forms.Panel pnlYonetici;
        private DevExpress.XtraEditors.PictureEdit pictureEdit2;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnSecimYonetici;
        private DevExpress.XtraEditors.SimpleButton btnSecimMusteri;
        private System.Windows.Forms.Button btnGiris;
    }
}

