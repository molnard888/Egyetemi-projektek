using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace T_2_OXOOBF
{
    public static class MySQLadapter
    {
        public static MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder
        {
            Server = "192.168.0.111",
            Port = 3306,
            Database = "raktarkezelo",
            UserID = "Admin"
        };

        public static string ExecuteSqlCommand(string _sqlcommand, string _process, string _details)
        {
            string returnString = "";
            MySqlConnection databaseConn = null;
            try
            {
                databaseConn = new MySqlConnection(builder.ConnectionString);
                MySqlCommand SqlSelectCommand = new MySqlCommand(_sqlcommand, databaseConn);
                SqlSelectCommand.CommandTimeout = 60;

                databaseConn.Open();
                int rowCount = SqlSelectCommand.ExecuteNonQuery();

                if (rowCount > 0)
                {
                    returnString = "A művelet sikeres!";
                    Class_Logging.InsertLogToDb(_process, _details);
                }
                else
                {
                    returnString = "A művelet sikertelen!";
                }
                databaseConn.Close();
            }
            catch (Exception exception)
            {
                returnString = "Hiba:\n" + exception.Message;
                if (databaseConn != null)
                {
                    databaseConn.Close();
                }
                Class_Logging.WriteToLogFile(exception.Message);
            }
            return returnString;
        }

        public static bool IsDatabaseContains(string queryString)
        {
            bool isDatabaseContains = false;
            MySqlConnection databaseConn = new MySqlConnection(MySQLadapter.builder.ConnectionString);
            MySqlCommand commandGetLogsFromDB = new MySqlCommand(queryString, databaseConn);
            commandGetLogsFromDB.CommandTimeout = 60;
            try
            {
                databaseConn.Open();
                MySqlDataReader myReader = commandGetLogsFromDB.ExecuteReader();

                if (myReader.HasRows) // Ha jó az input
                {
                    isDatabaseContains = true;
                }
                databaseConn.Close();
            }
            catch (Exception exception)
            {
                databaseConn.Close();
                string ErrorString = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " - Error getting info from DB: " + exception.Message;
                Class_Logging.WriteToLogFile(ErrorString);
            }
            return isDatabaseContains;
        }



    }

}
