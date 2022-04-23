using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MySqlConnector;

namespace T_2_OXOOBF
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TermekMod : ContentPage
    {
        public TermekMod(string TermekNev, string UsernameLbltext)
        {
            InitializeComponent();

            UsernameLbl.Text = UsernameLbltext;
            
            MySqlConnection databaseConn = new MySqlConnection(Helper.builder.ConnectionString);
            string queryString = "Select * from `products` WHERE Type='" + TermekNev + "'";   // Termeknev 
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
                        Azonosito.Placeholder = myReader.GetString(0);
                        Raktar.Placeholder = myReader.GetInt64(1).ToString();
                        Marka.Placeholder = myReader.GetString(2);
                        Tipus.Placeholder = myReader.GetString(3);
                        Kategoria.Placeholder = myReader.GetString(4);
                        Ar.Placeholder = myReader.GetInt64(5).ToString();
                        Mennyiseg.Placeholder = myReader.GetInt64(6).ToString();
                        Lokacio_sor.Placeholder = myReader.GetInt64(7).ToString();
                        Lokacio_oszlop.Placeholder = myReader.GetInt64(8).ToString();
                        Lokacio_szint.Placeholder = myReader.GetInt64(9).ToString();
                    }
                }
            }
            catch (Exception exception)
            {
                DisplayAlert("Error: ", exception.Message, "OK");
            }
            databaseConn.Close();
        }

        private void LogOutBtn_Clicked(object sender, EventArgs e)
        {
            (Application.Current).MainPage = new NavigationPage(new Page1());
        }

        private void MentesBttn_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Error: ", "Mentés", "OK");
        }

        private void MentesBttn_Clicked_1(object sender, EventArgs e)
        {

        }
    }
}