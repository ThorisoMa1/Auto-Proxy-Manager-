using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using autoPchanger.Business;
using System.Threading;

namespace autoPchanger
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //main area
            ProxyTraySettings pts;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            //sets trey app
            pts = new ProxyTraySettings();
            Thread t = new Thread(pts.ScanForWlan);//starts scanning process



            //displays everything in toolbar
            pts.Display();
            Business.Lists.treyIcon = pts;//sets to current instance
            t.Start();//starts thread

           
            Application.Run(); // Make sure the application runs!





        }
    }
}
