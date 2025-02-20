using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Raktarkezelo
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
                databaseConn = MySQLadapter.CreateDbConnection();
                MySqlCommand commandToExecute = new MySqlCommand(queryString_InsertLog, databaseConn);
                commandToExecute.CommandTimeout = 60;
                databaseConn.Open();

                int rowCount = commandToExecute.ExecuteNonQuery();

                if (rowCount <= 0)
                {
                    MessageBox.Show("Error:\nA log beszúrása az adatbázisba nem sikeres!");
                }
                
                databaseConn.Close();
            }
            catch (Exception exception)
            {
                if (databaseConn != null)
                {
                    databaseConn.Close();
                }
                MessageBox.Show("Error: " + exception.Message);
                string ErrorString = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " - Error during Inserting log to Database: " + exception.Message ;
                WriteToLogFile(ErrorString);
            }
        }

        public static void WriteToLogFile(string StringToLogFile)
        {
            StringToLogFile = StringToLogFile + "\n";
            string LogFileName = "ErrorsLog_"+ DateTime.Now.ToString("yyyy_MM") + ".txt";
            
            if (File.Exists(LogFileName)) {
                File.AppendAllText(LogFileName,StringToLogFile);
            }
            else {
                File.WriteAllText(LogFileName, StringToLogFile);
            }
        }
    }
}