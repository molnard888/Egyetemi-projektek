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
    public partial class FelhasznalokLV : ContentPage
    {
        public ObservableCollection<string> Items { get; set; }

        public FelhasznalokLV(string UsernameLbltext)
        {
            InitializeComponent();

            UsernameLbl.Text = UsernameLbltext;

            
            string queryString = "SELECT * FROM `users` ORDER BY `users`.`Username` ASC";
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
                        Items.Add("Felhasználó: " + myReader.GetString(0) + " | Név: " + myReader.GetString(4) + " " + myReader.GetString(5));
                    }
                }
                databaseConn.Close();
            }
            catch (Exception exception)
            {
                Items.Add("Error: " + exception.Message + " ; " + queryString);
            }





            MyListView.ItemsSource = Items;
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        private void LogOutBtn_Clicked(object sender, EventArgs e)
        {
            (Application.Current).MainPage = new NavigationPage(new Page1());
        }

        private void KeresBttn_Clicked(object sender, EventArgs e)
        {

        }

        private void RendezBttn_Clicked(object sender, EventArgs e)
        {

        }

        private void TorolBttn_Clicked(object sender, EventArgs e)
        {

        }

        private void SzerkesztesBttn_Clicked(object sender, EventArgs e)
        {

        }
    }
}
