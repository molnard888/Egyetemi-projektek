using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Raktarkezelo
{
    public partial class EladasModosit : Form
    {
        private string Tablename = "";
        private string RichtextboxSelectedItemnumber = "";
        public EladasModosit(string _tablename)
        {
            InitializeComponent();
            Tablename = _tablename;
            TextboxFeltolt();
            RichtextboxFeltolt();
        }

        private void TextboxFeltolt()
        {
            string queryString = "SELECT * FROM `sales` WHERE ItemNumbers='" +Tablename+ "' ; ";
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
                                    NameTextbox.Text = myReader.GetString(0);
                                    PhoneTextbox.Text = myReader.GetString(1);
                                    AddressTextbox.Text = myReader.GetString(2);
                                    StorageIdTextbox.Text = myReader.GetString(3);
                                    ItemnumbersTextbox.Text = myReader.GetString(4);
                                    SummaryTextbox.Text = myReader.GetString(5);
                                    SaletimeTextbox.Text = myReader.GetString(6);
                                }
                            }
                            databaseConn.Close();
                        }
                        catch (Exception exception)
                        {
                            MessageBox.Show("Error: " + exception.Message +" ; "+ queryString);
                        }
        }

        private void RichtextboxFeltolt()
        {
            if (!string.IsNullOrEmpty(ItemnumbersTextbox.Text) && !string.IsNullOrWhiteSpace(ItemnumbersTextbox.Text))
            {
                string queryString = "SELECT * FROM `" + ItemnumbersTextbox.Text + "` ; ";
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
                            richTextBox1.Text += myReader.GetString(0) + " | " + myReader.GetString(1) + " | " +
                                                 myReader.GetString(2)
                                                 + myReader.GetString(3) + " | " + myReader.GetString(5) + " Ft\n";
                        }
                    }

                    databaseConn.Close();
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Error: " + exception.Message + " ; " + queryString);
                }
            }
            else
            {
                MessageBox.Show("Hiba: Nincs találat!");
            }

        }

        private void ModositButton_Click(object sender, EventArgs e)
        {
            
        }

        private void TorolButton_Click(object sender, EventArgs e)
        {
            
        }
        
        private void Richtextbox_MouseClick(object sender, MouseEventArgs e)    // kijelölés
        {
            int firstcharindex = richTextBox1.GetFirstCharIndexOfCurrentLine();
            int currentline = richTextBox1.GetLineFromCharIndex(firstcharindex);
            string currentlinetext = richTextBox1.Lines[currentline];
            richTextBox1.Select(firstcharindex, currentlinetext.Length);

            string[] substrings = currentlinetext.Split('|');
            RichtextboxSelectedItemnumber = substrings[0].Remove(substrings[0].Length - 1, 1);
        }
        
    }
}