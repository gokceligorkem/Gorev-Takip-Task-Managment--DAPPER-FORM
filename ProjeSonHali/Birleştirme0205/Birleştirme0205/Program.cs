using Birleştirme0205.AdminSayfa;
using Birleştirme0205.KullanıcıSayfa;
using DevExpress.XtraPrinting.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Birleştirme0205
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new KullanıcıSayfa.KullanıcıSayfa());
            //Application.Run(new AnaSayfa());
            Application.Run(new Form1());
        }
    }
}
