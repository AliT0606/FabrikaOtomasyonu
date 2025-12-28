using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Tile;

namespace Fabrika_Otomasyonu
{
    public partial class FrmMusteri : DevExpress.XtraEditors.XtraForm
    {
        // YÖNETİM SINIFLARI
        VitrinYonetimi vitrinYonetim = new VitrinYonetimi();
        SiparisYonetimi siparisYonetimi = new SiparisYonetimi();
        string aktifMusteriAd = "";
        string aktifMusteriTel = "";
        string aktifMusteriAdres = "";
        MusteriYonetimi musteriYonetimi = new MusteriYonetimi();
        BildirimYonetimi bildirimYonetim = new BildirimYonetimi();

        // SEPET LİSTESİ
        BindingList<SepetOgesi> sepetListesi = new BindingList<SepetOgesi>();

        // DEĞİŞKENLER
        int seciliUrunId = 0;
        string seciliModelAd = "";
        decimal seciliTakimFiyati = 0;

        // HAFIZA
        Dictionary<string, byte[]> varyantHafiza = new Dictionary<string, byte[]>();


        // Adres Kutusu Tanımlaması
        DevExpress.XtraEditors.MemoEdit memoAdres;

        public FrmMusteri()
        {
            InitializeComponent();
            BaslangicAyarlari();
            OlaylariBagla();
            this.FormClosed += (s, e) => Application.Exit();
        }

        private void BaslangicAyarlari()
        {
            ConfigureTileView();

            // 1. Verileri Yükle
            gcUrunVitrin.DataSource = vitrinYonetim.VitrinListesiGetir();
            gcSiparisTakip.DataSource = siparisYonetimi.MusteriSiparisleriniGetir(aktifMusteriTel);
            // Sepet grid'i bağla
            gcSepet.DataSource = sepetListesi;
            

            // 2. Sağ Paneli Temizle
            TemizleSagPanel();
            SepetiGuncelle();

            // --- YENİ EKLENDİ: Başlangıçta Header İsmi Doğru Gelsin ---
            lblHeader.Text = elmKatalog.Text;
            AdresKutusunuOlustur();


            SepetSayfasiDuzenle();
            BildirimKontrol();
        }

        private void ConfigureTileView()
        {
            tvUrunVitrin.BeginUpdate();
            try
            {
                if (!gcUrunVitrin.RepositoryItems.Contains(repoResim))
                    gcUrunVitrin.RepositoryItems.Add(repoResim);

                colKapakResmi.ColumnEdit = repoResim;

                // LAYOUT AYARLARI
                tvUrunVitrin.OptionsTiles.Orientation = System.Windows.Forms.Orientation.Vertical;
                tvUrunVitrin.OptionsTiles.ColumnCount = 0;
                tvUrunVitrin.OptionsTiles.RowCount = 0;
                tvUrunVitrin.OptionsTiles.ItemSize = new System.Drawing.Size(240, 340);
                tvUrunVitrin.OptionsTiles.Padding = new System.Windows.Forms.Padding(12);
                tvUrunVitrin.OptionsTiles.ItemPadding = new System.Windows.Forms.Padding(8);
                tvUrunVitrin.OptionsBehavior.AllowSmoothScrolling = true;

                // TASARIM
                tvUrunVitrin.TileTemplate.Clear();

                // A) RESİM
                var imgElem = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
                imgElem.Column = colKapakResmi;
                imgElem.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopCenter;
                imgElem.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
                imgElem.ImageOptions.ImageSize = new System.Drawing.Size(200, 180);
                imgElem.Text = "";
                tvUrunVitrin.TileTemplate.Add(imgElem);

                // B) MODEL ADI
                var modelElem = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
                modelElem.Column = colModelAd;
                modelElem.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopCenter;
                modelElem.TextLocation = new System.Drawing.Point(0, 185);
                modelElem.Appearance.Normal.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
                modelElem.Appearance.Normal.ForeColor = System.Drawing.Color.Black;
                tvUrunVitrin.TileTemplate.Add(modelElem);

                // C) HAMMADDE
                var matElem = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
                matElem.Column = colAnaHammadde;
                matElem.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopCenter;
                matElem.TextLocation = new System.Drawing.Point(0, 210);
                matElem.Appearance.Normal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
                matElem.Appearance.Normal.ForeColor = System.Drawing.Color.Gray;
                matElem.Text = "Malzeme: {0}";
                tvUrunVitrin.TileTemplate.Add(matElem);

                // D) FİYAT
                var priceElem = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
                priceElem.Column = colFiyat;
                priceElem.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomCenter;
                priceElem.Appearance.Normal.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
                priceElem.Appearance.Normal.ForeColor = System.Drawing.Color.FromArgb(242, 122, 26);
                priceElem.Text = "{0:C2}";
                tvUrunVitrin.TileTemplate.Add(priceElem);
            }
            finally
            {
                tvUrunVitrin.EndUpdate();
            }
        }

