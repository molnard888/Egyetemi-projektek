using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Raktarkezelo
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string InputUsername = UsernameTextbox.Text;
            string InputPassword = PwTextbox.Text;
            string MySQLConnString = "datasource=127.0.0.1;port=3306;username=root;password=;database=raktarkezelo";
            MySqlConnection databaseConn = new MySqlConnection(MySQLConnString);
            string queryString = "Select * from `users` WHERE Username='" + InputUsername + "'";
            MySqlCommand commandCheckInputUsers = new MySqlCommand(queryString, databaseConn);
            commandCheckInputUsers.CommandTimeout = 60;

            try
            {
                databaseConn.Open();
                 
                MessageBox.Show("Kapcsolat létrejöt!");
                MySqlDataReader myReader = commandCheckInputUsers.ExecuteReader();
                
                if (myReader.HasRows && myReader.Read() && InputPassword==myReader.GetString(2) )   // Ha jó az input
                {
                    if (Convert.ToBoolean(myReader.GetString(3)))  // Ha admin
                    {
                        
                       
                        /*
                        ShowingPanelFront(WorkerBasePanel);
                        ShowingPanelFront(DisplayProductsPanel);
                        WbPanelSignedInAsUserLabel.Text = InputUsername;
                        WbPanelAddNewUserButton.Show();
                        WbPanelDisplayUsersButton.Show();
                        DisplayProductsPanelDeleteButton.Show();
                        WbPanelDispProductsButton.PerformClick(); */
                    }
                    else     // Ha dolgozó
                    {
                        // dolgozopanel
                        
                        /* HideAllPanels();
                        ShowingPanelFront(WorkerBasePanel);
                        ShowingPanelFront(DisplayProductsPanel);
                        WbPanelSignedInAsUserLabel.Text = InputUsername;
                        WbPanelAddNewUserButton.Hide();
                        WbPanelDisplayUsersButton.Hide();
                        DisplayProductsPanelDeleteButton.Hide();
                        WbPanelDispProductsButton.PerformClick(); */
                        
                    }
                    databaseConn.Close();
                }
                else     // hibás input
                {
                    MessageBox.Show("Invalid Username or Password");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Error: " + exception.Message);
            }
            

            UsernameTextbox.Text = "";
            PwTextbox.Text = "";
        }
    }
}