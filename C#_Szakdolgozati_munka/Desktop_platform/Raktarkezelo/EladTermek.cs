using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Raktarkezelo
{
    public partial class EladTermek : Form
    {
        public List<string> KosarLista;
        string Richtextbox1SelectedItemnumber = "";
        private int Vegosszeg = 0;
        System.Windows.Forms.Timer t = null;
        
        
        public EladTermek(List<string> _vasarloilista)
        {
            
            KosarLista = new List<string>(_vasarloilista);
            InitializeComponent();
            
            if (!KosarLista.Any())
            {
                
            }
            else
            {
                Richtextbox1_feltoltes();
            }
            VegOsszegEmptyLabel.Text = Vegosszeg.ToString() + " Ft";
            StartTimer();
        }

        private void StartTimer()
        {
            t = new System.Windows.Forms.Timer();
            t.Interval = 1000;
            t.Tick += new EventHandler(t_Tick);
            t.Enabled = true;
        }

        void t_Tick(object sender, EventArgs e)
        {
            IdoTextbox.Text = DateTime.Now.ToString();
        }
        
        public void Richtextbox1_feltoltes()
        {
            Vegosszeg = 0;
            richTextBox1.Text = "";
            for (int i = 0; i < KosarLista.Count; i++)
            {
                string queryString = "select * from raktarkezelo.products where ItemNumber='" + KosarLista[i] + "';";
                
                
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
                            richTextBox1.Text += myReader.GetString(0) + " | " +
                                                 myReader.GetString(2) +
                                                 " " + myReader.GetString(3) + " | " + myReader.GetString(4)
                                                 + " | " + myReader.GetString(5) + " Ft \n";
                            
                            try
                            {
                                Vegosszeg += Int32.Parse(myReader.GetString(5));
                            }
                            catch (FormatException e)
                            {
                                Console.WriteLine(e.Message);
                            }
                        }
                    }
                    databaseConn.Close();
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Error: " + exception.Message +" ; "+ queryString);
                }
            }

            VegOsszegEmptyLabel.Text = Vegosszeg.ToString() + " Ft";

        }
        
        private void Richtextbox1_MouseClick(object sender, MouseEventArgs e)    // kijelölés
        {
            if (!string.IsNullOrEmpty(richTextBox1.Text) && !string.IsNullOrWhiteSpace(richTextBox1.Text))
            {
                int firstcharindex = richTextBox1.GetFirstCharIndexOfCurrentLine();
                int currentline = richTextBox1.GetLineFromCharIndex(firstcharindex);
                string currentlinetext = richTextBox1.Lines[currentline];
                richTextBox1.Select(firstcharindex, currentlinetext.Length);

                string[] substrings = currentlinetext.Split('|');
                Richtextbox1SelectedItemnumber = substrings[0].Remove(substrings[0].Length - 1, 1);
            }
            else
            {
                MessageBox.Show("A tartomány üres!");
            }
        }


        private void BeolvasButton_Click(object sender, EventArgs e)
        {
            WebcamQrScanner QrScan = new WebcamQrScanner();
            QrScan.Show();
        }

        
        private void TorolButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Richtextbox1SelectedItemnumber) && !string.IsNullOrWhiteSpace(Richtextbox1SelectedItemnumber))
            {
                if (!string.IsNullOrEmpty(richTextBox1.Text) && !string.IsNullOrWhiteSpace(richTextBox1.Text))
                {
                    int firstcharindex = richTextBox1.GetFirstCharIndexOfCurrentLine();
                    int currentline = richTextBox1.GetLineFromCharIndex(firstcharindex);
                    KosarLista.RemoveAt(currentline);
                }
                else
                {
                    MessageBox.Show("A tartomány üres!");
                }
                richTextBox1.Text = "";
                Richtextbox1_feltoltes();
                MessageBox.Show("Sikeres törlés!");

            }
            else
            {
                MessageBox.Show("Nincs kiválasztva termék!");
            }
            Richtextbox1SelectedItemnumber = "";
        }
        
        private void EladButton_Click(object sender, EventArgs e)
        {
            
            if (!KosarLista.Any())
            {
                //MessageBox.Show("A kosár üres!");
            }
            else
            {
                if (!string.IsNullOrEmpty(richTextBox1.Text) && !string.IsNullOrWhiteSpace(richTextBox1.Text) 
                 && !string.IsNullOrWhiteSpace(KosarLista[0]) && !string.IsNullOrWhiteSpace(KosarLista[0]) && Vegosszeg>0)
            {
                // Insert
                if (string.IsNullOrEmpty(NameTextbox.Text) || string.IsNullOrWhiteSpace(NameTextbox.Text) ||
                string.IsNullOrEmpty(TelefonTextbox.Text) || string.IsNullOrWhiteSpace(TelefonTextbox.Text) ||
                string.IsNullOrEmpty(AddressTextbox.Text) || string.IsNullOrWhiteSpace(AddressTextbox.Text))
                {
                    MessageBox.Show("Érvénytelen Adat!");  
                }
                else
                {
                    
                    string MySQLConnString = "datasource=127.0.0.1;port=3306;username=root;password=;database=raktarkezelo";
                    MySqlConnection databaseConn = new MySqlConnection(MySQLConnString);
                    
                    // insert !!!
                    string SaleTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss_");
                    string tableName = SaleTime + TelefonTextbox.Text;
                    MessageBox.Show(tableName);
                    string queryString = "INSERT INTO raktarkezelo.sales VALUES ('" + NameTextbox.Text + "', '" + TelefonTextbox.Text + "', '" 
                                        + AddressTextbox.Text + "', '" + "1" + "', '" + SaleTime + TelefonTextbox.Text + "', '" 
                                        + Vegosszeg + "', '" + SaleTime + "'); " ;
                    string CreateDb = "CREATE TABLE `raktarkezelo`.`" + tableName + "` LIKE `raktarkezelo`.`products` ; " ;
                    string itemnumberQuery = "";
                    for (int i = 0; i < KosarLista.Count; i++)
                    {
                        itemnumberQuery += "INSERT INTO `raktarkezelo`.`" + tableName + "` SELECT * FROM `raktarkezelo`.`products` WHERE ItemNumber='"+KosarLista[i]+"' ; ";
                    }

                    try
                    {
                        //insert Sale _Begin
                        MySqlCommand commandUpdateProds = new MySqlCommand(queryString, databaseConn);
                        commandUpdateProds.CommandTimeout = 60;
                        try
                        {
                            MySqlDataReader myReader;
                            databaseConn.Open();
                            myReader = commandUpdateProds.ExecuteReader();
                            while (myReader.Read())
                            {
                            }

                            databaseConn.Close();
                            //MessageBox.Show("Sale inserted!\n" + queryString);
                        }
                        catch (Exception exception)
                        {
                            MessageBox.Show("Error: " + exception.Message);
                        }
                        //insert Sale _End

                        //create table _Begin
                        commandUpdateProds = new MySqlCommand(CreateDb, databaseConn);
                        commandUpdateProds.CommandTimeout = 60;
                        try
                        {
                            MySqlDataReader myReader;
                            databaseConn.Open();
                            myReader = commandUpdateProds.ExecuteReader();
                            while (myReader.Read())
                            {
                            }

                            databaseConn.Close();
                            //MessageBox.Show("Table created!\n" + CreateDb);
                        }
                        catch (Exception exception)
                        {
                            MessageBox.Show("Error: " + exception.Message);
                        }
                        //create table _End

                        //insert to new table _Begin
                        commandUpdateProds = new MySqlCommand(itemnumberQuery, databaseConn);
                        commandUpdateProds.CommandTimeout = 60;
                        try
                        {
                            MySqlDataReader myReader;
                            databaseConn.Open();
                            myReader = commandUpdateProds.ExecuteReader();
                            while (myReader.Read())
                            {
                            }

                            databaseConn.Close();
                            //MessageBox.Show("Itemnumbers inserted!\n" + itemnumberQuery);
                        }
                        catch (Exception exception)
                        {
                            MessageBox.Show("Error: " + exception.Message);
                        }
                        //insert to new table _End
                        
                        //drop last 4 column _Begin
                        string dropColumnsQuery = "ALTER TABLE `raktarkezelo`.`" + tableName + "` DROP COLUMN `Quantity` ; ";
                        dropColumnsQuery += "ALTER TABLE `raktarkezelo`.`" + tableName + "` DROP COLUMN `InnerLocRow` ; ";
                        dropColumnsQuery += "ALTER TABLE `raktarkezelo`.`" + tableName + "` DROP COLUMN `InnerLocColumn` ; ";
                        dropColumnsQuery += "ALTER TABLE `raktarkezelo`.`" + tableName + "` DROP COLUMN `InnerLocLevel` ; ";
                        
                        commandUpdateProds = new MySqlCommand(dropColumnsQuery, databaseConn);
                        commandUpdateProds.CommandTimeout = 60;
                        try
                        {
                            MySqlDataReader myReader;
                            databaseConn.Open();
                            myReader = commandUpdateProds.ExecuteReader();
                            while (myReader.Read())
                            {
                            }

                            databaseConn.Close();
                            //MessageBox.Show("Last 4 column dropped!\n" + dropColumnsQuery);
                        }
                        catch (Exception exception)
                        {
                            MessageBox.Show("Error: " + exception.Message);
                        }
                        //drop last 4 column _End
                        
                        this.Close();
                        MessageBox.Show("Sikeres vásárlás!");
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show("Error: " + exception.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("A kosár üres!");
            }
            }
            
            
        }


        private void OsszTorolButton_Click(object sender, EventArgs e)
        {
            KosarLista.Clear();
            Richtextbox1_feltoltes();
            
        }
    }
}