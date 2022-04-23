using MySqlConnector;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;




namespace T_2_OXOOBF
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        

        public Page1()
        {
            InitializeComponent();

            

        //Navigation.PushAsync(new Kezdolap(true, "Admin"));

        //try
        //{

        //    string MySQLConnString = "server=192.168.1.32;user=root;password=;database=1234";
        //    "Server = 192.168.1.32; Port = 3306; Database = 1234; user = root; password =";

        //    "server=127.0.0.1;port=3307;user=root;password=;database=raktarkezelo";
        //    MySqlConnection mySQLCon = new MySqlConnection(builder.ConnectionString);
        //    Console.WriteLine("Opening connection");
        //    mySQLCon.Open();

        //    if (mySQLCon.State.ToString() != "Open")
        //    {
        //        DisplayAlert("HIBA", mySQLCon.State.ToString(), "OK");
        //    }
        //    else
        //    {
        //        DisplayAlert("", "Kapcsolat létrejött!", "OK");
        //    }


        //}
        //catch (Exception exception)
        //{
        //    DisplayAlert("HIBA", exception.Message, "OK");
        //}
    }

        private void Button_Clicked(object sender, EventArgs e)
        {


            string InputUsername = Felhasznalonev.Text;
            string InputPassword = Jelszo.Text;

            MySqlConnection databaseConn = new MySqlConnection(Helper.builder.ConnectionString);
            string queryString = "Select * from `users` WHERE Username='" + InputUsername + "' and Password='" + InputPassword + "'";
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

                        Navigation.PushAsync(new Kezdolap(true, InputUsername));
                    }
                    else     // Ha dolgozó
                    {
                        Navigation.PushAsync(new Kezdolap(false, InputUsername));

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
            }
            databaseConn.Close();

            Felhasznalonev.Text = "";
            Jelszo.Text = "";
        }


    }
}
