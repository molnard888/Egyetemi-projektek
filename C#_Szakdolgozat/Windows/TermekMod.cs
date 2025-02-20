using MySql.Data.MySqlClient;
using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace Raktarkezelo
{
    public partial class TermekMod : Form
    {
        private string SelectedItemnumber = "";
        public TermekMod()
        {
            InitializeComponent();

            this.CenterToParent();
        }

        public TermekMod(string _selectedItemnumber)
        {
            InitializeComponent();

            this.CenterToParent();

            SelectedItemnumber = _selectedItemnumber;
            TextboxFeltoltes(SelectedItemnumber);
            QrGenerator(SelectedItemnumber);
        }

        private void TextboxFeltoltes(string _SelectedItemnumber)
        {
            if (!string.IsNullOrEmpty(_SelectedItemnumber) && !string.IsNullOrWhiteSpace(_SelectedItemnumber))
            {
                MySqlConnection databaseConn = MySQLadapter.CreateDbConnection();
                string queryString = "Select * from `products` WHERE ItemNumber='" + _SelectedItemnumber + "'";   // ItemNumber 
                MySqlCommand SqlSelectCommand = new MySqlCommand(queryString, databaseConn);
                SqlSelectCommand.CommandTimeout = 60;

                try
                {
                    databaseConn.Open();
                    MySqlDataReader myReader = SqlSelectCommand.ExecuteReader();

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
                    string ErrorString = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " - Error during Selecting product by ItemNumber from Db: " + exception.Message;
                    Class_Logging.WriteToLogFile(ErrorString);
                }
                databaseConn.Close();
            }

        }

        private void EditButton_Click(object sender, EventArgs e)
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

                MySqlConnection databaseConn = MySQLadapter.CreateDbConnection();
                string SqlExecuteCommand = "UPDATE raktarkezelo.products set ItemNumber='" + ItemNumTextbox.Text + "', StorageID='" + StorageIdTextbox.Text + "', Brand='" + BrandTextbox.Text
                                     + "', Type='" + TypeTextbox.Text + "', Category='" + CategoryTextbox.Text + "', Price='" + PriceTextbox.Text
                                     + "', Quantity='" + QuantityTextbox.Text + "', InnerLocRow='" + LocRowTextbox.Text + "', InnerLocColumn='" + LocColTextbox.Text
                                     + "', InnerLocLevel='" + LocLevTextbox.Text + "' where ItemNumber='" + SelectedItemnumber + "';";

                string returnedAnswer = MySQLadapter.ExecuteSqlCommand(SqlExecuteCommand, "Updated Product", SelectedItemnumber);

                MessageBox.Show(returnedAnswer);
                SelectedItemnumber = "";
                Kezdolap.termekek_Form.Listaz();
            }
        }



        private void QrGenerator(string _SelectedItemnumber)
        {
            QRCodeGenerator qr = new QRCodeGenerator();
            QRCodeData data = qr.CreateQrCode(_SelectedItemnumber, QRCodeGenerator.ECCLevel.Q);
            QRCode code = new QRCode(data);
            QrBox.Image = code.GetGraphic(7);
        }
        private void ItemNumTextbox_TextChanged(object sender, EventArgs e)
        {
            QrGenerator(ItemNumTextbox.Text);
        }

        private void QrBox_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                string path = @"D:\" + ItemNumTextbox.Text + ".bmp";
                QrBox.Image.Save(path, System.Drawing.Imaging.ImageFormat.Bmp);
                MessageBox.Show("Kép mentve: " + path);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
                string ErrorString = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " - Error during saving the QR code image: " + exception.ToString();
                Class_Logging.WriteToLogFile(ErrorString);
            }

        }
    }
}
