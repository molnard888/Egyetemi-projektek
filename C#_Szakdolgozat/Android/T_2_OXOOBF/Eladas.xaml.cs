using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static T_2_OXOOBF.Class_Common;

namespace T_2_OXOOBF
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Eladas : ContentPage
    {
        private List<Class_Termek> CartProds= new List<Class_Termek>();
        private Dictionary<string, int> DictProdQuantityInDb = new Dictionary<string, int>();
        private List<string> KosarLista = new List<string>();
        private Class_Termek SelectedItem = null;
        Color BttnDefaBlue = Color.FromHex("#2194f3");

        public Eladas(List<Class_Termek> InputList)
        {
            InitializeComponent();
            UsernameLbl.Text = Class_Common.getLoggedInUser();
            CartProds = InputList;
            Listaz();
        }

        private void Listaz()
        {
            MyListView.ItemsSource = null;
            MyListView.ItemsSource = CartProds; 

            int sum = 0;
            foreach (var item in CartProds)
            {
                try
                {
                    string VegosszegOnlyNumber = item.Ar.Remove(item.Ar.Length - 3);

                    //DisplayAlert("", VegosszegOnlyNumber +" "+ item.Cikkszam, "OK");

                    int result = 0;
                    if (int.TryParse(VegosszegOnlyNumber, out result))
                    {
                        sum += result;
                    }
                }
                catch (Exception ex)
                {
                    DisplayAlert("Error", ex.Message, "ok");
                }
            }
            Vegosszeg.Text = "Végösszeg: " + sum.ToString() + " Ft";
        }


        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;
            
            Class_Termek tempSelected = e.Item as Class_Termek;

            if (TorolBttn.BackgroundColor == Color.Orange)
            {
                bool DispAlertResponse = await DisplayAlert("Kiválasztva:", $"{tempSelected.Tipus}", "Törlés", "Mégse");
                if (DispAlertResponse)
                {
                    SelectedItem = e.Item as Class_Termek;
                }
            }

        }


        private void LogOutBtn_Clicked(object sender, EventArgs e)
        {
            Class_Common.LogOutWriteToDb();
            (Application.Current).MainPage = new NavigationPage(new LoginPage());
        }

        
        private void TorolBttn_Clicked(object sender, EventArgs e)
        {
            if (TorolBttn.BackgroundColor == Color.Orange && SelectedItem != null && !string.IsNullOrEmpty(SelectedItem.Cikkszam) && !string.IsNullOrWhiteSpace(SelectedItem.Cikkszam))
            {
                Listaz();
                TorolBttn.BackgroundColor = BttnDefaBlue;
            }
            else
            {
                SelectedItem = null;
                TorolBttn.BackgroundColor = Color.Orange;
            }
            SelectedItem = null;
        }

        private void BeolvasBttn_Clicked(object sender, EventArgs e)
        {
            // QR kod olvaso
            Class_Common.CartItems.Clear();
            Class_Common.CartItems = CartProds;
            Navigation.PushAsync(new Qr_olvaso(true));
        }

        private void OsszTorolBttn_Clicked(object sender, EventArgs e)
        {
            Vegosszeg.Text = "";
            CartProds = null;
            KosarLista = null;
            MyListView.ItemsSource = null;
        }

        private void EladasBttn_Clicked(object sender, EventArgs e)
        {
            string msgBoxError = "";
            if (CartProds == null || CartProds.Count() == 0)
            {
                DisplayAlert("Error","A kosár üres!","OK");
            }
            else
            {
                GetQuantityForProducts();
                bool IsQuantityEnough = true;
                GetQuantityForProducts();
                var CartProdIdsAndQuantity = KosarLista.GroupBy(x => x)
                                .Select(g => new { Value = g.Key, Count = g.Count() })
                                .OrderByDescending(x => x.Count);

                foreach (var x in CartProdIdsAndQuantity)
                {
                    if (DictProdQuantityInDb[x.Value] - x.Count < 0)
                    {
                        IsQuantityEnough = false;
                        msgBoxError = "[" + x.Value + "] termékből nincs elegendő darabszám a raktárban!";
                    }
                }

                if (IsQuantityEnough)
                {
                    try
                    {
                        string VegosszegOnlyNumber = Vegosszeg.Text.Remove(Vegosszeg.Text.Length - 3);
                        VegosszegOnlyNumber = VegosszegOnlyNumber.Remove(0, 11);
                        //DisplayAlert("", VegosszegOnlyNumber, "OK");
                        int Sum = 0;
                        if (int.TryParse(VegosszegOnlyNumber, out Sum))
                        { }

                        if (string.IsNullOrEmpty(Nev.Text) || string.IsNullOrWhiteSpace(Nev.Text) ||
                        string.IsNullOrEmpty(Cim.Text) || string.IsNullOrWhiteSpace(Cim.Text) ||
                        string.IsNullOrEmpty(Telefon.Text) || string.IsNullOrWhiteSpace(Telefon.Text) || Sum <= 0)
                        {
                            DisplayAlert("Hiba", "Érvénytelen Adat!", "OK");
                        }
                        else
                        {
                            string SaleTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss_");
                            string VasarlasID = SaleTime + Telefon.Text;

                            string InsertSaleUpdateProdQuantityTransaction = "START TRANSACTION; \n";
                            string ProdIdsAndQuantities = "";

                            foreach (var x in CartProdIdsAndQuantity)
                            {
                                ProdIdsAndQuantities += x.Value + "(" + x.Count + "),";
                                InsertSaleUpdateProdQuantityTransaction += "UPDATE raktarkezelo.products set Quantity = Quantity - " + x.Count + " WHERE ItemNumber = '" + x.Value + "'; \n";
                            }
                            ProdIdsAndQuantities = ProdIdsAndQuantities.Remove(ProdIdsAndQuantities.Length - 1, 1);

                            InsertSaleUpdateProdQuantityTransaction += "INSERT INTO raktarkezelo.sales VALUES ('" + Nev.Text + "', '" + Telefon.Text + "', '"
                                                + Cim.Text + "', '" + Class_Common.getStorageIDforUser() + "', '" + ProdIdsAndQuantities + "', '" + VasarlasID + "', '"
                                                + VegosszegOnlyNumber + "', '" + SaleTime + "'); ";


                            InsertSaleUpdateProdQuantityTransaction += "\nCOMMIT;";

                            string returnedAnswer = MySQLadapter.ExecuteSqlCommand(InsertSaleUpdateProdQuantityTransaction, "Added Sale", VasarlasID);

                            DisplayAlert("Üzenet", returnedAnswer, "OK");
                        }
                    }
                    catch (Exception exception)
                    {
                        DisplayAlert("Error", exception.Message, "OK");
                        string ErrorString = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " - Error during selling the products: " + exception.Message;
                        Class_Logging.WriteToLogFile(ErrorString);
                    }
                }
                else
                {
                    DisplayAlert("Error", msgBoxError, "OK");
                }



                
            }
        }


        private void GetQuantityForProducts()
        {
            KosarLista = new List<string>();
            foreach (var item in CartProds)
            {
                KosarLista.Add(item.Cikkszam);
            }
            DictProdQuantityInDb = new Dictionary<string, int>();
            List<string> KosarListaUnique = KosarLista.Distinct().ToList();

            MySqlConnection databaseConn = new MySqlConnection(MySQLadapter.builder.ConnectionString);
            string queryString = null;
            for (int i = 0; i < KosarListaUnique.Count; i++)
            {
                queryString = "SELECT ItemNumber, Quantity FROM raktarkezelo.products WHERE ItemNumber='" + KosarListaUnique[i] + "';";
                MySqlCommand SqlSelectCommand = new MySqlCommand(queryString, databaseConn);
                SqlSelectCommand.CommandTimeout = 60;

                try
                {
                    databaseConn.Open();

                    MySqlDataReader myReader = SqlSelectCommand.ExecuteReader();

                    if (myReader.HasRows) // Ha jó az input
                    {
                        // ItemNumber | Quantity ";
                        while (myReader.Read())
                        {
                            DictProdQuantityInDb.Add(myReader.GetString(0), myReader.GetInt32(1));
                        }
                    }

                    databaseConn.Close();
                }
                catch (Exception exception)
                {
                    if (databaseConn != null)
                    {
                        databaseConn.Close();
                    }
                    DisplayAlert("Error: ", exception.Message + " n" + queryString, "OK");
                    string ErrorString = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " - Error during getting Quantites from Db: " + exception.Message;
                    Class_Logging.WriteToLogFile(ErrorString);
                }
            }
        }





    }
    
}