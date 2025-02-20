using MySqlConnector;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;




namespace T_2_OXOOBF
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {


        public LoginPage()
        {
            InitializeComponent();

        }

        private void Button_Clicked(object sender, EventArgs e)
        {


            string InputUsername = Felhasznalonev.Text;
            string InputPassword = Jelszo.Text;

            MySqlConnection databaseConn = new MySqlConnection(MySQLadapter.builder.ConnectionString);
            string queryString = "Select * from `users` WHERE Username='" + InputUsername + "' and Password='" + Class_Encryption.Encrypt(InputPassword) + "'";
            MySqlCommand commandCheckInputUsers = new MySqlCommand(queryString, databaseConn);
            commandCheckInputUsers.CommandTimeout = 60;

            try
            {
                databaseConn.Open();

                MySqlDataReader myReader = commandCheckInputUsers.ExecuteReader();

                if (myReader.Read())   // Ha jó az input
                {

                    if (myReader.GetBoolean(3))  // Ha admin
                    {
                        Class_Common.setLoggedInUser(InputUsername);
                        Navigation.PushAsync(new Kezdolap(true));
                    }
                    else     // Ha dolgozó
                    {
                        Class_Common.setLoggedInUser(InputUsername);
                        Navigation.PushAsync(new Kezdolap(false));
                    }
                }
                else     // hibás input
                {
                    DisplayAlert("HIBA", "Hibás adatok", "OK");
                }
            }
            catch (Exception exception)
            {
                DisplayAlert("HIBA catch", "Error: " + exception.Message, "OK");
                string ErrorString = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " - Error during login: " + exception.Message;
                Class_Logging.WriteToLogFile(ErrorString);
            }
            databaseConn.Close();

            Felhasznalonev.Text = "";
            Jelszo.Text = "";
        }


    }
}
