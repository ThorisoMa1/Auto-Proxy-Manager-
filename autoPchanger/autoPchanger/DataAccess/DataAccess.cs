using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.SQLite;

namespace autoPchanger.DataAccess
{
    class DataAccess
    {

        private static string query;
        static string conString="";
        static SQLiteCommand comm;
        static SQLiteConnection conn;
        private static DataTable dt;
        private static DataAccess instance = new DataAccess();
        private static SQLiteDataReader sda;
        private string dbPath;

        internal static DataAccess Instance
        {
            get
            {
                return instance;
            }

            set
            {
                instance = value;
            }
        }

        public DataAccess()
        {
            
            dbPath =  Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "AutoProxyManagerDB.db");
            conString = "Data Source="+ dbPath+"; Version=3";
            conn = new SQLiteConnection(conString);
            
           
             dt = new DataTable();

            try
            {

                conn.Open();
               

                
            }
            catch (SQLiteException r)
            {
                string e = r.Message.ToString();
               //not done   
            }
            finally 
            {
                //closes the connection
                conn.Close();
            }
       
        }



        public static bool ProxyExists(string SsIdName)
        {
           

            query = "SELECT Ssid_ID FROM SSID WHERE SsidName='"+ SsIdName+"'";
            int ID=0;
            try
            {
                conn.Open();
                comm = new SQLiteCommand(query, conn);
                sda = comm.ExecuteReader();
               // bool check = sda.IsClosed;
                while(sda.Read())
                {
                    ID = int.Parse(sda["Ssid_ID"].ToString());
                  
                }
                if (ID == 0)
                {
                    return false;
                }
            }
            catch (SQLiteException e)
            {
                string s = e.Message.ToString();
                return false;
            }
            finally
            {
                conn.Close();
            }
          
            

            return true;
        }//checks of  db contains it
        public static bool useProxyCheck(string SsIdName)
        {
           
            
            query = "SELECT UseProxy FROM SSID WHERE SsidName = '" + SsIdName + "'";
            try
            {
                

                conn.Open();
                comm = new SQLiteCommand(query, conn);
                sda = comm.ExecuteReader();


                while (sda.Read())
                {
                    if (int.Parse(sda["UseProxy"].ToString()) == 0)
                    {
                        return false;
                    }
                }
                  
              

            }
            catch (SQLiteException e)
            {
                string s = e.Message.ToString();
                return false;
            }
            finally
            {
                conn.Close();
            }
            return true;
        }//checks if proxy is  to be used
        public static bool SetProxyCheck(bool choice)
        {
            return false;
        }//checks if proxy is  to be used
        public static string FetchProxySettings(string ssIdName)
        {
            string prox = null;

            query = "SELECT ProxyName FROM Proxies WHERE ProxyID IN (SELECT ProxyID FROM SSID WHERE SsidName= '"+ ssIdName+ "' )";
            try
            {


                conn.Open();
                comm = new SQLiteCommand(query, conn);
                sda = comm.ExecuteReader();


                while (sda.Read())
                {
                    prox=sda["ProxyName"].ToString();
                   
                }
                


            }
            catch (SQLiteException e)
            {
                string s = e.Message.ToString();
                
            }
            finally
            {
                conn.Close();
            }
            return prox;
        }
        public static int FetchPort(string ssIdName)
        {
            int port = 0;

            query = "SELECT ProxyPort FROM Proxies WHERE ProxyID IN (SELECT ProxyID FROM SSID WHERE SsidName= '" + ssIdName + "' )";
            try
            {


                conn.Open();
                comm = new SQLiteCommand(query, conn);
                sda = comm.ExecuteReader();


                while (sda.Read())
                {
                    port = int.Parse(sda["ProxyPort"].ToString());

                }
              


            }
            catch (SQLiteException e)
            {
                string s = e.Message.ToString();

            }
            finally
            {
                conn.Close();
            }
            return port;
        }//gets port

        public static bool Insert_SSID(string SSIDaAme)
        {
            int result;
          

            query = "INSERT INTO SSID(SsidName, ProxyID) VALUES('"+ SSIDaAme+"', NULL)";

            try
            {


                conn.Open();
                comm = new SQLiteCommand(query, conn);
                result= comm.ExecuteNonQuery();

                if (result < 1)
                {
                    return false ;
                }


            }
            catch (SQLiteException e)
            {
                string s = e.Message.ToString();

            }
            finally
            {
                conn.Close();
            }
            return true;
        }//insert new 
        public static bool Update_Proxy(string ssIdName,string proxy,string port)
        {
            int ID = GetSSID(ssIdName);
            string query3;

            if (string.IsNullOrEmpty(proxy)&&string.IsNullOrEmpty(port))
            {
                query3 = "UPDATE `SSID` SET `UseProxy`= " + 0 + " WHERE SsidName = '" + ssIdName + "'"; 
            }
            else
            {
                query3 = "UPDATE `SSID` SET `UseProxy`= " + 1 + " WHERE SsidName = '" + ssIdName + "'";

            }
            query = "UPDATE Proxies SET ProxyName ='"+ proxy+"' WHERE ProxyID ="+ ID;

            string q2= "UPDATE Proxies SET ProxyPort ='" + port + "' WHERE ProxyID ="+ ID;

            try
            {


                //conn.Open();
                comm = new SQLiteCommand(query, conn);
                sda = comm.ExecuteReader();

                //executes second update

                comm = new SQLiteCommand(q2, conn);
                sda = comm.ExecuteReader();

                comm = new SQLiteCommand(query3, conn);
                sda = comm.ExecuteReader();






            }
            catch (SQLiteException e)
            {
                string s = e.Message.ToString();
                return false;

            }
            finally
            {
                conn.Close();
            }
            return true; 
        }//gets port

