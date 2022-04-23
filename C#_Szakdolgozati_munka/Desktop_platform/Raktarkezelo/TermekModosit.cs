using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using QRCoder;

namespace Raktarkezelo
{
    public partial class TermekModosit : Form
    {
        private string SelectedItemnumber = "";
        public TermekModosit()
        {
            InitializeComponent();
        }
        
        public TermekModosit(string _selectedItemnumber)
        {
            InitializeComponent();
            SelectedItemnumber = _selectedItemnumber;
            TextboxFeltoltes(SelectedItemnumber);
            QrGenerator(SelectedItemnumber);
        }

        private void TextboxFeltoltes(string DispProdPanel_RichtextboxSelectedItemnumber)
        {
            if (!string.IsNullOrEmpty(DispProdPanel_RichtextboxSelectedItemnumber) && !string.IsNullOrWhiteSpace(DispProdPanel_RichtextboxSelectedItemnumber))
            {   
                
                string MySQLConnString = "datasource=127.0.0.1;port=3306;username=root;password=;database=raktarkezelo";
                MySqlConnection databaseConn = new MySqlConnection(MySQLConnString);
                string queryString = "Select * from `products` WHERE ItemNumber='" + DispProdPanel_RichtextboxSelectedItemnumber + "'";   // ItemNumber 
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
                            ItemNumTextbox.Text = myReader.GetString(0);
                            StorageIdTextbox.Text = myReader.GetString(1);
                            BrandTextbox.Text = myReader.GetString(2);
                            TypeTextbox.Text = myReader.GetString(3);
                            CategoryTextbox.Text = myReader.GetString(4);
                            PriceTextbox.Text = myReader.GetString(5);
                            QuantityTextbox.Text = myReader.GetString(6);
                            LocRowTextbox.Text = myReader.GetString(7);
                            LocColTextbox.Text = myReader.GetString(8);
                            LocLevTextbox.Text = myReader.GetString(9);
                        }
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Error: " + exception.Message);
                }
                databaseConn.Close();    
            }
            
        }

        private void QrGenerator(string _SelectedItemnumber)
        {
            QRCodeGenerator qr = new QRCodeGenerator();
            QRCodeData data = qr.CreateQrCode(_SelectedItemnumber, QRCodeGenerator.ECCLevel.Q);
            QRCode code = new QRCode(data);
            QrBox.Image = code.GetGraphic(7);
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            string MySQLConnString = "datasource=127.0.0.1;port=3306;username=root;password=;database=raktarkezelo";
            MySqlConnection databaseConn = new MySqlConnection(MySQLConnString);
            string queryString = "update raktarkezelo.products set StorageID='" + StorageIdTextbox.Text + "', Brand='" + BrandTextbox.Text 
                                 + "', Type='" + TypeTextbox.Text + "', Category='" + CategoryTextbox.Text  + "', Price='" + PriceTextbox.Text 
                                 + "', Quantity='" + QuantityTextbox.Text + "', InnerLocRow='" + LocRowTextbox.Text  + "', InnerLocColumn='" + LocColTextbox.Text
                                 + "', InnerLocLevel='" + LocLevTextbox.Text + "' where ItemNumber='" + ItemNumTextbox.Text + "';";

            // Edit -> Update
            MySqlCommand commandUpdateProds = new MySqlCommand(queryString, databaseConn);
            commandUpdateProds.CommandTimeout = 60;
            
            try
            {
                MySqlDataReader myReader;
                databaseConn.Open();
                myReader = commandUpdateProds.ExecuteReader();
                MessageBox.Show(SelectedItemnumber + " termék adatai frissültek!");  
                while (myReader.Read())  
                {  
                }
                databaseConn.Close();
                Form1.termekek_Form.Listaz();
                this.Dispose();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Error: " + exception.Message);
            }
            SelectedItemnumber = "";
        }

        private void ItemNumTextbox_TextChanged(object sender, EventArgs e)
        {
            QrGenerator(ItemNumTextbox.Text);
        }

        private void QrBox_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                string path = @"C:\Users\Daniel\Pictures\" + ItemNumTextbox.Text + "_" + DateTime.Now.ToString("yyyy-MM-dd_H-mm-ss") + ".bmp";
                MessageBox.Show(path);
                QrBox.Image.Save(path, System.Drawing.Imaging.ImageFormat.Bmp);
                MessageBox.Show("Kép mentve: " + path);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
            
        }
    }
}