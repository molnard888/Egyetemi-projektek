using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MySqlConnector;
using System.Collections.Generic;

namespace T_2_OXOOBF
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TermekekLV : ContentPage
    {

        //List<string> SelectedItems = new List<string>();
        bool IsButtonSelected = false;
        Color BttnDefaBlue = Color.FromHex("#2194f3");

        public ObservableCollection<string> Items { get; set; }

        public TermekekLV(string UsernameLbltext)
        {
            InitializeComponent();

            UsernameLbl.Text = UsernameLbltext;

            
            string queryString = "SELECT * FROM `products` ORDER BY `products`.`Brand` ASC";
            MySqlConnection databaseConn = new MySqlConnection(Helper.builder.ConnectionString);
            MySqlCommand commandCheckInputUsers = new MySqlCommand(queryString, databaseConn);
            commandCheckInputUsers.CommandTimeout = 60;

            Items = new ObservableCollection<string>{};

            try
            {
                databaseConn.Open();
                MySqlDataReader myReader = commandCheckInputUsers.ExecuteReader();

                if (myReader.HasRows) // Ha jó az input
                {
                    //"ItemNumber | StorageID | Brand | Type | Category | Price | Quantity | InnerLocRow | InnerLocColumn | InnerLocLevel\n";
                    while (myReader.Read())
                    {
                        Items.Add(myReader.GetString(2) + " | " + myReader.GetString(3) + " | " +
                                             myReader.GetString(4) +
                                             " | " + myReader.GetInt64(5) + " Ft");
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

        public TermekekLV(string UsernameLbltext, string TipusQr)
        {
            InitializeComponent();

            UsernameLbl.Text = UsernameLbltext;


            string queryString = "SELECT * FROM `products` WHERE `products`.`Type`='"+TipusQr+"' ORDER BY `products`.`Brand` ASC";
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
                    //"ItemNumber | StorageID | Brand | Type | Category | Price | Quantity | InnerLocRow | InnerLocColumn | InnerLocLevel\n";
                    while (myReader.Read())
                    {
                        Items.Add(myReader.GetString(2) + " | " + myReader.GetString(3) + " | " +
                                             myReader.GetString(4) +
                                             " | " + myReader.GetInt64(5) + " Ft");
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

        void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            //DisplayAlert("Termeknev", e.Item.ToString().Split('|')[0], "ok");
            

            if (KosarbaBttn.BackgroundColor == Color.Orange)
            {
                Helper.SelectedItems.Add(e.Item.ToString());
            }
            else if(SzerkesztesBttn.BackgroundColor == Color.Orange)
            {
                Helper.SelectedItems.Add(e.Item.ToString());
            }

            //Deselect Item
            //((ListView)sender).SelectedItem = null;
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

        private void KosarbaBttn_Clicked(object sender, EventArgs e)
        {
            if (KosarbaBttn.BackgroundColor == Color.Orange)
            {
                KosarbaBttn.BackgroundColor = BttnDefaBlue;
                // Meghivjuk az Eladas Page-et
                Navigation.PushAsync(new Eladas(UsernameLbl.Text, Helper.SelectedItems));

            }
            else if(IsButtonSelected == false)
            {
                Helper.SelectedItems.Clear();
                KosarbaBttn.BackgroundColor = Color.Orange;
            }

        }
        private void EladasBttn_Clicked(object sender, EventArgs e)
        {
            
        }

        private void SzerkesztesBttn_Clicked(object sender, EventArgs e)
        {
            if (SzerkesztesBttn.BackgroundColor == Color.Orange && Helper.SelectedItems.Count == 1)
            {
                SzerkesztesBttn.BackgroundColor = BttnDefaBlue;
                
                Navigation.PushAsync(new TermekMod(Helper.SelectedItems[0], UsernameLbl.Text));
            }
            else if (IsButtonSelected == false)
            {
                Helper.SelectedItems.Clear();
                SzerkesztesBttn.BackgroundColor = Color.Orange;
            }
            else
            {
                DisplayAlert("Hiba", "Túl sok kiválasztott elem", "OK");
                Helper.SelectedItems.Clear();
                SzerkesztesBttn.BackgroundColor = BttnDefaBlue;
            }
        }   

        private void Beolvas_Clicked(object sender, EventArgs e)
        {

        }

        private void Torol_Clicked(object sender, EventArgs e)
        {

        }

        private void BeolvasBttn_Clicked(object sender, EventArgs e)
        {

        }

        private void TorolBttn_Clicked_1(object sender, EventArgs e)
        {

        }

        private void OsszTorolBttn_Clicked(object sender, EventArgs e)
        {

        }

        private void EladasBttn_Clicked_1(object sender, EventArgs e)
        {

        }
    }
}
