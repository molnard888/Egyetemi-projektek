using MySql.Data.MySqlClient;
using System;

namespace Raktarkezelo
{
    public static class MySQLadapter
    {
        public static MySqlConnection CreateDbConnection()
        {
            
            string MySQLConnString =
                "datasource=192.168.0.111;" +
                "port=3306;" +
                "username=Admin;" +
                "database=raktarkezelo";
            
            return new MySqlConnection(MySQLConnString);
        }


        //string MySQLConnString = "datasource=192.168.43.138;port=3306;username=Admin;database=raktarkezelo";

        public static string ExecuteSqlCommand(string _sqlcommand, string _process, string _details)
        {
            string returnString = "";
            MySqlConnection databaseConn = null;
            try
            {
                databaseConn = MySQLadapter.CreateDbConnection();
                MySqlCommand SqlExecuteCommand = new MySqlCommand(_sqlcommand, databaseConn);
                SqlExecuteCommand.CommandTimeout = 60;

                databaseConn.Open();
                int rowCount = SqlExecuteCommand.ExecuteNonQuery();

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
                returnString = "Hiba:\n"+exception.Message;
                if (databaseConn != null)
                {
                    databaseConn.Close();
                }
                Class_Logging.WriteToLogFile(exception.Message);
            }
            return returnString;
        }
    }
}