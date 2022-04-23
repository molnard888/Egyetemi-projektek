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
            SelectedUsername = _selectedUsername;
            TextboxFeltoltes(SelectedUsername);
        }
        
        private void TextboxFeltoltes(string _selectedUsername)
        {
            
                string MySQLConnString = "datasource=127.0.0.1;port=3306;username=root;password=;database=raktarkezelo";
                MySqlConnection databaseConn = new MySqlConnection(MySQLConnString);
                string queryString = "Select * from `users` WHERE Username='" + _selectedUsername + "'";  
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
                            StorageIdTextbox.Text = myReader.GetString(1);
                            PasswordTextbox.Text = myReader.GetString(2);
                            IsAdminTextbox.Text = myReader.GetString(3);
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
                }
                databaseConn.Close();    
            }
            
        

        private void ModositButton_Click(object sender, EventArgs e)
        {
            string MySQLConnString = "datasource=127.0.0.1;port=3306;username=root;password=;database=raktarkezelo";
            MySqlConnection databaseConn = new MySqlConnection(MySQLConnString);
            string queryString = "update raktarkezelo.users set StorageID='" + StorageIdTextbox.Text + "', Password='" + PasswordTextbox.Text 
                                 + "', IsAdmin='" + IsAdminTextbox.Text  + "', LastName='" + LastnameTextbox.Text + "', FirstName='" + FirstnameTextbox.Text 
                                 + "', PhoneNumber='" + TelefonTextbox.Text  + "', Email='" + EmailTextbox.Text + "' where Username='" + UsernameTextbox.Text + "';";

            // Edit -> Update
            MySqlCommand commandUpdateProds = new MySqlCommand(queryString, databaseConn);
            commandUpdateProds.CommandTimeout = 60;
            
            try
            {
                MySqlDataReader myReader;
                databaseConn.Open();
                myReader = commandUpdateProds.ExecuteReader();
                MessageBox.Show(SelectedUsername + " adatai frissültek!");  
                while (myReader.Read())  
                {  
                }
                databaseConn.Close();
                this.Dispose();
                Form1.felhasznalok_Form.Listaz();
                
            }
            catch (Exception exception)
            {
                MessageBox.Show("Error: " + exception.Message);
            }
            SelectedUsername = "";
        }
    }
}