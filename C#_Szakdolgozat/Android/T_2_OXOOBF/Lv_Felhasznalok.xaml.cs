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
    public partial class FelhasznalokLV : ContentPage
    {
        private List<Class_Felhasznalo> SelectedUsers = null;
        Class_Felhasznalo SelectedUser = null;
        bool IsButtonSelected = false;
        Color BttnDefaBlue = Color.FromHex("#2194f3");
        private ObservableCollection<Class_Felhasznalo> Users { get; set; }



        public FelhasznalokLV()
        {
            InitializeComponent();
            UsernameLbl.Text = Class_Common.getLoggedInUser();

            FelhasznalokListaz();
        }

        public FelhasznalokLV(string Query)
        {
            InitializeComponent();
            UsernameLbl.Text = Class_Common.getLoggedInUser();

            FelhasznalokListaz(Query);
        }


        private void FelhasznalokListaz(string queryString = "SELECT * FROM `users` ORDER BY `users`.`Username` ASC")
        {
            
            MySqlConnection databaseConn = new MySqlConnection(MySQLadapter.builder.ConnectionString);
            MySqlCommand commandCheckInputUsers = new MySqlCommand(queryString, databaseConn);
            commandCheckInputUsers.CommandTimeout = 60;

            Users = new ObservableCollection<Class_Felhasznalo> { };

            try
            {
                databaseConn.Open();
                MySqlDataReader myReader = commandCheckInputUsers.ExecuteReader();

                if (myReader.HasRows) // Ha jó az input
                {
                    while (myReader.Read())
                    {
                        Users.Add(new Class_Felhasznalo(myReader.GetString(0),
                                                            myReader.GetInt64(1).ToString(),
                                                            myReader.GetString(2),
                                                            myReader.GetInt16(3).ToString(),
                                                            myReader.GetString(4),
                                                            myReader.GetString(5),
                                                            myReader.GetString(6),
                                                            myReader.GetString(7)));
                    }
                }
                databaseConn.Close();
            }
            catch (Exception exception)
            {
                DisplayAlert("Hiba: ", exception.Message + " : " + queryString, "OK");
                string ErrorString = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " - Error getting users from DB: " + exception.Message;
                Class_Logging.WriteToLogFile(ErrorString);
            }

            MyListView.ItemsSource = null;
            MyListView.ItemsSource = Users;
        }


        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;
            Class_Felhasznalo tempSelected = e.Item as Class_Felhasznalo;

            if (SzerkesztesBttn.BackgroundColor == Color.Orange)     ////*********************** EZ MI?
            {
                bool DispAlertResponse = await DisplayAlert("Kiválasztva:", $"{tempSelected.Felhasznalonev}", "Részletek/Módosítás", "Mégse");
                if (DispAlertResponse)
                {
                    SelectedUser = e.Item as Class_Felhasznalo;
                }

            }
            else if (TorolBttn.BackgroundColor == Color.Orange)
            {
                bool DispAlertResponse = await DisplayAlert("Kiválasztva:", $"{tempSelected.Felhasznalonev}", "Törlés", "Mégse");
                if (DispAlertResponse)
                {
                    SelectedUser = e.Item as Class_Felhasznalo;
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
            Navigation.PushAsync(new UjFelhasznalo(2));
        }

        private async void RendezBttn_Clicked(object sender, EventArgs e)
        {
            string sortOrder = await DisplayActionSheet("Sorrend:", "Cancel", "", new string[] { "Felhasználónév növ.", "Felhasználónév csök.", "Raktár növ.", "Raktár csök.",
                "Jogosultság növ.","Jogosultság csök." });

            string SqlSelectProducts = "SELECT * FROM `users` ORDER BY `users`.";
            string queryString = SqlSelectProducts + "`Username` ASC";

            switch (sortOrder)
            {

                case "Felhasználónév növ.":
                    queryString = SqlSelectProducts + "`Username` ASC";
                    break;

                case "Felhasználónév csök.":
                    queryString = SqlSelectProducts + "`Username` DESC";
                    break;

                case "Raktár növ.":
                    queryString = SqlSelectProducts + "`StorageID` ASC";
                    break;

                case "Raktár csök.":
                    queryString = SqlSelectProducts + "`StorageID` DESC";
                    break;

                case "Jogosultság növ.":
                    queryString = SqlSelectProducts + "`IsAdmin` ASC";
                    break;

                case "Jogosultság csök.":
                    queryString = SqlSelectProducts + "`IsAdmin` DESC";
                    break;
            }

            FelhasznalokListaz(queryString);
        }

        private void TorolBttn_Clicked(object sender, EventArgs e)
        {
            if (TorolBttn.BackgroundColor == Color.Orange && SelectedUser != null && !string.IsNullOrEmpty(SelectedUser.Felhasznalonev) && !string.IsNullOrWhiteSpace(SelectedUser.Felhasznalonev))
            {
                string SqlExecuteCommand = "Delete from `users` WHERE Username='" + SelectedUser.Felhasznalonev + "'";   // Username 
                string returnedAnswer = MySQLadapter.ExecuteSqlCommand(SqlExecuteCommand, "Deleted User", SelectedUser.Felhasznalonev);

                DisplayAlert("Üzenet", returnedAnswer, "OK");
                SelectedUser = null;
                FelhasznalokListaz();
            }
            else if (IsButtonSelected == false)  // Aktiválás, ha más gomb nem aktív
            {
                SelectedUser = null;
                TorolBttn.BackgroundColor = Color.Orange;
                IsButtonSelected = true;
            }
            else
            {
                if (TorolBttn.BackgroundColor == Color.Orange)
                {
                    TorolBttn.BackgroundColor = BttnDefaBlue;
                    IsButtonSelected = false;
                }

            }
            SelectedUser = null;
        }

        private void SzerkesztesBttn_Clicked(object sender, EventArgs e)
        {
            if (SzerkesztesBttn.BackgroundColor == Color.Orange && SelectedUser != null && !string.IsNullOrEmpty(SelectedUser.Felhasznalonev) && !string.IsNullOrWhiteSpace(SelectedUser.Felhasznalonev))
            {
                SzerkesztesBttn.BackgroundColor = BttnDefaBlue;
                IsButtonSelected = false;
                Navigation.PushAsync(new UjFelhasznalo(1, SelectedUser.Felhasznalonev));
            }
            else if (IsButtonSelected == false) // Aktiválás, ha más gomb nem aktív
            {
                SelectedUser = null;
                SzerkesztesBttn.BackgroundColor = Color.Orange;
                IsButtonSelected = true;
            }
            else
            {
                SzerkesztesBttn.BackgroundColor = BttnDefaBlue;
                IsButtonSelected = false;
            }

            SelectedUser = null;
        }
    }
}
