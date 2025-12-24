
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
        BildirimYonetimi bildirimYonetim = new BildirimYonetimi();
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
            // Dropdown (Seçim kutusu) içlerini dolduralım
            cmbHammaddeTur.Properties.Items.AddRange(new object[] { "Deri", "Emitasyon", "Kumaş", "Süet", "Rugan" });
            cmbHamTur.Properties.Items.AddRange(new object[] { "Deri", "Emitasyon", "Kumaş", "Süet", "Rugan", "Taban" });

            // --- YENİ AYARLAR ---

            // 1. Mesaj kutusuna elle yazmayı kapat (Sadece kopyalanabilir olur)
            memoOzurMesaji.Properties.ReadOnly = true;

            // 2. Başlangıçta Makine/Sorun kutusu gizli olsun, seçim yapınca açılsın
            lblArizaMakine.Visible = false;
            txtArizaMakine.Visible = false;

            // 3. Panel Sayfa Açılınca Ortada Dursun
            // Sayfa boyutu değişirse panel hep ortada kalsın diye olay ekliyoruz
            pageMakineler.SizeChanged += (s, e) =>
            {
                groupArizaBildirim.Location = new Point(
                    (pageMakineler.Width - groupArizaBildirim.Width) / 2,
                    (pageMakineler.Height - groupArizaBildirim.Height) / 2
                );
            };
        }

        // ... Diğer OlaylariBagla ve Buton metodları AYNI (önceki koddan devam) ...
        private void OlaylariBagla()
        {
            // -----------------------------------------------------------
            // 1. SOL MENÜ GEÇİŞLERİ
            // -----------------------------------------------------------
            accordionControl1.ElementClick += (s, e) =>
            {
                // Sadece alt elemanlara (Item) tıklayınca çalışsın
                if (e.Element.Style == DevExpress.XtraBars.Navigation.ElementStyle.Item)
                {
                    lblBaslik.Text = e.Element.Text; // Başlığı güncelle

                    switch (e.Element.Name)
                    {
                        case "elmUrunler":
                            navFrameYonetici.SelectedPage = pageUrunler;
                            UrunListesiniYenile();
                            break;

                        case "elmMakineler":
                            // Arıza Paneli Sayfası
                            navFrameYonetici.SelectedPage = pageMakineler;
                            // Sayfa açılınca paneli tekrar ortalayalım (garanti olsun)
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
                            // SiparisleriYenile(); // Sipariş kodlarını eklediysen aç
                            break;
                    }
                }
            };

            // -----------------------------------------------------------
            // 2. ARIZA VE SORUN BİLDİRİM PANELİ (GÜNCELLENMİŞ HALİ)
            // -----------------------------------------------------------

            // A) Sorun Tipi Seçilince: Yazılar ve İpuçları Değişsin
            cmbSorunTipi.SelectedIndexChanged += (s, e) =>
            {
                // Kutuları her halükarda görünür yap
                lblArizaMakine.Visible = true;
                txtArizaMakine.Visible = true;

                if (cmbSorunTipi.Text == "Makine Arızası")
                {
                    // Makine seçildiyse
                    lblArizaMakine.Text = "Arızalı Makine Adı:";
                    txtArizaMakine.Properties.NullValuePrompt = "Örn: Kesim Makinesi 2"; // İpucu
                }
                else
                {
                    // Diğer sorun seçildiyse
                    lblArizaMakine.Text = "Sorun Başlığı:"; // Etiket değişti
                    txtArizaMakine.Properties.NullValuePrompt = ""; // İpucu kalktı
                }

                // İçini temizle ki eski yazı kalmasın
                txtArizaMakine.Text = "";
                OtomatikMesajOlustur(); // Mesajı da güncelle
            };

            // B) Makine Adı Yazıldıkça veya Süre Seçildikçe Mesajı Güncelle
            txtArizaMakine.EditValueChanged += (s, e) => OtomatikMesajOlustur();
            cmbSure.SelectedIndexChanged += (s, e) => OtomatikMesajOlustur();

            // C) BİLDİRİM GÖNDER BUTONU
            btnBildirimGonder.Click += (s, e) =>
            {
                if (string.IsNullOrEmpty(memoOzurMesaji.Text))
                {
                    XtraMessageBox.Show("Mesaj içeriği oluşmadı, lütfen bilgileri seçin!", "Uyarı");
                    return;
                }

                if (XtraMessageBox.Show("Bu bildirim yayınlansın mı?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    bildirimYonetim.BildirimGonder("⚠️ Fabrika Durum Bildirimi", memoOzurMesaji.Text);

                    XtraMessageBox.Show("Bildirim başarıyla yayınlandı.", "Başarılı");

                    // Temizle
                    memoOzurMesaji.Text = "";
                    cmbSure.SelectedIndex = -1;
                    txtArizaMakine.Text = "";
                    cmbSorunTipi.SelectedIndex = -1;

                    // Paneli eski haline getir (Gizle)
                    lblArizaMakine.Visible = false;
                    txtArizaMakine.Visible = false;
                }
            };

            // -----------------------------------------------------------
            // 3. DİĞER BUTONLAR (ÜRÜN VE HAMMADDE)
            // -----------------------------------------------------------

            // Resim Seçme
            peUrunResim.Click += (s, e) =>
            {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.Filter = "Resim|*.jpg;*.jpeg;*.png;";
                    if (ofd.ShowDialog() == DialogResult.OK) peUrunResim.Image = Image.FromFile(ofd.FileName);
                }
            };

            // Hammadde Tür Seçimi (Birim Ayarı)
            cmbHamTur.SelectedIndexChanged += (s, e) =>
            {
                if (cmbHamTur.EditValue == null) return;
                if (cmbHamTur.Text == "Taban") cmbHamBirim.SelectedItem = "Adet";
                else cmbHamBirim.SelectedItem = "m² (Metrekare)";
                cmbHamBirim.Enabled = false;
            };

            // Buton Tıklamalarını Metodlara Bağla
            btnRenkEkle.Click += BtnRenkEkle_Click;
            btnUrunKaydet.Click += BtnUrunKaydet_Click;
            btnUrunKaldir.Click += BtnUrunKaldir_Click;
            btnHammaddeEkle.Click += BtnHammaddeEkle_Click;
        }

        // ... Buton Click Metodları (BtnUrunKaldir_Click vs.) AYNI ...
        private void BtnUrunKaldir_Click(object sender, EventArgs e)
        {
            var row = gvUrunListesi.GetFocusedDataRow(); // Seçili satırı al

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
                    urunYonetim.UrunSil(id); // Veritabanından sil
                    UrunListesiniYenile(); // Listeyi güncelle
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
            if (cmbRenkSec.EditValue == null) { XtraMessageBox.Show("Renk seçiniz!"); return; }
            var resim = peUrunResim.Image;
            var yeni = new GeciciVaryant { Renk = cmbRenkSec.Text, GorselResim = resim, ResimData = urunYonetim.ResimToByte(resim) };
            eklenecekVaryantlar.Add(yeni);
            lstEklenenVaryantlar.Items.Add($"{yeni.Renk} - [Görsel: {(resim != null ? "Var" : "Yok")}]");
            peUrunResim.Image = null; cmbRenkSec.SelectedIndex = -1;
        }

        private void BtnUrunKaydet_Click(object sender, EventArgs e)
        {
            // Kontroller
            if (string.IsNullOrEmpty(txtUrunModel.Text)) { XtraMessageBox.Show("Model adı boş olamaz!"); return; }
            if (string.IsNullOrEmpty(txtUrunFiyat.Text)) { XtraMessageBox.Show("Fiyat girmediniz!"); return; }

            try
            {
                // Fiyat metnini sayıya çevir (TL işaretini temizler)
                decimal fiyat = Convert.ToDecimal(txtUrunFiyat.EditValue);

                // Parametreleri gönder
                urunYonetim.UrunEkle(
                    txtUrunModel.Text,
                    cmbUrunTur.Text,
                    cmbHammaddeTur.Text,
                    fiyat, // YENİ
                    eklenecekVaryantlar
                );

                XtraMessageBox.Show("Ürün başarıyla kaydedildi.");

                // Temizlik ve Yenileme
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
        private void OtomatikMesajOlustur()
        {
            // Verileri al
            string tip = cmbSorunTipi.Text;
            string sure = cmbSure.Text;
            string girilenYazi = txtArizaMakine.Text; // Hem makine adı hem de sorun başlığı burası

            // Eğer tip seçilmediyse işlem yapma
            if (string.IsNullOrEmpty(tip)) return;

            string mesaj = "";

            if (tip == "Makine Arızası")
            {
                // Makine adı boşsa "bir makinemiz", doluysa "'Kesim Makinesi'" yazar
                string makineAdi = string.IsNullOrEmpty(girilenYazi) ? "bir makinemiz" : $"'{girilenYazi}'";

                mesaj = $"Sayın Müşterimiz,\n\nFabrikamızdaki {makineAdi} üzerinde yaşanan teknik bir arıza sebebiyle üretim planımızda aksamalar olmuştur.\n\nSiparişlerinizin teslimatı tahmini olarak {sure} gecikecektir.\n\nAnlayışınız için teşekkür ederiz.";
            }
            else // Diğer Sorun
            {
                // BURAYI DÜZELTTİK: Senin yazdığın yazıyı mesaja ekliyoruz
                // Eğer boşsa "genel aksaklık" yazar, doluysa senin yazdığını (örn: Fabrika genel izin) yazar.
                string sebep = string.IsNullOrEmpty(girilenYazi) ? "genel teknik aksaklıklar" : $"'{girilenYazi}'";

                mesaj = $"Sayın Müşterimiz,\n\nFabrikamızda yaşanan durum {sebep} nedeniyle üretim süreçlerimizde geçici yavaşlama olmuştur.\n\nSiparişlerinizde {sure} kadar gecikme yaşanabilir.\n\nAnlayışınız için teşekkür ederiz.";
            }

            // Mesajı kutuya bas
            memoOzurMesaji.Text = mesaj;
        }

        private void UrunListesiniYenile() 
        { gcUrunListesi.DataSource = urunYonetim.UrunleriGetir(); 
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
            txtUrunFiyat.Text = ""; // Fiyatı temizle
            cmbUrunTur.SelectedIndex = -1;
            cmbHammaddeTur.SelectedIndex = -1;
            lstEklenenVaryantlar.Items.Clear();
            eklenecekVaryantlar.Clear();
            peUrunResim.Image = null;
        }
    }
}
