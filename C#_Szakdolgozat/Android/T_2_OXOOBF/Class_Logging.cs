using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MySqlConnector;

namespace T_2_OXOOBF
{
    public static class Class_Logging
    {

        

        public static void InsertLogToDb(string _process, string _details)
        {
            string LogDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string queryString_InsertLog = "INSERT INTO raktarkezelo.log (Storage, UserName, DateTime, Proc, Details) VALUES ('" + Class_Common.getStorageIDforUser() + "', '" + Class_Common.getLoggedInUser() + "', '"
                                       + LogDateTime + "', '" + _process + "', '" + _details + "');";
            MySqlConnection databaseConn = null;

            try
            {
                databaseConn = new MySqlConnection(MySQLadapter.builder.ConnectionString);
                MySqlCommand commandInsertLog = new MySqlCommand(queryString_InsertLog, databaseConn);
                commandInsertLog.CommandTimeout = 60;
                databaseConn.Open();
                MySqlDataReader LogInserter;
                LogInserter = commandInsertLog.ExecuteReader();
                while (LogInserter.Read())
                {
                }
                LogInserter.Close();
                databaseConn.Close();
            }
            catch (Exception exception)
            {
                App.Current.MainPage.DisplayAlert("Error:", exception.Message, "OK");
                //MessageBox.Show("Error: " + exception.Message);
                string ErrorString = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " - Error during Inserting log to Database: " + exception.Message;
                WriteToLogFile(ErrorString);
            }
        }

        public static void WriteToLogFile(string StringToLogFile)
        {
            StringToLogFile += "\n";
            // Writing the Logs to local file
            string Filename = "LogFile_" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
            string LogFileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), Filename);
            

            if (File.Exists(LogFileName))
            {
                File.AppendAllText(LogFileName, StringToLogFile);
            }
            else
            {
                File.WriteAllText(LogFileName, StringToLogFile);
            }
        }
    }
}
