using System.Drawing;

namespace Fabrika_Otomasyonu
{
    /// <summary>
    /// Sepete eklenen her bir ürün satırını temsil eden veri modeli.
    /// </summary>
    public class SepetOgesi
    {
        public int UrunId { get; set; }// Ürünün Idsi 
        public string ModelAd { get; set; }// Ürünün modeli
        public string Renk { get; set; }// Ürünün Rengi
        public string AnaHammadde { get; set; } // Ürünün ham maddesi 

        /// <summary>
        /// Sepette bu üründen kaç takım var?
        /// </summary>
        public int TakimSayisi { get; set; }

        /// <summary>
        /// Ürünün birim takım fiyatı.
        /// </summary>
        public decimal BirimFiyat { get; set; }

        /// <summary>
        /// Toplam Tutar = Birim Fiyat * Takım Sayısı
        /// </summary>
        public decimal ToplamTutar { get; set; }

        public Image UrunResmi { get; set; } // Grid'de gösterilecek görsel

        /// <summary>
        /// Listelerde veya raporlarda kullanılacak özet metin.
        /// </summary>
        public string TamBilgi
        {
            get
            {
                return $"{ModelAd}\nRenk: {Renk}\nBirim Fiyat: {BirimFiyat:C2}";
            }
        }
    }
}