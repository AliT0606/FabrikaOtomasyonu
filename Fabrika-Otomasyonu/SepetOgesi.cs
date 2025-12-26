using System.Drawing;

namespace Fabrika_Otomasyonu
{
    // Sepetteki her bir satırı temsil eder
    public class SepetOgesi
    {
        public int UrunId { get; set; }
        public string ModelAd { get; set; }
        public string Renk { get; set; }
        public int TakimSayisi { get; set; } // Kaç takım?
        public decimal BirimFiyat { get; set; } // 1 Takım Fiyatı
        public decimal ToplamTutar { get; set; } // Takım * Adet
        public Image UrunResmi { get; set; } // Listede gözükecek resim
        public string TamBilgi
        {
            get
            {
                return $"{ModelAd}\nRenk: {Renk}\nBirim Fiyat: {BirimFiyat:C2}";
            }
        }
    }

}