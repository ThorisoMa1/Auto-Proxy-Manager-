using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autoPchanger.Business
{
    class Lists
    {
        private static volatile bool stop;
        static readonly Lists instance = new Lists();
     
        public static volatile bool InUse;
        public static volatile bool pause;
        public static volatile ProxyTraySettings treyIcon;
        public static volatile string ssid;
        public static volatile bool recentConnection=false;





        public Lists()
        {
            Stop = false;
        }

        internal static Lists Instance
        {
            get
            {
                return instance;
            }
        }

        public static bool Stop
        {
            get
            {
                return stop;
            }

            set
            {
                stop = value;
            }
        }
    }
}
