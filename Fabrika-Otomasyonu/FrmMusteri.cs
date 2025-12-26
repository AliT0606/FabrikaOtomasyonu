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
        SiparisYonetimi siparisYonetim = new SiparisYonetimi();

        // SEPET LİSTESİ -> BindingList ile Grid ile uyumlu hale getirildi
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
            // 1. Verileri Yükle
            gcUrunVitrin.DataSource = vitrinYonetim.VitrinListesiGetir();
            gcSiparisTakip.DataSource = siparisYonetim.SiparisleriGetir();

            // Sepet grid'i bir kez bağla
            gcSepet.DataSource = sepetListesi;

            // 2. Sağ Paneli Temizle
            TemizleSagPanel();
            SepetiGuncelle();
        }

        private void OlaylariBagla()
        {
            // --- 1. SOL MENÜ GEÇİŞLERİ (GARANTİ YÖNTEM) ---
            accordionControl1.ElementClick += (s, e) =>
            {
                // İsim yerine direkt nesne kontrolü yapıyoruz (Daha güvenli)
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
                    gcSiparisTakip.DataSource = siparisYonetim.SiparisleriGetir();
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
                    seciliTakimFiyati = birimFiyat * 8; // 1 Takım = 8 Çift

                    // Paneli Doldur
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
                    peSeciliResim.Image = ByteToImage(varyantHafiza[secilenRenk]);
                }
                else
                {
                    peSeciliResim.Image = null;
                }
            };

            // --- 5. ADET DEĞİŞİMİ ---
            txtAdet.EditValueChanged += (s, e) => FiyatHesapla();

            // --- 6. SEPETE EKLE ---
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
                    UrunResmi = peSeciliResim.Image
                };

                sepetListesi.Add(yeniOge);
                XtraMessageBox.Show("Sepete eklendi!", "Başarılı");
                TemizleSagPanel();
                SepetiGuncelle();
            };

            // --- 7. SEPET İŞLEMLERİ ---
            btnSepetiTemizle.Click += (s, e) => { sepetListesi.Clear(); SepetiGuncelle(); };

            btnSepetiOnayla.Click += (s, e) =>
            {
                if (sepetListesi.Count == 0) return;

                if (XtraMessageBox.Show("Siparişi onaylıyor musunuz?", "Onay", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    foreach (var item in sepetListesi)
                    {
                        string tamAd = $"{item.ModelAd} ({item.Renk}) - [TAKIM]";
                        siparisYonetim.SiparisOlustur("Misafir Müşteri", tamAd, item.TakimSayisi, item.BirimFiyat);
                    }
                    sepetListesi.Clear();
                    SepetiGuncelle();
                    XtraMessageBox.Show("Sipariş alındı!", "Teşekkürler");

                    // Takip sayfasına yönlendir
                    navFrameMusteri.SelectedPage = pageTakip;
                    gcSiparisTakip.DataSource = siparisYonetim.SiparisleriGetir();
                }
            };

            // --- SİL BUTONU ---
            repoSil.ButtonClick += (s, e) =>
            {
                var row = gvSepet.GetFocusedRow() as SepetOgesi;
                if (row != null)
                {
                    sepetListesi.Remove(row);
                    SepetiGuncelle();
                }
            };

            // NOT: repoAdet.ButtonClick event'i Designer içinde repoAdet_ButtonClick yöntemiyle bağlandı.
        }

        // --- YARDIMCI METODLAR ---

        private void VaryantlariDoldur(int id)
        {
            cmbVaryant.Properties.Items.Clear();
            varyantHafiza.Clear();
            peSeciliResim.Image = null;

            DataTable dt = vitrinYonetim.UrunDetaylariniGetir(id);
            foreach (DataRow row in dt.Rows)
            {
                string renk = row["Renk"].ToString();
                byte[] resim = row["Resim"] != DBNull.Value ? (byte[])row["Resim"] : null;

                cmbVaryant.Properties.Items.Add(renk);
                if (resim != null) varyantHafiza.Add(renk, resim);
            }

            if (cmbVaryant.Properties.Items.Count > 0) cmbVaryant.SelectedIndex = 0;
        }

        private void FiyatHesapla()
        {
            if (seciliTakimFiyati > 0)
            {
                lblToplamFiyat.Text = (seciliTakimFiyati * txtAdet.Value).ToString("C2");
            }
            else
            {
                lblToplamFiyat.Text = "0.00 TL";
            }
        }

        private void SepetiGuncelle()
        {
            // BindingList ile DataSource zaten bağlı, sadece yenile ve toplamı hesapla
            try
            {
                gcSepet.RefreshDataSource();
            }
            catch { gvSepet.RefreshData(); }

            try { gvSepet.BestFitColumns(); } catch { }

            lblSepetToplam.Text = $"  Toplam: {sepetListesi.Sum(x => x.ToplamTutar):C2}";
        }

        private void TemizleSagPanel()
        {
            seciliUrunId = 0;
            lblUrunBaslik.Text = "Ürün Seçiniz";
            peSeciliResim.Image = null;
            cmbVaryant.Properties.Items.Clear();
            cmbVaryant.Text = "";
            txtAdet.Value = 1;
            lblToplamFiyat.Text = "0.00 TL";
        }

        private Image ByteToImage(byte[] data)
        {
            if (data == null) return null;
            using (var ms = new MemoryStream(data)) return Image.FromStream(ms);
        }

        // repoAdet butonlarında tek handler: Tag ile plus/minus kontrolü -> SepetOgesi üzerinden güncelle
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
    }
}