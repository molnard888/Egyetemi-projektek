using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Raktarkezelo
{
    public partial class UjFelhasznalo : Form
    {
        public UjFelhasznalo()
        {
            InitializeComponent();
        }

        private void HozzaadButton_Click(object sender, EventArgs e)
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
                string MySQLConnString = "datasource=127.0.0.1;port=3306;username=root;password=;database=raktarkezelo";
                MySqlConnection databaseConn = new MySqlConnection(MySQLConnString);
                
                // insert !!!
                string queryString = "INSERT INTO raktarkezelo.users VALUES ('" + UsernameTextbox.Text + "', '" + StorageIdTextbox.Text + "', '" 
                                     + PasswordTextbox.Text + "', '" + IsAdminTextbox.Text + "', '" + LastnameTextbox.Text  + "', '" 
                                     + FirstnameTextbox.Text + "', '" + TelefonTextbox.Text + "', '" + EmailTextbox.Text + "');"; 
                // Edit -> Insert
                MySqlCommand commandUpdateProds = new MySqlCommand(queryString, databaseConn);
                commandUpdateProds.CommandTimeout = 60;
            
                try
                {
                    MySqlDataReader myReader;
                    databaseConn.Open();
                    myReader = commandUpdateProds.ExecuteReader();
                    MessageBox.Show("Felhasználó hozzáadva!");  
                    while (myReader.Read())  
                    {  
                    }
                    databaseConn.Close();
                    Form1.felhasznalok_Form = new Felhasznalok();
                    Form1.felhasznalok_Form.Show();
                    this.Dispose();
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Error: " + exception.Message);
                }
            }
        }

        private void UjFelhasznalo_Load(object sender, EventArgs e)
        {
            this.ActiveControl = UsernameTextbox;
        }
    }
}