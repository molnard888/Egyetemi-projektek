using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Raktarkezelo
{
    public partial class FelhasznaloModosit : Form
    {
        private string SelectedUsername = "";
        
        
        public FelhasznaloModosit(string _selectedUsername)
        {
            InitializeComponent();
            UsernameTextbox.Enabled = false;

            this.CenterToParent();
            SelectedUsername = _selectedUsername;
            TextboxFeltoltes(SelectedUsername);

        }
        
        private void TextboxFeltoltes(string _selectedUsername)
        {
            
            MySqlConnection databaseConn = MySQLadapter.CreateDbConnection();
                string queryString = "Select * from `users` WHERE Username='" + _selectedUsername + "'";  
                MySqlCommand SqlSelectCommand = new MySqlCommand(queryString, databaseConn);
                SqlSelectCommand.CommandTimeout = 60;

                try
                {
                    databaseConn.Open();
                    MySqlDataReader myReader = SqlSelectCommand.ExecuteReader();

                    if (myReader.HasRows) // Ha jó az input
                    {
                        while (myReader.Read())
                        {
                            UsernameTextbox.Text = myReader.GetString(0);
                            StorageIdTextbox.Text = myReader.GetInt16(1).ToString();
                            PasswordTextbox.Text = myReader.GetString(2);
                            IsAdminTextbox.Text = myReader.GetInt16(3).ToString();
                            LastnameTextbox.Text = myReader.GetString(4);
                            FirstnameTextbox.Text = myReader.GetString(5);
                            TelefonTextbox.Text = myReader.GetString(6);
                            EmailTextbox.Text = myReader.GetString(7);
                        }
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Error: " + exception.Message);
                    string ErrorString = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " - Error during filling up FelhasznaloModosit textbox: " + exception.Message;
                    Class_Logging.WriteToLogFile(ErrorString);
                }
                databaseConn.Close();    
            }
            
        

        private void ModositButton_Click(object sender, EventArgs e)
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
                MessageBox.Show("Érvénytelen Adat!");
            }
            else
            {

                MySqlConnection databaseConn = MySQLadapter.CreateDbConnection();
                string SqlExecuteCommand = "update raktarkezelo.users set StorageID='" + StorageIdTextbox.Text + "', Password='" + Class_Encryption.Encrypt(PasswordTextbox.Text)
                                     + "', IsAdmin='" + IsAdminTextbox.Text + "', LastName='" + LastnameTextbox.Text + "', FirstName='" + FirstnameTextbox.Text
                                     + "', PhoneNumber='" + TelefonTextbox.Text + "', Email='" + EmailTextbox.Text + "' where Username='" + UsernameTextbox.Text + "';";

                string returnedAnswer = MySQLadapter.ExecuteSqlCommand(SqlExecuteCommand, "Updated User", UsernameTextbox.Text);

                MessageBox.Show(returnedAnswer);
                SelectedUsername = "";
                Kezdolap.felhasznalok_Form.Listaz();

            }
        }
    }
}