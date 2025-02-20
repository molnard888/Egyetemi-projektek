using System;
using System.Collections.Generic;
using System.Text;
using MySqlConnector;
using Xamarin.Essentials;
using Xamarin.Forms.PlatformConfiguration;

namespace T_2_OXOOBF
{
    public static class Class_Common
    {
        

        private static string loggedInUser = null;
        private static string storageIDforUser = null;
        public static List<Class_Termek> CartItems = new List<Class_Termek>();
        public static string EladasokSelectedSales;


        public static void setLoggedInUser(string username)
        {
            loggedInUser = username;
            setStorageIDforUser();
            Class_Logging.InsertLogToDb("Signed In", DeviceInfo.Name);
        }
        public static string getLoggedInUser()
        {
            return loggedInUser;
        }

        

        public static void setStorageIDforUser()
        {
            
            MySqlConnection databaseConn = new MySqlConnection(MySQLadapter.builder.ConnectionString);
            string queryString = "SELECT StorageID FROM users WHERE Username like '" + Class_Common.getLoggedInUser() + "'"; 
            MySqlCommand commandSelectedProdQuantity = new MySqlCommand(queryString, databaseConn);
            commandSelectedProdQuantity.CommandTimeout = 60;

            try
            {
                databaseConn.Open();
                MySqlDataReader myReader = commandSelectedProdQuantity.ExecuteReader();

                if (myReader.HasRows) // Ha jó az input
                {
                    while (myReader.Read())
                    {
                        storageIDforUser = myReader.GetInt16(0).ToString();
                        if (String.IsNullOrEmpty(storageIDforUser) || String.IsNullOrWhiteSpace(storageIDforUser))
                        {
                            throw new Exception();
                        }
                        
                    }
                }
                databaseConn.Close();
                
            }
            catch (Exception exception)
            {
                string ErrorString = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " - Error during getting StorageID from Database for "+getLoggedInUser()+": " + exception.Message;
                Class_Logging.WriteToLogFile(ErrorString);
            }

        }

        public static string getStorageIDforUser()
        {
            return storageIDforUser;
        }

        public static void LogOutWriteToDb()
        {
            string LogDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string queryString_InsertLog = "INSERT INTO raktarkezelo.log (Storage, UserName, DateTime, Proc, Details) VALUES ((SELECT StorageID FROM users WHERE Username like '"+ Class_Common.getLoggedInUser() + "'), '" + Class_Common.getLoggedInUser() + "', '"
                                           + LogDateTime + "', '" + "Signed Out" + "', '" + DeviceInfo.Name + "');";
            Class_Logging.InsertLogToDb("Signed Out", DeviceInfo.Name);
            loggedInUser = null;
            storageIDforUser = null;
        }
    }
}
