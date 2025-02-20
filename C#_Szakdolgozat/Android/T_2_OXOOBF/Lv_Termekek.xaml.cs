using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MySqlConnector;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using static T_2_OXOOBF.Class_Common;

namespace T_2_OXOOBF
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TermekekLV : ContentPage
    {
        private List<Class_Termek> SelectedItems = new List<Class_Termek>();
        Class_Termek SelectedItem = null;
        bool IsButtonSelected = false;
        Color BttnDefaBlue = Color.FromHex("#2194f3");
        public ObservableCollection<Class_Termek> Items { get; set; }
       

        public TermekekLV()
        {
            InitializeComponent();
            SelectedItems = new List<Class_Termek>();
            UsernameLbl.Text = Class_Common.getLoggedInUser();

            TermekListaz();
        }

        public TermekekLV(string QrOrQuery, bool IsQuery)
        {
            InitializeComponent();
            UsernameLbl.Text = Class_Common.getLoggedInUser();

            if (IsQuery)
            {
                TermekListaz(QrOrQuery);
            }
            else
            {
                TermekListazQR(QrOrQuery);
            }
        }

        void TermekListaz(string queryString = "SELECT * FROM `products` ORDER BY `products`.`Brand` ASC")
        {

            MySqlConnection databaseConn = new MySqlConnection(MySQLadapter.builder.ConnectionString);
            MySqlCommand commandGetProductsFromDB = new MySqlCommand(queryString, databaseConn);
            commandGetProductsFromDB.CommandTimeout = 60;

            Items = new ObservableCollection<Class_Termek> { };

            try
            {
                databaseConn.Open();
                MySqlDataReader myReader = commandGetProductsFromDB.ExecuteReader();

                if (myReader.HasRows) // Ha jó az input
                {
                    //"ItemNumber | StorageID | Brand | Type | Category | Price | Quantity | InnerLocRow | InnerLocColumn | InnerLocLevel\n";
                    while (myReader.Read())
                    {
                        
                        Items.Add(new Class_Termek(myReader.GetString(0),
                                                            myReader.GetInt64(1).ToString(),
                                                            myReader.GetString(2),
                                                            myReader.GetString(3),
                                                            myReader.GetString(4),
                                                            myReader.GetInt64(5).ToString() + " Ft",
                                                            myReader.GetInt64(6).ToString(),
                                                            myReader.GetInt64(7).ToString(),
                                                            myReader.GetInt64(8).ToString(),
                                                            myReader.GetInt64(9).ToString()));
                    }
                }
                databaseConn.Close();
            }
            catch (Exception exception)
            {
                databaseConn.Close();
                DisplayAlert("Hiba:", exception.Message, queryString);
                string ErrorString = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " - Error getting products from DB: " + exception.Message;
                Class_Logging.WriteToLogFile(ErrorString);
            }

            MyListView.ItemsSource = null;
            MyListView.ItemsSource = Items;
        }

        

        void TermekListazQR(string QrID)
        {
            string queryString = "SELECT * FROM `products` WHERE `products`.`ItemNumber`='" + QrID + "' ORDER BY `products`.`Brand` ASC";
            MySqlConnection databaseConn = new MySqlConnection(MySQLadapter.builder.ConnectionString);
            MySqlCommand commandCheckInputUsers = new MySqlCommand(queryString, databaseConn);
            commandCheckInputUsers.CommandTimeout = 60;

            Items = new ObservableCollection<Class_Termek> { };

            try
            {
                databaseConn.Open();
                MySqlDataReader myReader = commandCheckInputUsers.ExecuteReader();

                if (myReader.HasRows) // Ha jó az input
                {
                    //"ItemNumber | StorageID | Brand | Type | Category | Price | Quantity | InnerLocRow | InnerLocColumn | InnerLocLevel\n";
                    while (myReader.Read())
                    {
                        /* Items.Add(myReader.GetString(2) + " | " + myReader.GetString(3) + " | " +
                                             myReader.GetString(4) +
                                             " | " + myReader.GetInt64(5) + " Ft"); */
                        Items.Add(new Class_Termek(myReader.GetString(0),
                                                            myReader.GetInt64(1).ToString(),
                                                            myReader.GetString(2),
                                                            myReader.GetString(3),
                                                            myReader.GetString(4),
                                                            myReader.GetInt64(5).ToString() + " Ft",
                                                            myReader.GetInt64(6).ToString(),
                                                            myReader.GetInt64(7).ToString(),
                                                            myReader.GetInt64(8).ToString(),
                                                            myReader.GetInt64(9).ToString()));
                    }
                }
                databaseConn.Close();
            }
            catch (Exception exception)
            {
                DisplayAlert("Error", exception.Message, queryString);
                string ErrorString = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " - Error getting products from DB: " + exception.Message;
                Class_Logging.WriteToLogFile(ErrorString);
            }

            MyListView.ItemsSource = Items;
        }

        
        
        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;
            Class_Termek tempSelected = e.Item as Class_Termek;


            if (KosarbaBttn.BackgroundColor == Color.Orange)
            {   
                bool DispAlertResponse = await DisplayAlert("Kiválasztva:", $"{tempSelected.Tipus}", "Kosárba", "Mégse");
                if (DispAlertResponse)
                {
                    SelectedItems.Add(e.Item as Class_Termek);
                }
                
            }
            else if(SzerkesztesBttn.BackgroundColor == Color.Orange)     ////*********************** EZ MI?
            {
                bool DispAlertResponse = await DisplayAlert("Kiválasztva:", $"{tempSelected.Tipus}", "Részletek/Módosítás", "Mégse");
                if (DispAlertResponse)
                {
                    SelectedItem = e.Item as Class_Termek;
                }
                
            }
            else if(TorolBttn.BackgroundColor == Color.Orange)
            {
                bool DispAlertResponse = await DisplayAlert("Kiválasztva:", $"{tempSelected.Tipus}", "Törlés", "Mégse");
                if (DispAlertResponse)
                {
                    SelectedItem = e.Item as Class_Termek;
                }
            }

            
        }

        private void TorolBttn_Clicked(object sender, EventArgs e)
        {
            
            if (TorolBttn.BackgroundColor == Color.Orange && SelectedItem != null && !string.IsNullOrEmpty(SelectedItem.Cikkszam) && !string.IsNullOrWhiteSpace(SelectedItem.Cikkszam))
            {
                string SqlExecuteCommand = "Delete from `products` WHERE ItemNumber='" + SelectedItem.Cikkszam + "'";   // ItemNumber 
                string returnedAnswer = MySQLadapter.ExecuteSqlCommand(SqlExecuteCommand, "Deleted Product", SelectedItem.Cikkszam);

                DisplayAlert("Üzenet", returnedAnswer, "OK");
                TermekListaz();
            }
            else if (IsButtonSelected == false)  // Aktiválás, ha más gomb nem aktív
            {
                SelectedItem = null;
                TorolBttn.BackgroundColor = Color.Orange;
                IsButtonSelected = true;
            }
            else
            {
                if(TorolBttn.BackgroundColor == Color.Orange)
                {
                    TorolBttn.BackgroundColor = BttnDefaBlue;
                    IsButtonSelected = false;
                }
                
            }
            SelectedItem = null;
            
        }


        private void SzerkesztesBttn_Clicked(object sender, EventArgs e)
        {
           
            if (SzerkesztesBttn.BackgroundColor == Color.Orange && SelectedItem != null && !string.IsNullOrEmpty(SelectedItem.Cikkszam) && !string.IsNullOrWhiteSpace(SelectedItem.Cikkszam))
            {
                SzerkesztesBttn.BackgroundColor = BttnDefaBlue;
                IsButtonSelected = false;
                Navigation.PushAsync(new UjTermek(1, SelectedItem.Cikkszam));
            }
            else if (IsButtonSelected == false) // Aktiválás, ha más gomb nem aktív
            {
                SelectedItem = null;
                SzerkesztesBttn.BackgroundColor = Color.Orange;
                IsButtonSelected = true;
            }
            else
            {
                SzerkesztesBttn.BackgroundColor = BttnDefaBlue;
                IsButtonSelected = false;
            }

            SelectedItem = null;
        }



        private void KosarbaBttn_Clicked(object sender, EventArgs e)
        {
            if (KosarbaBttn.BackgroundColor == Color.Orange)
            {
                KosarbaBttn.BackgroundColor = BttnDefaBlue;

                if (SelectedItems != null)
                {
                    Navigation.PushAsync(new Eladas(SelectedItems));    // Meghivjuk az Eladas Page-et
                }


            }
            else if (IsButtonSelected == false)  // Aktiválás, ha más gomb nem aktív
            {
                SelectedItems.Clear();
                KosarbaBttn.BackgroundColor = Color.Orange;
                IsButtonSelected = true;
            }

            SelectedItem = null;
        }

        private async void RendezBttn_Clicked(object sender, EventArgs e)
        {
            string sortOrder = await DisplayActionSheet("Sorrend:", "Cancel", "", new string[] { "Márka növ.", "Márka csök.", "Típus növ.", "Típus csök.",
                "Kategória növ.","Kategória csök.", "Ár növ.", "Ár csök." });

            string SqlSelectProducts = "SELECT * FROM `products` ORDER BY `products`.";
            string queryString = SqlSelectProducts + "`Brand` ASC";

            switch (sortOrder)
            {

                case "Márka növ.":
                    queryString = SqlSelectProducts + "`Brand` ASC";
                    break;

                case "Márka csök.":
                    queryString = SqlSelectProducts + "`Brand` DESC";
                    break;

                case "Típus növ.":
                    queryString = SqlSelectProducts + "`Type` ASC";
                    break;

                case "Típus csök.":
                    queryString = SqlSelectProducts + "`Type` DESC";
                    break;

                case "Kategória növ.":
                    queryString = SqlSelectProducts + "`Category` ASC";
                    break;

                case "Kategória csök.":
                    queryString = SqlSelectProducts + "`Category` DESC";
                    break;

                case "Ár növ.":
                    queryString = SqlSelectProducts + "`Price` ASC";
                    break;

                case "Ár csök.":
                    queryString = SqlSelectProducts + "`Price` DESC";
                    break;
            }

            TermekListaz(queryString);

        }


        private void LogOutBtn_Clicked(object sender, EventArgs e)
        {
            Class_Common.LogOutWriteToDb();
            (Application.Current).MainPage = new NavigationPage(new LoginPage());
        }

        private void KeresBttn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new UjTermek(2));
        }

    }
}