        private void OlaylariBagla()
        {
            // --- 1. MENÜ GEÇİŞLERİ ---
            accordionControl1.ElementClick += (s, e) =>
            {
                // --- YENİ EKLENDİ: Başlığı Güncelle ---
                // Tıklanan menü elemanının ismini alıp yukarıya yazıyoruz.
                lblHeader.Text = e.Element.Text;

                if (e.Element == elmKatalog)
                {
                    navFrameMusteri.SelectedPage = pageKatalog;
                }
                else if (e.Element == elmSepet)
                {
                    navFrameMusteri.SelectedPage = pageSepet;
                    SepetiGuncelle();
                }
                else if (e.Element == elmTakip)
                {
                    navFrameMusteri.SelectedPage = pageTakip;
                    gcSiparisTakip.DataSource = siparisYonetimi.SiparisleriGetir();
                }
            };

            // --- 2. FİLTRELEME ---
            cmbKategoriFiltre.SelectedIndexChanged += (s, e) =>
            {
                string secilenKategori = cmbKategoriFiltre.Text;
                gcUrunVitrin.DataSource = vitrinYonetim.KategoriyeGoreGetir(secilenKategori);
            };

            // --- 3. VİTRİNDEN ÜRÜN SEÇME ---
            tvUrunVitrin.ItemClick += (s, e) =>
            {
                TileView view = s as TileView;
                var row = view.GetRow(e.Item.RowHandle) as DataRowView;

                if (row != null)
                {
                    seciliUrunId = Convert.ToInt32(row["Id"]);
                    seciliModelAd = row["ModelAd"].ToString();
                    decimal birimFiyat = row["Fiyat"] != DBNull.Value ? Convert.ToDecimal(row["Fiyat"]) : 0;
                    seciliTakimFiyati = birimFiyat * 8;

                    lblUrunBaslik.Text = seciliModelAd;
                    txtAdet.Value = 1;
                    FiyatHesapla();

                    VaryantlariDoldur(seciliUrunId);
                }
            };

            // --- 4. RENK DEĞİŞİMİ ---
            cmbVaryant.SelectedIndexChanged += (s, e) =>
            {
                string secilenRenk = cmbVaryant.Text;
                if (varyantHafiza.ContainsKey(secilenRenk))
                {
                    Image yeniResim = ByteToImage(varyantHafiza[secilenRenk]);
                    ResmiKutuyaKoy(yeniResim);
                }
                else
                {
                    ResmiKutuyaKoy(null);
                }
            };

            // --- 5. ADET VE SEPET ---
            txtAdet.EditValueChanged += (s, e) => FiyatHesapla();

            btnSepeteEkle.Click += (s, e) =>
            {
                if (seciliUrunId == 0 || cmbVaryant.SelectedIndex == -1)
                {
                    XtraMessageBox.Show("Lütfen ürün ve renk seçiniz!", "Uyarı");
                    return;
                }

                // Grid'den o anki ürünün hammadde bilgisini çekiyoruz (Null kontrolü ile)
                var row = tvUrunVitrin.GetRow(tvUrunVitrin.FocusedRowHandle) as DataRowView;
                string hammadde = row != null ? row["AnaHammadde"].ToString() : "Standart";

                // Resmin kopyasını (Clone) alıyoruz ki ekrandan silinince sepetten gitmesin
                Image sepetResmi = null;
                if (peSeciliResim.Image != null) sepetResmi = new Bitmap(peSeciliResim.Image);

                SepetOgesi yeniOge = new SepetOgesi
                {
                    UrunId = seciliUrunId,
                    ModelAd = seciliModelAd,
                    AnaHammadde = hammadde, // <-- Artık grid'den aldığımız veriyi koyuyoruz
                    Renk = cmbVaryant.Text,
                    TakimSayisi = Convert.ToInt32(txtAdet.Value),
                    BirimFiyat = seciliTakimFiyati,
                    ToplamTutar = seciliTakimFiyati * Convert.ToInt32(txtAdet.Value),
                    UrunResmi = sepetResmi
                };

                sepetListesi.Add(yeniOge);
                XtraMessageBox.Show("Sepete eklendi!", "Başarılı");
                SepetiGuncelle();
            };

            // --- DİĞER BUTONLAR ---
            btnSepetiTemizle.Click += (s, e) => { sepetListesi.Clear(); SepetiGuncelle(); };

            btnSepetiOnayla.Click += (s, e) =>
            {
                if (sepetListesi.Count == 0) return;

                if (string.IsNullOrEmpty(memoAdres.Text) || memoAdres.Text.Length < 5)
                {
                    XtraMessageBox.Show("Lütfen teslimat adresinizi giriniz!", "Eksik Bilgi");
                    return;
                }

                if (XtraMessageBox.Show("Siparişi onaylıyor musunuz?", "Onay", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    musteriYonetimi.MusteriKaydetVeyaGuncelle(aktifMusteriAd, aktifMusteriTel, memoAdres.Text);
                    aktifMusteriAdres = memoAdres.Text;

                    // --- ÖNEMLİ: TEK BİR SİPARİŞ KODU OLUŞTURUYORUZ ---
                    // Örn: "SIP-A1B2" gibi rastgele bir kod
                    string grupKodu = "SIP-" + Guid.NewGuid().ToString().Substring(0, 4).ToUpper();

                    foreach (var item in sepetListesi)
                    {
                        string tamAd = $"{item.ModelAd} ({item.Renk}) - [TAKIM]";

                        // Hepsine aynı 'grupKodu'nu gönderiyoruz
                        siparisYonetimi.SiparisOlustur(
                            aktifMusteriAd,
                            aktifMusteriTel,
                            tamAd,
                            item.TakimSayisi,
                            item.BirimFiyat,
                            memoAdres.Text,
                            grupKodu // <-- ORTAK KOD
                        );
                    }

                    // Sipariş oluştu, şimdi tarihleri GRUP BAZLI hesapla
                    siparisYonetimi.TumTarihleriGuncelle();

                    sepetListesi.Clear();
                    SepetiGuncelle();
                    memoAdres.Text = "";
                    XtraMessageBox.Show("Siparişiniz tek paket olarak alındı!", "Teşekkürler");

                    navFrameMusteri.SelectedPage = pageTakip;
                    if (!string.IsNullOrEmpty(aktifMusteriTel))
                        gcSiparisTakip.DataSource = siparisYonetimi.MusteriSiparisleriniGetir(aktifMusteriTel);
                }
            };

            repoSil.ButtonClick += (s, e) =>
            {
                var row = gvSepet.GetFocusedRow() as SepetOgesi;
                if (row != null) { sepetListesi.Remove(row); SepetiGuncelle(); }
            };
        }

        // --- YARDIMCI METODLAR ---

        private void ResmiKutuyaKoy(Image yeniResim)
        {
            if (peSeciliResim.Image != null)
            {
                peSeciliResim.Image.Dispose();
            }
            peSeciliResim.Image = yeniResim;
        }

        private void VaryantlariDoldur(int id)
        {
            cmbVaryant.Properties.Items.BeginUpdate();
            cmbVaryant.Properties.Items.Clear();
            ResmiKutuyaKoy(null);
            varyantHafiza.Clear();

            DataTable dt = vitrinYonetim.UrunDetaylariniGetir(id);
            foreach (DataRow row in dt.Rows)
            {
                string renk = row["Renk"].ToString();
                byte[] resim = row["Resim"] != DBNull.Value ? (byte[])row["Resim"] : null;

                cmbVaryant.Properties.Items.Add(renk);
                if (resim != null) varyantHafiza.Add(renk, resim);
            }
            cmbVaryant.Properties.Items.EndUpdate();

            if (cmbVaryant.Properties.Items.Count > 0)
            {
                cmbVaryant.SelectedIndex = 0;
                string ilkRenk = cmbVaryant.Properties.Items[0].ToString();
                if (varyantHafiza.ContainsKey(ilkRenk))
                {
                    ResmiKutuyaKoy(ByteToImage(varyantHafiza[ilkRenk]));
                }
            }
        }

        private void FiyatHesapla()
        {
            lblToplamFiyat.Text = seciliTakimFiyati > 0
                ? (seciliTakimFiyati * txtAdet.Value).ToString("C2")
                : "0.00 TL";
        }

        private void SepetiGuncelle()
        {
            try { gcSepet.RefreshDataSource(); } catch { gvSepet.RefreshData(); }
            try { gvSepet.BestFitColumns(); } catch { }
            lblSepetToplam.Text = $"  Toplam: {sepetListesi.Sum(x => x.ToplamTutar):C2}";
        }

        private void TemizleSagPanel()
        {
            seciliUrunId = 0;
            lblUrunBaslik.Text = "Ürün Seçiniz";
            ResmiKutuyaKoy(null);
            cmbVaryant.Properties.Items.Clear();
            cmbVaryant.Text = "";
            txtAdet.Value = 1;
            lblToplamFiyat.Text = "0.00 TL";
        }

        private Image ByteToImage(byte[] data)
        {
            if (data == null || data.Length < 100) return null;
            try
            {
                MemoryStream ms = new MemoryStream(data);
                return Image.FromStream(ms);
            }
            catch
            {
                return null;
            }
        }

        private void repoAdet_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var row = gvSepet.GetFocusedRow() as SepetOgesi;
            if (row == null) return;

            string islem = (e.Button.Tag ?? "").ToString().ToLowerInvariant();

            if (islem == "plus")
            {
                row.TakimSayisi++;
                row.ToplamTutar = row.TakimSayisi * row.BirimFiyat;
            }
            else if (islem == "minus")
            {
                if (row.TakimSayisi > 1)
                {
                    row.TakimSayisi--;
                    row.ToplamTutar = row.TakimSayisi * row.BirimFiyat;
                }
                else
                {
                    if (MessageBox.Show("Ürünü sepetten çıkarmak istiyor musunuz?", "Sil", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        sepetListesi.Remove(row);
                    }
                }
            }
            SepetiGuncelle();
        }

        private void cmbKategoriFiltre_Click(object sender, EventArgs e)
        {
            try { if (cmbKategoriFiltre != null) cmbKategoriFiltre.ShowPopup(); } catch { }
        }
        public FrmMusteri(string ad, string tel ,string adres)
        {
            InitializeComponent();

            // Gelen bilgileri hafızaya al
            aktifMusteriAd = ad;
            aktifMusteriTel = tel;
            aktifMusteriAdres = adres;  

            BaslangicAyarlari();
            OlaylariBagla();
        }
        private void AdresKutusunuOlustur()
        {
            // 1. Etiket
            LabelControl lblAdresBaslik = new LabelControl();
            lblAdresBaslik.Text = "Teslimat Adresi:";
            lblAdresBaslik.Location = new Point(20, gcSepet.Bottom + 20); // Gridin altına koy
            lblAdresBaslik.Appearance.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            pageSepet.Controls.Add(lblAdresBaslik);

            // 2. Adres Kutusu (MemoEdit)
            memoAdres = new MemoEdit();
            memoAdres.Location = new Point(20, gcSepet.Bottom + 45);
            memoAdres.Size = new Size(400, 80);
            memoAdres.Properties.NullValuePrompt = "Lütfen açık adresinizi buraya giriniz...";
            pageSepet.Controls.Add(memoAdres);
        }
        private void SepetSayfasiDuzenle()
        {
            // 1. Alt Panel Oluştur (Adres ve Butonlar için)
            PanelControl pnlAlt = new PanelControl();
            pnlAlt.Dock = DockStyle.Bottom; // Sayfanın en altına yapış
            pnlAlt.Height = 130;            // Yüksekliği ayarla
            pnlAlt.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pageSepet.Controls.Add(pnlAlt);

            // Paneli öne getir ki Grid arkada kalsın
            pnlAlt.BringToFront();

            // 2. Mevcut Butonları ve Toplam Yazısını Bu Panele Taşı
            // (Böylece butonlar kaybolmaz, panelin içinde durur)
            btnSepetiOnayla.Parent = pnlAlt;
            btnSepetiTemizle.Parent = pnlAlt;
            lblSepetToplam.Parent = pnlAlt;

            // Butonların Yerlerini Ayarla (Sağ Alt Köşe)
            btnSepetiOnayla.Location = new Point(pnlAlt.Width - 220, 70);
            btnSepetiOnayla.Anchor = AnchorStyles.Bottom | AnchorStyles.Right; // Ekran büyürse sağda kalsın

            btnSepetiTemizle.Location = new Point(pnlAlt.Width - 220, 20);
            btnSepetiTemizle.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            lblSepetToplam.Location = new Point(pnlAlt.Width - 400, 80);
            lblSepetToplam.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            // 3. Adres Kutusunu Ekle
            LabelControl lblAdres = new LabelControl();
            lblAdres.Text = "Teslimat Adresi ve Notlar:";
            lblAdres.Location = new Point(10, 10);
            lblAdres.Appearance.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            pnlAlt.Controls.Add(lblAdres);

            memoAdres = new MemoEdit();
            memoAdres.Parent = pnlAlt; // Panele ekle
            memoAdres.Location = new Point(10, 30);
            memoAdres.Size = new Size(400, 80); // Genişlik ve Yükseklik
            memoAdres.Properties.NullValuePrompt = "Açık adresinizi ve kargo notunuzu buraya giriniz...";

            if (!string.IsNullOrEmpty(aktifMusteriAdres))
            {
                memoAdres.Text = aktifMusteriAdres;
            }
            // 4. Grid'i Kalan Boşluğa Yay (Fill)
            gcSepet.Dock = DockStyle.Fill;
            gcSepet.BringToFront(); // Grid öne gelsin ama Dock olduğu için paneli ezmez, üstüne oturur.
        }
        private void BildirimKontrol()
        {
            // 1. Son bildirimi çek
            string[] gelenBildirim = bildirimYonetim.SonBildirimiGetir();

            if (gelenBildirim != null)
            {
                string baslik = gelenBildirim[0];
                string mesaj = gelenBildirim[1];

                // --- MANTIK KONTROLÜ (YENİ EKLENDİ) ---

                // Eğer bildirim bir "Arıza" veya "Makine" ile ilgiliyse kontrol et
                if (baslik.Contains("Arıza") || baslik.Contains("Makine") || mesaj.Contains("gecikecektir"))
                {
                    // Müşterinin mevcut siparişlerini getir
                    DataTable dtSiparisler = siparisYonetimi.MusteriSiparisleriniGetir(aktifMusteriTel);

                    bool etkilenecekSiparisVarMi = false;

                    foreach (DataRow row in dtSiparisler.Rows)
                    {
                        string durum = row["Durum"].ToString();

                        // Sadece fabrikada olan işler etkilenir
                        if (durum == "Onay Bekliyor" || durum == "Hazırlanıyor")
                        {
                            etkilenecekSiparisVarMi = true;
                            break; // Bir tane bulsak yeter, döngüden çık
                        }
                    }

                    // Eğer fabrikada işi yoksa (Siparişi yok veya hepsi Kargoda ise)
                    // Bu uyarıyı gösterme, metoddan çık.
                    if (!etkilenecekSiparisVarMi) return;
                }
                // ---------------------------------------

                // DevExpress Alert veya MessageBox ile göster
                XtraMessageBox.Show(mesaj, baslik, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}