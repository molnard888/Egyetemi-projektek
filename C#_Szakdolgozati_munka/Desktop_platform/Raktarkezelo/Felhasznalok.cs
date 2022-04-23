using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Raktarkezelo
{
    public partial class Felhasznalok : Form
    {
        string FelhasznalokPanel_RichtextboxSelectedUsername = "";
        private string Talalat = "";
        
        public Felhasznalok()
        {
            InitializeComponent();
        }
        
        public Felhasznalok(string talalat)
        {
            if(!talalat.Equals("Select * from `products` WHERE 1 "))
                Talalat = talalat;
            InitializeComponent();
        }

        public void KeresByQuery(string _queryString)
        {
            if (!string.IsNullOrEmpty(_queryString) && !string.IsNullOrWhiteSpace(_queryString))
            {
                FelhasznalokPanel_RichtextboxSelectedUsername = "";
                richTextBox1.Text = "";

                string MySQLConnString = "datasource=127.0.0.1;port=3306;username=root;password=;database=raktarkezelo";
                MySqlConnection databaseConn = new MySqlConnection(MySQLConnString);
                MySqlCommand commandCheckInputUsers = new MySqlCommand(_queryString, databaseConn);
                commandCheckInputUsers.CommandTimeout = 60;

                try
                {
                    databaseConn.Open();
                    MySqlDataReader myReader = commandCheckInputUsers.ExecuteReader();

                    if (myReader.HasRows) // Ha jó az input
                    {
                        while (myReader.Read())
                        {
                            richTextBox1.Text += myReader.GetString(0) + " | " + myReader.GetString(1) + " | " + myReader.GetString(4)
                                                 + " " + myReader.GetString(5) + " | " + myReader.GetString(7) + "\n";
                        }
                    }
                    databaseConn.Close();
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Error: " + exception.Message +" ; "+ _queryString);
                }


            }
        }

        public void Listaz()
        {
            FelhasznalokPanel_RichtextboxSelectedUsername = "";
            richTextBox1.Text = "";
            string queryString = "";

            if (!string.IsNullOrEmpty(Talalat) && !string.IsNullOrWhiteSpace(Talalat))
            {
                queryString = Talalat;
                switch (RendezesCombobox.SelectedIndex)
                {
                    case 0:
                        queryString += " ORDER BY `users`.`Username` ASC";
                        break;
                    case 1:
                        queryString += " ORDER BY `users`.`Username` DESC";
                        break;
                    case 2:
                        queryString += " ORDER BY `users`.`StorageID` ASC";
                        break;
                    case 3:
                        queryString += " ORDER BY `users`.`StorageID` DESC";
                        break;
                    case 4:
                        queryString += " ORDER BY `users`.`LastName` ASC";
                        break;
                    case 5:
                        queryString += " ORDER BY `users`.`LastName` DESC";
                        break;
                }
            }
            else
            {
                queryString = "SELECT * FROM `users` ORDER BY `users`.`Username` ASC";
                
                switch (RendezesCombobox.SelectedIndex)
                {
                    case 0:
                        queryString = "SELECT * FROM `users` ORDER BY `users`.`Username` ASC";
                        break;
                    case 1:
                        queryString = "SELECT * FROM `users` ORDER BY `users`.`Username` DESC";
                        break;
                    case 2:
                        queryString = "SELECT * FROM `users` ORDER BY `users`.`StorageID` ASC";
                        break;
                    case 3:
                        queryString = "SELECT * FROM `users` ORDER BY `users`.`StorageID` DESC";
                        break;
                    case 4:
                        queryString = "SELECT * FROM `users` ORDER BY `users`.`LastName` ASC";
                        break;
                    case 5:
                        queryString = "SELECT * FROM `users` ORDER BY `users`.`LastName` DESC";
                        break;
                }
            }
            

            string MySQLConnString = "datasource=127.0.0.1;port=3306;username=root;password=;database=raktarkezelo";
            MySqlConnection databaseConn = new MySqlConnection(MySQLConnString);
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
                        richTextBox1.Text += myReader.GetString(0) + " | " + myReader.GetString(1) + " | " + myReader.GetString(4)
                                             + " " + myReader.GetString(5) + " | " + myReader.GetString(7) + "\n";
                    }
                }
                databaseConn.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Error: " + exception.Message +" ; "+ queryString);
            }
            
        }

        private void RendezesCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Listaz();
        }

        private void richTextBox1_MouseClick(object sender, MouseEventArgs e)
        {
            int firstcharindex = richTextBox1.GetFirstCharIndexOfCurrentLine();
            int currentline = richTextBox1.GetLineFromCharIndex(firstcharindex);
            string currentlinetext = richTextBox1.Lines[currentline];
            richTextBox1.Select(firstcharindex, currentlinetext.Length);

            string[] substrings = currentlinetext.Split('|');
            FelhasznalokPanel_RichtextboxSelectedUsername = substrings[0].Remove(substrings[0].Length - 1, 1);
        }

        private void KeresesButton_Click(object sender, EventArgs e)
        {
            FelhasznaloKereses FelhKeres_Form = new FelhasznaloKereses();
            FelhKeres_Form.Show();
            this.Dispose();
        }

        private void ModositButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(FelhasznalokPanel_RichtextboxSelectedUsername) &&
                !string.IsNullOrWhiteSpace(FelhasznalokPanel_RichtextboxSelectedUsername))
            {
                FelhasznaloModosit FelhMod_Form = new FelhasznaloModosit(FelhasznalokPanel_RichtextboxSelectedUsername);
                FelhMod_Form.Show();
            }
            else
            {
                MessageBox.Show("Nincs kiválasztva felhasználó!");
            }
        }


        private void TorlesButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(FelhasznalokPanel_RichtextboxSelectedUsername) &&
                !string.IsNullOrWhiteSpace(FelhasznalokPanel_RichtextboxSelectedUsername))
            {
                string MySQLConnString = "datasource=127.0.0.1;port=3306;username=root;password=;database=raktarkezelo";
                MySqlConnection databaseConn = new MySqlConnection(MySQLConnString);
                string queryString = "Delete from `users` WHERE Username='" + FelhasznalokPanel_RichtextboxSelectedUsername + "'";   // ItemNumber 
                MySqlCommand commandSelectedProdQuantity = new MySqlCommand(queryString, databaseConn);
                commandSelectedProdQuantity.CommandTimeout = 60;

                try
                {
                    databaseConn.Open();
                    MySqlDataReader myReader = commandSelectedProdQuantity.ExecuteReader();

                    if (myReader.HasRows) // Ha jó az input
                    {
                        while (myReader.Read())
                        {
                        }
                    }
                    databaseConn.Close();
                    MessageBox.Show(FelhasznalokPanel_RichtextboxSelectedUsername + " felhasználó sikeresen törölve!");
                    this.Listaz();
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Error: " + exception.Message);
                }
                  
            }
            else
            {
                MessageBox.Show("Nincs kiválasztva felhasználó!");
            }
            FelhasznalokPanel_RichtextboxSelectedUsername = "";
            }


        private void VisszaButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Felhasznalok_Load(object sender, EventArgs e)
        {
            RendezesCombobox.SelectedIndex = 4;
        }
    }
}