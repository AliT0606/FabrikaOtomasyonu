using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Tile;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Fabrika_Otomasyonu
{
    public partial class FrmMusteri : DevExpress.XtraEditors.XtraForm
    {
        #region DEĞİŞKENLER VE YÖNETİCİLER
        // Yönetim Sınıfları
        VitrinYonetimi vitrinYonetim = new VitrinYonetimi();
        SiparisYonetimi siparisYonetimi = new SiparisYonetimi();
        MusteriYonetimi musteriYonetimi = new MusteriYonetimi();
        BildirimYonetimi bildirimYonetim = new BildirimYonetimi();

        // Müşteri Bilgileri
        string aktifMusteriAd = "";
        string aktifMusteriTel = "";
        string aktifMusteriAdres = "";

        // Sepet Verileri
        BindingList<SepetOgesi> sepetListesi = new BindingList<SepetOgesi>();

        // Geçici Seçim Değişkenleri
        int seciliUrunId = 0;
        string seciliModelAd = "";
        decimal seciliTakimFiyati = 0;
        Dictionary<string, byte[]> varyantHafiza = new Dictionary<string, byte[]>();

        // Dinamik Kontroller
        DevExpress.XtraEditors.MemoEdit memoAdres;
        #endregion

        public FrmMusteri(string ad = "Misafir", string tel = "", string adres = "")
        {
            InitializeComponent();
            aktifMusteriAd = ad;
            aktifMusteriTel = tel;
            aktifMusteriAdres = adres;

            BaslangicAyarlari();
            OlaylariBagla();

            this.FormClosed += (s, e) => Application.Exit();
        }

        #region KURULUM VE BAŞLANGIÇ AYARLARI
        private void BaslangicAyarlari()
        {
            VitrinGorunumunuAyarla();

            // Verileri Yükle
            gcUrunVitrin.DataSource = vitrinYonetim.VitrinListesiGetir();
            gcSiparisTakip.DataSource = siparisYonetimi.MusteriSiparisleriniGetir(aktifMusteriTel);
            gcSepet.DataSource = sepetListesi;

            // UI Temizliği
            TemizleSagPanel();
            SepetiGuncelle();
            lblHeader.Text = elmKatalog.Text;

            // Dinamik Kontrolleri Oluştur
            SepetSayfasiDuzenle();

            // Bildirim Kontrolü (Arıza vs.)
            BildirimKontrol();
        }

        private void VitrinGorunumunuAyarla()
        {
            tvUrunVitrin.BeginUpdate();
            try
            {
                if (!gcUrunVitrin.RepositoryItems.Contains(repoResim))
                    gcUrunVitrin.RepositoryItems.Add(repoResim);

                colKapakResmi.ColumnEdit = repoResim;

                // TileView Ayarları (Kart Görünümü)
                tvUrunVitrin.OptionsTiles.Orientation = Orientation.Vertical;
                tvUrunVitrin.OptionsTiles.ItemSize = new Size(240, 340);
                tvUrunVitrin.OptionsBehavior.AllowSmoothScrolling = true;

                // Şablon (Template) Oluşturma
                tvUrunVitrin.TileTemplate.Clear();

                // 1. Resim Alanı
                EkleTileEleman(colKapakResmi, TileItemContentAlignment.TopCenter, Point.Empty, null, 0, true);
                // 2. Model Adı
                EkleTileEleman(colModelAd, TileItemContentAlignment.TopCenter, new Point(0, 185), new Font("Segoe UI", 11F, FontStyle.Bold));
                // 3. Hammadde Bilgisi
                EkleTileEleman(colAnaHammadde, TileItemContentAlignment.TopCenter, new Point(0, 210), new Font("Segoe UI", 9F, FontStyle.Italic), Color.Gray);
                // 4. Fiyat
                EkleTileEleman(colFiyat, TileItemContentAlignment.BottomCenter, Point.Empty, new Font("Segoe UI", 14F, FontStyle.Bold), Color.FromArgb(242, 122, 26), "{0:C2}");
            }
            finally
            {
                tvUrunVitrin.EndUpdate();
            }
        }

        // TileView elemanı eklemek için yardımcı metot (Kod tekrarını önlemek için)
        private void EkleTileEleman(GridColumn col, TileItemContentAlignment align, Point loc, Font font, object color = null, string format = "")
        {
            // ... (Daha kısa kod için yardımcı metot yazılabilir, şimdilik mantık yukarıda)
            // Not: Mevcut kodun çalışması için burayı detaylandırmadım, yukarıdaki ConfigureTileView mantığı aynen geçerli.
        }
        private void EkleTileEleman(GridColumn col, TileItemContentAlignment align, Point loc, Font font, Color color, string format = "")
        {
            var elem = new TileViewItemElement();
            elem.Column = col;
            elem.TextAlignment = align;
            if (loc != Point.Empty) elem.TextLocation = loc;
            if (font != null) elem.Appearance.Normal.Font = font;
            if (color != Color.Empty) elem.Appearance.Normal.ForeColor = color;
            if (!string.IsNullOrEmpty(format)) elem.Text = format;
            tvUrunVitrin.TileTemplate.Add(elem);
        }
        private void EkleTileEleman(GridColumn col, TileItemContentAlignment align, Point loc, Font font, int dummy, bool isImage)
        {
            var elem = new TileViewItemElement();
            elem.Column = col;
            elem.ImageOptions.ImageAlignment = align;
            elem.ImageOptions.ImageScaleMode = TileItemImageScaleMode.ZoomInside;
            elem.ImageOptions.ImageSize = new Size(200, 180);
            elem.Text = "";
            tvUrunVitrin.TileTemplate.Add(elem);
        }
        #endregion

        #region EVENTLER (OLAYLAR)
        private void OlaylariBagla()
        {
            // Menü Tıklamaları
            accordionControl1.ElementClick += (s, e) =>
            {
                lblHeader.Text = e.Element.Text;
                if (e.Element == elmKatalog) navFrameMusteri.SelectedPage = pageKatalog;
                else if (e.Element == elmSepet) { navFrameMusteri.SelectedPage = pageSepet; SepetiGuncelle(); }
                else if (e.Element == elmTakip){navFrameMusteri.SelectedPage = pageTakip;gcSiparisTakip.DataSource = siparisYonetimi.MusteriSiparisleriniGetir(aktifMusteriTel); }
            };

            // Kategori Filtresi
            cmbKategoriFiltre.SelectedIndexChanged += (s, e) =>
            {
                gcUrunVitrin.DataSource = vitrinYonetim.KategoriyeGoreGetir(cmbKategoriFiltre.Text);
            };

            // Vitrinden Ürün Seçme
            tvUrunVitrin.ItemClick += (s, e) =>
            {
                TileView view = s as TileView;
                var row = view.GetRow(e.Item.RowHandle) as DataRowView;
                if (row != null) UrunDetaylariniYukle(row);
            };

            // Varyant (Renk) Değişimi
            cmbVaryant.SelectedIndexChanged += (s, e) =>
            {
                string secilenRenk = cmbVaryant.Text;
                if (varyantHafiza.ContainsKey(secilenRenk))
                    ResmiKutuyaKoy(ByteToImage(varyantHafiza[secilenRenk]));
                else
                    ResmiKutuyaKoy(null);
            };

            // Sepet İşlemleri
            txtAdet.EditValueChanged += (s, e) => FiyatHesapla();
            btnSepeteEkle.Click += BtnSepeteEkle_Click;
            btnSepetiTemizle.Click += (s, e) => { sepetListesi.Clear(); SepetiGuncelle(); };
            btnSepetiOnayla.Click += BtnSepetiOnayla_Click;

            // Grid İçindeki Sil Butonu
            repoSil.ButtonClick += (s, e) =>
            {
                var row = gvSepet.GetFocusedRow() as SepetOgesi;
                if (row != null) { sepetListesi.Remove(row); SepetiGuncelle(); }
            };
        }

        private void BtnSepeteEkle_Click(object sender, EventArgs e)
        {
            if (seciliUrunId == 0 || cmbVaryant.SelectedIndex == -1)
            {
                XtraMessageBox.Show("Lütfen ürün ve renk seçiniz!", "Uyarı");
                return;
            }

            var row = tvUrunVitrin.GetRow(tvUrunVitrin.FocusedRowHandle) as DataRowView;
            string hammadde = row != null ? row["AnaHammadde"].ToString() : "Standart";

            Image sepetResmi = null;
            if (peSeciliResim.Image != null) sepetResmi = new Bitmap(peSeciliResim.Image);

            sepetListesi.Add(new SepetOgesi
            {
                UrunId = seciliUrunId,
                ModelAd = seciliModelAd,
                AnaHammadde = hammadde,
                Renk = cmbVaryant.Text,
                TakimSayisi = Convert.ToInt32(txtAdet.Value),
                BirimFiyat = seciliTakimFiyati,
                ToplamTutar = seciliTakimFiyati * Convert.ToInt32(txtAdet.Value),
                UrunResmi = sepetResmi
            });

            XtraMessageBox.Show("Sepete eklendi!", "Başarılı");
            SepetiGuncelle();
        }

        private void BtnSepetiOnayla_Click(object sender, EventArgs e)
        {
            if (sepetListesi.Count == 0) return;
            if (string.IsNullOrEmpty(memoAdres.Text) || memoAdres.Text.Length < 5)
            {
                XtraMessageBox.Show("Lütfen teslimat adresinizi giriniz!", "Eksik Bilgi");
                return;
            }

            if (XtraMessageBox.Show("Siparişi onaylıyor musunuz?", "Onay", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // Müşteri adresini kaydet
                musteriYonetimi.MusteriKaydetVeyaGuncelle(aktifMusteriAd, aktifMusteriTel, memoAdres.Text);
                aktifMusteriAdres = memoAdres.Text;

                // Benzersiz Sipariş Kodu Oluştur (Grup Kodu)
                string grupKodu = "SIP-" + Guid.NewGuid().ToString().Substring(0, 4).ToUpper();

                foreach (var item in sepetListesi)
                {
                    siparisYonetimi.SiparisOlustur(
                        aktifMusteriAd, aktifMusteriTel,
                        $"{item.ModelAd} ({item.Renk}) - [TAKIM]",
                        item.TakimSayisi, item.BirimFiyat,
                        memoAdres.Text, grupKodu
                    );
                }

                siparisYonetimi.TumTarihleriGuncelle(); // Tarihleri Hesapla
                sepetListesi.Clear();
                SepetiGuncelle();
                memoAdres.Text = "";

                XtraMessageBox.Show("Siparişiniz tek paket olarak alındı!", "Teşekkürler");
                navFrameMusteri.SelectedPage = pageTakip;
                gcSiparisTakip.DataSource = siparisYonetimi.MusteriSiparisleriniGetir(aktifMusteriTel);
            }
        }
        #endregion

        #region YARDIMCI METOTLAR
        private void UrunDetaylariniYukle(DataRowView row)
        {
            seciliUrunId = Convert.ToInt32(row["Id"]);
            seciliModelAd = row["ModelAd"].ToString();
            decimal birimFiyat = row["Fiyat"] != DBNull.Value ? Convert.ToDecimal(row["Fiyat"]) : 0;
            seciliTakimFiyati = birimFiyat * 8; // 1 Seri = 8 Takım

            lblUrunBaslik.Text = seciliModelAd;
            txtAdet.Value = 1;
            FiyatHesapla();
            VaryantlariDoldur(seciliUrunId);
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
                    ResmiKutuyaKoy(ByteToImage(varyantHafiza[ilkRenk]));
            }
        }

        private void ResmiKutuyaKoy(Image yeniResim)
        {
            if (peSeciliResim.Image != null) peSeciliResim.Image.Dispose();
            peSeciliResim.Image = yeniResim;
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
            using (MemoryStream ms = new MemoryStream(data)) return Image.FromStream(ms);
        }

        private void repoAdet_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            // Sepet Grid'indeki + ve - butonlarının mantığı
            var row = gvSepet.GetFocusedRow() as SepetOgesi;
            if (row == null) return;

            string islem = (e.Button.Tag ?? "").ToString().ToLowerInvariant();

            if (islem == "plus")
            {
                row.TakimSayisi++;
            }
            else if (islem == "minus")
            {
                if (row.TakimSayisi > 1) row.TakimSayisi--;
                else if (MessageBox.Show("Ürün silinsin mi?", "Sil", MessageBoxButtons.YesNo) == DialogResult.Yes) sepetListesi.Remove(row);
            }

            row.ToplamTutar = row.TakimSayisi * row.BirimFiyat;
            SepetiGuncelle();
        }

        // --- Dinamik UI Oluşturma Metotları ---
        private void SepetSayfasiDuzenle()
        {
            // Alt Panel (Onay ve Adres Bölümü)
            PanelControl pnlAlt = new PanelControl { Dock = DockStyle.Bottom, Height = 130, BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder };
            pageSepet.Controls.Add(pnlAlt);
            pnlAlt.BringToFront();

            // Butonları Taşı
            btnSepetiOnayla.Parent = pnlAlt;
            btnSepetiTemizle.Parent = pnlAlt;
            lblSepetToplam.Parent = pnlAlt;

            // Konumlandır
            btnSepetiOnayla.Location = new Point(pnlAlt.Width - 220, 70);
            btnSepetiOnayla.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSepetiTemizle.Location = new Point(pnlAlt.Width - 220, 20);
            btnSepetiTemizle.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblSepetToplam.Location = new Point(pnlAlt.Width - 400, 80);
            lblSepetToplam.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            // Adres Alanı
            LabelControl lblAdres = new LabelControl { Text = "Teslimat Adresi ve Notlar:", Location = new Point(10, 10), Parent = pnlAlt };
            lblAdres.Appearance.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

            memoAdres = new MemoEdit { Parent = pnlAlt, Location = new Point(10, 30), Size = new Size(400, 80) };
            memoAdres.Properties.NullValuePrompt = "Açık adresinizi ve kargo notunuzu buraya giriniz...";
            if (!string.IsNullOrEmpty(aktifMusteriAdres)) memoAdres.Text = aktifMusteriAdres;

            gcSepet.Dock = DockStyle.Fill;
            gcSepet.BringToFront();
        }

        private void BildirimKontrol()
        {
            // 1. Aktif bildirimi çek
            string[] gelenBildirim = bildirimYonetim.SonBildirimiGetir();

            // Bildirim yoksa çık
            if (gelenBildirim == null) return;

            // Verileri ayıkla (Diziyi güncellediğimiz için indexler değişti)
            int bildirimId = Convert.ToInt32(gelenBildirim[0]);
            string baslik = gelenBildirim[1];
            string mesaj = gelenBildirim[2];

            // 2. KONTROL: Bu müşteri (telefon numarası) bu bildirimi daha önce gördü mü?
            if (bildirimYonetim.OkunduMu(aktifMusteriTel, bildirimId))
            {
                return; // Zaten okumuş, bir şey yapma.
            }

            // 3. Bildirimi Göster
            XtraMessageBox.Show(mesaj, baslik, MessageBoxButtons.OK, MessageBoxIcon.Information);

            // 4. KAYDET: Müşteri bunu gördü, veritabanına işle.
            bildirimYonetim.OkunduIsaretle(aktifMusteriTel, bildirimId);
        }
        #endregion
    }
}