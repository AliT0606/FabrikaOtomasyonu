using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Fabrika_Otomasyonu
{
    public partial class FrmYonetici : DevExpress.XtraEditors.XtraForm
    {
        UrunYonetimi urunYonetim = new UrunYonetimi();
        List<GeciciVaryant> eklenecekVaryantlar = new List<GeciciVaryant>();

        public FrmYonetici()
        {
            InitializeComponent();
            Veritabani.TablolariKur();

            BaslangicAyarlari();

            // Form açılınca İKİ listeyi de doldur
            UrunListesiniYenile();
            HammaddeListesiniYenile(); // <-- YENİ EKLENDİ

            OlaylariBagla();
        }

        private void BaslangicAyarlari()
        {
            // Ürün Ekleme Kısmı
            cmbHammaddeTur.Properties.Items.Clear();
            cmbHammaddeTur.Properties.Items.AddRange(new object[] { "Deri", "Emitasyon", "Kumaş", "Süet", "Rugan" });

            // Stok Kısmı
            cmbHamTur.Properties.Items.Clear();
            cmbHamTur.Properties.Items.AddRange(new object[] { "Deri", "Emitasyon", "Kumaş", "Süet", "Rugan", "Taban" });

            cmbHamTur.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            cmbHamBirim.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            cmbHamBirim.Enabled = false;
        }

        private void OlaylariBagla()
        {
            accordionControl1.ElementClick += (s, e) =>
            {
                if (e.Element.Style == DevExpress.XtraBars.Navigation.ElementStyle.Item)
                {
                    lblBaslik.Text = e.Element.Text;
                    switch (e.Element.Name)
                    {
                        case "elmUrunler":
                            navFrameYonetici.SelectedPage = pageUrunler;
                            UrunListesiniYenile(); // Sayfaya girince yenile
                            break;
                        case "elmMakineler":
                            navFrameYonetici.SelectedPage = pageMakineler;
                            break;
                        case "elmHammadde":
                            navFrameYonetici.SelectedPage = pageHammadde;
                            HammaddeListesiniYenile(); // Sayfaya girince yenile
                            break;
                        case "elmSiparisler":
                            navFrameYonetici.SelectedPage = pageSiparisler;
                            break;
                    }
                }
            };

            // Resim Seçme
            peUrunResim.Click += (s, e) =>
            {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;";
                    if (ofd.ShowDialog() == DialogResult.OK)
                        peUrunResim.Image = Image.FromFile(ofd.FileName);
                }
            };

            // Akıllı Birim Seçimi
            cmbHamTur.SelectedIndexChanged += (s, e) =>
            {
                if (cmbHamTur.EditValue == null) return;
                if (cmbHamTur.Text == "Taban") cmbHamBirim.SelectedItem = "Adet";
                else cmbHamBirim.SelectedItem = "m² (Metrekare)";
                cmbHamBirim.Enabled = false;
            };

            btnRenkEkle.Click += BtnRenkEkle_Click;
            btnUrunKaydet.Click += BtnUrunKaydet_Click;
            btnUrunKaldir.Click += BtnUrunKaldir_Click;

            // Stok Ekleme Butonu
            btnHammaddeEkle.Click += BtnHammaddeEkle_Click;

            gvUrunListesi.FocusedRowChanged += (s, e) => {
                var row = gvUrunListesi.GetFocusedDataRow();
                btnUrunKaldir.Visible = (row != null);
            };
        }

        // --- STOK EKLEME İŞLEMİ (GÜNCELLENDİ) ---
        private void BtnHammaddeEkle_Click(object sender, EventArgs e)
        {
            if (cmbHamTur.EditValue == null || string.IsNullOrEmpty(txtHamMiktar.Text))
            {
                XtraMessageBox.Show("Lütfen tür ve miktar giriniz.");
                return;
            }

            try
            {
                // Miktarı sayıya çevir
                double miktar = Convert.ToDouble(txtHamMiktar.Text);

                // Veritabanına kaydet (Varsa üstüne ekler, yoksa yeni açar)
                urunYonetim.HammaddeStokEkle(cmbHamTur.Text, cmbHamBirim.Text, miktar);

                XtraMessageBox.Show("Stok başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Listeyi Yenile ki ekranda görünsün!
                HammaddeListesiniYenile();

                // Temizlik
                txtHamMiktar.Text = "";
                cmbHamTur.SelectedIndex = -1;
                cmbHamBirim.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Hata: " + ex.Message);
            }
        }

        // --- LİSTELEME METODLARI ---
        private void UrunListesiniYenile()
        {
            gcUrunListesi.DataSource = urunYonetim.UrunleriGetir();
            gvUrunListesi.BestFitColumns();
        }

        private void HammaddeListesiniYenile()
        {
            // Veritabanından çek ve Grid'e bağla
            gcHammaddeListesi.DataSource = urunYonetim.HammaddeleriGetir();
            gvHammaddeListesi.BestFitColumns();
        }

        // Diğer butonlar aynen kalıyor...
        private void BtnRenkEkle_Click(object sender, EventArgs e)
        {
            if (cmbRenkSec.EditValue == null) { XtraMessageBox.Show("Renk seçiniz!"); return; }
            var resim = peUrunResim.Image;
            var yeni = new GeciciVaryant { Renk = cmbRenkSec.Text, GorselResim = resim, ResimData = urunYonetim.ResimToByte(resim) };
            eklenecekVaryantlar.Add(yeni);
            lstEklenenVaryantlar.Items.Add($"{yeni.Renk} - [Görsel: {(resim != null ? "Var" : "Yok")}]");
            peUrunResim.Image = null; cmbRenkSec.SelectedIndex = -1;
        }

        private void BtnUrunKaydet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUrunModel.Text) || cmbUrunTur.EditValue == null || cmbHammaddeTur.EditValue == null)
            { XtraMessageBox.Show("Eksik bilgi!"); return; }

            if (eklenecekVaryantlar.Count == 0) { XtraMessageBox.Show("Varyant eklemediniz!"); return; }

            try
            {
                urunYonetim.UrunEkle(txtUrunModel.Text, cmbUrunTur.Text, cmbHammaddeTur.Text, eklenecekVaryantlar);
                XtraMessageBox.Show("Kaydedildi.");
                FormuTemizle(); UrunListesiniYenile();
            }
            catch (Exception ex) { XtraMessageBox.Show(ex.Message); }
        }

        private void BtnUrunKaldir_Click(object sender, EventArgs e)
        {
            var row = gvUrunListesi.GetFocusedDataRow();
            if (row == null) return;
            if (XtraMessageBox.Show("Silinsin mi?", "Onay", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                urunYonetim.UrunSil(Convert.ToInt32(row["Id"]));
                UrunListesiniYenile();
            }
        }

        private void FormuTemizle()
        {
            txtUrunModel.Text = ""; cmbUrunTur.SelectedIndex = -1; cmbHammaddeTur.SelectedIndex = -1;
            lstEklenenVaryantlar.Items.Clear(); eklenecekVaryantlar.Clear(); peUrunResim.Image = null;
        }
    }
}