using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;
using MySqlConnector;
using static T_2_OXOOBF.Class_Common;

namespace T_2_OXOOBF
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Lv_Naplo : ContentPage
    {
        private List<Class_Naplo> SelectedLogs = null;
        Class_Naplo SelectedLog = null;
        bool IsButtonSelected = false;
        Color BttnDefaBlue = Color.FromHex("#2194f3");
        public ObservableCollection<Class_Naplo> Logs { get; set; }

        public Lv_Naplo(string queryString=null)
        {
            InitializeComponent();
            UsernameLbl.Text = Class_Common.getLoggedInUser();

            if (String.IsNullOrEmpty(queryString)){
                NaploListaz();
            }
            else
            {
                NaploListaz(queryString);
            }
            
            
        }



        private void NaploListaz(string queryString = "SELECT * FROM `log` ORDER BY `log`.`DateTime` DESC")
        {
            
            MySqlConnection databaseConn = new MySqlConnection(MySQLadapter.builder.ConnectionString);
            MySqlCommand commandGetLogsFromDB = new MySqlCommand(queryString, databaseConn);
            commandGetLogsFromDB.CommandTimeout = 60;

            Logs = new ObservableCollection<Class_Naplo> { };

            try
            {
                databaseConn.Open();
                MySqlDataReader myReader = commandGetLogsFromDB.ExecuteReader();

                if (myReader.HasRows) // Ha jó az input
                {

                    while (myReader.Read())
                    {
                        Logs.Add(new Class_Naplo(myReader.GetInt64(0).ToString(),
                                                            myReader.GetInt64(1).ToString(),
                                                            myReader.GetString(2),
                                                            myReader.GetDateTime(3).ToString(),
                                                            myReader.GetString(4),
                                                            myReader.GetString(5)));
                    }
                }
                databaseConn.Close();
            }
            catch (Exception exception)
            {
                databaseConn.Close();
                DisplayAlert("Hiba:", exception.Message, queryString);
                string ErrorString = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " - Error getting log from DB: " + exception.Message;
                Class_Logging.WriteToLogFile(ErrorString);
            }

            MyListView.ItemsSource = null;
            MyListView.ItemsSource = Logs;
        }

        private void LogOutBtn_Clicked(object sender, EventArgs e)
        {
            Class_Common.LogOutWriteToDb();
            (Application.Current).MainPage = new NavigationPage(new LoginPage());
        }


        private async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;
            Class_Naplo tempSelected = e.Item as Class_Naplo;


            if (SzerkesztesBttn.BackgroundColor == Color.Orange)  
            {
                string displayString = tempSelected.Felhasznalonev +"\n"+ tempSelected.Idopont;
                bool DispAlertResponse = await DisplayAlert("Kiválasztva:", displayString, "Részletek", "Mégse");
                if (DispAlertResponse)
                {
                    SelectedLog = e.Item as Class_Naplo;
                }

            }
            
        }

        private void KeresBttn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Reszletek_Naplo(1));
        }

        private async void RendezBttn_Clicked(object sender, EventArgs e)
        {
            string sortOrder = await DisplayActionSheet("Sorrend:", "Cancel", "", new string[] { "Felhasználónév növ.", "Felhasználónév csök.", "Időpont növ.", "Időpont csök.",
                "Művelet növ.","Művelet csök." });

            string SqlSelectLogs = "SELECT * FROM `log` ORDER BY `log`.";
            string queryString = SqlSelectLogs + "`UserName` ASC";

            switch (sortOrder)
            {

                case "Felhasználónév növ.":
                    queryString = SqlSelectLogs + "`UserName` ASC";
                    break;

                case "Felhasználónév csök.":
                    queryString = SqlSelectLogs + "`UserName` DESC";
                    break;

                case "Időpont növ.":
                    queryString = SqlSelectLogs + "`DateTime` ASC";
                    break;

                case "Időpont csök.":
                    queryString = SqlSelectLogs + "`DateTime` DESC";
                    break;

                case "Művelet növ.":
                    queryString = SqlSelectLogs + "`Proc` ASC";
                    break;

                case "Művelet csök.":
                    queryString = SqlSelectLogs + "`Proc` DESC";
                    break;
            }

            NaploListaz(queryString);
        }

        private void SzerkesztesBttn_Clicked(object sender, EventArgs e)
        {
            if (SzerkesztesBttn.BackgroundColor == Color.Orange && SelectedLog != null && !string.IsNullOrEmpty(SelectedLog.NaploID) && !string.IsNullOrWhiteSpace(SelectedLog.NaploID))
            {
                SzerkesztesBttn.BackgroundColor = BttnDefaBlue;
                IsButtonSelected = false;
                Navigation.PushAsync(new Reszletek_Naplo(0, SelectedLog.NaploID));
            }
            else if (IsButtonSelected == false) // Aktiválás, ha más gomb nem aktív
            {
                SelectedLog = null;
                SzerkesztesBttn.BackgroundColor = Color.Orange;
                IsButtonSelected = true;
            }
            else
            {
                SzerkesztesBttn.BackgroundColor = BttnDefaBlue;
                IsButtonSelected = false;
            }

            SelectedLog = null;
        }
    }
}