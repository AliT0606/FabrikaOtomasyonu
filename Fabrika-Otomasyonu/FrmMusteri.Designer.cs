namespace Fabrika_Otomasyonu
{
    partial class FrmMusteri
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement1 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement2 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement3 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement4 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();

            // GRID SÜTUNLARI VE REPOSITORY
            this.colKapakResmi = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.colModelAd = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.colAnaHammadde = new DevExpress.XtraGrid.Columns.TileViewColumn(); // yeni sütun
            this.colFiyat = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.colId = new DevExpress.XtraGrid.Columns.TileViewColumn();

            this.repoResim = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.repoBilgi = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.repoAdet = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.repoSil = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();

            // ANA KONTROLLER
            this.pnlHeader = new DevExpress.XtraEditors.PanelControl();
            this.lblHeader = new DevExpress.XtraEditors.LabelControl();
            this.navFrameMusteri = new DevExpress.XtraBars.Navigation.NavigationFrame();
            this.accordionControl1 = new DevExpress.XtraBars.Navigation.AccordionControl();

            // SAYFALAR
            this.pageKatalog = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.pageSepet = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.pageTakip = new DevExpress.XtraBars.Navigation.NavigationPage();

            // KATALOG BİLEŞENLERİ
            this.pnlKatalogUst = new DevExpress.XtraEditors.PanelControl();
            this.lblFiltre = new DevExpress.XtraEditors.LabelControl();
            this.cmbKategoriFiltre = new DevExpress.XtraEditors.ComboBoxEdit();
            this.pnlKatalogSag = new DevExpress.XtraEditors.PanelControl();
            this.pnlSagDetay = new DevExpress.XtraEditors.PanelControl();
            this.gcUrunVitrin = new DevExpress.XtraGrid.GridControl();
            this.tvUrunVitrin = new DevExpress.XtraGrid.Views.Tile.TileView();

            // DETAY BİLEŞENLERİ
            this.lblUrunBaslik = new DevExpress.XtraEditors.LabelControl();
            this.peSeciliResim = new DevExpress.XtraEditors.PictureEdit();
            this.cmbVaryant = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtAdet = new DevExpress.XtraEditors.SpinEdit();
            this.lblToplamFiyat = new DevExpress.XtraEditors.LabelControl();
            this.btnSepeteEkle = new DevExpress.XtraEditors.SimpleButton();

            // SEPET BİLEŞENLERİ
            this.gcSepet = new DevExpress.XtraGrid.GridControl();
            this.gvSepet = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSepetResim = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSepetBilgi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSepetAdet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSepetTutar = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSepetSil = new DevExpress.XtraGrid.Columns.GridColumn();

            this.pnlSepetAlt = new DevExpress.XtraEditors.PanelControl();
            this.lblSepetToplam = new DevExpress.XtraEditors.LabelControl();
            this.btnSepetiTemizle = new DevExpress.XtraEditors.SimpleButton();
            this.btnSepetiOnayla = new DevExpress.XtraEditors.SimpleButton();

            // TAKİP BİLEŞENLERİ
            this.gcSiparisTakip = new DevExpress.XtraGrid.GridControl();
            this.gvSiparisTakip = new DevExpress.XtraGrid.Views.Grid.GridView();

            // MENU ELEMANLARI
            this.elmKatalog = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.elmSepet = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.elmTakip = new DevExpress.XtraBars.Navigation.AccordionControlElement();

            ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).BeginInit();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navFrameMusteri)).BeginInit();
            this.navFrameMusteri.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoResim)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoBilgi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoAdet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoSil)).BeginInit();
            this.pageKatalog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlKatalogUst)).BeginInit();
            this.pnlKatalogUst.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKategoriFiltre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlKatalogSag)).BeginInit();
            this.pnlKatalogSag.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSagDetay)).BeginInit();
            this.pnlSagDetay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.peSeciliResim.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbVaryant.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAdet.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcUrunVitrin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tvUrunVitrin)).BeginInit();
            this.pageSepet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcSepet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSepet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSepetAlt)).BeginInit();
            this.pnlSepetAlt.SuspendLayout();
            this.pageTakip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcSiparisTakip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSiparisTakip)).BeginInit();
            this.SuspendLayout();

            // --- HEADER ---
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 70;
            this.pnlHeader.Appearance.BackColor = System.Drawing.Color.FromArgb(0, 102, 204);
            this.pnlHeader.Appearance.Options.UseBackColor = true;
            this.pnlHeader.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlHeader.Controls.Add(this.lblHeader);

            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHeader.Text = "MÜŞTERİ PANELİ";
            this.lblHeader.Appearance.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblHeader.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblHeader.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;

            // --- SOL MENÜ ---
            this.accordionControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.accordionControl1.Size = new System.Drawing.Size(250, 630);
            this.accordionControl1.Appearance.AccordionControl.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.accordionControl1.Appearance.AccordionControl.Options.UseBackColor = true;
            this.accordionControl1.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
                this.elmKatalog, this.elmSepet, this.elmTakip});

            this.elmKatalog.Text = "ÜRÜN KATALOĞU"; this.elmKatalog.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item; this.elmKatalog.Height = 50;
            this.elmSepet.Text = "SEPETİM"; this.elmSepet.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item; this.elmSepet.Height = 50;
            this.elmTakip.Text = "SİPARİŞ TAKİBİ"; this.elmTakip.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item; this.elmTakip.Height = 50;

            // --- NAV FRAME ---
            this.navFrameMusteri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navFrameMusteri.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] { this.pageKatalog, this.pageSepet, this.pageTakip });
            this.navFrameMusteri.SelectedPage = this.pageKatalog;

            // =================================================================================
            // SAYFA 1: KATALOG (GÜNCELLENDİ - FLOW WRAP + HAMMADDE ALT SATIRDA)
            // =================================================================================
            this.pnlKatalogUst.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlKatalogUst.Height = 60;
            this.pnlKatalogUst.Controls.Add(this.lblFiltre);
            this.pnlKatalogUst.Controls.Add(this.cmbKategoriFiltre);
            this.lblFiltre.Text = "Kategori Filtrele:";
            this.lblFiltre.Location = new System.Drawing.Point(30, 20);
            this.cmbKategoriFiltre.Location = new System.Drawing.Point(150, 17);
            this.cmbKategoriFiltre.Size = new System.Drawing.Size(200, 26);
            this.cmbKategoriFiltre.Properties.Items.Clear();
            this.cmbKategoriFiltre.Properties.Items.AddRange(new object[] { "Tümü", "Bot", "Spor", "Klasik" });
            this.cmbKategoriFiltre.SelectedIndex = 0;
            this.cmbKategoriFiltre.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbKategoriFiltre.Properties.DropDownRows = 6;
            this.cmbKategoriFiltre.Click += new System.EventHandler(this.cmbKategoriFiltre_Click);

            this.pnlKatalogSag.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlKatalogSag.Width = 320;
            this.pnlKatalogSag.Controls.Add(this.pnlSagDetay);
            this.pnlSagDetay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSagDetay.Padding = new System.Windows.Forms.Padding(20);

            this.lblUrunBaslik.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblUrunBaslik.Height = 50;
            this.lblUrunBaslik.Text = "SEÇİLİ ÜRÜN";
            this.lblUrunBaslik.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblUrunBaslik.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblUrunBaslik.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;

            this.peSeciliResim.Dock = System.Windows.Forms.DockStyle.Top;
            this.peSeciliResim.Height = 220;
            this.peSeciliResim.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;

            this.cmbVaryant.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmbVaryant.Height = 40;
            this.cmbVaryant.Properties.NullValuePrompt = "Renk Seçiniz...";
            this.cmbVaryant.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;

            this.txtAdet.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtAdet.Height = 40;
            this.txtAdet.Properties.NullValuePrompt = "Takım Sayısı";
            this.txtAdet.Properties.IsFloatValue = false;
            this.txtAdet.Properties.MaskSettings.Set("mask", "d");
            this.txtAdet.Properties.Buttons.Clear();

            this.lblToplamFiyat.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblToplamFiyat.Height = 50;
            this.lblToplamFiyat.Text = "0.00 TL";
            this.lblToplamFiyat.Appearance.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblToplamFiyat.Appearance.ForeColor = System.Drawing.Color.Green;
            this.lblToplamFiyat.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblToplamFiyat.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;

            this.btnSepeteEkle.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSepeteEkle.Height = 55;
            this.btnSepeteEkle.Text = "SEPETE EKLE";
            this.btnSepeteEkle.Appearance.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.btnSepeteEkle.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnSepeteEkle.Appearance.ForeColor = System.Drawing.Color.White;

            this.pnlSagDetay.Controls.Add(this.lblUrunBaslik);
            this.pnlSagDetay.Controls.Add(this.peSeciliResim);
            this.pnlSagDetay.Controls.Add(this.cmbVaryant);
            this.pnlSagDetay.Controls.Add(this.txtAdet);
            this.pnlSagDetay.Controls.Add(this.lblToplamFiyat);
            this.pnlSagDetay.Controls.Add(this.btnSepeteEkle);

            this.gcUrunVitrin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcUrunVitrin.MainView = this.tvUrunVitrin;
            this.gcUrunVitrin.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.tvUrunVitrin });

            this.tvUrunVitrin.GridControl = this.gcUrunVitrin;
            this.tvUrunVitrin.OptionsTiles.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.tvUrunVitrin.OptionsTiles.ColumnCount = 0;
            this.tvUrunVitrin.OptionsTiles.RowCount = 0;
            this.tvUrunVitrin.OptionsTiles.ItemSize = new System.Drawing.Size(240, 320);

            // Yan yana dizilip sığmadığında alt satıra geçmesi için:
            this.tvUrunVitrin.OptionsTiles.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tvUrunVitrin.OptionsTiles.RowCount = 0; // Otomatik satır sayısı
            this.tvUrunVitrin.OptionsTiles.ColumnCount = 0;
            this.tvUrunVitrin.OptionsTiles.ItemSize = new System.Drawing.Size(240, 320);
            this.tvUrunVitrin.OptionsTiles.Padding = new System.Windows.Forms.Padding(12);
            this.tvUrunVitrin.OptionsTiles.ItemPadding = new System.Windows.Forms.Padding(10);
            // Smooth scroll opsiyonel
            this.tvUrunVitrin.OptionsBehavior.AllowSmoothScrolling = true;
            // Görselin Tile içinde düzgün gözükmesi için KapakResmi column'u picture edit ile bağla
            this.colKapakResmi.FieldName = "KapakResmi";
            this.colKapakResmi.ColumnEdit = this.repoResim; // <- önemli
            this.colKapakResmi.Visible = true;

            // Diğer sütunlar
            this.colModelAd.FieldName = "ModelAd";
            this.colModelAd.Visible = true;

            this.colAnaHammadde.FieldName = "AnaHammadde";
            this.colAnaHammadde.Visible = true;

            this.colFiyat.FieldName = "Fiyat";
            this.colFiyat.Visible = true;

            this.colId.FieldName = "Id";
            this.colId.Visible = false;

            this.tvUrunVitrin.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { this.colKapakResmi, this.colModelAd, this.colAnaHammadde, this.colFiyat, this.colId });

            // Tile template elements (model adı altında hammaddesi gösterilir)
            tileViewItemElement1.Column = this.colKapakResmi;
            tileViewItemElement1.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopCenter;
            tileViewItemElement1.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            tileViewItemElement1.ImageOptions.ImageSize = new System.Drawing.Size(180, 180);
            tileViewItemElement1.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.Manual;
            tileViewItemElement1.TextLocation = new System.Drawing.Point(0, 0);

            tileViewItemElement2.Column = this.colModelAd;
            tileViewItemElement2.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement2.TextLocation = new System.Drawing.Point(0, 185);
            tileViewItemElement2.Appearance.Normal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            tileViewItemElement2.Appearance.Normal.ForeColor = System.Drawing.Color.DarkSlateGray;
            tileViewItemElement2.Text = "{0}";

            tileViewItemElement4.Column = this.colAnaHammadde;
            tileViewItemElement4.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement4.TextLocation = new System.Drawing.Point(0, 208);
            tileViewItemElement4.Appearance.Normal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            tileViewItemElement4.Appearance.Normal.ForeColor = System.Drawing.Color.Gray;
            tileViewItemElement4.Text = "{0}";

            tileViewItemElement3.Column = this.colFiyat;
            tileViewItemElement3.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomCenter;
            tileViewItemElement3.Appearance.Normal.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            tileViewItemElement3.Appearance.Normal.ForeColor = System.Drawing.Color.FromArgb(242, 122, 26);
            tileViewItemElement3.Text = "{0:C}";

            this.tvUrunVitrin.TileTemplate.Clear();
            this.tvUrunVitrin.TileTemplate.Add(tileViewItemElement1);
            this.tvUrunVitrin.TileTemplate.Add(tileViewItemElement2);
            this.tvUrunVitrin.TileTemplate.Add(tileViewItemElement4);
            this.tvUrunVitrin.TileTemplate.Add(tileViewItemElement3);

            this.pageKatalog.Controls.Add(this.gcUrunVitrin);
            this.pageKatalog.Controls.Add(this.pnlKatalogSag);
            this.pageKatalog.Controls.Add(this.pnlKatalogUst);

            // =================================================================================
            // SAYFA 2: SEPET (UYARI: aynı kalabilir)
            // =================================================================================
            this.pageSepet.Controls.Add(this.gcSepet);
            this.pageSepet.Controls.Add(this.pnlSepetAlt);

            this.gcSepet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcSepet.MainView = this.gvSepet;
            this.gcSepet.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
                this.repoResim,
                this.repoBilgi,
                this.repoAdet,
                this.repoSil
            });
            this.gcSepet.BackColor = System.Drawing.Color.FromArgb(250, 250, 250);

            // Grid Genel
            this.gvSepet.GridControl = this.gcSepet;
            this.gvSepet.OptionsView.ShowColumnHeaders = false;
            this.gvSepet.OptionsView.ShowGroupPanel = false;
            this.gvSepet.OptionsView.ShowIndicator = false;
            this.gvSepet.OptionsView.RowAutoHeight = false; // Yükseklik sabit kalsın
            this.gvSepet.RowHeight = 130;
            this.gvSepet.OptionsView.ColumnAutoWidth = true; // Sütunlar ekrana yayılsın

            this.gvSepet.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.gvSepet.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.True;
            this.gvSepet.Appearance.Row.BackColor = System.Drawing.Color.White;
            this.gvSepet.Appearance.HorzLine.BackColor = System.Drawing.Color.LightGray;
            this.gvSepet.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvSepet.OptionsSelection.EnableAppearanceFocusedRow = false;

            // SÜTUN 1: RESİM (UÇURUMU ENGELLEMEK İÇİN FIXED WIDTH)
            this.colSepetResim.FieldName = "UrunResmi";
            this.colSepetResim.Visible = true;
            this.colSepetResim.VisibleIndex = 0;
            this.colSepetResim.Width = 120; // Sabit Genişlik
            this.colSepetResim.OptionsColumn.FixedWidth = true; // KİLİT NOKTA
            this.colSepetResim.ColumnEdit = this.repoResim;
            this.colSepetResim.OptionsColumn.AllowEdit = false;
            this.colSepetResim.OptionsColumn.AllowFocus = false;

            this.repoResim.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.repoResim.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.repoResim.ShowMenu = false;
            this.repoResim.ReadOnly = true;

            // SÜTUN 2: BİLGİ (Kalan tüm alanı bu kaplasın)
            this.colSepetBilgi.FieldName = "TamBilgi";
            this.colSepetBilgi.Visible = true;
            this.colSepetBilgi.VisibleIndex = 1;
            this.colSepetBilgi.ColumnEdit = this.repoBilgi;
            this.colSepetBilgi.OptionsColumn.AllowEdit = false;
            this.colSepetBilgi.OptionsColumn.AllowFocus = false;
            // Dikey Ortalama
            this.colSepetBilgi.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;

            this.repoBilgi.ReadOnly = true;
            this.repoBilgi.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.repoBilgi.Appearance.Options.UseFont = true;
            this.repoBilgi.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.repoBilgi.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;

            // SÜTUN 3: ADET (DÜZELTİLDİ: [-] Sayı [+] Formatı)
            this.colSepetAdet.FieldName = "TakimSayisi";
            this.colSepetAdet.Visible = true;
            this.colSepetAdet.VisibleIndex = 2;
            this.colSepetAdet.Width = 140;
            this.colSepetAdet.OptionsColumn.FixedWidth = true;
            this.colSepetAdet.ColumnEdit = this.repoAdet;
            // Tıklama için AllowEdit ve AllowFocus TRUE olmalı.
            this.colSepetAdet.OptionsColumn.AllowEdit = true;
            this.colSepetAdet.OptionsColumn.AllowFocus = true;
            this.colSepetAdet.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;

            this.repoAdet.AutoHeight = false;
            this.repoAdet.Buttons.Clear();

            // 1. EKSİ BUTONU (SOLA YAPIŞIK)
            DevExpress.XtraEditors.Controls.EditorButton btnEksi = new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph);
            btnEksi.Caption = " - ";
            btnEksi.Tag = "minus";
            btnEksi.IsLeft = true; // <-- BU KOMUT SOLA ALIR
            btnEksi.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            btnEksi.Appearance.ForeColor = System.Drawing.Color.Red;

            // 2. ARTI BUTONU (SAĞA YAPIŞIK)
            DevExpress.XtraEditors.Controls.EditorButton btnArti = new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph);
            btnArti.Caption = " + ";
            btnArti.Tag = "plus";
            btnArti.IsLeft = false; // <-- BU KOMUT SAĞA ALIR
            btnArti.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            btnArti.Appearance.ForeColor = System.Drawing.Color.Green;

            this.repoAdet.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { btnEksi, btnArti });

            // METİN AYARLARI (Klavye girişi kapalı, sadece görsel sayı)
            this.repoAdet.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.repoAdet.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.repoAdet.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.repoAdet.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;

            // ButtonClick Event'ini buraya bağlıyoruz!
            this.repoAdet.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.repoAdet_ButtonClick);
            // SÜTUN 4: TUTAR (Genişlik arttırıldı, kesilme engellendi)
            this.colSepetTutar.FieldName = "ToplamTutar";
            this.colSepetTutar.Visible = true;
            this.colSepetTutar.VisibleIndex = 3;
            this.colSepetTutar.Width = 160; // Genişletildi
            this.colSepetTutar.OptionsColumn.FixedWidth = true;
            this.colSepetTutar.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSepetTutar.DisplayFormat.FormatString = "c2";
            this.colSepetTutar.AppearanceCell.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.colSepetTutar.AppearanceCell.ForeColor = System.Drawing.Color.FromArgb(242, 122, 26);
            this.colSepetTutar.AppearanceCell.Options.UseFont = true;
            this.colSepetTutar.AppearanceCell.Options.UseForeColor = true;
            this.colSepetTutar.OptionsColumn.AllowEdit = false;
            this.colSepetTutar.OptionsColumn.AllowFocus = false;
            this.colSepetTutar.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;

            // SÜTUN 5: SİL
            this.colSepetSil.Visible = true;
            this.colSepetSil.VisibleIndex = 4;
            this.colSepetSil.Width = 60;
            this.colSepetSil.OptionsColumn.FixedWidth = true;
            this.colSepetSil.ColumnEdit = this.repoSil;
            this.colSepetSil.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;

            this.repoSil.AutoHeight = false;
            this.repoSil.Buttons.Clear();
            this.repoSil.Buttons.Add(new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete));
            this.repoSil.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;

            this.gvSepet.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colSepetResim, this.colSepetBilgi, this.colSepetAdet, this.colSepetTutar, this.colSepetSil
            });

            // Sepet Alt Panel
            this.pnlSepetAlt.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlSepetAlt.Height = 70;
            this.pnlSepetAlt.Controls.Add(this.lblSepetToplam);
            this.pnlSepetAlt.Controls.Add(this.btnSepetiTemizle);
            this.pnlSepetAlt.Controls.Add(this.btnSepetiOnayla);

            this.lblSepetToplam.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblSepetToplam.Text = "  Toplam: 0.00 TL";
            this.lblSepetToplam.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblSepetToplam.Appearance.ForeColor = System.Drawing.Color.FromArgb(242, 122, 26);

            this.btnSepetiOnayla.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSepetiOnayla.Text = "SEPETİ ONAYLA";
            this.btnSepetiOnayla.Width = 160;
            this.btnSepetiOnayla.Appearance.BackColor = System.Drawing.Color.FromArgb(242, 122, 26);
            this.btnSepetiOnayla.Appearance.ForeColor = System.Drawing.Color.White;

            this.btnSepetiTemizle.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSepetiTemizle.Text = "TEMİZLE";
            this.btnSepetiTemizle.Width = 120;
            this.btnSepetiTemizle.Appearance.BackColor = System.Drawing.Color.Firebrick;
            this.btnSepetiTemizle.Appearance.ForeColor = System.Drawing.Color.White;

            // TAKİP
            this.pageTakip.Controls.Add(this.gcSiparisTakip);
            this.gcSiparisTakip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcSiparisTakip.MainView = this.gvSiparisTakip;

            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.navFrameMusteri);
            this.Controls.Add(this.accordionControl1);
            this.Controls.Add(this.pnlHeader);
            this.Name = "FrmMusteri";
            this.Text = "Müşteri Paneli";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

            ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.navFrameMusteri)).EndInit();
            this.navFrameMusteri.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoResim)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoBilgi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoAdet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoSil)).EndInit();
            this.pageKatalog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlKatalogUst)).EndInit();
            this.pnlKatalogUst.ResumeLayout(false);
            this.pnlKatalogUst.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKategoriFiltre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlKatalogSag)).EndInit();
            this.pnlKatalogSag.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlSagDetay)).EndInit();
            this.pnlSagDetay.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.peSeciliResim.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbVaryant.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAdet.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcUrunVitrin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tvUrunVitrin)).EndInit();
            this.pageSepet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcSepet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSepet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSepetAlt)).EndInit();
            this.pnlSepetAlt.ResumeLayout(false);
            this.pageTakip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcSiparisTakip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSiparisTakip)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        // DEĞİŞKENLER (AnaHammadde eklendi)
        private DevExpress.XtraEditors.PanelControl pnlHeader;
        private DevExpress.XtraEditors.LabelControl lblHeader;
        private DevExpress.XtraBars.Navigation.AccordionControl accordionControl1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement elmKatalog;
        private DevExpress.XtraBars.Navigation.AccordionControlElement elmSepet;
        private DevExpress.XtraBars.Navigation.AccordionControlElement elmTakip;
        private DevExpress.XtraBars.Navigation.NavigationFrame navFrameMusteri;
        private DevExpress.XtraBars.Navigation.NavigationPage pageKatalog;
        private DevExpress.XtraBars.Navigation.NavigationPage pageSepet;
        private DevExpress.XtraBars.Navigation.NavigationPage pageTakip;

        // KATALOG
        private DevExpress.XtraEditors.PanelControl pnlKatalogUst;
        private DevExpress.XtraEditors.ComboBoxEdit cmbKategoriFiltre;
        private DevExpress.XtraEditors.LabelControl lblFiltre;
        private DevExpress.XtraEditors.PanelControl pnlKatalogSag;
        private DevExpress.XtraEditors.PanelControl pnlSagDetay;
        private DevExpress.XtraGrid.GridControl gcUrunVitrin;
        private DevExpress.XtraGrid.Views.Tile.TileView tvUrunVitrin;
        private DevExpress.XtraGrid.Columns.TileViewColumn colKapakResmi;
        private DevExpress.XtraGrid.Columns.TileViewColumn colModelAd;
        private DevExpress.XtraGrid.Columns.TileViewColumn colAnaHammadde; // eklendi
        private DevExpress.XtraGrid.Columns.TileViewColumn colFiyat;
        private DevExpress.XtraGrid.Columns.TileViewColumn colId;
        private DevExpress.XtraEditors.LabelControl lblUrunBaslik;
        private DevExpress.XtraEditors.PictureEdit peSeciliResim;
        private DevExpress.XtraEditors.ComboBoxEdit cmbVaryant;
        private DevExpress.XtraEditors.SpinEdit txtAdet;
        private DevExpress.XtraEditors.LabelControl lblToplamFiyat;
        private DevExpress.XtraEditors.SimpleButton btnSepeteEkle;

        // SEPET (ÖZELLEŞTİRİLMİŞ)
        private DevExpress.XtraGrid.GridControl gcSepet;
        private DevExpress.XtraGrid.Views.Grid.GridView gvSepet;
        private DevExpress.XtraGrid.Columns.GridColumn colSepetResim;
        private DevExpress.XtraGrid.Columns.GridColumn colSepetBilgi;
        private DevExpress.XtraGrid.Columns.GridColumn colSepetAdet;
        private DevExpress.XtraGrid.Columns.GridColumn colSepetTutar;
        private DevExpress.XtraGrid.Columns.GridColumn colSepetSil;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repoResim;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repoBilgi;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repoAdet;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repoSil;

        private DevExpress.XtraEditors.PanelControl pnlSepetAlt;
        private DevExpress.XtraEditors.LabelControl lblSepetToplam;
        private DevExpress.XtraEditors.SimpleButton btnSepetiOnayla;
        private DevExpress.XtraEditors.SimpleButton btnSepetiTemizle;
        private DevExpress.XtraGrid.GridControl gcSiparisTakip;
        private DevExpress.XtraGrid.Views.Grid.GridView gvSiparisTakip;
    }
}