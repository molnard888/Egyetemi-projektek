using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MySqlConnector;

namespace T_2_OXOOBF
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class eladasokLV : ContentPage
    {
        bool IsButtonSelected = false;
        Color BttnDefaBlue = Color.FromHex("#2194f3");
        string VasarlasID;

        public ObservableCollection<string> Items { get; set; }

        public eladasokLV(string UsernameLbltext)
        {
            InitializeComponent();
            ReszletekBttn.BackgroundColor = BttnDefaBlue;

            UsernameLbl.Text = UsernameLbltext;

           
            string queryString = "SELECT * FROM `sales` ORDER BY `sales`.`Ido` ASC";
            MySqlConnection databaseConn = new MySqlConnection(Helper.builder.ConnectionString);
            MySqlCommand commandCheckInputUsers = new MySqlCommand(queryString, databaseConn);
            commandCheckInputUsers.CommandTimeout = 60;

            Items = new ObservableCollection<string> { };

            try
            {
                databaseConn.Open();
                MySqlDataReader myReader = commandCheckInputUsers.ExecuteReader();

                if (myReader.HasRows) // Ha jó az input
                {
                    
                    while (myReader.Read())
                    {
                        Items.Add(myReader.GetInt64(0).ToString() + " | " + myReader.GetString(2) + " | " +
                                             myReader.GetDateTime(7).ToString() +
                                             " | " + myReader.GetInt64(6).ToString() + " Ft");
                    }
                }
                databaseConn.Close();
            }
            catch (Exception exception)
            {
                DisplayAlert("E", "Error: " + exception.Message + " ; " + queryString, "OK");
            }





            MyListView.ItemsSource = Items;
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            if (ReszletekBttn.BackgroundColor == Color.Orange)
            {
                string[] stringSeparators = new string[] { " | " };
                string[] Substrings = e.Item.ToString().Split(stringSeparators, StringSplitOptions.None);
                VasarlasID = Substrings[0];
            }

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        private void LogOutBtn_Clicked(object sender, EventArgs e)
        {
            (Application.Current).MainPage = new NavigationPage(new Page1());
        }

        private void ReszletekBttn_Clicked(object sender, EventArgs e)
        {
            if (ReszletekBttn.BackgroundColor == Color.Orange)
            {
                ReszletekBttn.BackgroundColor = BttnDefaBlue;
                // Meghivjuk az Eladas Page-et
                Navigation.PushAsync(new VasarlasReszletek(UsernameLbl.Text, VasarlasID));

            }
            else if (IsButtonSelected == false)
            {
                Helper.SelectedItems.Clear();
                ReszletekBttn.BackgroundColor = Color.Orange;
            }
        }
    }
}
