using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository; // Butonlar için gerekli
using DevExpress.XtraGrid.Columns;       // Sütun işlemleri için gerekli
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
        BildirimYonetimi bildirimYonetim = new BildirimYonetimi();
        SiparisYonetimi siparisYonetimi = new SiparisYonetimi(); // Sipariş sınıfı

        List<GeciciVaryant> eklenecekVaryantlar = new List<GeciciVaryant>();

        public FrmYonetici()
        {
            InitializeComponent();
            Veritabani.TablolariKur();

            // Sipariş Grid'inin buton ayarlarını yapıyoruz
            SiparisGridiniHazirla();

            BaslangicAyarlari();

            UrunListesiniYenile();
            HammaddeListesiniYenile();
            OlaylariBagla();
            this.FormClosed += (s, e) => Application.Exit();
        }

        // ============================================================
        // 1. SİPARİŞ YÖNETİMİ MANTIKLARI (YENİ EKLENEN KISIM)
        // ============================================================
        private void SiparisGridiniHazirla()
        {
            // Grid Designer'da eklendi ama buton olaylarını burada kodla bağlıyoruz.
            // Bu sayede "ONAYLA" veya "KARGOLA" ayrımını yapabileceğiz.

            // 1. Buton Nesnesi Oluştur (RepositoryItem)
            RepositoryItemButtonEdit btnIslem = new RepositoryItemButtonEdit();
            btnIslem.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            btnIslem.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;
            btnIslem.Buttons[0].Caption = "İşlem";

            // Tıklama Olayını Bağla
            btnIslem.ButtonClick += SiparisIslem_Click;

            // Grid'e Ekle
            gcSiparisYonetim.RepositoryItems.Add(btnIslem);

            // 2. Her satır için butonu özelleştir (Onay Bekliyor -> Turuncu, Hazırlanıyor -> Yeşil)
            gvSiparisYonetim.CustomRowCellEdit += (s, e) =>
            {
                if (e.Column.FieldName == "Islem")
                {
                    string durum = gvSiparisYonetim.GetRowCellValue(e.RowHandle, "Durum")?.ToString();

                    // Butonun kopyasını alıp o satıra özel ayarlıyoruz
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
                        btn.Buttons[0].Enabled = false; // Tıklanamaz yap
                    }
                    e.RepositoryItem = btn;
                }
            };
        }

        private void SiparisIslem_Click(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var row = gvSiparisYonetim.GetFocusedDataRow();
            if (row == null) return;

            // ID yerine KOD alıyoruz
            string siparisKodu = row["SiparisKodu"].ToString();
            string durum = row["Durum"].ToString();

            if (durum == "Onay Bekliyor")
            {
                // Grup bazlı onay metodunu çağırıyoruz
                bool basarili = siparisYonetimi.SiparisiOnaylaVeStokDus(siparisKodu);

                if (basarili)
                {
                    siparisYonetimi.TumTarihleriGuncelle(); // Tarihleri ötele
                    XtraMessageBox.Show("Tüm paket onaylandı ve üretime alındı.");
                }
            }
            else if (durum == "Hazırlanıyor")
            {
                // Grup bazlı durum değiştirme
                siparisYonetimi.DurumDegistirGrup(siparisKodu, "Kargoda");

                siparisYonetimi.TumTarihleriGuncelle(); // Sıra boşaldı, öne çek
                XtraMessageBox.Show("Paketteki tüm ürünler kargoya verildi!");
            }

            SiparisleriYenile();
        }

        private void SiparisleriYenile()
        {
            gcSiparisYonetim.DataSource = siparisYonetimi.SiparisleriGetir();
            gvSiparisYonetim.BestFitColumns();

            // 1. İşlem Sütunu (Buton)
            if (gvSiparisYonetim.Columns["Islem"] == null)
            {
                GridColumn col = gvSiparisYonetim.Columns.AddField("Islem");
                col.Visible = true;
                col.Caption = "İŞLEMLER";
                col.Width = 100;
                col.VisibleIndex = 99;
            }

            // 2. Gereksizleri Gizle
            if (gvSiparisYonetim.Columns["Id"] != null) gvSiparisYonetim.Columns["Id"].Visible = false;

            // --- KRİTİK NOKTA: GRUPLAMA AYARI ---
            // Eğer SiparisKodu sütunu varsa, ona göre grupla
            if (gvSiparisYonetim.Columns["SiparisKodu"] != null)
            {
                gvSiparisYonetim.Columns["SiparisKodu"].GroupIndex = 0; // 0. seviye gruplama yap
                gvSiparisYonetim.ExpandAllGroups(); // Grupları açık tut

                // Görünüm Ayarları
                gvSiparisYonetim.OptionsView.ShowGroupPanel = false; // Yukarıdaki boşluğu gizle
                gvSiparisYonetim.OptionsBehavior.AutoExpandAllGroups = true;
            }
        }

        // ============================================================
        // 2. DİĞER AYARLAR VE EVENTLER (SENİN KODLARIN)
        // ============================================================

        private void BaslangicAyarlari()
        {
            // Dropdown (Seçim kutusu) içlerini dolduralım
            if (cmbUrunTur != null)
            {
                cmbUrunTur.Properties.Items.Clear();
                cmbUrunTur.Properties.Items.AddRange(new object[] { "Bot", "Spor", "Klasik" });
            }

            if (cmbRenkSec != null)
            {
                cmbRenkSec.Properties.Items.Clear();
                cmbRenkSec.Properties.Items.AddRange(new object[] { "Siyah", "Lacivert", "Kahverengi", "Taba", "Haki" });
            }

            if (cmbHammaddeTur != null)
            {
                cmbHammaddeTur.Properties.Items.Clear();
                cmbHammaddeTur.Properties.Items.AddRange(new object[] { "Deri", "Emitasyon", "Bez" });
            }

            if (cmbHamTur != null)
            {
                cmbHamTur.Properties.Items.Clear();
                cmbHamTur.Properties.Items.AddRange(new object[] { "Deri", "Emitasyon", "Bez", "Taban" });
            }

            if (cmbHamBirim != null)
            {
                cmbHamBirim.Properties.Items.Clear();
                cmbHamBirim.Properties.Items.AddRange(new object[] { "Adet", "Kg", "m² (Metrekare)", "Litre" });
            }

            // Diğer ayarlar
            if (memoOzurMesaji != null) memoOzurMesaji.Properties.ReadOnly = true;
            if (lblArizaMakine != null) lblArizaMakine.Visible = false;
            if (txtArizaMakine != null) txtArizaMakine.Visible = false;

            // Paneli Ortala
            if (pageMakineler != null && groupArizaBildirim != null)
            {
                pageMakineler.SizeChanged += (s, e) =>
                {
                    groupArizaBildirim.Location = new Point(
                        (pageMakineler.Width - groupArizaBildirim.Width) / 2,
                        (pageMakineler.Height - groupArizaBildirim.Height) / 2
                    );
                };
            }
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
                            UrunListesiniYenile();
                            break;

                        case "elmMakineler":
                            navFrameYonetici.SelectedPage = pageMakineler;
                            groupArizaBildirim.Location = new Point(
                                (pageMakineler.Width - groupArizaBildirim.Width) / 2,
                                (pageMakineler.Height - groupArizaBildirim.Height) / 2
                            );
                            break;

                        case "elmHammadde":
                            navFrameYonetici.SelectedPage = pageHammadde;
                            HammaddeListesiniYenile();
                            break;

                        case "elmSiparisler":
                            navFrameYonetici.SelectedPage = pageSiparisler;
                            SiparisleriYenile(); // ARTIK BU METOD VAR VE ÇALIŞACAK
                            break;
                    }
                }
            };

            // ARIZA PANELİ OLAYLARI
            cmbSorunTipi.SelectedIndexChanged += (s, e) =>
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
                OtomatikMesajOlustur();
            };

            txtArizaMakine.EditValueChanged += (s, e) => OtomatikMesajOlustur();
            cmbSure.SelectedIndexChanged += (s, e) => OtomatikMesajOlustur();

            // BİLDİRİM GÖNDER BUTONU
            btnBildirimGonder.Click += (s, e) =>
            {
                if (string.IsNullOrEmpty(memoOzurMesaji.Text))
                {
                    XtraMessageBox.Show("Mesaj içeriği oluşmadı, lütfen bilgileri seçin!", "Uyarı");
                    return;
                }

                if (XtraMessageBox.Show("Bu bildirim tüm müşterilere yayınlansın mı?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // Başlık, seçilen sorun tipine göre olsun
                    string baslik = cmbSorunTipi.Text == "Makine Arızası" ? "⚠️ Üretim Arıza Bildirimi" : "ℹ️ Genel Bilgilendirme";

                    // VERİTABANINA KAYDET
                    bildirimYonetim.BildirimGonder(baslik, memoOzurMesaji.Text);

                    XtraMessageBox.Show("Bildirim başarıyla yayınlandı! Müşteriler giriş yaptıklarında görecekler.", "Başarılı");

                    // Temizle
                    memoOzurMesaji.Text = "";
                    cmbSure.SelectedIndex = -1;
                    txtArizaMakine.Text = "";
                    cmbSorunTipi.SelectedIndex = -1;
                    lblArizaMakine.Visible = false;
                    txtArizaMakine.Visible = false;
                }
                siparisYonetimi.TumTarihleriGuncelle();
            };

            // RESİM SEÇME
            peUrunResim.Click += (s, e) =>
            {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.Filter = "Resim|*.jpg;*.jpeg;*.png;";
                    if (ofd.ShowDialog() == DialogResult.OK) peUrunResim.Image = Image.FromFile(ofd.FileName);
                }
            };

            // HAMMADDE TÜR SEÇİMİ
            cmbHamTur.SelectedIndexChanged += (s, e) =>
            {
                if (cmbHamTur.EditValue == null) return;
                if (cmbHamTur.Text == "Taban") cmbHamBirim.SelectedItem = "Adet";
                else cmbHamBirim.SelectedItem = "m² (Metrekare)";
                cmbHamBirim.Enabled = false;
            };

            // BUTONLARI BAĞLA
            btnRenkEkle.Click += BtnRenkEkle_Click;
            btnUrunKaydet.Click += BtnUrunKaydet_Click;
            btnUrunKaldir.Click += BtnUrunKaldir_Click;
            btnHammaddeEkle.Click += BtnHammaddeEkle_Click;
        }

        // --- BUTON CLICK METODLARI ---

        private void BtnUrunKaldir_Click(object sender, EventArgs e)
        {
            var row = gvUrunListesi.GetFocusedDataRow();
            if (row == null)
            {
                XtraMessageBox.Show("Lütfen silinecek ürünü listeden seçin!");
                return;
            }

            if (XtraMessageBox.Show($"'{row["ModelAd"]}' adlı ürün ve tüm varyantları silinecek. Onaylıyor musunuz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    int id = Convert.ToInt32(row["Id"]);
                    urunYonetim.UrunSil(id);
                    UrunListesiniYenile();
                    XtraMessageBox.Show("Ürün silindi.");
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        private void BtnRenkEkle_Click(object sender, EventArgs e)
        {
            // 1. Renk seçili mi kontrolü (Eski kodun)
            if (cmbRenkSec.EditValue == null)
            {
                XtraMessageBox.Show("Lütfen bir renk seçiniz!");
                return;
            }

            string secilenRenk = cmbRenkSec.Text;

            // 2. YENİ EKLENEN KISIM: Bu renk listede zaten var mı?
            // System.Linq kütüphanesini kullanıyoruz
            bool renkZatenVar = eklenecekVaryantlar.Exists(x => x.Renk == secilenRenk);

            if (renkZatenVar)
            {
                XtraMessageBox.Show($"'{secilenRenk}' rengi zaten listeye eklenmiş! Aynı rengi tekrar ekleyemezsin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // İşlemi durdur, ekleme yapma
            }

            // 3. Sorun yoksa ekle (Eski kodun devamı)
            var resim = peUrunResim.Image;

            // Resmi byte'a çeviriyoruz
            var yeni = new GeciciVaryant
            {
                Renk = secilenRenk,
                GorselResim = resim,
                ResimData = urunYonetim.ResimToByte(resim)
            };

            eklenecekVaryantlar.Add(yeni);
            lstEklenenVaryantlar.Items.Add($"{yeni.Renk} - [Görsel: {(resim != null ? "Var" : "Yok")}]");

            // Temizlik
            peUrunResim.Image = null;
            cmbRenkSec.SelectedIndex = -1;
        }

        private void BtnUrunKaydet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUrunModel.Text)) { XtraMessageBox.Show("Model adı boş olamaz!"); return; }
            if (string.IsNullOrEmpty(txtUrunFiyat.Text)) { XtraMessageBox.Show("Fiyat girmediniz!"); return; }

            try
            {
                decimal fiyat = Convert.ToDecimal(txtUrunFiyat.EditValue);
                urunYonetim.UrunEkle(
                    txtUrunModel.Text,
                    cmbUrunTur.Text,
                    cmbHammaddeTur.Text,
                    fiyat,
                    eklenecekVaryantlar
                );

                XtraMessageBox.Show("Ürün başarıyla kaydedildi.");
                FormuTemizle();
                UrunListesiniYenile();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Hata: " + ex.Message);
            }
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

        // --- YARDIMCI METODLAR ---

        private void OtomatikMesajOlustur()
        {
            string tip = cmbSorunTipi.Text;
            string sure = cmbSure.Text;
            string girilenYazi = txtArizaMakine.Text;

            if (string.IsNullOrEmpty(tip)) return;

            string mesaj = "";

            if (tip == "Makine Arızası")
            {
                string makineAdi = string.IsNullOrEmpty(girilenYazi) ? "bir makinemiz" : $"'{girilenYazi}'";
                mesaj = $"Sayın Müşterimiz,\n\nFabrikamızdaki {makineAdi} üzerinde yaşanan teknik bir arıza sebebiyle üretim planımızda aksamalar olmuştur.\n\nSiparişlerinizin teslimatı tahmini olarak {sure} gecikecektir.\n\nAnlayışınız için teşekkür ederiz.";
            }
            else
            {
                string sebep = string.IsNullOrEmpty(girilenYazi) ? "genel teknik aksaklıklar" : $"'{girilenYazi}'";
                mesaj = $"Sayın Müşterimiz,\n\nFabrikamızda yaşanan durum {sebep} nedeniyle üretim süreçlerimizde geçici yavaşlama olmuştur.\n\nSiparişlerinizde {sure} kadar gecikme yaşanabilir.\n\nAnlayışınız için teşekkür ederiz.";
            }
            memoOzurMesaji.Text = mesaj;
        }

        private void UrunListesiniYenile()
        {
            gcUrunListesi.DataSource = urunYonetim.UrunleriGetir();
            gvUrunListesi.BestFitColumns();
        }

        private void HammaddeListesiniYenile()
        {
            gcHammaddeListesi.DataSource = hammaddeYonetim.HammaddeleriGetir();
            gvHammaddeListesi.BestFitColumns();
        }

        private void FormuTemizle()
        {
            txtUrunModel.Text = "";
            txtUrunFiyat.Text = "";
            cmbUrunTur.SelectedIndex = -1;
            cmbHammaddeTur.SelectedIndex = -1;
            lstEklenenVaryantlar.Items.Clear();
            eklenecekVaryantlar.Clear();
            peUrunResim.Image = null;
        }
    }
}