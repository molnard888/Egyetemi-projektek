using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace T_2_OXOOBF
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Reszletek_Naplo : ContentPage
    {
        int Mode;
        public Reszletek_Naplo(int _mode, string logID = null)   // _mode = 0: Részletek / 1: Keresés
        {
            InitializeComponent();
            UsernameLbl.Text = Class_Common.getLoggedInUser();

            Mode = _mode;
            switch (Mode)
            {
                case 0:
                    MentesBttn.IsVisible = false;
                    LogInfo(logID);
                    break;
                case 1:
                    LogID.IsEnabled = true;                  
                    Raktar.IsEnabled = true;
                    Felhasznalonev.IsEnabled = true;
                    Idopont.IsEnabled = true;
                    Muvelet.IsEnabled = true;
                    Reszletek.IsEnabled = true;

                    MentesBttn.IsVisible = true;
                    MentesBttn.Text = "Keresés";
                    break;
            }
        }

        private void MentesBttn_Clicked(object sender, EventArgs e)
        {
            if (Mode == 1)
            {
                SearchSale();
            }
        }

        private void LogInfo(string logID)
        {
            string queryString = "SELECT * FROM `log` WHERE `log`.`LogID`='" + logID + "'";
            MySqlConnection databaseConn = new MySqlConnection(MySQLadapter.builder.ConnectionString);
            MySqlCommand commandCheckInputUsers = new MySqlCommand(queryString, databaseConn);
            commandCheckInputUsers.CommandTimeout = 60;


            try
            {
                databaseConn.Open();
                MySqlDataReader myReader = commandCheckInputUsers.ExecuteReader();

                if (myReader.HasRows) // Ha jó az input
                {

                    while (myReader.Read())
                    {
                        LogID.Text = myReader.GetInt64(0).ToString();
                        Raktar.Text = myReader.GetInt64(1).ToString();
                        Felhasznalonev.Text = myReader.GetString(2);
                        Idopont.Text = myReader.GetDateTime(3).ToString();
                        Muvelet.Text = myReader.GetString(4);
                        Reszletek.Text = myReader.GetString(5);
                    }
                }
                databaseConn.Close();
            }
            catch (Exception exception)
            {
                databaseConn.Close();
                DisplayAlert("Hiba:", exception.Message + " ; " + queryString, "OK");
                string ErrorString = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " - Error during getting sales from DB: " + exception.Message;
                Class_Logging.WriteToLogFile(ErrorString);
            }
        }

        private void SearchSale()
        {
            String queryString = "SELECT * FROM `log` WHERE ";
            bool hasInput = false;

            if (!string.IsNullOrEmpty(LogID.Text) && !string.IsNullOrWhiteSpace(LogID.Text))
            {
                queryString += " `log`.`LogID`='" + LogID.Text + "' AND";
                hasInput = true;
            }
            if (!string.IsNullOrEmpty(Raktar.Text) && !string.IsNullOrWhiteSpace(Raktar.Text))
            {
                queryString += " `log`.`Storage`='" + Raktar.Text + "' AND";
                hasInput = true;
            }
            if (!string.IsNullOrEmpty(Felhasznalonev.Text) && !string.IsNullOrWhiteSpace(Felhasznalonev.Text))
            {
                queryString += " `log`.`UserName`='" + Felhasznalonev.Text + "' AND";
                hasInput = true;
            }
            if (!string.IsNullOrEmpty(Idopont.Text) && !string.IsNullOrWhiteSpace(Idopont.Text))
            {
                queryString += " `log`.`DateTime`='" + Idopont.Text + "' AND";
                hasInput = true;
            }
            if (!string.IsNullOrEmpty(Muvelet.Text) && !string.IsNullOrWhiteSpace(Muvelet.Text))
            {
                queryString += " `log`.`Proc`='" + Muvelet.Text + "' AND";
                hasInput = true;
            }
            if (!string.IsNullOrEmpty(Reszletek.Text) && !string.IsNullOrWhiteSpace(Reszletek.Text))
            {
                queryString += " `log`.`Details`='" + Reszletek.Text + "' AND";
                hasInput = true;
            }
            
            queryString = queryString.Remove(queryString.Length - 3);
            queryString += " ORDER BY `log`.`DateTime` DESC";


            if (hasInput && MySQLadapter.IsDatabaseContains(queryString))
            {
                Navigation.PushAsync(new Lv_Naplo(queryString));
            }
            else if (!hasInput)
            {
                DisplayAlert("Hiba:", "Minden mező üres!", "OK");
            }
            else if (!MySQLadapter.IsDatabaseContains(queryString))
            {
                DisplayAlert("Hiba", "Nincs találat", "OK");
            }

        }

        private void LogOutBtn_Clicked(object sender, EventArgs e)
        {
            Class_Common.LogOutWriteToDb();
            (Application.Current).MainPage = new NavigationPage(new LoginPage());
        }
    }
}