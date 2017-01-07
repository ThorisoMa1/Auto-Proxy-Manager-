using autoPchanger.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using autoPchanger.Business;
using System.Diagnostics;

namespace autoPchanger.Business
{
    class ProxyTraySettings:IDisposable
    {
        readonly  NotifyIcon the_Icon;

        public NotifyIcon The_Icon
        {
            get
            {
                return the_Icon;
            }
        }

        public ProxyTraySettings()
        {
          this.the_Icon= new NotifyIcon();
           
        }
        
      

        public void Display()
        {
            // Put the icon in the system tray and allow it react to mouse clicks.			
            The_Icon.MouseClick += new MouseEventHandler(the_icon_MouseClick);
            The_Icon.Icon = Resources.computer;
            The_Icon.Text = "Proxy Application";
            The_Icon.Visible = true;
            The_Icon.ContextMenuStrip = new ContetMenu().Create();//creates  the emnu

        }
        public void ScanForWlan()
        {
            Lists c = Lists.Instance;//uses singlton method

            WifiProxyHandler h = new WifiProxyHandler();//starts the check process
            
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        public void Dispose()
        {

              The_Icon.Dispose();
         }

        void the_icon_MouseClick(object sender, MouseEventArgs e)
        {
            // Handle mouse button clicks.
            if (e.Button == MouseButtons.Left)
            {
                //will do something
            }
        }
        public  void ShowNotification(string type)
        {
            string title =null;
            string text=null ;
            switch (type)
            {
                case "paused":
                    title = "Paused";
                    text = "not manageing your proxy";
                    break;
                case "resuming":
                    title = "Resuming";
                    text = "Will now get back to management";
                    break;
                case "new network":
                    title = "Network Detected";
                    text = "Your connected to a new network";
                    break;
                case "update":
                    title = "update applied";
                    text = "Your changes were saved";
                    break;
                case "proxy set":
                    title = "Proxy Set";
                    text = "Your proxy has been set";
                    break;
                case "exit":
                    title = "Exiting application";
                    text = "Proxy manager is  going to sleep";
                    break;
            }
           
            //the_Icon.ShowBalloonTip.text = "test";
            The_Icon.ShowBalloonTip(10000,title, text,ToolTipIcon.Info);
        }
        void Pause_Click(object sender, EventArgs e)
        {


            
           ShowNotification("paused");



        }
    }
}
