using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static T_2_OXOOBF.Class_Common;

namespace T_2_OXOOBF
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UjFelhasznalo : ContentPage
    {
        int Mode;
        public UjFelhasznalo(int _mode, string UserNameForEditing = null)  // 0: Uj, 1: Módosít, 2: Keresés
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
                    UsernameTextbox.IsEnabled = false;
                    UserInfo(UserNameForEditing);
                    break;
                case 2:
                    MentesBttn.Text = "Keresés";
                    PasswordLbl.TextColor = Color.Gray;
                    PasswordTextbox.IsEnabled = false;
                    break;
            }
                
        }

        private void MentesBttn_Clicked(object sender, EventArgs e)
        {
            switch (Mode)
            {
                case 0:
                    WriteNewUserToDb();
                    break;
                case 1:
                    UpdateUserToDb();
                    break;
                case 2:
                    SearchUser();
                    break;  
            }
        }

        private void UserInfo(string UserNameForEditing)
        {
            MySqlConnection databaseConn = new MySqlConnection(MySQLadapter.builder.ConnectionString);
            string queryString = "SELECT * FROM `users` WHERE Username='" + UserNameForEditing + "'";   // Felhasznalonev 
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
                        UsernameTextbox.Text = myReader.GetString(0);
                        StorageIdTextbox.Text = myReader.GetInt64(1).ToString();
                        PasswordTextbox.Text = myReader.GetString(2);
                        IsAdminTextbox.Text = myReader.GetInt64(3).ToString();
                        LastnameTextbox.Text = myReader.GetString(4);
                        FirstnameTextbox.Text = myReader.GetString(5);
                        TelefonTextbox.Text = myReader.GetString(6);
                        EmailTextbox.Text = myReader.GetString(7);
                    }
                }
                databaseConn.Close();

            }
            catch (Exception exception)
            {
                databaseConn.Close();

                DisplayAlert("Error: ", exception.Message, "OK");
                string ErrorString = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " - Error during getting user from DB: " + exception.Message;
                Class_Logging.WriteToLogFile(ErrorString);
            }
        }

        private void SearchUser()
        {
            String queryString = "SELECT * FROM `users` WHERE ";
            bool hasInput = false;

            if (!string.IsNullOrEmpty(UsernameTextbox.Text) && !string.IsNullOrWhiteSpace(UsernameTextbox.Text))
            {
                queryString += " `users`.`Username`='" + UsernameTextbox.Text + "' AND";
                hasInput = true;
            }
            if (!string.IsNullOrEmpty(StorageIdTextbox.Text) && !string.IsNullOrWhiteSpace(StorageIdTextbox.Text))
            {
                queryString += " `users`.`StorageID`='" + StorageIdTextbox.Text + "' AND";
                hasInput = true;
            }
            if (!string.IsNullOrEmpty(IsAdminTextbox.Text) && !string.IsNullOrWhiteSpace(IsAdminTextbox.Text))
            {
                queryString += " `users`.`IsAdmin`='" + IsAdminTextbox.Text + "' AND";
                hasInput = true;
            }
            if (!string.IsNullOrEmpty(LastnameTextbox.Text) && !string.IsNullOrWhiteSpace(LastnameTextbox.Text))
            {
                queryString += " `users`.`LastName`='" + LastnameTextbox.Text + "' AND";
                hasInput = true;
            }
            if (!string.IsNullOrEmpty(FirstnameTextbox.Text) && !string.IsNullOrWhiteSpace(FirstnameTextbox.Text))
            {
                queryString += " `users`.`FirstName`='" + FirstnameTextbox.Text + "' AND";
                hasInput = true;
            }
            if (!string.IsNullOrEmpty(TelefonTextbox.Text) && !string.IsNullOrWhiteSpace(TelefonTextbox.Text))
            {
                queryString += " `users`.`PhoneNumber`='" + TelefonTextbox.Text + "' AND";
                hasInput = true;
            }
            if (!string.IsNullOrEmpty(EmailTextbox.Text) && !string.IsNullOrWhiteSpace(EmailTextbox.Text))
            {
                queryString += " `users`.`Email`='" + EmailTextbox.Text + "' AND";
                hasInput = true;
            }
            queryString = queryString.Remove(queryString.Length - 3);
            queryString += " ORDER BY `users`.`Username` ASC";

            if (hasInput && MySQLadapter.IsDatabaseContains(queryString))
            {
                Navigation.PushAsync(new FelhasznalokLV(queryString));
            }
            else if(!hasInput)
            {
                DisplayAlert("Hiba:", "Minden mező üres!", "OK");
            }
            else if (!MySQLadapter.IsDatabaseContains(queryString))
            {
                DisplayAlert("Hiba", "Nincs találat", "OK");
            }

        }

        private void UpdateUserToDb()
        {
            if (CheckIfInputsNotEmpty())
            {
                DisplayAlert("Hiba:", "Egy mező sem lehet üres!", "OK");
            }
            else
            {
                string SqlExecuteCommand = "UPDATE raktarkezelo.users SET StorageID='" + StorageIdTextbox.Text + "', Password='" + Class_Encryption.Encrypt(PasswordTextbox.Text)
                                 + "', IsAdmin='" + IsAdminTextbox.Text + "', LastName='" + LastnameTextbox.Text + "', FirstName='" + FirstnameTextbox.Text
                                 + "', PhoneNumber='" + TelefonTextbox.Text + "', Email='" + EmailTextbox.Text + "' "+ " WHERE Username='"+ UsernameTextbox.Text+ "';";

                string returnedAnswer = MySQLadapter.ExecuteSqlCommand(SqlExecuteCommand, "Updated User Data", UsernameTextbox.Text);

                DisplayAlert("Üzenet", returnedAnswer, "OK");
            }
        }


        private void WriteNewUserToDb()
        {
            if (CheckIfInputsNotEmpty())
            {
                DisplayAlert("Hiba:", "Egy mező sem lehet üres!", "OK");
            }
            else
            {
                string SqlExecuteCommand = "INSERT INTO raktarkezelo.users VALUES ('" + UsernameTextbox.Text + "', '" + StorageIdTextbox.Text + "', '"
                                     + Class_Encryption.Encrypt(PasswordTextbox.Text) + "', '" + IsAdminTextbox.Text + "', '" + LastnameTextbox.Text + "', '"
                                     + FirstnameTextbox.Text + "', '" + TelefonTextbox.Text + "', '" + EmailTextbox.Text + "');";

                string returnedAnswer = MySQLadapter.ExecuteSqlCommand(SqlExecuteCommand, "Inserted User", UsernameTextbox.Text);

                DisplayAlert("Üzenet", returnedAnswer, "OK");
            }
        }

        private bool CheckIfInputsNotEmpty()
        {
            if (string.IsNullOrEmpty(UsernameTextbox.Text) || string.IsNullOrWhiteSpace(UsernameTextbox.Text) ||
                string.IsNullOrEmpty(StorageIdTextbox.Text) || string.IsNullOrWhiteSpace(StorageIdTextbox.Text) ||
                string.IsNullOrEmpty(PasswordTextbox.Text) || string.IsNullOrWhiteSpace(PasswordTextbox.Text) ||
                string.IsNullOrEmpty(IsAdminTextbox.Text) || string.IsNullOrWhiteSpace(IsAdminTextbox.Text) ||
                string.IsNullOrEmpty(LastnameTextbox.Text) || string.IsNullOrWhiteSpace(LastnameTextbox.Text) ||
                string.IsNullOrEmpty(FirstnameTextbox.Text) || string.IsNullOrWhiteSpace(FirstnameTextbox.Text) ||
                string.IsNullOrEmpty(TelefonTextbox.Text) || string.IsNullOrWhiteSpace(TelefonTextbox.Text) ||
                string.IsNullOrEmpty(EmailTextbox.Text) || string.IsNullOrWhiteSpace(EmailTextbox.Text))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void LogOutBtn_Clicked(object sender, EventArgs e)
        {
            Class_Common.LogOutWriteToDb();
            (Application.Current).MainPage = new NavigationPage(new LoginPage());
        }
    }
}