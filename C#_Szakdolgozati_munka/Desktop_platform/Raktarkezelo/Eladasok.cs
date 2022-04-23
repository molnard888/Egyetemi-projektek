using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Raktarkezelo
{
    public partial class Eladasok : Form
    {
        private string RichtextboxSelectedDatetime = "";
        private string RichtextboxSelectedPhone = "";
        private string Talalat = "";
        
        public Eladasok()
        {
            InitializeComponent();
            RendezesCombobox.SelectedIndex = 1;
            Listaz();
        }
        
        
        public void Listaz()
        {
            RichtextboxSelectedDatetime = "";
            richTextBox1.Text = "";
            string queryString = "";

            if (!string.IsNullOrEmpty(Talalat) && !string.IsNullOrWhiteSpace(Talalat))
            {
                queryString = Talalat;
                switch (RendezesCombobox.SelectedIndex)
                {
                    case 0:
                        queryString += " ORDER BY `sales`.`SaleDatetime` ASC";
                        break;
                    case 1:
                        queryString += " ORDER BY `sales`.`SaleDatetime` DESC";
                        break;
                    case 2:
                        queryString += " ORDER BY `sales`.`Name` ASC";
                        break;
                    case 3:
                        queryString += " ORDER BY `sales`.`Name` DESC";
                        break;
                    case 4:
                        queryString += " ORDER BY `sales`.`Address` ASC";
                        break;
                    case 5:
                        queryString += " ORDER BY `sales`.`Address` DESC";
                        break;
                }
            }
            else
            {
                queryString = "SELECT * FROM `sales` ORDER BY SaleDatetime DESC";   /* ORDER BY `sales`.`SaleDatetime` */ 
                
                switch (RendezesCombobox.SelectedIndex)
                {
                    case 0:
                        queryString = "SELECT * FROM `sales` ORDER BY SaleDatetime ASC";
                        break;
                    case 1:
                        queryString = "SELECT * FROM `sales` ORDER BY SaleDatetime DESC";
                        break;
                    case 2:
                        queryString = "SELECT * FROM `sales` ORDER BY `sales`.`Name` ASC";
                        break;
                    case 3:
                        queryString = "SELECT * FROM `sales` ORDER BY `sales`.`Name` DESC";
                        break;
                    case 4:
                        queryString = "SELECT * FROM `sales` ORDER BY `sales`.`Address` ASC";
                        break;
                    case 5:
                        queryString = "SELECT * FROM `sales` ORDER BY `sales`.`Address` DESC";
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
                        /* DateTime myDate = DateTime.ParseExact(myReader.GetDateTime(6), "yyyy-MM-dd HH:mm:ss",
                            System.Globalization.CultureInfo.InvariantCulture);  */
                        /* myReader.GetDateTime(6).Year+"-"+myReader.GetDateTime(6).Month+"-"+myReader.GetDateTime(6).Day+" "
                                             + myReader.GetDateTime(6).Hour+":"+myReader.GetDateTime(6).Minute+":"+myReader.GetDateTime(6).Second
                                             */
                        richTextBox1.Text +=  myReader.GetDateTime(6).ToString("yyyy-MM-dd HH:mm:ss") + " | " + myReader.GetString(0) + " | " + myReader.GetString(1) 
                                             + " | " + myReader.GetString(5) +" Ft\n";
                        
                    }
                }
                databaseConn.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Error: " + exception.Message +" ; "+ queryString);
            }
            
        }
        
        

        private void TorlesButton_Click(object sender, EventArgs e)
        {
            // drop table 'SaleDatetime+Phone'
            // delete row where phone='' AND SaleDatetime=''
            if (!string.IsNullOrEmpty(richTextBox1.Text) && !string.IsNullOrWhiteSpace(richTextBox1.Text)
                                                         && !string.IsNullOrWhiteSpace(RichtextboxSelectedDatetime) &&
                                                         !string.IsNullOrWhiteSpace(RichtextboxSelectedDatetime)
                                                         && !string.IsNullOrWhiteSpace(RichtextboxSelectedPhone) &&
                                                         !string.IsNullOrWhiteSpace(RichtextboxSelectedPhone))
            {
                string MySQLConnString = "datasource=127.0.0.1;port=3306;username=root;password=;database=raktarkezelo";
                MySqlConnection databaseConn = new MySqlConnection(MySQLConnString);
                
                // delete row from sales _Begin
                string queryString = "Delete from `sales` WHERE Phone='" + RichtextboxSelectedPhone + "' AND SaleDatetime='" +RichtextboxSelectedDatetime+ "'; ";  
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
                    MessageBox.Show("Row removed from database successfully! " + queryString);
                    this.Listaz();
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Error: " + exception.Message);
                }
                // delete row from sales _End
                
                // drop table _Begin
                string tablename = RichtextboxSelectedDatetime +"_"+ RichtextboxSelectedPhone;
                queryString = "DROP TABLE '" +tablename+ "' ; ";  
                commandSelectedProdQuantity = new MySqlCommand(queryString, databaseConn);
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
                    MessageBox.Show("Table removed from database successfully! ");
                    this.Listaz();
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Error: " + exception.Message);
                }
                // drop table _End
                  
                Listaz();
            }
            else
            {
                MessageBox.Show("Nincs kiválasztva termék!");
            }
            
            RichtextboxSelectedDatetime = "";
            RichtextboxSelectedPhone = "";
        }

        private void ModositButton_Click(object sender, EventArgs e)
        {
            // ModositasMintázat
            // Uj form kell, itemnumberek --> richttextbox
            // részletek
            
            if (!string.IsNullOrEmpty(richTextBox1.Text) && !string.IsNullOrWhiteSpace(richTextBox1.Text)
                                                         && !string.IsNullOrWhiteSpace(RichtextboxSelectedDatetime) &&
                                                         !string.IsNullOrWhiteSpace(RichtextboxSelectedDatetime)
                                                         && !string.IsNullOrWhiteSpace(RichtextboxSelectedPhone) &&
                                                         !string.IsNullOrWhiteSpace(RichtextboxSelectedPhone))
            {
                EladasModosit eladasMod_Form = new EladasModosit(RichtextboxSelectedDatetime+"_"+RichtextboxSelectedPhone);
                eladasMod_Form.Show();
            }
            //MessageBox.Show(RichtextboxSelectedDatetime+"_"+RichtextboxSelectedPhone);
            
            RichtextboxSelectedDatetime = "";
            RichtextboxSelectedPhone = "";
        }

        private void KeresesButton_Click(object sender, EventArgs e)
        {
            // KeresésMintázat
            // Uj form kell 
        }

        private void RendezesCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Listaz();
        }

        private void VisszaButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void richTextBox1_MouseClick(object sender, MouseEventArgs e)
        {
            int firstcharindex = richTextBox1.GetFirstCharIndexOfCurrentLine();
            int currentline = richTextBox1.GetLineFromCharIndex(firstcharindex);
            string currentlinetext = richTextBox1.Lines[currentline];
            richTextBox1.Select(firstcharindex, currentlinetext.Length);

            string[] substrings = currentlinetext.Split('|');
            RichtextboxSelectedDatetime = substrings[0].Remove(substrings[0].Length - 1, 1);
            /* DateTime myDate = DateTime.ParseExact(RichtextboxSelectedDatetime, "yyyy-MM-dd HH:mm:ss",
                System.Globalization.CultureInfo.InvariantCulture); */
            RichtextboxSelectedPhone = substrings[2].Remove(substrings[2].Length - 1, 1).Substring(1);
        }
    }
}