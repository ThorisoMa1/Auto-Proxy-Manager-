using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using autoPchanger.DataAccess;
using autoPchanger.Presentation;
using System.Windows.Forms;


namespace autoPchanger.Business
{
    class WifiProxyHandler
    {
        static bool pause;
        static bool setProx;
        DataAccess.DataAccess da;
        static bool inUse;
        static bool stop;
        internal  static  bool recentConnection = Lists.recentConnection;//sets connection status
        public WifiProxyHandler()
        {
          
            
            inUse = false;
            da = DataAccess.DataAccess.Instance;//singlton method
            //will change proxy according to settings
            do
            {
                recentConnection = Lists.recentConnection;
                WlanAdapterDetails();
                stop = Lists.Stop;//sets it according to external variable
              
                
            } while (stop == false);
        }
        public static void WlanAdapterDetails()
        {
            string proxy;
            int port;
            string line;
            List<string> Deatils;
            List<WiFi> adapterInfo;
            //this makes usse of command  promt to  gather the users information but if you know of a better method please post it and the updates will be applied.
            List<string> data;
            //wil show the current network
            //is the command used in the prompt
            string command;
            //starts the process
            ProcessStartInfo info;
            pause = Lists.pause;
            if (!pause)
            {
                proxy = null;
                port = 0;
                line = "";
                 Deatils = new List<string>();
                 adapterInfo = new List<WiFi>();
                //this makes usse of command  promt to  gather the users information but if you know of a better method please post it and the updates will be applied.
                data = new List<string>();

                command = "/C netsh  wlan show interfaces";
                info = new ProcessStartInfo();

                info.WorkingDirectory = @"C:\Temp";
                info.FileName = @"C:\Windows\System32\cmd.exe";
                info.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                info.Arguments = command;
                info.CreateNoWindow = true;
                //Makes usre that the conosle windows out is printed into the program
                info.RedirectStandardOutput = true;
                info.UseShellExecute = false;
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.StartInfo = info;
                proc.Start();


                //Gave a set count in order to force it to capture the information
                for (int i = 0; i < 22; i++)
                {
                    line = proc.StandardOutput.ReadLine();
                    if (line != "" && line != null)
                    {

                        //in order to get rid of all the spaces
                        line = line.Replace(" ", "");
                        data.Add(line);
                    }

                }


                //this prints out the count of  data
                //cuts the string precisly
                for (int i = 1; i < data.Count; i++)
                {
                    data[i] = data[i].Substring(data[i].IndexOf(':') + 1);
                }


                //The wi fi object that will be compared to required proxy is bieng built
                adapterInfo.Add(new WiFi(data[6], data[5]));


                //this will first check if the wi fi is connected.
                if (WiFi.Status == "connected")
                {
                    if (recentConnection == false)
                    {

                        Lists.ssid = WiFi.SSID.ToLower();//sets ssd in lists
                        //recentConnection = true;
                        if (DataAccess.DataAccess.ProxyExists(WiFi.SSID.ToLower()))
                        {
                            //will set the proxy accoringly 
                            //now we check for proxyName
                            if (DataAccess.DataAccess.useProxyCheck(WiFi.SSID.ToLower()))
                            {

                                proxy = DataAccess.DataAccess.FetchProxySettings(WiFi.SSID.ToLower());//sets  proxy
                                port = DataAccess.DataAccess.FetchPort(WiFi.SSID.ToLower());


                               
                                ProxySet(proxy, port);
                               
                                //Thread.Sleep(5000);


                            }
                            else
                            {
                                ProxyDisable();
                                Lists.recentConnection = false;
                                recentConnection = Lists.recentConnection;
                            }
                        }
                        else
                        {
                            DataAccess.DataAccess.Insert_SSID(WiFi.SSID.ToLower());

                            inUse = Business.Lists.InUse;

                            //will add name to the proxyLIst
                            if (!inUse)
                            {
                                Business.Lists.InUse = true;
                                DialogResult r = MessageBox.Show("Use Proxy ?", "new network Detected", MessageBoxButtons.YesNo);
                                if (r == DialogResult.Yes)
                                {


                                    AddProxy(WiFi.SSID.ToLower());//dialig for new proxy addtion




                                }
                                else
                                {
                                    DataAccess.DataAccess.Insert_ProxyAndPort(null,null, WiFi.SSID.ToLower());
                                    Lists.recentConnection = true;
                                    recentConnection = Lists.recentConnection;//adds empty proxy that can be updated later to db
                                }
                            }



                            //ask to add to db
                        }
                    }
                    //if it  is connecte then it willl check if the ssid is the same as the required one

                }
                else
                {
                    Lists.recentConnection = false;
                   
                    ProxyDisable();
                }

            }
            
          
           


        }
        public static void ProxyDisable()
        {
            RegistryKey reg = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Internet settings", true);
            reg.SetValue("ProxyEnable", 000000000);
            reg.SetValue("ProxyServer", " :");

          
        }//disables proxy
        public static void ProxySet(string proxy,int port)
        {

            RegistryKey reg = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Internet settings", true);

            //sets proxyy config
            reg.SetValue("ProxyEnable", 000000001);

            reg.SetValue("ProxyServer",proxy+":"+port);//sets appropriate proxy
            Business.Lists.treyIcon.ShowNotification("proxy set");
            Lists.recentConnection = true;
            

        }//sets proxy
        public static  void AddProxy(string ssidName)
        {

           
            ProxySettings pts = new ProxySettings(ssidName);
            pts.ShowDialog();
            
        }
      
    }
}
