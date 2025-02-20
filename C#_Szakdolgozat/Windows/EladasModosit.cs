using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Raktarkezelo
{
    public partial class EladasModosit : Form
    {
        private string VasarlasID = "";
        private string RichtextboxSelectedItemnumber = "";
        public EladasModosit(string _tablename)
        {
            InitializeComponent();
            this.CenterToParent();
            VasarlasID = _tablename;
            MessageBox.Show(VasarlasID);
            richTextBox1.Text = " ";
            TextboxFeltolt();
            RichtextboxFeltolt();
        }

        private void TextboxFeltolt()
        {
            string queryString = "SELECT * FROM `sales` WHERE SaleID='" +VasarlasID+ "' ; ";

            MySqlConnection databaseConn = MySQLadapter.CreateDbConnection();
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
                                    NameTextbox.Text = myReader.GetString(0);
                                    PhoneTextbox.Text = myReader.GetString(1);
                                    AddressTextbox.Text = myReader.GetString(2);
                                    StorageIdTextbox.Text = myReader.GetString(3);
                                    ItemnumbersTextbox.Text = myReader.GetString(5);
                                    SummaryTextbox.Text = myReader.GetString(6);
                                    SaletimeTextbox.Text = myReader.GetString(7);
                                }
                            }
                            databaseConn.Close();
                        }
                        catch (Exception exception)
                        {
                            MessageBox.Show("Error: " + exception.Message +" ; "+ queryString);
                            string ErrorString = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " - Error during Selecting sales by ItemNumber: " + exception.Message;
                            Class_Logging.WriteToLogFile(ErrorString);
                        }
        }

        private void RichtextboxFeltolt()
        {
            if (!string.IsNullOrEmpty(ItemnumbersTextbox.Text) && !string.IsNullOrWhiteSpace(ItemnumbersTextbox.Text))
            {
                string queryString = "SELECT ItemNumbers FROM `sales` WHERE SaleID='" +VasarlasID+ "' ; ";
                MySqlConnection databaseConn = MySQLadapter.CreateDbConnection();
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
                            richTextBox1.Text = myReader.GetString(0).Replace(',', '\n'); 
                        }
                    }
                    databaseConn.Close();
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Error: " + exception.Message + " ; " + queryString);
                    string ErrorString = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " - Error during editing a sale: " + exception.Message;
                    Class_Logging.WriteToLogFile(ErrorString);
                }
            }
            else
            {
                MessageBox.Show("Hiba: Nincs találat!");
            }

        }

    }
}