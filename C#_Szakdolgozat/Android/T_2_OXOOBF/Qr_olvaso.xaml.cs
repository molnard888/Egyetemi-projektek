using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MySqlConnector;
using static T_2_OXOOBF.Class_Common;

namespace T_2_OXOOBF
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Qr_olvaso : ContentPage
    {
        bool EladOrNo=false;
        public Qr_olvaso(bool EladOrNot)
        {
            InitializeComponent();

            EladOrNo = EladOrNot;
            UsernameLbl.Text = Class_Common.getLoggedInUser();
        }

        private void ZXingScannerView_OnScanResult(ZXing.Result result)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                
                ScanResult.Text = result.Text;
                QRscanner.IsScanning = false;
                
                if(EladOrNo == true)
                {

                    MySqlConnection databaseConn = new MySqlConnection(MySQLadapter.builder.ConnectionString);
                    string queryString = "Select * from `products` WHERE ItemNumber='" + ScanResult.Text + "'";   // ItemNumber 
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
                                Class_Common.CartItems.Add(new Class_Termek(myReader.GetString(0),
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
                    }
                    catch (Exception exception)
                    {
                        DisplayAlert("Error",exception.Message, "OK");
                        string ErrorString = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " - Error during Selecting product by ItemNumber from Db: " + exception.Message;
                        Class_Logging.WriteToLogFile(ErrorString);
                    }
                    databaseConn.Close();


                    Navigation.PushAsync(new Eladas(Class_Common.CartItems));
                }
                else
                {
                    Navigation.PushAsync(new TermekekLV(ScanResult.Text, false));
                }
                
                
                
            });
        }

        private void LogOutBtn_Clicked(object sender, EventArgs e)
        {
            Class_Common.LogOutWriteToDb();
            (Application.Current).MainPage = new NavigationPage(new LoginPage());
        }

        private void BeolvasStartStop_Clicked(object sender, EventArgs e)
        {
            if (QRscanner.IsScanning == true)
            {
                QRscanner.IsScanning = false;
            }
            else
            {
                QRscanner.IsScanning = false;
            }
        }
    }
}