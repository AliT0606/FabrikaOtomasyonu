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
            this.components = new System.ComponentModel.Container();
            this.pnlHeader = new DevExpress.XtraEditors.PanelControl();
            this.lblBaslik = new DevExpress.XtraEditors.LabelControl();
            this.accordionControl1 = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.elmUrunler = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.elmMakineler = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.elmHammadde = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.elmSiparisler = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.navFrameYonetici = new DevExpress.XtraBars.Navigation.NavigationFrame();

            // --- SAYFALAR ---
            this.pageUrunler = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.gcUrunListesi = new DevExpress.XtraGrid.GridControl();
            this.gvUrunListesi = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.pnlUrunIslemleri = new DevExpress.XtraEditors.PanelControl();
            this.groupUrunEkle = new DevExpress.XtraEditors.GroupControl();
            this.txtUrunModel = new DevExpress.XtraEditors.TextEdit();
            this.cmbUrunTur = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmbHammaddeTur = new DevExpress.XtraEditors.ComboBoxEdit();
            this.groupVaryant = new DevExpress.XtraEditors.GroupControl();
            this.cmbRenkSec = new DevExpress.XtraEditors.ComboBoxEdit();
            this.peUrunResim = new DevExpress.XtraEditors.PictureEdit();
            this.btnRenkEkle = new DevExpress.XtraEditors.SimpleButton();
            this.lstEklenenVaryantlar = new DevExpress.XtraEditors.ListBoxControl();
            this.btnUrunKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.btnUrunKaldir = new DevExpress.XtraEditors.SimpleButton();

            this.pageHammadde = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.gcHammaddeListesi = new DevExpress.XtraGrid.GridControl();
            this.gvHammaddeListesi = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.pnlHammaddeIslem = new DevExpress.XtraEditors.PanelControl();
            this.groupHammaddeEkle = new DevExpress.XtraEditors.GroupControl();
            this.cmbHamTur = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmbHamBirim = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtHamMiktar = new DevExpress.XtraEditors.TextEdit();
            this.btnHammaddeEkle = new DevExpress.XtraEditors.SimpleButton();

            this.pageMakineler = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.pageSiparisler = new DevExpress.XtraBars.Navigation.NavigationPage();

            ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).BeginInit();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.navFrameYonetici)).BeginInit();
            this.navFrameYonetici.SuspendLayout();

            // Ürünler
            this.pageUrunler.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcUrunListesi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvUrunListesi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlUrunIslemleri)).BeginInit();
            this.pnlUrunIslemleri.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupUrunEkle)).BeginInit();
            this.groupUrunEkle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUrunModel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbUrunTur.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbHammaddeTur.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupVaryant)).BeginInit();
            this.groupVaryant.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbRenkSec.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.peUrunResim.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstEklenenVaryantlar)).BeginInit();

            // Hammadde
            this.pageHammadde.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcHammaddeListesi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvHammaddeListesi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlHammaddeIslem)).BeginInit();
            this.pnlHammaddeIslem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupHammaddeEkle)).BeginInit();
            this.groupHammaddeEkle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbHamTur.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbHamBirim.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHamMiktar.Properties)).BeginInit();

            this.SuspendLayout();

            //
            // pnlHeader (ÜST HEADER - BOYDAN BOYA)
            //
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top; // En tepeye yapışır
            this.pnlHeader.Height = 70;
            this.pnlHeader.Appearance.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Appearance.Options.UseBackColor = true;
            this.pnlHeader.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlHeader.Controls.Add(this.lblBaslik);
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.pnlHeader.Size = new System.Drawing.Size(1200, 70);
            this.pnlHeader.TabIndex = 2; // Tab index önemli

            this.lblBaslik.Text = "ÜRÜN YÖNETİMİ";
            this.lblBaslik.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            this.lblBaslik.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblBaslik.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblBaslik.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblBaslik.Size = new System.Drawing.Size(400, 70);

            // 
            // accordionControl1 (SOL MENÜ - Header'ın Altında Kalacak)
            // 
            this.accordionControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.accordionControl1.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.elmUrunler,
            this.elmMakineler,
            this.elmHammadde,
            this.elmSiparisler});
            this.accordionControl1.Location = new System.Drawing.Point(0, 70); // Y:70'den başlar
            this.accordionControl1.Name = "accordionControl1";
            this.accordionControl1.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Touch;
            this.accordionControl1.Size = new System.Drawing.Size(260, 680); // Yükseklik ayarlandı
            this.accordionControl1.TabIndex = 0;
            this.accordionControl1.Appearance.AccordionControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(44)))), ((int)(((byte)(52)))));
            this.accordionControl1.Appearance.Item.Normal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(181)))), ((int)(((byte)(189)))));
            this.accordionControl1.Appearance.Item.Hovered.ForeColor = System.Drawing.Color.White;
            this.accordionControl1.Appearance.Item.Hovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(66)))), ((int)(((byte)(78)))));

            this.elmUrunler.Name = "elmUrunler";
            this.elmUrunler.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.elmUrunler.Text = "  ÜRÜN YÖNETİMİ";

            this.elmMakineler.Name = "elmMakineler";
            this.elmMakineler.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.elmMakineler.Text = "  MAKİNE DURUMU";

            this.elmHammadde.Name = "elmHammadde";
            this.elmHammadde.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.elmHammadde.Text = "  HAMMADDE STOK";

            this.elmSiparisler.Name = "elmSiparisler";
            this.elmSiparisler.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.elmSiparisler.Text = "  SİPARİŞ TAKİBİ";

            // 
            // navFrameYonetici (İÇERİK ALANI)
            // 
            this.navFrameYonetici.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.navFrameYonetici.Appearance.Options.UseBackColor = true;
            this.navFrameYonetici.Controls.Add(this.pageUrunler);
            this.navFrameYonetici.Controls.Add(this.pageMakineler);
            this.navFrameYonetici.Controls.Add(this.pageHammadde);
            this.navFrameYonetici.Controls.Add(this.pageSiparisler);
            this.navFrameYonetici.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navFrameYonetici.Location = new System.Drawing.Point(260, 70); // Sidebar ve Header'a göre konum
            this.navFrameYonetici.Name = "navFrameYonetici";
            this.navFrameYonetici.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.pageUrunler,
            this.pageMakineler,
            this.pageHammadde,
            this.pageSiparisler});
            this.navFrameYonetici.SelectedPage = this.pageUrunler;
            this.navFrameYonetici.Size = new System.Drawing.Size(940, 680);
            this.navFrameYonetici.TabIndex = 1;

            // --- ÜRÜN PANELİ TASARIMI ---
            this.pageUrunler.Caption = "pageUrunler";
            this.pageUrunler.Controls.Add(this.gcUrunListesi);
            this.pageUrunler.Controls.Add(this.btnUrunKaldir);
            this.pageUrunler.Controls.Add(this.pnlUrunIslemleri);
            this.pageUrunler.Name = "pageUrunler";
            this.pageUrunler.Size = new System.Drawing.Size(940, 680);

            this.gcUrunListesi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcUrunListesi.MainView = this.gvUrunListesi;
            this.gcUrunListesi.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gvUrunListesi });
            this.gcUrunListesi.Padding = new System.Windows.Forms.Padding(10);

            this.gvUrunListesi.GridControl = this.gcUrunListesi;
            this.gvUrunListesi.OptionsBehavior.Editable = false;
            this.gvUrunListesi.OptionsView.ShowGroupPanel = false;
            this.gvUrunListesi.OptionsView.ShowIndicator = false;
            this.gvUrunListesi.OptionsView.EnableAppearanceEvenRow = true;
            this.gvUrunListesi.Appearance.HeaderPanel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.gvUrunListesi.Appearance.Row.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.gvUrunListesi.RowHeight = 35;

            this.btnUrunKaldir.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnUrunKaldir.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnUrunKaldir.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnUrunKaldir.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnUrunKaldir.Appearance.Options.UseBackColor = true;
            this.btnUrunKaldir.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnUrunKaldir.Height = 50;
            this.btnUrunKaldir.Text = "SEÇİLİ ÜRÜNÜ SİL";
            this.btnUrunKaldir.Visible = false;

            this.pnlUrunIslemleri.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlUrunIslemleri.Width = 380;
            this.pnlUrunIslemleri.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlUrunIslemleri.Padding = new System.Windows.Forms.Padding(15);
            this.pnlUrunIslemleri.Controls.Add(this.groupUrunEkle);

            this.groupUrunEkle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupUrunEkle.Text = "YENİ ÜRÜN KARTI";
            this.groupUrunEkle.AppearanceCaption.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.groupUrunEkle.AppearanceCaption.ForeColor = System.Drawing.Color.DimGray;
            this.groupUrunEkle.Controls.Add(this.btnUrunKaydet);
            this.groupUrunEkle.Controls.Add(this.lstEklenenVaryantlar);
            this.groupUrunEkle.Controls.Add(this.groupVaryant);
            this.groupUrunEkle.Controls.Add(this.cmbHammaddeTur);
            this.groupUrunEkle.Controls.Add(this.cmbUrunTur);
            this.groupUrunEkle.Controls.Add(this.txtUrunModel);

            this.txtUrunModel.Properties.NullValuePrompt = "Ürün Model Adı";
            this.txtUrunModel.Location = new System.Drawing.Point(25, 50);
            this.txtUrunModel.Size = new System.Drawing.Size(300, 36);
            this.txtUrunModel.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtUrunModel.Properties.AutoHeight = false;

            this.cmbUrunTur.Properties.NullValuePrompt = "Kategori Seçiniz";
            this.cmbUrunTur.Properties.Items.AddRange(new object[] { "Klasik", "Bot", "Spor" });
            this.cmbUrunTur.Location = new System.Drawing.Point(25, 95);
            this.cmbUrunTur.Size = new System.Drawing.Size(300, 36);
            this.cmbUrunTur.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cmbUrunTur.Properties.AutoHeight = false;
            this.cmbUrunTur.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;

            this.cmbHammaddeTur.Properties.NullValuePrompt = "Ana Malzeme";
            this.cmbHammaddeTur.Properties.Items.AddRange(new object[] { "Deri", "Emitasyon", "Kumaş", "Süet" });
            this.cmbHammaddeTur.Location = new System.Drawing.Point(25, 140);
            this.cmbHammaddeTur.Size = new System.Drawing.Size(300, 36);
            this.cmbHammaddeTur.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cmbHammaddeTur.Properties.AutoHeight = false;
            this.cmbHammaddeTur.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;

            this.groupVaryant.Location = new System.Drawing.Point(25, 190);
            this.groupVaryant.Size = new System.Drawing.Size(300, 230);
            this.groupVaryant.Text = "Renk & Görsel";
            this.groupVaryant.AppearanceCaption.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.groupVaryant.Controls.Add(this.cmbRenkSec);
            this.groupVaryant.Controls.Add(this.peUrunResim);
            this.groupVaryant.Controls.Add(this.btnRenkEkle);

            this.cmbRenkSec.Properties.NullValuePrompt = "Renk Seçimi";
            this.cmbRenkSec.Properties.Items.AddRange(new object[] { "Siyah", "Kahve", "Haki", "Beyaz", "Lacivert" });
            this.cmbRenkSec.Location = new System.Drawing.Point(15, 35);
            this.cmbRenkSec.Size = new System.Drawing.Size(270, 34);
            this.cmbRenkSec.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbRenkSec.Properties.AutoHeight = false;
            this.cmbRenkSec.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;

            this.peUrunResim.Location = new System.Drawing.Point(15, 75);
            this.peUrunResim.Size = new System.Drawing.Size(130, 130);
            this.peUrunResim.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.peUrunResim.Properties.NullText = "Fotoğraf";
            this.peUrunResim.Properties.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.peUrunResim.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;

            this.btnRenkEkle.Location = new System.Drawing.Point(155, 75);
            this.btnRenkEkle.Size = new System.Drawing.Size(130, 130);
            this.btnRenkEkle.Text = "EKLE";
            this.btnRenkEkle.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.btnRenkEkle.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnRenkEkle.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnRenkEkle.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRenkEkle.Appearance.Options.UseBackColor = true;
            this.btnRenkEkle.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;

            this.lstEklenenVaryantlar.Location = new System.Drawing.Point(25, 430);
            this.lstEklenenVaryantlar.Size = new System.Drawing.Size(300, 150);
            this.lstEklenenVaryantlar.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);

            this.btnUrunKaydet.Location = new System.Drawing.Point(25, 595);
            this.btnUrunKaydet.Size = new System.Drawing.Size(300, 50);
            this.btnUrunKaydet.Text = "KAYDET VE YAYINLA";
            this.btnUrunKaydet.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnUrunKaydet.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnUrunKaydet.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnUrunKaydet.Appearance.Options.UseBackColor = true;
            this.btnUrunKaydet.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnUrunKaydet.Cursor = System.Windows.Forms.Cursors.Hand;

            // --- HAMMADDE PANELİ TASARIMI ---
            this.pageHammadde.Caption = "pageHammadde";
            this.pageHammadde.Controls.Add(this.gcHammaddeListesi);
            this.pageHammadde.Controls.Add(this.pnlHammaddeIslem);
            this.pageHammadde.Name = "pageHammadde";
            this.pageHammadde.Size = new System.Drawing.Size(940, 680);

            this.pnlHammaddeIslem.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlHammaddeIslem.Width = 380;
            this.pnlHammaddeIslem.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlHammaddeIslem.Padding = new System.Windows.Forms.Padding(15);
            this.pnlHammaddeIslem.Controls.Add(this.groupHammaddeEkle);

            this.groupHammaddeEkle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupHammaddeEkle.Text = "STOK GİRİŞ İŞLEMİ";
            this.groupHammaddeEkle.AppearanceCaption.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.groupHammaddeEkle.AppearanceCaption.ForeColor = System.Drawing.Color.DimGray;
            this.groupHammaddeEkle.Controls.Add(this.btnHammaddeEkle);
            this.groupHammaddeEkle.Controls.Add(this.txtHamMiktar);
            this.groupHammaddeEkle.Controls.Add(this.cmbHamBirim);
            this.groupHammaddeEkle.Controls.Add(this.cmbHamTur);

            this.cmbHamTur.Properties.NullValuePrompt = "Hammadde Türü";
            this.cmbHamTur.Properties.Items.AddRange(new object[] { "Ayakkabı Hammaddesi", "Taban" });
            this.cmbHamTur.Location = new System.Drawing.Point(25, 60);
            this.cmbHamTur.Size = new System.Drawing.Size(300, 36);
            this.cmbHamTur.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cmbHamTur.Properties.AutoHeight = false;
            this.cmbHamTur.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;

            this.cmbHamBirim.Properties.NullValuePrompt = "Birim";
            this.cmbHamBirim.Properties.Items.AddRange(new object[] { "m² (Metrekare)", "Adet" });
            this.cmbHamBirim.Location = new System.Drawing.Point(25, 110);
            this.cmbHamBirim.Size = new System.Drawing.Size(300, 36);
            this.cmbHamBirim.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cmbHamBirim.Properties.AutoHeight = false;
            this.cmbHamBirim.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;

            this.txtHamMiktar.Properties.NullValuePrompt = "Miktar Giriniz";
            this.txtHamMiktar.Location = new System.Drawing.Point(25, 160);
            this.txtHamMiktar.Size = new System.Drawing.Size(300, 36);
            this.txtHamMiktar.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtHamMiktar.Properties.AutoHeight = false;
            this.txtHamMiktar.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.txtHamMiktar.Properties.MaskSettings.Set("mask", "n");

            this.btnHammaddeEkle.Location = new System.Drawing.Point(25, 230);
            this.btnHammaddeEkle.Size = new System.Drawing.Size(300, 50);
            this.btnHammaddeEkle.Text = "STOĞU GÜNCELLE";
            this.btnHammaddeEkle.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(18)))));
            this.btnHammaddeEkle.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnHammaddeEkle.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnHammaddeEkle.Appearance.Options.UseBackColor = true;
            this.btnHammaddeEkle.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnHammaddeEkle.Cursor = System.Windows.Forms.Cursors.Hand;

            this.gcHammaddeListesi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcHammaddeListesi.MainView = this.gvHammaddeListesi;
            this.gcHammaddeListesi.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gvHammaddeListesi });
            this.gcHammaddeListesi.Padding = new System.Windows.Forms.Padding(10);
            this.gvHammaddeListesi.GridControl = this.gcHammaddeListesi;
            this.gvHammaddeListesi.OptionsBehavior.Editable = false;
            this.gvHammaddeListesi.OptionsView.ShowGroupPanel = false;
            this.gvHammaddeListesi.OptionsView.EnableAppearanceEvenRow = true;
            this.gvHammaddeListesi.Appearance.HeaderPanel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.gvHammaddeListesi.Appearance.Row.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.gvHammaddeListesi.RowHeight = 35;

            // Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 750);

            // DİKKAT: Header'ın üstte kalması için ekleme sırası önemlidir.
            // En son eklenen kontrol, Dock mantığında en önde/üstte yer alır (bazı durumlarda).
            // Ancak en garantisi, "Controls.Add" sırasını tersine çevirmektir.
            // Burada önce NavFrame, Sonra Accordion, Sonra Header ekliyoruz.
            // Böylece pnlHeader (Top) en son eklendiği için "Dock=Top" komutunu EN DIŞ katmanda uygular.
            this.Controls.Add(this.navFrameYonetici);
            this.Controls.Add(this.accordionControl1);
            this.Controls.Add(this.pnlHeader);

            this.Name = "FrmYonetici";
            this.Text = "Fabrika Yönetim Paneli";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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
            ((System.ComponentModel.ISupportInitialize)(this.txtUrunModel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbUrunTur.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbHammaddeTur.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupVaryant)).EndInit();
            this.groupVaryant.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmbRenkSec.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.peUrunResim.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstEklenenVaryantlar)).EndInit();

            this.pageHammadde.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcHammaddeListesi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvHammaddeListesi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlHammaddeIslem)).EndInit();
            this.pnlHammaddeIslem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupHammaddeEkle)).EndInit();
            this.groupHammaddeEkle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmbHamTur.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbHamBirim.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHamMiktar.Properties)).EndInit();

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