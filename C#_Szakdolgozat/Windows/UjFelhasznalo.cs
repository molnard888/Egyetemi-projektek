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
            
            this.CenterToParent();
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
                
                string SqlExecuteCommand = "INSERT INTO raktarkezelo.users VALUES ('" + UsernameTextbox.Text + "', '" + StorageIdTextbox.Text + "', '" 
                                     + Class_Encryption.Encrypt(PasswordTextbox.Text) + "', '" + IsAdminTextbox.Text + "', '" + LastnameTextbox.Text  + "', '" 
                                     + FirstnameTextbox.Text + "', '" + TelefonTextbox.Text + "', '" + EmailTextbox.Text + "');";
                
                string returnedAnswer = MySQLadapter.ExecuteSqlCommand(SqlExecuteCommand, "Added User", UsernameTextbox.Text);

                MessageBox.Show(returnedAnswer);

                Kezdolap.felhasznalok_Form = new Felhasznalok();
                    Kezdolap.felhasznalok_Form.ShowDialog();
                    this.Dispose();
                
            }
        }

        private void UjFelhasznalo_Load(object sender, EventArgs e)
        {
            this.ActiveControl = UsernameTextbox;
        }
    }
}