namespace Fabrika_Otomasyonu
{
    partial class FrmYonetici
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
            this.pnlHeader = new DevExpress.XtraEditors.PanelControl();
            this.lblBaslik = new DevExpress.XtraEditors.LabelControl();
            this.accordionControl1 = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.elmUrunler = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.elmMakineler = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.elmHammadde = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.elmSiparisler = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.navFrameYonetici = new DevExpress.XtraBars.Navigation.NavigationFrame();
            this.pageUrunler = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.gcUrunListesi = new DevExpress.XtraGrid.GridControl();
            this.gvUrunListesi = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnUrunKaldir = new DevExpress.XtraEditors.SimpleButton();
            this.pnlUrunIslemleri = new DevExpress.XtraEditors.PanelControl();
            this.groupUrunEkle = new DevExpress.XtraEditors.GroupControl();
            this.btnUrunKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.lstEklenenVaryantlar = new DevExpress.XtraEditors.ListBoxControl();
            this.groupVaryant = new DevExpress.XtraEditors.GroupControl();
            this.cmbRenkSec = new DevExpress.XtraEditors.ComboBoxEdit();
            this.peUrunResim = new DevExpress.XtraEditors.PictureEdit();
            this.btnRenkEkle = new DevExpress.XtraEditors.SimpleButton();
            this.cmbHammaddeTur = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmbUrunTur = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtUrunModel = new DevExpress.XtraEditors.TextEdit();
            this.pageMakineler = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.pageHammadde = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.gcHammaddeListesi = new DevExpress.XtraGrid.GridControl();
            this.gvHammaddeListesi = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.pnlHammaddeIslem = new DevExpress.XtraEditors.PanelControl();
            this.groupHammaddeEkle = new DevExpress.XtraEditors.GroupControl();
            this.btnHammaddeEkle = new DevExpress.XtraEditors.SimpleButton();
            this.txtHamMiktar = new DevExpress.XtraEditors.TextEdit();
            this.cmbHamBirim = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmbHamTur = new DevExpress.XtraEditors.ComboBoxEdit();
            this.pageSiparisler = new DevExpress.XtraBars.Navigation.NavigationPage();
            ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).BeginInit();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.navFrameYonetici)).BeginInit();
            this.navFrameYonetici.SuspendLayout();
            this.pageUrunler.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcUrunListesi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvUrunListesi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlUrunIslemleri)).BeginInit();
            this.pnlUrunIslemleri.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupUrunEkle)).BeginInit();
            this.groupUrunEkle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lstEklenenVaryantlar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupVaryant)).BeginInit();
            this.groupVaryant.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbRenkSec.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.peUrunResim.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbHammaddeTur.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbUrunTur.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUrunModel.Properties)).BeginInit();
            this.pageHammadde.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcHammaddeListesi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvHammaddeListesi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlHammaddeIslem)).BeginInit();
            this.pnlHammaddeIslem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupHammaddeEkle)).BeginInit();
            this.groupHammaddeEkle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtHamMiktar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbHamBirim.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbHamTur.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.pnlHeader.Appearance.Options.UseBackColor = true;
            this.pnlHeader.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlHeader.Controls.Add(this.lblBaslik);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(17, 0, 0, 0);
            this.pnlHeader.Size = new System.Drawing.Size(1029, 57);
            this.pnlHeader.TabIndex = 2;
            // 
            // lblBaslik
            // 
            this.lblBaslik.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            this.lblBaslik.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblBaslik.Appearance.Options.UseFont = true;
            this.lblBaslik.Appearance.Options.UseForeColor = true;
            this.lblBaslik.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblBaslik.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblBaslik.Location = new System.Drawing.Point(17, 0);
            this.lblBaslik.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new System.Drawing.Size(343, 57);
            this.lblBaslik.TabIndex = 0;
            this.lblBaslik.Text = "ÜRÜN YÖNETİMİ";
            // 
            // accordionControl1
            // 
            this.accordionControl1.Appearance.AccordionControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(44)))), ((int)(((byte)(52)))));
            this.accordionControl1.Appearance.AccordionControl.Options.UseBackColor = true;
            this.accordionControl1.Appearance.Item.Hovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(66)))), ((int)(((byte)(78)))));
            this.accordionControl1.Appearance.Item.Hovered.ForeColor = System.Drawing.Color.White;
            this.accordionControl1.Appearance.Item.Hovered.Options.UseBackColor = true;
            this.accordionControl1.Appearance.Item.Hovered.Options.UseForeColor = true;
            this.accordionControl1.Appearance.Item.Normal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(181)))), ((int)(((byte)(189)))));
            this.accordionControl1.Appearance.Item.Normal.Options.UseForeColor = true;
            this.accordionControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.accordionControl1.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.elmUrunler,
            this.elmMakineler,
            this.elmHammadde,
            this.elmSiparisler});
            this.accordionControl1.Location = new System.Drawing.Point(0, 57);
            this.accordionControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.accordionControl1.Name = "accordionControl1";
            this.accordionControl1.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Touch;
            this.accordionControl1.Size = new System.Drawing.Size(223, 552);
            this.accordionControl1.TabIndex = 0;
            // 
            // elmUrunler
            // 
            this.elmUrunler.Name = "elmUrunler";
            this.elmUrunler.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.elmUrunler.Text = "  ÜRÜN YÖNETİMİ";
            // 
            // elmMakineler
            // 
            this.elmMakineler.Name = "elmMakineler";
            this.elmMakineler.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.elmMakineler.Text = "  MAKİNE DURUMU";
            // 
            // elmHammadde
            // 
            this.elmHammadde.Name = "elmHammadde";
            this.elmHammadde.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.elmHammadde.Text = "  HAMMADDE STOK";
            // 
            // elmSiparisler
            // 
            this.elmSiparisler.Name = "elmSiparisler";
            this.elmSiparisler.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.elmSiparisler.Text = "  SİPARİŞ TAKİBİ";
            // 
            // navFrameYonetici
            // 
            this.navFrameYonetici.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.navFrameYonetici.Appearance.Options.UseBackColor = true;
            this.navFrameYonetici.Controls.Add(this.pageUrunler);
            this.navFrameYonetici.Controls.Add(this.pageMakineler);
            this.navFrameYonetici.Controls.Add(this.pageHammadde);
            this.navFrameYonetici.Controls.Add(this.pageSiparisler);
            this.navFrameYonetici.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navFrameYonetici.Location = new System.Drawing.Point(223, 57);
            this.navFrameYonetici.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.navFrameYonetici.Name = "navFrameYonetici";
            this.navFrameYonetici.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.pageUrunler,
            this.pageMakineler,
            this.pageHammadde,
            this.pageSiparisler});
            this.navFrameYonetici.SelectedPage = this.pageUrunler;
            this.navFrameYonetici.Size = new System.Drawing.Size(806, 552);
            this.navFrameYonetici.TabIndex = 1;
            // 
            // pageUrunler
            // 
            this.pageUrunler.Caption = "pageUrunler";
            this.pageUrunler.Controls.Add(this.gcUrunListesi);
            this.pageUrunler.Controls.Add(this.btnUrunKaldir);
            this.pageUrunler.Controls.Add(this.pnlUrunIslemleri);
            this.pageUrunler.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pageUrunler.Name = "pageUrunler";
            this.pageUrunler.Size = new System.Drawing.Size(691, 448);
            // 
            // gcUrunListesi
            // 
            this.gcUrunListesi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcUrunListesi.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gcUrunListesi.Location = new System.Drawing.Point(0, 0);
            this.gcUrunListesi.MainView = this.gvUrunListesi;
            this.gcUrunListesi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gcUrunListesi.Name = "gcUrunListesi";
            this.gcUrunListesi.Padding = new System.Windows.Forms.Padding(9, 8, 9, 8);
            this.gcUrunListesi.Size = new System.Drawing.Size(365, 407);
            this.gcUrunListesi.TabIndex = 0;
            this.gcUrunListesi.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvUrunListesi});
            // 
            // gvUrunListesi
            // 
            this.gvUrunListesi.Appearance.HeaderPanel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.gvUrunListesi.Appearance.Row.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.gvUrunListesi.DetailHeight = 284;
            this.gvUrunListesi.GridControl = this.gcUrunListesi;
            this.gvUrunListesi.Name = "gvUrunListesi";
            this.gvUrunListesi.OptionsBehavior.Editable = false;
            this.gvUrunListesi.OptionsEditForm.PopupEditFormWidth = 686;
            this.gvUrunListesi.OptionsView.EnableAppearanceEvenRow = true;
            this.gvUrunListesi.OptionsView.ShowGroupPanel = false;
            this.gvUrunListesi.OptionsView.ShowIndicator = false;
            this.gvUrunListesi.RowHeight = 28;
            // 
            // btnUrunKaldir
            // 
            this.btnUrunKaldir.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnUrunKaldir.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnUrunKaldir.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnUrunKaldir.Appearance.Options.UseBackColor = true;
            this.btnUrunKaldir.Appearance.Options.UseFont = true;
            this.btnUrunKaldir.Appearance.Options.UseForeColor = true;
            this.btnUrunKaldir.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnUrunKaldir.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnUrunKaldir.Location = new System.Drawing.Point(0, 407);
            this.btnUrunKaldir.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUrunKaldir.Name = "btnUrunKaldir";
            this.btnUrunKaldir.Size = new System.Drawing.Size(365, 41);
            this.btnUrunKaldir.TabIndex = 1;
            this.btnUrunKaldir.Text = "SEÇİLİ ÜRÜNÜ SİL";
            this.btnUrunKaldir.Visible = false;
            // 
            // pnlUrunIslemleri
            // 
            this.pnlUrunIslemleri.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlUrunIslemleri.Controls.Add(this.groupUrunEkle);
            this.pnlUrunIslemleri.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlUrunIslemleri.Location = new System.Drawing.Point(365, 0);
            this.pnlUrunIslemleri.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlUrunIslemleri.Name = "pnlUrunIslemleri";
            this.pnlUrunIslemleri.Padding = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.pnlUrunIslemleri.Size = new System.Drawing.Size(326, 448);
            this.pnlUrunIslemleri.TabIndex = 2;
            // 
            // groupUrunEkle
            // 
            this.groupUrunEkle.AppearanceCaption.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.groupUrunEkle.AppearanceCaption.ForeColor = System.Drawing.Color.DimGray;
            this.groupUrunEkle.AppearanceCaption.Options.UseFont = true;
            this.groupUrunEkle.AppearanceCaption.Options.UseForeColor = true;
            this.groupUrunEkle.Controls.Add(this.btnUrunKaydet);
            this.groupUrunEkle.Controls.Add(this.lstEklenenVaryantlar);
            this.groupUrunEkle.Controls.Add(this.groupVaryant);
            this.groupUrunEkle.Controls.Add(this.cmbHammaddeTur);
            this.groupUrunEkle.Controls.Add(this.cmbUrunTur);
            this.groupUrunEkle.Controls.Add(this.txtUrunModel);
            this.groupUrunEkle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupUrunEkle.Location = new System.Drawing.Point(13, 12);
            this.groupUrunEkle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupUrunEkle.Name = "groupUrunEkle";
            this.groupUrunEkle.Size = new System.Drawing.Size(300, 424);
            this.groupUrunEkle.TabIndex = 0;
            this.groupUrunEkle.Text = "YENİ ÜRÜN KARTI";
            // 
            // btnUrunKaydet
            // 
            this.btnUrunKaydet.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnUrunKaydet.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnUrunKaydet.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnUrunKaydet.Appearance.Options.UseBackColor = true;
            this.btnUrunKaydet.Appearance.Options.UseFont = true;
            this.btnUrunKaydet.Appearance.Options.UseForeColor = true;
            this.btnUrunKaydet.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnUrunKaydet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUrunKaydet.Location = new System.Drawing.Point(21, 483);
            this.btnUrunKaydet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUrunKaydet.Name = "btnUrunKaydet";
            this.btnUrunKaydet.Size = new System.Drawing.Size(257, 41);
            this.btnUrunKaydet.TabIndex = 0;
            this.btnUrunKaydet.Text = "KAYDET VE YAYINLA";
            // 
            // lstEklenenVaryantlar
            // 
            this.lstEklenenVaryantlar.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lstEklenenVaryantlar.Appearance.Options.UseFont = true;
            this.lstEklenenVaryantlar.Location = new System.Drawing.Point(21, 349);
            this.lstEklenenVaryantlar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lstEklenenVaryantlar.Name = "lstEklenenVaryantlar";
            this.lstEklenenVaryantlar.Size = new System.Drawing.Size(257, 122);
            this.lstEklenenVaryantlar.TabIndex = 1;
            // 
            // groupVaryant
            // 
            this.groupVaryant.AppearanceCaption.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.groupVaryant.AppearanceCaption.Options.UseFont = true;
            this.groupVaryant.Controls.Add(this.cmbRenkSec);
            this.groupVaryant.Controls.Add(this.peUrunResim);
            this.groupVaryant.Controls.Add(this.btnRenkEkle);
            this.groupVaryant.Location = new System.Drawing.Point(21, 154);
            this.groupVaryant.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupVaryant.Name = "groupVaryant";
            this.groupVaryant.Size = new System.Drawing.Size(257, 187);
            this.groupVaryant.TabIndex = 2;
            this.groupVaryant.Text = "Renk & Görsel";
            // 
            // cmbRenkSec
            // 
            this.cmbRenkSec.Location = new System.Drawing.Point(13, 28);
            this.cmbRenkSec.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbRenkSec.Name = "cmbRenkSec";
            this.cmbRenkSec.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbRenkSec.Properties.Appearance.Options.UseFont = true;
            this.cmbRenkSec.Properties.AutoHeight = false;
            this.cmbRenkSec.Properties.Items.AddRange(new object[] {
            "Siyah",
            "Kahve",
            "Haki",
            "Beyaz",
            "Lacivert"});
            this.cmbRenkSec.Properties.NullValuePrompt = "Renk Seçimi";
            this.cmbRenkSec.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbRenkSec.Size = new System.Drawing.Size(231, 28);
            this.cmbRenkSec.TabIndex = 0;
            // 
            // peUrunResim
            // 
            this.peUrunResim.Location = new System.Drawing.Point(13, 61);
            this.peUrunResim.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.peUrunResim.Name = "peUrunResim";
            this.peUrunResim.Properties.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.peUrunResim.Properties.Appearance.Options.UseBackColor = true;
            this.peUrunResim.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.peUrunResim.Properties.NullText = "Fotoğraf";
            this.peUrunResim.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.peUrunResim.Size = new System.Drawing.Size(111, 106);
            this.peUrunResim.TabIndex = 1;
            // 
            // btnRenkEkle
            // 
            this.btnRenkEkle.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnRenkEkle.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRenkEkle.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnRenkEkle.Appearance.Options.UseBackColor = true;
            this.btnRenkEkle.Appearance.Options.UseFont = true;
            this.btnRenkEkle.Appearance.Options.UseForeColor = true;
            this.btnRenkEkle.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnRenkEkle.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.btnRenkEkle.Location = new System.Drawing.Point(133, 61);
            this.btnRenkEkle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRenkEkle.Name = "btnRenkEkle";
            this.btnRenkEkle.Size = new System.Drawing.Size(111, 106);
            this.btnRenkEkle.TabIndex = 2;
            this.btnRenkEkle.Text = "EKLE";
            // 
            // cmbHammaddeTur
            // 
            this.cmbHammaddeTur.Location = new System.Drawing.Point(21, 114);
            this.cmbHammaddeTur.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbHammaddeTur.Name = "cmbHammaddeTur";
            this.cmbHammaddeTur.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cmbHammaddeTur.Properties.Appearance.Options.UseFont = true;
            this.cmbHammaddeTur.Properties.AutoHeight = false;
            this.cmbHammaddeTur.Properties.Items.AddRange(new object[] {
            "Deri",
            "Emitasyon",
            "Kumaş",
            "Süet"});
            this.cmbHammaddeTur.Properties.NullValuePrompt = "Ana Malzeme";
            this.cmbHammaddeTur.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbHammaddeTur.Size = new System.Drawing.Size(257, 29);
            this.cmbHammaddeTur.TabIndex = 3;
            // 
            // cmbUrunTur
            // 
            this.cmbUrunTur.Location = new System.Drawing.Point(21, 77);
            this.cmbUrunTur.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbUrunTur.Name = "cmbUrunTur";
            this.cmbUrunTur.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cmbUrunTur.Properties.Appearance.Options.UseFont = true;
            this.cmbUrunTur.Properties.AutoHeight = false;
            this.cmbUrunTur.Properties.Items.AddRange(new object[] {
            "Klasik",
            "Bot",
            "Spor"});
            this.cmbUrunTur.Properties.NullValuePrompt = "Kategori Seçiniz";
            this.cmbUrunTur.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbUrunTur.Size = new System.Drawing.Size(257, 29);
            this.cmbUrunTur.TabIndex = 4;
            // 
            // txtUrunModel
            // 
            this.txtUrunModel.Location = new System.Drawing.Point(21, 41);
            this.txtUrunModel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtUrunModel.Name = "txtUrunModel";
            this.txtUrunModel.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtUrunModel.Properties.Appearance.Options.UseFont = true;
            this.txtUrunModel.Properties.AutoHeight = false;
            this.txtUrunModel.Properties.NullValuePrompt = "Ürün Model Adı";
            this.txtUrunModel.Size = new System.Drawing.Size(257, 29);
            this.txtUrunModel.TabIndex = 5;
            // 
            // pageMakineler
            // 
            this.pageMakineler.Caption = "pageMakineler";
            this.pageMakineler.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pageMakineler.Name = "pageMakineler";
            this.pageMakineler.Size = new System.Drawing.Size(691, 448);
            // 
            // pageHammadde
            // 
            this.pageHammadde.Caption = "pageHammadde";
            this.pageHammadde.Controls.Add(this.gcHammaddeListesi);
            this.pageHammadde.Controls.Add(this.pnlHammaddeIslem);
            this.pageHammadde.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pageHammadde.Name = "pageHammadde";
            this.pageHammadde.Size = new System.Drawing.Size(691, 448);
            // 
            // gcHammaddeListesi
            // 
            this.gcHammaddeListesi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcHammaddeListesi.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gcHammaddeListesi.Location = new System.Drawing.Point(0, 0);
            this.gcHammaddeListesi.MainView = this.gvHammaddeListesi;
            this.gcHammaddeListesi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gcHammaddeListesi.Name = "gcHammaddeListesi";
            this.gcHammaddeListesi.Padding = new System.Windows.Forms.Padding(9, 8, 9, 8);
            this.gcHammaddeListesi.Size = new System.Drawing.Size(365, 448);
            this.gcHammaddeListesi.TabIndex = 0;
            this.gcHammaddeListesi.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvHammaddeListesi});
            // 
            // gvHammaddeListesi
            // 
            this.gvHammaddeListesi.Appearance.HeaderPanel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.gvHammaddeListesi.Appearance.Row.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.gvHammaddeListesi.DetailHeight = 284;
            this.gvHammaddeListesi.GridControl = this.gcHammaddeListesi;
            this.gvHammaddeListesi.Name = "gvHammaddeListesi";
            this.gvHammaddeListesi.OptionsBehavior.Editable = false;
            this.gvHammaddeListesi.OptionsEditForm.PopupEditFormWidth = 686;
            this.gvHammaddeListesi.OptionsView.EnableAppearanceEvenRow = true;
            this.gvHammaddeListesi.OptionsView.ShowGroupPanel = false;
            this.gvHammaddeListesi.RowHeight = 28;
            // 
            // pnlHammaddeIslem
            // 
            this.pnlHammaddeIslem.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlHammaddeIslem.Controls.Add(this.groupHammaddeEkle);
            this.pnlHammaddeIslem.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlHammaddeIslem.Location = new System.Drawing.Point(365, 0);
            this.pnlHammaddeIslem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlHammaddeIslem.Name = "pnlHammaddeIslem";
            this.pnlHammaddeIslem.Padding = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.pnlHammaddeIslem.Size = new System.Drawing.Size(326, 448);
            this.pnlHammaddeIslem.TabIndex = 1;
            // 
            // groupHammaddeEkle
            // 
            this.groupHammaddeEkle.AppearanceCaption.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.groupHammaddeEkle.AppearanceCaption.ForeColor = System.Drawing.Color.DimGray;
            this.groupHammaddeEkle.AppearanceCaption.Options.UseFont = true;
            this.groupHammaddeEkle.AppearanceCaption.Options.UseForeColor = true;
            this.groupHammaddeEkle.Controls.Add(this.btnHammaddeEkle);
            this.groupHammaddeEkle.Controls.Add(this.txtHamMiktar);
            this.groupHammaddeEkle.Controls.Add(this.cmbHamBirim);
            this.groupHammaddeEkle.Controls.Add(this.cmbHamTur);
            this.groupHammaddeEkle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupHammaddeEkle.Location = new System.Drawing.Point(13, 12);
            this.groupHammaddeEkle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupHammaddeEkle.Name = "groupHammaddeEkle";
            this.groupHammaddeEkle.Size = new System.Drawing.Size(300, 424);
            this.groupHammaddeEkle.TabIndex = 0;
            this.groupHammaddeEkle.Text = "STOK GİRİŞ İŞLEMİ";
            // 
            // btnHammaddeEkle
            // 
            this.btnHammaddeEkle.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(18)))));
            this.btnHammaddeEkle.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnHammaddeEkle.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnHammaddeEkle.Appearance.Options.UseBackColor = true;
            this.btnHammaddeEkle.Appearance.Options.UseFont = true;
            this.btnHammaddeEkle.Appearance.Options.UseForeColor = true;
            this.btnHammaddeEkle.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnHammaddeEkle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHammaddeEkle.Location = new System.Drawing.Point(21, 187);
            this.btnHammaddeEkle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnHammaddeEkle.Name = "btnHammaddeEkle";
            this.btnHammaddeEkle.Size = new System.Drawing.Size(257, 41);
            this.btnHammaddeEkle.TabIndex = 0;
            this.btnHammaddeEkle.Text = "STOĞU GÜNCELLE";
            // 
            // txtHamMiktar
            // 
            this.txtHamMiktar.Location = new System.Drawing.Point(21, 130);
            this.txtHamMiktar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtHamMiktar.Name = "txtHamMiktar";
            this.txtHamMiktar.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtHamMiktar.Properties.Appearance.Options.UseFont = true;
            this.txtHamMiktar.Properties.AutoHeight = false;
            this.txtHamMiktar.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.txtHamMiktar.Properties.MaskSettings.Set("mask", "n");
            this.txtHamMiktar.Properties.NullValuePrompt = "Miktar Giriniz";
            this.txtHamMiktar.Size = new System.Drawing.Size(257, 29);
            this.txtHamMiktar.TabIndex = 1;
            // 
            // cmbHamBirim
            // 
            this.cmbHamBirim.Location = new System.Drawing.Point(21, 89);
            this.cmbHamBirim.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbHamBirim.Name = "cmbHamBirim";
            this.cmbHamBirim.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cmbHamBirim.Properties.Appearance.Options.UseFont = true;
            this.cmbHamBirim.Properties.AutoHeight = false;
            this.cmbHamBirim.Properties.Items.AddRange(new object[] {
            "m² (Metrekare)",
            "Adet"});
            this.cmbHamBirim.Properties.NullValuePrompt = "Birim";
            this.cmbHamBirim.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbHamBirim.Size = new System.Drawing.Size(257, 29);
            this.cmbHamBirim.TabIndex = 2;
            // 
            // cmbHamTur
            // 
            this.cmbHamTur.Location = new System.Drawing.Point(21, 49);
            this.cmbHamTur.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbHamTur.Name = "cmbHamTur";
            this.cmbHamTur.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cmbHamTur.Properties.Appearance.Options.UseFont = true;
            this.cmbHamTur.Properties.AutoHeight = false;
            this.cmbHamTur.Properties.Items.AddRange(new object[] {
            "Ayakkabı Hammaddesi",
            "Taban"});
            this.cmbHamTur.Properties.NullValuePrompt = "Hammadde Türü";
            this.cmbHamTur.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbHamTur.Size = new System.Drawing.Size(257, 29);
            this.cmbHamTur.TabIndex = 3;
            // 
            // pageSiparisler
            // 
            this.pageSiparisler.Caption = "pageSiparisler";
            this.pageSiparisler.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pageSiparisler.Name = "pageSiparisler";
            this.pageSiparisler.Size = new System.Drawing.Size(691, 448);
            // 
            // FrmYonetici
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1029, 609);
            this.Controls.Add(this.navFrameYonetici);
            this.Controls.Add(this.accordionControl1);
            this.Controls.Add(this.pnlHeader);
            this.IconOptions.ShowIcon = false;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmYonetici";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fabrika Yönetim Paneli";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.navFrameYonetici)).EndInit();
            this.navFrameYonetici.ResumeLayout(false);
            this.pageUrunler.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcUrunListesi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvUrunListesi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlUrunIslemleri)).EndInit();
            this.pnlUrunIslemleri.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupUrunEkle)).EndInit();
            this.groupUrunEkle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lstEklenenVaryantlar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupVaryant)).EndInit();
            this.groupVaryant.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmbRenkSec.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.peUrunResim.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbHammaddeTur.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbUrunTur.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUrunModel.Properties)).EndInit();
            this.pageHammadde.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcHammaddeListesi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvHammaddeListesi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlHammaddeIslem)).EndInit();
            this.pnlHammaddeIslem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupHammaddeEkle)).EndInit();
            this.groupHammaddeEkle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtHamMiktar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbHamBirim.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbHamTur.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Navigation.AccordionControl accordionControl1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement elmUrunler;
        private DevExpress.XtraBars.Navigation.AccordionControlElement elmMakineler;
        private DevExpress.XtraBars.Navigation.AccordionControlElement elmHammadde;
        private DevExpress.XtraBars.Navigation.AccordionControlElement elmSiparisler;
        private DevExpress.XtraEditors.PanelControl pnlHeader;
        private DevExpress.XtraEditors.LabelControl lblBaslik;
        private DevExpress.XtraBars.Navigation.NavigationFrame navFrameYonetici;
        private DevExpress.XtraBars.Navigation.NavigationPage pageUrunler;
        private DevExpress.XtraBars.Navigation.NavigationPage pageMakineler;
        private DevExpress.XtraBars.Navigation.NavigationPage pageHammadde;
        private DevExpress.XtraBars.Navigation.NavigationPage pageSiparisler;

        private DevExpress.XtraGrid.GridControl gcUrunListesi;
        private DevExpress.XtraGrid.Views.Grid.GridView gvUrunListesi;
        private DevExpress.XtraEditors.SimpleButton btnUrunKaldir;
        private DevExpress.XtraEditors.PanelControl pnlUrunIslemleri;
        private DevExpress.XtraEditors.GroupControl groupUrunEkle;
        private DevExpress.XtraEditors.TextEdit txtUrunModel;
        private DevExpress.XtraEditors.ComboBoxEdit cmbUrunTur;
        private DevExpress.XtraEditors.ComboBoxEdit cmbHammaddeTur;
        private DevExpress.XtraEditors.GroupControl groupVaryant;
        private DevExpress.XtraEditors.ComboBoxEdit cmbRenkSec;
        private DevExpress.XtraEditors.PictureEdit peUrunResim;
        private DevExpress.XtraEditors.SimpleButton btnRenkEkle;
        private DevExpress.XtraEditors.ListBoxControl lstEklenenVaryantlar;
        private DevExpress.XtraEditors.SimpleButton btnUrunKaydet;

        private DevExpress.XtraGrid.GridControl gcHammaddeListesi;
        private DevExpress.XtraGrid.Views.Grid.GridView gvHammaddeListesi;
        private DevExpress.XtraEditors.PanelControl pnlHammaddeIslem;
        private DevExpress.XtraEditors.GroupControl groupHammaddeEkle;
        private DevExpress.XtraEditors.ComboBoxEdit cmbHamTur;
        private DevExpress.XtraEditors.ComboBoxEdit cmbHamBirim;
        private DevExpress.XtraEditors.TextEdit txtHamMiktar;
        private DevExpress.XtraEditors.SimpleButton btnHammaddeEkle;
    }
}