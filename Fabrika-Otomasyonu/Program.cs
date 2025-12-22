using System;
using System.Windows.Forms;
using DevExpress.Skins; // Skin yönetimi için gerekli

namespace Fabrika_Otomasyonu
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            // BonusSkins satırını kaldırdım (DLL hatası vermemesi için)
            // Standart temalar yine çalışacaktır.
            SkinManager.EnableFormSkins();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // DÜZELTME: Metodun yeni adı "TablolariKur"
            Veritabani.TablolariKur();

            // Login ekranını başlat
            Application.Run(new LoginScreen());
        }
    }
}