using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MySqlConnector;
using static T_2_OXOOBF.Class_Common;
using ZXing.QrCode.Internal;

namespace T_2_OXOOBF
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VasarlasReszletek : ContentPage
    {
        int Mode;
        public VasarlasReszletek(int _mode, string vasarlasid=null)     // _mode = 0: Részletek / 1: Keresés
        {
            InitializeComponent();
            UsernameLbl.Text = Class_Common.getLoggedInUser();

            Mode = _mode;
            switch (Mode)
            {
                case 0:
                    MentesBttn.IsVisible = false;
                    VasarlasInfo(vasarlasid);
                    break;
                case 1:
                    Nev.IsEnabled = true;
                    Telefon.IsEnabled = true;
                    Cim.IsEnabled = true;
                    RaktarID.IsEnabled = true;
                    Azonositok.IsEnabled = true;
                    VasarlasID.IsEnabled = true;
                    Vegosszeg.IsEnabled = true;
                    VasarlasIdo.IsEnabled = true;

                    MentesBttn.IsVisible = true;
                    MentesBttn.Text = "Keresés";
                    break;
            }

        }

        private void MentesBttn_Clicked(object sender, EventArgs e)
        {
            if(Mode == 1)
            {
                SearchSale();
            }
        }

        private void VasarlasInfo(string vasarlasid)
        {
            //DisplayAlert("", "VasarlasInfo", "OK");
            string queryString = "SELECT * FROM `sales` WHERE `sales`.`SaleID`='" + vasarlasid + "'";
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
                        Nev.Text = myReader.GetString(0);
                        Telefon.Text = myReader.GetString(1);
                        Cim.Text = myReader.GetString(2);
                        RaktarID.Text = myReader.GetInt64(3).ToString();
                        Azonositok.Text = myReader.GetString(4);
                        VasarlasID.Text = myReader.GetString(5);
                        Vegosszeg.Text = myReader.GetInt64(6).ToString();
                        VasarlasIdo.Text = myReader.GetDateTime(7).ToString();
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
            String queryString = "SELECT * FROM `sales` WHERE ";
            bool hasInput = false;

            if (!string.IsNullOrEmpty(Nev.Text) && !string.IsNullOrWhiteSpace(Nev.Text))
            {
                queryString += " `sales`.`Name`='" + Nev.Text + "' AND";
                hasInput = true;
            }
            if (!string.IsNullOrEmpty(RaktarID.Text) && !string.IsNullOrWhiteSpace(RaktarID.Text))
            {
                queryString += " `sales`.`StorageID`='" + RaktarID.Text + "' AND";
                hasInput = true;
            }
            if (!string.IsNullOrEmpty(Telefon.Text) && !string.IsNullOrWhiteSpace(Telefon.Text))
            {
                queryString += " `sales`.`Phone`='" + Telefon.Text + "' AND";
                hasInput = true;
            }
            if (!string.IsNullOrEmpty(Cim.Text) && !string.IsNullOrWhiteSpace(Cim.Text))
            {
                queryString += " `sales`.`Address`='" + Cim.Text + "' AND";
                hasInput = true;
            }
            if (!string.IsNullOrEmpty(Azonositok.Text) && !string.IsNullOrWhiteSpace(Azonositok.Text))
            {
                queryString += " `sales`.`ItemNumbers`='" + Azonositok.Text + "' AND";
                hasInput = true;
            }
            if (!string.IsNullOrEmpty(VasarlasID.Text) && !string.IsNullOrWhiteSpace(VasarlasID.Text))
            {
                queryString += " `sales`.`SaleID`='" + VasarlasID.Text + "' AND";
                hasInput = true;
            }
            if (!string.IsNullOrEmpty(Vegosszeg.Text) && !string.IsNullOrWhiteSpace(Vegosszeg.Text))
            {
                queryString += " `sales`.`Sum`='" + Vegosszeg.Text + "' AND";
                hasInput = true;
            }
            if (!string.IsNullOrEmpty(VasarlasIdo.Text) && !string.IsNullOrWhiteSpace(VasarlasIdo.Text))
            {
                queryString += " `sales`.`SaleDatetime`='" + VasarlasIdo.Text + "' AND";
                hasInput = true;
            }

            queryString = queryString.Remove(queryString.Length - 3);
            queryString += " ORDER BY `sales`.`SaleID` ASC";

            if (hasInput && MySQLadapter.IsDatabaseContains(queryString))
            {
                Navigation.PushAsync(new eladasokLV(queryString));
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