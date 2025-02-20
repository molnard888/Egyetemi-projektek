using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MySqlConnector;
using static T_2_OXOOBF.Class_Common;
using System.Collections.Generic;

namespace T_2_OXOOBF
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class eladasokLV : ContentPage
    {
        public static List<EladasClass> SelectedSales = null;
        EladasClass SelectedSale = null;
        bool IsButtonSelected = false;
        Color BttnDefaBlue = Color.FromHex("#2194f3");
        public ObservableCollection<EladasClass> Sales { get; set; }


        public eladasokLV()
        {
            InitializeComponent();
            SelectedSales = new List<EladasClass>();    
            UsernameLbl.Text = Class_Common.getLoggedInUser();

            EladasListaz();
        }

        public eladasokLV(string _query)
        {
            InitializeComponent();
            UsernameLbl.Text = Class_Common.getLoggedInUser();

            EladasListaz(_query);
        }

            void EladasListaz(string queryString = "SELECT * FROM `sales` ORDER BY `sales`.`SaleDatetime` DESC")
        {
            
            MySqlConnection databaseConn = new MySqlConnection(MySQLadapter.builder.ConnectionString);
            MySqlCommand commandCheckInputUsers = new MySqlCommand(queryString, databaseConn);
            commandCheckInputUsers.CommandTimeout = 60;

            Sales = new ObservableCollection<EladasClass> { };
            string azonosito = "";

            try
            {
                databaseConn.Open();
                MySqlDataReader myReader = commandCheckInputUsers.ExecuteReader();


                if (myReader.HasRows) // Ha jó az input
                {

                    while (myReader.Read())
                    {
                        Sales.Add(new EladasClass(myReader.GetString(0),
                                                            myReader.GetString(1),
                                                            myReader.GetString(2),
                                                            myReader.GetInt64(3).ToString(),
                                                            myReader.GetString(4),
                                                            myReader.GetString(5),
                                                            myReader.GetInt64(6).ToString() + " Ft",
                                                            myReader.GetDateTime(7).ToString()));
                        azonosito = myReader.GetString(5);
                    }

                }
                databaseConn.Close();
                //DisplayAlert("ID: ", azonosito, "OK");

            }
            catch (Exception exception)
            {
                DisplayAlert("Error: ", exception.Message + " ; " + queryString, "OK");
                string ErrorString = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " - Error getting sales from DB: " + exception.Message;
                Class_Logging.WriteToLogFile(ErrorString);
            }





            MyListView.ItemsSource = Sales;
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;
            EladasClass tempSelected = e.Item as EladasClass;


            if (SzerkesztesBttn.BackgroundColor == Color.Orange)     ////*********************** EZ MI?
            {
                bool DispAlertResponse = await DisplayAlert("Kiválasztva:", $"{tempSelected.VasarlasID}", "Részletek/Módosítás", "Mégse");
                if (DispAlertResponse)
                {
                    SelectedSale = e.Item as EladasClass;
                }

            }
            else if (TorolBttn.BackgroundColor == Color.Orange)
            {
                bool DispAlertResponse = await DisplayAlert("Kiválasztva:", $"{tempSelected.VasarlasID}", "Törlés", "Mégse");
                if (DispAlertResponse)
                {
                    SelectedSale = e.Item as EladasClass;
                }
            }
        }

        private void LogOutBtn_Clicked(object sender, EventArgs e)
        {
            Class_Common.LogOutWriteToDb();
            (Application.Current).MainPage = new NavigationPage(new LoginPage());
        }

        
        private void KeresBttn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new VasarlasReszletek(1)); // Keresés
        }

        private async void RendezBttn_Clicked(object sender, EventArgs e)
        {
            string sortOrder = await DisplayActionSheet("Sorrend:", "Mégsem", "", new string[] { "Név növ.", "Név csök.", "Azonosító növ.", "Azonosító csök.",
                "Végösszeg növ.","Végösszeg csök." });

            string SqlSelectSales = "SELECT * FROM `sales` ORDER BY `sales`.";
            string queryString = SqlSelectSales + "`Brand` ASC";

            switch (sortOrder)
            {

                case "Név növ.":
                    queryString = SqlSelectSales + "`Name` ASC";
                    break;

                case "Név csök.":
                    queryString = SqlSelectSales + "`Name` DESC";
                    break;

                case "Azonosító növ.":
                    queryString = SqlSelectSales + "`SaleID` ASC";
                    break;

                case "Azonosító csök.":
                    queryString = SqlSelectSales + "`SaleID` DESC";
                    break;

                case "Végösszeg növ.":
                    queryString = SqlSelectSales + "`Sum` ASC";
                    break;

                case "Végösszeg csök.":
                    queryString = SqlSelectSales + "`Sum` DESC";
                    break;

            }

            EladasListaz(queryString);
        }

        private void TorolBttn_Clicked(object sender, EventArgs e)
        {
            if (TorolBttn.BackgroundColor == Color.Orange && SelectedSale != null && !string.IsNullOrEmpty(SelectedSale.VasarlasID) && !string.IsNullOrWhiteSpace(SelectedSale.VasarlasID))
            {
                string SqlExecuteCommand = "Delete from `sales` WHERE SaleID='" + SelectedSale.VasarlasID + "'";   // SaleID
                string returnedAnswer = MySQLadapter.ExecuteSqlCommand(SqlExecuteCommand, "Deleted Sale", SelectedSale.VasarlasID);

                DisplayAlert("Üzenet", returnedAnswer, "OK");
                EladasListaz();

            }
            else if (IsButtonSelected == false)  // Aktiválás, ha más gomb nem aktív
            {
                SelectedSale = null;
                TorolBttn.BackgroundColor = Color.Orange;
                IsButtonSelected = true;
            }
            else
            {
                if (TorolBttn.BackgroundColor == Color.Orange)
                {
                    //DisplayAlert("Error", "Nincs kiválasztva termék!", "ok");
                    TorolBttn.BackgroundColor = BttnDefaBlue;
                    IsButtonSelected = false;
                }

            }
            SelectedSale = null;
        }

        private void SzerkesztesBttn_Clicked(object sender, EventArgs e)
        {
            if (SzerkesztesBttn.BackgroundColor == Color.Orange && SelectedSale != null && !string.IsNullOrEmpty(SelectedSale.VasarlasID) && !string.IsNullOrWhiteSpace(SelectedSale.VasarlasID))
            {
                SzerkesztesBttn.BackgroundColor = BttnDefaBlue;
                IsButtonSelected = false;
                Navigation.PushAsync(new VasarlasReszletek(0, SelectedSale.VasarlasID)); // Részletek
            }
            else if (IsButtonSelected == false) // Aktiválás, ha más gomb nem aktív
            {
                
                SelectedSale = null;
                SzerkesztesBttn.BackgroundColor = Color.Orange;
                IsButtonSelected = true;
            }
            else
            {
                DisplayAlert("Hiba", "Nincs kiválasztva vásárlás", "OK");
                SzerkesztesBttn.BackgroundColor = BttnDefaBlue;
                IsButtonSelected = false;
            }

            SelectedSale = null;
        }
    }
}
