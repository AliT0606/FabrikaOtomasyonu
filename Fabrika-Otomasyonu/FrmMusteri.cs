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

        // SEPET LİSTESİ
        BindingList<SepetOgesi> sepetListesi = new BindingList<SepetOgesi>();

        // DEĞİŞKENLER
        int seciliUrunId = 0;
        string seciliModelAd = "";
        decimal seciliTakimFiyati = 0;

        // HAFIZA
        Dictionary<string, byte[]> varyantHafiza = new Dictionary<string, byte[]>();

        public FrmMusteri()
        {
            InitializeComponent();
            BaslangicAyarlari();
            OlaylariBagla();
        }

        private void BaslangicAyarlari()
        {
            ConfigureTileView();

            // 1. Verileri Yükle
            gcUrunVitrin.DataSource = vitrinYonetim.VitrinListesiGetir();
            gcSiparisTakip.DataSource = siparisYonetimi.SiparisleriGetir();

            // Sepet grid'i bağla
            gcSepet.DataSource = sepetListesi;

            // 2. Sağ Paneli Temizle
            TemizleSagPanel();
            SepetiGuncelle();
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
                    // YENİ GÜVENLİ METODU KULLANIYORUZ
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

                SepetOgesi yeniOge = new SepetOgesi
                {
                    UrunId = seciliUrunId,
                    ModelAd = seciliModelAd,
                    Renk = cmbVaryant.Text,
                    TakimSayisi = Convert.ToInt32(txtAdet.Value),
                    BirimFiyat = seciliTakimFiyati,
                    ToplamTutar = seciliTakimFiyati * Convert.ToInt32(txtAdet.Value),
                    UrunResmi = peSeciliResim.Image // Mevcut resmi alıyoruz
                };

                sepetListesi.Add(yeniOge);
                XtraMessageBox.Show("Sepete eklendi!", "Başarılı");

                // Sepete ekledikten sonra paneli tamamen temizleme ki müşteri art arda ekleyebilsin
                // Sadece adeti sıfırlayabilirsin veya böyle bırakabilirsin.
                // TemizleSagPanel(); // <- Bunu kaldırdım, kullanıcı aynı üründen farklı renk seçebilsin diye.
                SepetiGuncelle();
            };

            // --- DİĞER BUTONLAR ---
            btnSepetiTemizle.Click += (s, e) => { sepetListesi.Clear(); SepetiGuncelle(); };

            btnSepetiOnayla.Click += (s, e) =>
            {
                if (sepetListesi.Count == 0) return;
                if (XtraMessageBox.Show("Siparişi onaylıyor musunuz?", "Onay", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    foreach (var item in sepetListesi)
                    {
                        string tamAd = $"{item.ModelAd} ({item.Renk}) - [TAKIM]";
                        siparisYonetimi.SiparisOlustur("Misafir Müşteri", tamAd, item.TakimSayisi, item.BirimFiyat);
                    }
                    sepetListesi.Clear();
                    SepetiGuncelle();
                    XtraMessageBox.Show("Sipariş alındı!", "Teşekkürler");
                    navFrameMusteri.SelectedPage = pageTakip;
                    gcSiparisTakip.DataSource = siparisYonetimi.SiparisleriGetir();
                }
            };

            repoSil.ButtonClick += (s, e) =>
            {
                var row = gvSepet.GetFocusedRow() as SepetOgesi;
                if (row != null) { sepetListesi.Remove(row); SepetiGuncelle(); }
            };
        }

        // --- KRİTİK YARDIMCI METODLAR ---

        // Hafızayı şişirmemek için eski resmi silip yenisini koyan metod
        private void ResmiKutuyaKoy(Image yeniResim)
        {
            // Eski resim varsa hafızadan at
            if (peSeciliResim.Image != null)
            {
                peSeciliResim.Image.Dispose();
            }

            peSeciliResim.Image = yeniResim;
        }

        private void VaryantlariDoldur(int id)
        {
            // Güncelleme sırasında ekran titremesin
            cmbVaryant.Properties.Items.BeginUpdate();
            cmbVaryant.Properties.Items.Clear();

            // Resmi de güvenli temizle
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
            cmbVaryant.Properties.Items.EndUpdate(); // Güncellemeyi bitir

            if (cmbVaryant.Properties.Items.Count > 0)
            {
                cmbVaryant.SelectedIndex = 0;

                // EKSTRA GÜVENLİK: 
                // Index değişimi bazen tetiklenmeyebilir (zaten 0 ise),
                // bu yüzden seçili rengin resmini burada ELLE yüklüyoruz.
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
            ResmiKutuyaKoy(null); // Güvenli temizleme
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
                // Stream açık kalmalı, using kullanmıyoruz.
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
    }
}