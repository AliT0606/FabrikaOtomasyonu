using Fabrika_Otomasyonu;
using System;
using System.Windows.Forms;

namespace FabrikaOtomasyonu
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Veritabani.KurulumYap();

            Application.Run(new LoginScreen());
        }
    }
}
