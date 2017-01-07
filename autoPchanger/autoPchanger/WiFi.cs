using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autoPchanger
{
    public  class WiFi
    {
        #region fields
        string cipher;
        string name;
        private static string status;
        string description;
        Guid code;
        string physicalAdrress;
        string state;
        private static string sSID;

        public static string SSID
        {
            get { return WiFi.sSID; }
            set { WiFi.sSID = value; }
        }
        public static string Status
        {
            get { return WiFi.status; }
            set { WiFi.status = value; }
        }
        string bSSID;
        string networkType;
        string radioType;
        double channel;
        string signal;
        string authentication;
        string connectionMode;
        double uploadSpeed;
        double downloadSpeed;
        #endregion

        #region properties

        private string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string Description
        {
            get { return description; }
            set { description = value; }
        }
        private Guid Code
        {
            get { return code; }
            set { code = value; }
        }
        private string PhysicalAdrress
        {
            get { return physicalAdrress; }
            set { physicalAdrress = value; }
        }
        private string State
        {
            get { return state; }
            set { state = value; }
        }

        private string BSSID
        {
            get { return bSSID; }
            set { bSSID = value; }
        }
        private string NetworkType
        {
            get { return networkType; }
            set { networkType = value; }
        }
        private string RadioType
        {
            get { return radioType; }
            set { radioType = value; }
        }


        private string Authentication
        {
            get { return authentication; }
            set { authentication = value; }
        }


        private string Cipher
        {
            get { return cipher; }
            set { cipher = value; }
        }


        private string ConnectionMode
        {
            get { return connectionMode; }
            set { connectionMode = value; }
        }


        private double Channel
        {
            get { return channel; }
            set { channel = value; }
        }


        private double DownloadSpeed
        {
            get { return downloadSpeed; }
            set { downloadSpeed = value; }
        }


        private double UploadSpeed
        {
            get { return uploadSpeed; }
            set { uploadSpeed = value; }
        }


        private string Signal
        {
            get { return signal; }
            set { signal = value; }
        }



        #endregion
        //this method returns the ssid of the network to preform the check
        public WiFi(string SSID, string Status)
        {
            sSID = SSID;
            status = Status;
        }

        //this goes hand in hand with the top
        public string SSname()
        {
            string ssName = sSID;
            return ssName;
        }
        

    }
}
