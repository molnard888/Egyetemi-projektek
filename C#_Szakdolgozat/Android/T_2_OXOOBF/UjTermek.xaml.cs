using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.QrCode.Internal;
using static T_2_OXOOBF.Class_Common;

namespace T_2_OXOOBF
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UjTermek : ContentPage
    {
        int Mode;
        public UjTermek(int _mode, string TermekCikkszam=null)
        {
            InitializeComponent();
            UsernameLbl.Text = Class_Common.getLoggedInUser();
            Mode = _mode;

            switch (Mode)
            {
                case 0:
                    MentesBttn.Text = "Hozzáad";
                    break;
                case 1:
                    MentesBttn.Text = "Módosít";
                    TermekInfo(TermekCikkszam);
                    break;
                case 2:
                    MentesBttn.Text = "Keresés";
                    break;
            }
        }

        

        private void MentesBttn_Clicked(object sender, EventArgs e)
        {
            switch (Mode)
            {
                case 0:
                    WriteNewProductToDb();
                    break;
                case 1:
                    UpdateProductToDb();
                    break;
                case 2:
                    SearchProduct();
                    break;
            }
        }

        private void TermekInfo(string TermekCikkszam)
        {
            MySqlConnection databaseConn = new MySqlConnection(MySQLadapter.builder.ConnectionString);
            string queryString = "Select * from `products` WHERE ItemNumber='" + TermekCikkszam + "'";   // Termeknev 
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
                        Azonosito.Text = myReader.GetString(0);
                        Raktar.Text = myReader.GetInt64(1).ToString();
                        Marka.Text = myReader.GetString(2);
                        Tipus.Text = myReader.GetString(3);
                        Kategoria.Text = myReader.GetString(4);
                        Ar.Text = myReader.GetInt64(5).ToString();
                        Mennyiseg.Text = myReader.GetInt64(6).ToString();
                        Lokacio_sor.Text = myReader.GetInt64(7).ToString();
                        Lokacio_oszlop.Text = myReader.GetInt64(8).ToString();
                        Lokacio_szint.Text = myReader.GetInt64(9).ToString();
                    }
                }
                databaseConn.Close();

            }
            catch (Exception exception)
            {
                databaseConn.Close();

                DisplayAlert("Error: ", exception.Message, "OK");
                string ErrorString = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " - Error during getting products from DB: " + exception.Message;
                Class_Logging.WriteToLogFile(ErrorString);
            }
            
        }

        private void WriteNewProductToDb()
        {
            if (CheckIfInputsNotEmpty())
            {
                DisplayAlert("Hiba:", "Érvénytelen Adat!", "ok");
            }
            else
            {
                string SqlExecuteCommand = "INSERT INTO raktarkezelo.products VALUES ('" + Azonosito.Text + "', '" + Raktar.Text + "', '"
                                     + Marka.Text + "', '" + Tipus.Text + "', '" + Kategoria.Text + "', '"
                                     + Ar.Text + "', '" + Mennyiseg.Text + "', '" + Lokacio_sor.Text + "', '"
                                     + Lokacio_oszlop.Text + "', '" + Lokacio_szint.Text + "');";

                string returnedAnswer = MySQLadapter.ExecuteSqlCommand(SqlExecuteCommand, "Inserted Product", Azonosito.Text);

                DisplayAlert("Üzenet", returnedAnswer, "OK");

            }
        }

        private void UpdateProductToDb()
        {
            string SqlExecuteCommand = "UPDATE raktarkezelo.products SET StorageID='" + Raktar.Text + "', Brand='" + Marka.Text
                                 + "', Type='" + Tipus.Text + "', Category='" + Kategoria.Text + "', Price='" + Ar.Text
                                 + "', Quantity='" + Mennyiseg.Text + "', InnerLocRow='" + Lokacio_sor.Text + "', InnerLocColumn='" + Lokacio_oszlop.Text
                                 + "', InnerLocLevel='" + Lokacio_szint.Text + "' where ItemNumber='" + Azonosito.Text + "';";

            string returnedAnswer = MySQLadapter.ExecuteSqlCommand(SqlExecuteCommand, "Updated Product Data", Azonosito.Text);
            DisplayAlert("Üzenet", returnedAnswer, "OK");
        }

        private void SearchProduct()
        {
            String queryString = "SELECT * FROM `products` WHERE ";
            bool hasInput = false;

            if (!string.IsNullOrEmpty(Raktar.Text) && !string.IsNullOrWhiteSpace(Raktar.Text))
            {
                queryString += " `products`.`StorageID`='" + Raktar.Text + "' AND";
                hasInput = true;
            }
            if (!string.IsNullOrEmpty(Marka.Text) && !string.IsNullOrWhiteSpace(Marka.Text))
            {
                queryString += " `products`.`Brand`='" + Marka.Text + "' AND";
                hasInput = true;
            }
            if (!string.IsNullOrEmpty(Tipus.Text) && !string.IsNullOrWhiteSpace(Tipus.Text))
            {
                queryString += " `products`.`Type`='" + Tipus.Text + "' AND";
                hasInput = true;
            }
            if (!string.IsNullOrEmpty(Kategoria.Text) && !string.IsNullOrWhiteSpace(Kategoria.Text))
            {
                queryString += " `products`.`Category`='" + Kategoria.Text + "' AND";
                hasInput = true;
            }
            if (!string.IsNullOrEmpty(Ar.Text) && !string.IsNullOrWhiteSpace(Ar.Text))
            {
                queryString += " `products`.`Price`='" + Ar.Text + "' AND";
                hasInput = true;
            }
            if (!string.IsNullOrEmpty(Mennyiseg.Text) && !string.IsNullOrWhiteSpace(Mennyiseg.Text))
            {
                queryString += " `products`.`Quantity`='" + Mennyiseg.Text + "' AND";
                hasInput = true;
            }
            if (!string.IsNullOrEmpty(Lokacio_sor.Text) && !string.IsNullOrWhiteSpace(Lokacio_sor.Text))
            {
                queryString += " `products`.`InnerLocRow`='" + Lokacio_sor.Text + "' AND";
                hasInput = true;
            }
            if (!string.IsNullOrEmpty(Lokacio_oszlop.Text) && !string.IsNullOrWhiteSpace(Lokacio_oszlop.Text))
            {
                queryString += " `products`.`InnerLocColumn`='" + Lokacio_oszlop.Text + "' AND";
                hasInput = true;
            }
            if (!string.IsNullOrEmpty(Lokacio_szint.Text) && !string.IsNullOrWhiteSpace(Lokacio_szint.Text))
            {
                queryString += " `products`.`InnerLocLevel`='" + Lokacio_szint.Text + "' AND";
                hasInput = true;
            }
            if (!string.IsNullOrEmpty(Azonosito.Text) && !string.IsNullOrWhiteSpace(Azonosito.Text))
            {
                queryString += " `products`.`ItemNumber`='" + Azonosito.Text + "' AND";
                hasInput = true;
            }
            queryString = queryString.Remove(queryString.Length - 3);
            queryString += " ORDER BY `products`.`Brand` ASC";

            if (hasInput && MySQLadapter.IsDatabaseContains(queryString))
            {
                Navigation.PushAsync(new TermekekLV(queryString, true));
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

        private bool CheckIfInputsNotEmpty()
        {
            if (string.IsNullOrEmpty(Raktar.Text) || string.IsNullOrWhiteSpace(Raktar.Text) ||
            string.IsNullOrEmpty(Marka.Text) || string.IsNullOrWhiteSpace(Marka.Text) ||
            string.IsNullOrEmpty(Tipus.Text) || string.IsNullOrWhiteSpace(Tipus.Text) ||
            string.IsNullOrEmpty(Kategoria.Text) || string.IsNullOrWhiteSpace(Kategoria.Text) ||
            string.IsNullOrEmpty(Ar.Text) || string.IsNullOrWhiteSpace(Ar.Text) ||
            string.IsNullOrEmpty(Mennyiseg.Text) || string.IsNullOrWhiteSpace(Mennyiseg.Text) ||
            string.IsNullOrEmpty(Lokacio_sor.Text) || string.IsNullOrWhiteSpace(Lokacio_sor.Text) ||
            string.IsNullOrEmpty(Lokacio_oszlop.Text) || string.IsNullOrWhiteSpace(Lokacio_oszlop.Text) ||
            string.IsNullOrEmpty(Lokacio_szint.Text) || string.IsNullOrWhiteSpace(Lokacio_szint.Text) ||
            string.IsNullOrEmpty(Azonosito.Text) || string.IsNullOrWhiteSpace(Azonosito.Text))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void LogOutBtn_Clicked(object sender, EventArgs e)
        {
            Class_Common.LogOutWriteToDb();
            (Application.Current).MainPage = new NavigationPage(new LoginPage());
        }

    }
}