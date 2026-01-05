using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Fabrika_Otomasyonu
{
    public partial class FrmYonetici : DevExpress.XtraEditors.XtraForm
    {
        #region YÖNETİM SINIFLARI
        UrunYonetimi urunYonetim = new UrunYonetimi();
        HammaddeYonetimi hammaddeYonetim = new HammaddeYonetimi();
        BildirimYonetimi bildirimYonetim = new BildirimYonetimi();
        SiparisYonetimi siparisYonetimi = new SiparisYonetimi();

        // Ürün eklerken geçici tutulan varyant listesi
        List<GeciciVaryant> eklenecekVaryantlar = new List<GeciciVaryant>();
        #endregion

        public FrmYonetici()
        {
            InitializeComponent();

            Veritabani.TablolariKur();
            SiparisGridiniHazirla();
            BaslangicAyarlari();

            // Listeleri Doldur
            UrunListesiniYenile();
            HammaddeListesiniYenile();

            OlaylariBagla();

            this.FormClosed += (s, e) => Application.Exit();
        }

        #region KURULUM VE BAŞLANGIÇ
        private void BaslangicAyarlari()
        {
            // Dropdown listelerini doldur
            DoldurCombo(cmbUrunTur, "Bot", "Spor", "Klasik");
            DoldurCombo(cmbRenkSec, "Siyah", "Lacivert", "Kahverengi", "Taba", "Haki");
            DoldurCombo(cmbHammaddeTur, "Deri", "Emitasyon", "Bez");
            DoldurCombo(cmbHamTur, "Deri", "Emitasyon", "Bez", "Taban");
            DoldurCombo(cmbHamBirim, "Adet", "Kg", "m² (Metrekare)", "Litre");

            // UI Ayarları
            if (memoOzurMesaji != null) memoOzurMesaji.Properties.ReadOnly = true;
            Gizle(lblArizaMakine);
            Gizle(txtArizaMakine);

            // Panel Ortalama
            if (pageMakineler != null)
            {
                pageMakineler.SizeChanged += (s, e) =>
                {
                    if (groupArizaBildirim != null)
                        groupArizaBildirim.Location = new Point(
                            (pageMakineler.Width - groupArizaBildirim.Width) / 2,
                            (pageMakineler.Height - groupArizaBildirim.Height) / 2
                        );
                };
            }
        }

        // Yardımcı (Kod tekrarını önler)
        private void DoldurCombo(ComboBoxEdit cmb, params string[] items)
        {
            if (cmb != null) { cmb.Properties.Items.Clear(); cmb.Properties.Items.AddRange(items); }
        }
        private void Gizle(Control ctrl) { if (ctrl != null) ctrl.Visible = false; }
        #endregion

        #region SİPARİŞ YÖNETİMİ
        private void SiparisGridiniHazirla()
        {
            // "İşlem" Butonunu Oluştur
            RepositoryItemButtonEdit btnIslem = new RepositoryItemButtonEdit();
            btnIslem.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            btnIslem.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;
            btnIslem.Buttons[0].Caption = "İşlem";
            btnIslem.ButtonClick += SiparisIslem_Click;
            gcSiparisYonetim.RepositoryItems.Add(btnIslem);

            // Satıra göre buton rengini ve metnini değiştir (Conditional Formatting)
            gvSiparisYonetim.CustomRowCellEdit += (s, e) =>
            {
                if (e.Column.FieldName == "Islem")
                {
                    string durum = gvSiparisYonetim.GetRowCellValue(e.RowHandle, "Durum")?.ToString();
                    RepositoryItemButtonEdit btn = btnIslem.Clone() as RepositoryItemButtonEdit;

                    if (durum == "Onay Bekliyor")
                    {
                        btn.Buttons[0].Caption = "ONAYLA";
                        btn.Buttons[0].Appearance.BackColor = Color.Orange;
                    }
                    else if (durum == "Hazırlanıyor")
                    {
                        btn.Buttons[0].Caption = "KARGOLA";
                        btn.Buttons[0].Appearance.BackColor = Color.DarkOrange;
                        btn.Buttons[0].Appearance.ForeColor = Color.White;
                    }
                    else
                    {
                        btn.Buttons[0].Caption = "Tamamlandı";
                        btn.Buttons[0].Enabled = false;
                    }
                    e.RepositoryItem = btn;
                }
            };
        }

        private void SiparisIslem_Click(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var row = gvSiparisYonetim.GetFocusedDataRow();
            if (row == null) return;

            string siparisKodu = row["SiparisKodu"].ToString();
            string durum = row["Durum"].ToString();

            if (durum == "Onay Bekliyor")
            {
                if (siparisYonetimi.SiparisiOnaylaVeStokDus(siparisKodu))
                {
                    siparisYonetimi.TumTarihleriGuncelle();
                    XtraMessageBox.Show("Sipariş onaylandı ve üretime alındı.");
                }
            }
            else if (durum == "Hazırlanıyor")
            {
                siparisYonetimi.DurumDegistirGrup(siparisKodu, "Kargoda");
                siparisYonetimi.TumTarihleriGuncelle();
                XtraMessageBox.Show("Sipariş kargoya verildi!");
            }
            SiparisleriYenile();
        }

        private void SiparisleriYenile()
        {
            gcSiparisYonetim.DataSource = siparisYonetimi.SiparisleriGetir();
            gvSiparisYonetim.BestFitColumns();

            // Sütun Ayarları
            if (gvSiparisYonetim.Columns["Islem"] == null)
            {
                GridColumn col = gvSiparisYonetim.Columns.AddField("Islem");
                col.Visible = true;
                col.Caption = "İŞLEMLER";
                col.VisibleIndex = 99;
            }
            if (gvSiparisYonetim.Columns["Id"] != null) gvSiparisYonetim.Columns["Id"].Visible = false;

            // Gruplama (Sipariş Kodu'na göre)
            if (gvSiparisYonetim.Columns["SiparisKodu"] != null)
            {
                gvSiparisYonetim.Columns["SiparisKodu"].GroupIndex = 0;
                gvSiparisYonetim.ExpandAllGroups();
                gvSiparisYonetim.OptionsView.ShowGroupPanel = false;
            }
        }
        #endregion

        #region OLAYLAR (EVENTS)
        private void OlaylariBagla()
        {
            // Menü Geçişleri
            accordionControl1.ElementClick += (s, e) =>
            {
                if (e.Element.Style != DevExpress.XtraBars.Navigation.ElementStyle.Item) return;

                lblBaslik.Text = e.Element.Text;
                switch (e.Element.Name)
                {
                    case "elmUrunler": navFrameYonetici.SelectedPage = pageUrunler; UrunListesiniYenile(); break;
                    case "elmMakineler": navFrameYonetici.SelectedPage = pageMakineler; break;
                    case "elmHammadde": navFrameYonetici.SelectedPage = pageHammadde; HammaddeListesiniYenile(); break;
                    case "elmSiparisler": navFrameYonetici.SelectedPage = pageSiparisler; SiparisleriYenile(); break;
                }
            };

            // Arıza Bildirim Mantığı
            cmbSorunTipi.SelectedIndexChanged += (s, e) => { ArizaFormunuAyarla(); OtomatikMesajOlustur(); };
            txtArizaMakine.EditValueChanged += (s, e) => OtomatikMesajOlustur();
            cmbSure.SelectedIndexChanged += (s, e) => OtomatikMesajOlustur();

            btnBildirimGonder.Click += BtnBildirimGonder_Click;

            // Ürün & Hammadde Butonları
            peUrunResim.Click += (s, e) => ResimSec();
            btnRenkEkle.Click += BtnRenkEkle_Click;
            btnUrunKaydet.Click += BtnUrunKaydet_Click;
            btnUrunKaldir.Click += BtnUrunKaldir_Click;
            btnHammaddeEkle.Click += BtnHammaddeEkle_Click;

            // Hammadde birim ayarı
            cmbHamTur.SelectedIndexChanged += (s, e) =>
            {
                if (cmbHamTur.Text == "Taban") cmbHamBirim.SelectedItem = "Adet";
                else cmbHamBirim.SelectedItem = "m² (Metrekare)";
            };
        }

        private void ArizaFormunuAyarla()
        {
            lblArizaMakine.Visible = true;
            txtArizaMakine.Visible = true;
            if (cmbSorunTipi.Text == "Makine Arızası")
            {
                lblArizaMakine.Text = "Arızalı Makine Adı:";
                txtArizaMakine.Properties.NullValuePrompt = "Örn: Kesim Makinesi 2";
            }
            else
            {
                lblArizaMakine.Text = "Sorun Başlığı:";
                txtArizaMakine.Properties.NullValuePrompt = "";
            }
            txtArizaMakine.Text = "";
        }

        private void ResimSec()
        {
            using (OpenFileDialog ofd = new OpenFileDialog { Filter = "Resim|*.jpg;*.jpeg;*.png;" })
            {
                if (ofd.ShowDialog() == DialogResult.OK) peUrunResim.Image = Image.FromFile(ofd.FileName);
            }
        }
        #endregion

        #region BUTON İŞLEMLERİ (CRUD)
        private void BtnBildirimGonder_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(memoOzurMesaji.Text)) { XtraMessageBox.Show("Mesaj içeriği oluşmadı!"); return; }

            if (XtraMessageBox.Show("Bu bildirim yayınlansın mı?", "Onay", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string baslik = cmbSorunTipi.Text == "Makine Arızası" ? "⚠️ Üretim Arıza Bildirimi" : "ℹ️ Genel Bilgilendirme";
                bildirimYonetim.BildirimGonder(baslik, memoOzurMesaji.Text);
                XtraMessageBox.Show("Bildirim yayınlandı.");

                // Temizlik
                memoOzurMesaji.Text = ""; cmbSure.SelectedIndex = -1; txtArizaMakine.Text = ""; cmbSorunTipi.SelectedIndex = -1;
                siparisYonetimi.TumTarihleriGuncelle();
            }
        }

        private void BtnRenkEkle_Click(object sender, EventArgs e)
        {
            if (cmbRenkSec.EditValue == null) { XtraMessageBox.Show("Renk seçiniz!"); return; }
            string renk = cmbRenkSec.Text;

            if (eklenecekVaryantlar.Exists(x => x.Renk == renk))
            {
                XtraMessageBox.Show("Bu renk zaten eklendi!"); return;
            }

            var img = peUrunResim.Image;
            eklenecekVaryantlar.Add(new GeciciVaryant { Renk = renk, GorselResim = img, ResimData = urunYonetim.ResimToByte(img) });
            lstEklenenVaryantlar.Items.Add($"{renk} - [Görsel: {(img != null ? "Var" : "Yok")}]");

            peUrunResim.Image = null; cmbRenkSec.SelectedIndex = -1;
        }

        private void BtnUrunKaydet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUrunModel.Text) || string.IsNullOrEmpty(txtUrunFiyat.Text))
            {
                XtraMessageBox.Show("Eksik bilgi!"); return;
            }

            try
            {
                urunYonetim.UrunEkle(txtUrunModel.Text, cmbUrunTur.Text, cmbHammaddeTur.Text, Convert.ToDecimal(txtUrunFiyat.EditValue), eklenecekVaryantlar);
                XtraMessageBox.Show("Ürün kaydedildi.");
                FormuTemizle();
                UrunListesiniYenile();
            }
            catch (Exception ex) { XtraMessageBox.Show("Hata: " + ex.Message); }
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

        private void BtnHammaddeEkle_Click(object sender, EventArgs e)
        {
            if (cmbHamTur.EditValue == null || string.IsNullOrEmpty(txtHamMiktar.Text)) return;
            hammaddeYonetim.HammaddeStokEkle(cmbHamTur.Text, cmbHamBirim.Text, Convert.ToDouble(txtHamMiktar.Text));
            XtraMessageBox.Show("Stok Eklendi.");
            HammaddeListesiniYenile();
            txtHamMiktar.Text = "";
        }
        #endregion

        #region YARDIMCI METOTLAR
        private void OtomatikMesajOlustur()
        {
            if (string.IsNullOrEmpty(cmbSorunTipi.Text)) return;
            string sure = cmbSure.Text;
            string detay = string.IsNullOrEmpty(txtArizaMakine.Text) ? "genel teknik aksaklıklar" : $"'{txtArizaMakine.Text}'";

            if (cmbSorunTipi.Text == "Makine Arızası")
                memoOzurMesaji.Text = $"Sayın Müşterimiz,\n\nFabrikamızdaki {detay} arızası nedeniyle siparişleriniz {sure} gecikecektir.\nAnlayışınız için teşekkür ederiz.";
            else
                memoOzurMesaji.Text = $"Sayın Müşterimiz,\n\n{detay} sebebiyle üretim planımızda aksama olmuştur. Teslimat {sure} gecikebilir.";
        }

        private void UrunListesiniYenile() { gcUrunListesi.DataSource = urunYonetim.UrunleriGetir(); gvUrunListesi.BestFitColumns(); }
        private void HammaddeListesiniYenile() { gcHammaddeListesi.DataSource = hammaddeYonetim.HammaddeleriGetir(); gvHammaddeListesi.BestFitColumns(); }

        private void FormuTemizle()
        {
            txtUrunModel.Text = ""; txtUrunFiyat.Text = ""; cmbUrunTur.SelectedIndex = -1; cmbHammaddeTur.SelectedIndex = -1;
            lstEklenenVaryantlar.Items.Clear(); eklenecekVaryantlar.Clear(); peUrunResim.Image = null;
        }
        #endregion
    }
}