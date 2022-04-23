using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Raktarkezelo
{
    public partial class UjTermek : Form
    {
        public UjTermek()
        {
            InitializeComponent();
        }

        private void AddNewButton_Click(object sender, EventArgs e)
        {
              if (string.IsNullOrEmpty(ItemNumTextbox.Text) || string.IsNullOrWhiteSpace(ItemNumTextbox.Text) ||
                string.IsNullOrEmpty(StorageIdTextbox.Text) || string.IsNullOrWhiteSpace(StorageIdTextbox.Text) ||
                string.IsNullOrEmpty(BrandTextbox.Text) || string.IsNullOrWhiteSpace(BrandTextbox.Text) ||
                string.IsNullOrEmpty(TypeTextbox.Text) || string.IsNullOrWhiteSpace(TypeTextbox.Text) ||
                string.IsNullOrEmpty(CategoryTextbox.Text) || string.IsNullOrWhiteSpace(CategoryTextbox.Text) ||
                string.IsNullOrEmpty(PriceTextbox.Text) || string.IsNullOrWhiteSpace(PriceTextbox.Text) ||
                string.IsNullOrEmpty(QuantityTextbox.Text) || string.IsNullOrWhiteSpace(QuantityTextbox.Text) ||
                string.IsNullOrEmpty(LocRowTextbox.Text) || string.IsNullOrWhiteSpace(LocRowTextbox.Text) ||
                string.IsNullOrEmpty(LocColTextbox.Text) || string.IsNullOrWhiteSpace(LocColTextbox.Text) ||
                string.IsNullOrEmpty(LocLevTextbox.Text) || string.IsNullOrWhiteSpace(LocLevTextbox.Text))
            {
                MessageBox.Show("Érvénytelen Adat!");  
            }
            else
              {
                string MySQLConnString = "datasource=127.0.0.1;port=3306;username=root;password=;database=raktarkezelo";
                MySqlConnection databaseConn = new MySqlConnection(MySQLConnString);
                
                // insert !!!
                string queryString = "INSERT INTO raktarkezelo.products VALUES ('" + ItemNumTextbox.Text + "', '" + StorageIdTextbox.Text + "', '" 
                                     + BrandTextbox.Text + "', '" + TypeTextbox.Text + "', '" + CategoryTextbox.Text  + "', '" 
                                     + PriceTextbox.Text + "', '" + QuantityTextbox.Text + "', '" + LocRowTextbox.Text  + "', '" 
                                     + LocColTextbox.Text + "', '" + LocLevTextbox.Text  + "');"; 
                // Edit -> Insert
                MySqlCommand commandUpdateProds = new MySqlCommand(queryString, databaseConn);
                commandUpdateProds.CommandTimeout = 60;
            
                try
                {
                    MySqlDataReader myReader;
                    databaseConn.Open();
                    myReader = commandUpdateProds.ExecuteReader();
                    MessageBox.Show("Termék hozzáadva!");  
                    while (myReader.Read())  
                    {  
                    }
                    databaseConn.Close();
                    this.Dispose();
                    Form1.termekek_Form = new Termekek();
                    Form1.termekek_Form.Show();
                    // AddNewProductButton.PerformClick();
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Error: " + exception.Message);
                }
            }
                
        }
    }
}