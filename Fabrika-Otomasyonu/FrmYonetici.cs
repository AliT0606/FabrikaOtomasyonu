
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
        HammaddeYonetimi hammaddeYonetim = new HammaddeYonetimi();
        List<GeciciVaryant> eklenecekVaryantlar = new List<GeciciVaryant>();

        public FrmYonetici()
        {
            InitializeComponent();
            Veritabani.TablolariKur();
            BaslangicAyarlari();

            UrunListesiniYenile();
            HammaddeListesiniYenile();
            OlaylariBagla();
        }

        private void BaslangicAyarlari()
        {
            // Butonun mutlaka en üstte görünmesini garantiye al
            btnUrunKaldir.Visible = true;
            btnUrunKaldir.BringToFront();

            // Listeler
            cmbHammaddeTur.Properties.Items.Clear();
            cmbHammaddeTur.Properties.Items.AddRange(new object[] { "Deri", "Emitasyon", "Kumaş", "Süet", "Rugan" });

            cmbHamTur.Properties.Items.Clear();
            cmbHamTur.Properties.Items.AddRange(new object[] { "Deri", "Emitasyon", "Kumaş", "Süet", "Rugan", "Taban" });

            cmbHamTur.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            cmbHamBirim.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            cmbHamBirim.Enabled = false;
        }

        // ... Diğer OlaylariBagla ve Buton metodları AYNI (önceki koddan devam) ...
        private void OlaylariBagla()
        {
            // (Önceki kodların aynısı...)
            accordionControl1.ElementClick += (s, e) =>
            {
                if (e.Element.Style == DevExpress.XtraBars.Navigation.ElementStyle.Item)
                {
                    lblBaslik.Text = e.Element.Text;
                    switch (e.Element.Name)
                    {
                        case "elmUrunler": navFrameYonetici.SelectedPage = pageUrunler; UrunListesiniYenile(); break;
                        case "elmMakineler": navFrameYonetici.SelectedPage = pageMakineler; break;
                        case "elmHammadde": navFrameYonetici.SelectedPage = pageHammadde; HammaddeListesiniYenile(); break;
                        case "elmSiparisler": navFrameYonetici.SelectedPage = pageSiparisler; break;
                    }
                }
            };

            // ... Diğerlerini yukarıdan kopyala yapıştır yapabilirsin ...

            peUrunResim.Click += (s, e) =>
            {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;";
                    if (ofd.ShowDialog() == DialogResult.OK) peUrunResim.Image = Image.FromFile(ofd.FileName);
                }
            };

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
            btnHammaddeEkle.Click += BtnHammaddeEkle_Click;
        }

        // ... Buton Click Metodları (BtnUrunKaldir_Click vs.) AYNI ...
        private void BtnUrunKaldir_Click(object sender, EventArgs e)
        {
            var row = gvUrunListesi.GetFocusedDataRow();
            if (row == null) { XtraMessageBox.Show("Ürün seçiniz!"); return; }

            if (XtraMessageBox.Show("Silinsin mi?", "Onay", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                urunYonetim.UrunSil(Convert.ToInt32(row["Id"]));
                UrunListesiniYenile();
            }
        }

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

        private void BtnHammaddeEkle_Click(object sender, EventArgs e)
        {
            if (cmbHamTur.EditValue == null || string.IsNullOrEmpty(txtHamMiktar.Text))
            { XtraMessageBox.Show("Eksik bilgi!"); return; }

            try
            {
                hammaddeYonetim.HammaddeStokEkle(cmbHamTur.Text, cmbHamBirim.Text, Convert.ToDouble(txtHamMiktar.Text));
                XtraMessageBox.Show("Stok Güncellendi.");
                HammaddeListesiniYenile();
                txtHamMiktar.Text = ""; cmbHamTur.SelectedIndex = -1; cmbHamBirim.SelectedIndex = -1;
            }
            catch (Exception ex) { XtraMessageBox.Show(ex.Message); }
        }

        private void UrunListesiniYenile() { gcUrunListesi.DataSource = urunYonetim.UrunleriGetir(); gvUrunListesi.BestFitColumns(); }
        private void HammaddeListesiniYenile() { gcHammaddeListesi.DataSource = hammaddeYonetim.HammaddeleriGetir(); gvHammaddeListesi.BestFitColumns(); }
        private void FormuTemizle() { txtUrunModel.Text = ""; cmbUrunTur.SelectedIndex = -1; cmbHammaddeTur.SelectedIndex = -1; lstEklenenVaryantlar.Items.Clear(); eklenecekVaryantlar.Clear(); peUrunResim.Image = null; }
    }
}