        public static bool Insert_ProxyAndPort(string Proxy,string port,string SSID)
        {
            int useProx=0;
            int result;

            if (string.IsNullOrEmpty(Proxy) || string.IsNullOrEmpty(port))
            {
                Proxy = " ";
                port = " ";

            }
            else
            {
                useProx = 1;
            }

            query = " INSERT INTO Proxies(ProxyName,ProxyPort) VALUES ('"+Proxy+"','"+port+"')";

            try
            {


                conn.Open();
                comm = new SQLiteCommand(query, conn);
                result = comm.ExecuteNonQuery();

                if (result < 1)
                {
                    return false;
                }

               
               
                

            }
            catch (SQLiteException e)
            {
                string s = e.Message.ToString();

            }
            finally
            {
                conn.Close();
            }


            if (useProx == 0)
            {
                inserProxyIDDiabledProxy(GetProxyIDRevised(), SSID, useProx);
            }
            else
            {
                inserProxyID(GetProxyIDRevised(), SSID);
            }
            return true;
        }//insert new SSID
        private static int GetProxyID(string Proxy, string port)
        {
            
            int ID=0;

            query = " SELECT ProxyID FROM Proxies WHERE ProxyName = '"+Proxy+"' AND ProxyPort ="+ port+"";

            try
            {


                conn.Open();
                comm = new SQLiteCommand(query, conn);
                sda = comm.ExecuteReader();


                while (sda.Read())
                {
                    ID = int.Parse(sda["ProxyID"].ToString());

                }


            }
            catch (SQLiteException e)
            {
                string s = e.Message.ToString();

            }
            finally
            {
                conn.Close();
            }
          
            return ID;
        }//Gets reccently inserted prox ID
        private static int GetProxyIDRevised()
        {

            int ID = 0;

            query = " SELECT MAX(rowId) as Rowid FROM proxies";

            try
            {


                conn.Open();
                comm = new SQLiteCommand(query, conn);
                sda = comm.ExecuteReader();


                while (sda.Read())
                {
                    ID = int.Parse(sda["Rowid"].ToString());

                }


            }
            catch (SQLiteException e)
            {
                string s = e.Message.ToString();

            }
            finally
            {
                conn.Close();
            }
            return ID;
        }//Gets reccently inserted prox ID
        private static int GetSSID(string ssID)
        {

            int ID = 0;

            query = " SELECT ProxyID FROM SSID WHERE SsidName = '" + ssID.ToLower() +"'";

            try
            {


                 conn.Open();
                comm = new SQLiteCommand(query, conn);
                sda = comm.ExecuteReader();


                while (sda.Read())
                {
                    string s= sda["ProxyID"].ToString();
                    ID = int.Parse(sda["ProxyID"].ToString());

                }


            }
            catch (SQLiteException e)
            {
                string s = e.Message.ToString();

            }

            return ID;
        }//Gets SSID




        private static bool inserProxyID(int ID,string ssIDNAME)
        {
            int result;


            query = "UPDATE `SSID` SET `ProxyID`="+ ID +" WHERE SsidName='"+ssIDNAME+"'";

            try
            {


                conn.Open();
                comm = new SQLiteCommand(query, conn);
                result = comm.ExecuteNonQuery();

                if (result < 1)
                {
                    return false;
                }



            }
            catch (SQLiteException e)
            {
                string s = e.Message.ToString();

            }
            finally
            {
                conn.Close();
            }
           
            return true;
        }
        private static bool inserProxyIDDiabledProxy(int ID, string ssIDNAME,int useProxy)
        {
            int result;
            string query2;


            query2 = "UPDATE `SSID` SET `UseProxy`= " + useProxy + " WHERE SsidName = '" + ssIDNAME + "'";
            query = "UPDATE `SSID` SET `ProxyID`=" + ID + " WHERE SsidName='" + ssIDNAME + "'";

            try
            {


                conn.Open();
                comm = new SQLiteCommand(query, conn);
                result = comm.ExecuteNonQuery();

                if (result < 1)
                {
                    return false;
                }

                comm = new SQLiteCommand(query2, conn);
                result = comm.ExecuteNonQuery();

                if (result < 1)
                {
                    return false;
                }

            }
            catch (SQLiteException e)
            {
                string s = e.Message.ToString();

            }
            finally
            {
                conn.Close();
            }

            return true;
        }







        #region logonForm Validatoin
        #endregion





    }
}
