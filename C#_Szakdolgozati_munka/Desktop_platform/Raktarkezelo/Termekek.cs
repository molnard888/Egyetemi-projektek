using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Raktarkezelo
{
    public partial class Termekek : Form
    {
        
        string TermekekPanel_RichtextboxSelectedItemnumber = "";
        private string Talalat = "";
        public static List<string> VasarloiLista = new List<string>();
        public static EladTermek elad_Form;
        
        public Termekek()
        {
            InitializeComponent();
            RendezesCombobox.SelectedIndex = 0;
        }
        
        public Termekek(string talalat)
        {
            if(!talalat.Equals("Select * from `products` WHERE 1 "))
                Talalat = talalat;
            InitializeComponent();
            RendezesCombobox.SelectedIndex = 0;
        }
        

        private void Termekek_Load(object sender, EventArgs e)
        {
            Listaz();
        }

        private void VisszaButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public void Listaz()
        {
            TermekekPanel_RichtextboxSelectedItemnumber = "";
            richTextBox1.Text = "";
            string queryString = "";

            if (!string.IsNullOrEmpty(Talalat) && !string.IsNullOrWhiteSpace(Talalat))
            {
                queryString = Talalat;
                switch (RendezesCombobox.SelectedIndex)
                {
                    case 0:
                        queryString += " ORDER BY `products`.`ItemNumber` ASC";
                        break;
                    case 1:
                        queryString += " ORDER BY `products`.`ItemNumber` DESC";
                        break;
                    case 2:
                        queryString += " ORDER BY `products`.`Brand` ASC";
                        break;
                    case 3:
                        queryString += " ORDER BY `products`.`Brand` DESC";
                        break;
                    case 4:
                        queryString += " ORDER BY `products`.`Quantity` ASC";
                        break;
                    case 5:
                        queryString += " ORDER BY `products`.`Quantity` DESC";
                        break;
                }
            }
            else
            {
                queryString = "SELECT * FROM `products` ORDER BY `products`.`ItemNumber` ASC";
            
                switch (RendezesCombobox.SelectedIndex)
                {
                    case 0:
                        queryString = "SELECT * FROM `products` ORDER BY `products`.`ItemNumber` ASC";
                        break;
                    case 1:
                        queryString = "SELECT * FROM `products` ORDER BY `products`.`ItemNumber` DESC";
                        break;
                    case 2:
                        queryString = "SELECT * FROM `products` ORDER BY `products`.`Brand` ASC";
                        break;
                    case 3:
                        queryString = "SELECT * FROM `products` ORDER BY `products`.`Brand` DESC";
                        break;
                    case 4:
                        queryString = "SELECT * FROM `products` ORDER BY `products`.`Quantity` ASC";
                        break;
                    case 5:
                        queryString = "SELECT * FROM `products` ORDER BY `products`.`Quantity` DESC";
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
                    //richTextBox1.Text = "ItemNumber | StorageID | Brand | Type | Category | Price | Quantity | InnerLocRow | InnerLocColumn | InnerLocLevel\n";
                    while (myReader.Read())
                    {
                        richTextBox1.Text += myReader.GetString(0) + " | " + myReader.GetString(1) + " | " +
                                             myReader.GetString(2) +
                                             " | " + myReader.GetString(3) + " | " + myReader.GetString(4)
                                             + " | " + myReader.GetString(5) + " | " + myReader.GetString(6) + " | [" +
                                             myReader.GetString(7) + ";" + myReader.GetString(8) + ";" +
                                             myReader.GetString(9) + "]\n";
                    }
                }
                databaseConn.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Error: " + exception.Message +" ; "+ queryString);
            }
            
        }
        
        private void DisplayProductsPanelRichtextbox_MouseClick(object sender, MouseEventArgs e)    // kijelölés
        {
            int firstcharindex = richTextBox1.GetFirstCharIndexOfCurrentLine();
            int currentline = richTextBox1.GetLineFromCharIndex(firstcharindex);
            string currentlinetext = richTextBox1.Lines[currentline];
            richTextBox1.Select(firstcharindex, currentlinetext.Length);

            string[] substrings = currentlinetext.Split('|');
            TermekekPanel_RichtextboxSelectedItemnumber = substrings[0].Remove(substrings[0].Length - 1, 1);
        }


        private void TorlesButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TermekekPanel_RichtextboxSelectedItemnumber) && !string.IsNullOrWhiteSpace(TermekekPanel_RichtextboxSelectedItemnumber))
            {
                
                string MySQLConnString = "datasource=127.0.0.1;port=3306;username=root;password=;database=raktarkezelo";
                MySqlConnection databaseConn = new MySqlConnection(MySQLConnString);
                string queryString = "Delete from `products` WHERE ItemNumber='" + TermekekPanel_RichtextboxSelectedItemnumber + "'";   // ItemNumber 
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
                    MessageBox.Show("Item: " + TermekekPanel_RichtextboxSelectedItemnumber + " removed from database successfully!");
                    this.Listaz();
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Error: " + exception.Message);
                }
                  
            }
            else
            {
                MessageBox.Show("Nincs kiválasztva termék!");
            }
            TermekekPanel_RichtextboxSelectedItemnumber = "";
        }

        private void ModositButton_Click(object sender, EventArgs e)
        {
            if (!TermekekPanel_RichtextboxSelectedItemnumber.Equals(""))
            {
                TermekModosit termMod_Form = new TermekModosit(TermekekPanel_RichtextboxSelectedItemnumber);
                termMod_Form.Show();
            }
            else
            {
                MessageBox.Show("Nincs kiválasztva termék!");
            }
            TermekekPanel_RichtextboxSelectedItemnumber = "";
            
        }

        private void KeresesButton_Click(object sender, EventArgs e)
        {
            TermekKereses termekKereses_Form = new TermekKereses();
            termekKereses_Form.Show();
            this.Dispose();
        }

        private void RendezesCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Listaz();
        }

        private void EladButton_Click(object sender, EventArgs e)
        {
            /* if (!string.IsNullOrEmpty(TermekekPanel_RichtextboxSelectedItemnumber) && !string.IsNullOrWhiteSpace(TermekekPanel_RichtextboxSelectedItemnumber))
            {
                            int SelectedProdQuantity = 0;
                            string MySQLConnString = "datasource=127.0.0.1;port=3306;username=root;password=;database=raktarkezelo";
                            MySqlConnection databaseConn = new MySqlConnection(MySQLConnString);
                            string queryString = "Select * from `products` WHERE ItemNumber='" + TermekekPanel_RichtextboxSelectedItemnumber + "'";   // ItemNumber 
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
                                        SelectedProdQuantity = Convert.ToInt32(myReader.GetString(6));
                                    }
                                }
                                databaseConn.Close();
                                if (SelectedProdQuantity > 0)
                                {
                                    queryString = "update raktarkezelo.products set Quantity='" +
                                                  Convert.ToString(SelectedProdQuantity - 1) + "' where ItemNumber='" +
                                                  TermekekPanel_RichtextboxSelectedItemnumber + "';";
                                    // Sell -> Update
                                    commandSelectedProdQuantity = new MySqlCommand(queryString, databaseConn);
                                    commandSelectedProdQuantity.CommandTimeout = 60;
                                    databaseConn.Open();
                                    myReader = commandSelectedProdQuantity.ExecuteReader();
                                    MessageBox.Show("Item: " + TermekekPanel_RichtextboxSelectedItemnumber + " sold successfully!");
                                    while (myReader.Read())
                                    {
                                    }
                                    databaseConn.Close();
                                    this.Listaz();
                                }
                                else
                                {
                                    MessageBox.Show("A termék nincs raktáron!");
                                }
                                
                                
                            }
                            catch (Exception exception)
                            {
                                MessageBox.Show("Error: " + exception.Message);
                            }
                              
                        }
                        else
                        {
                            MessageBox.Show("Please select a product!");
                        }
                        TermekekPanel_RichtextboxSelectedItemnumber = "";  */

                elad_Form = new EladTermek(VasarloiLista);
                elad_Form.Show();
                VasarloiLista.Clear();
                KosarbaButton.Text = "Kosárba (" + VasarloiLista.Count + ")";
        }

        private void KosárbaButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TermekekPanel_RichtextboxSelectedItemnumber) &&
                !string.IsNullOrWhiteSpace(TermekekPanel_RichtextboxSelectedItemnumber))
            {
                VasarloiLista.Add(TermekekPanel_RichtextboxSelectedItemnumber);
                KosarbaButton.Text = "Kosárba (" + VasarloiLista.Count + ")";
                TermekekPanel_RichtextboxSelectedItemnumber = "";
            }
            else
            {
                KosarbaButton.Text = "Kosárba (" + VasarloiLista.Count + ")";
                MessageBox.Show("Nincs kiválasztva termék!");
                TermekekPanel_RichtextboxSelectedItemnumber = "";
            }
        }

        public void ujElad_Form()
        {
            EladButton.PerformClick();
        }
    }
}