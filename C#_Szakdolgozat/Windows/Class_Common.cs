using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raktarkezelo
{
    public static class Class_Common
    {
        
        private static string LoggedInUser = null;
        private static string storageIDforUser = null;
        public static List<Class_Termek> CartItems = new List<Class_Termek>();

        public static void setLoggedInUser(string username)
        {
            if(username == null)
            {
                LoggedInUser = null;
                storageIDforUser = null;
            }
            else
            {
                LoggedInUser = username;
                setStorageIDforUser();
            }
            

        }
        public static string getLoggedInUser()
        {
            return LoggedInUser;
        }



        public static void setStorageIDforUser()
        {

            MySqlConnection databaseConn = MySQLadapter.CreateDbConnection();
            string queryString = "SELECT StorageID FROM users WHERE Username like '" + Class_Common.getLoggedInUser() + "'";
            MySqlCommand SqlSelectCommand = new MySqlCommand(queryString, databaseConn);
            SqlSelectCommand.CommandTimeout = 60;

            try
            {
                databaseConn.Open();
                MySqlDataReader myReader = SqlSelectCommand.ExecuteReader();

                if (myReader.HasRows) // Ha jó az input
                {
                    while (myReader.Read())
                    {
                        storageIDforUser = myReader.GetInt16(0).ToString();

                        if (String.IsNullOrEmpty(storageIDforUser) || String.IsNullOrWhiteSpace(storageIDforUser))
                        {
                            throw new Exception("A felhasználóhoz tartozó lekért raktárID üres.");
                        }

                    }
                }
                databaseConn.Close();

            }
            catch (Exception exception)
            {
                string ErrorString = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " - Error during getting StorageID from Database for "
                    + getLoggedInUser() + ": " + exception.Message;
                Class_Logging.WriteToLogFile(ErrorString);
            }

        }

        public static string getStorageIDforUser()
        {
            return storageIDforUser;
        }

        public static void LogOutWriteToDb()
        {
            Class_Logging.InsertLogToDb("Signed Out", Environment.MachineName);
        }
    }
}
