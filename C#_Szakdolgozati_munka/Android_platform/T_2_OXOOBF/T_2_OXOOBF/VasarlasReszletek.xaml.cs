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
    public partial class VasarlasReszletek : ContentPage
    {
        public string[] Items;

        public VasarlasReszletek(string UsernameLbltext, string VasarlasID)
        {
            InitializeComponent();

            UsernameLbl.Text = UsernameLbltext;


            string queryString = "SELECT * FROM `sales` WHERE `sales`.`VasarlasID`='" + VasarlasID + "'";
            MySqlConnection databaseConn = new MySqlConnection(Helper.builder.ConnectionString);
            MySqlCommand commandCheckInputUsers = new MySqlCommand(queryString, databaseConn);
            commandCheckInputUsers.CommandTimeout = 60;

            
            string TermekekString="";

            try
            {
                databaseConn.Open();
                MySqlDataReader myReader = commandCheckInputUsers.ExecuteReader();

                if (myReader.HasRows) // Ha jó az input
                {

                    while (myReader.Read())
                    {
                        

                        VasarlasIDlbl.Text = "VásárlásID: " + myReader.GetInt64(0).ToString();
                        StorageIDlbl.Text = "RaktárID: " + myReader.GetInt64(1).ToString();

                        Nevlbl.Text = "Név: " + myReader.GetString(2);
                        Telefonlbl.Text = "Telefon: " + myReader.GetString(3);
                        Cimlbl.Text = "Cím: " + myReader.GetString(4);

                        TermekekString = myReader.GetString(5);

                        Vegosszeglbl.Text = "Végösszeg: " + myReader.GetInt64(6).ToString();
                        Idolbl.Text = "Időpont: " + myReader.GetDateTime(7).ToString();
                    }
                    Items = TermekekString.Split(';');
                }
                databaseConn.Close();
            }
            catch (Exception exception)
            {
                DisplayAlert("E", "Error: " + exception.Message + " ; " + queryString, "OK");
            }

            

            MyListView.ItemsSource = Items;
        }

        private void LogOutBtn_Clicked(object sender, EventArgs e)
        {
            (Application.Current).MainPage = new NavigationPage(new Page1());
        }

        private void MyListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }
    }
}