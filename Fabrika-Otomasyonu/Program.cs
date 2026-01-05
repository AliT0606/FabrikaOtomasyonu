using System;
using System.Windows.Forms;
using DevExpress.Skins;

namespace Fabrika_Otomasyonu
{
    static class Program
    {
        /// <summary>
        /// Uygulamanın ana giriş noktası.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // DevExpress Tema Ayarları
            SkinManager.EnableFormSkins();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Veritabanı ve tabloların kurulumunu/kontrolünü yap
            Veritabani.TablolariKur();

            // Giriş ekranı ile uygulamayı başlat
            Application.Run(new LoginScreen());
        }
    }
}