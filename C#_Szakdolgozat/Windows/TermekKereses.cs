using System;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Raktarkezelo
{
    public partial class TermekKereses : Form
    {
        public TermekKereses()
        {
            InitializeComponent();
            
            this.CenterToParent();
        }


        private void SearchButton_Click(object sender, EventArgs e)
        {
            string queryString = "Select * from `products` WHERE ";

            if (!string.IsNullOrEmpty(ItemNumTextbox.Text) && !string.IsNullOrWhiteSpace(ItemNumTextbox.Text))
            {
                queryString += " ItemNumber='" + ItemNumTextbox.Text + "' AND";
            }

            if (!string.IsNullOrEmpty(StorageIdTextbox.Text) && !string.IsNullOrWhiteSpace(StorageIdTextbox.Text))
            {
                queryString += " StorageID='" + StorageIdTextbox.Text + "' AND";
            }

            if (!string.IsNullOrEmpty(BrandTextbox.Text) && !string.IsNullOrWhiteSpace(BrandTextbox.Text))
            {
                queryString += " Brand='" + BrandTextbox.Text + "' AND";
            }

            if (!string.IsNullOrEmpty(TypeTextbox.Text) && !string.IsNullOrWhiteSpace(TypeTextbox.Text))
            {
                queryString += " Type='" + TypeTextbox.Text + "' AND";
            }

            if (!string.IsNullOrEmpty(CategoryTextbox.Text) && !string.IsNullOrWhiteSpace(CategoryTextbox.Text))
            {
                queryString += " Category='" + CategoryTextbox.Text + "' AND";
            }

            if (!string.IsNullOrEmpty(PriceFromTextbox.Text) && !string.IsNullOrWhiteSpace(PriceFromTextbox.Text))
            {
                queryString += " Price>='" + PriceFromTextbox.Text + "' AND";
            }

            if (!string.IsNullOrEmpty(PriceToTextbox.Text) && !string.IsNullOrWhiteSpace(PriceToTextbox.Text))
            {
                queryString += " Price<='" + PriceToTextbox.Text + "' AND";
            }

            if (!string.IsNullOrEmpty(QuantityTextbox.Text) && !string.IsNullOrWhiteSpace(QuantityTextbox.Text))
            {
                queryString += " Quantity='" + QuantityTextbox.Text + "' AND";
            }

            if (!string.IsNullOrEmpty(LocRowTextbox.Text) && !string.IsNullOrWhiteSpace(LocRowTextbox.Text))
            {
                queryString += " InnerLocRow='" + LocRowTextbox.Text + "' AND";
            }

            if (!string.IsNullOrEmpty(LocColTextbox.Text) && !string.IsNullOrWhiteSpace(LocColTextbox.Text))
            {
                queryString += " InnerLocColumn='" + LocColTextbox.Text + "' AND";
            }

            if (!string.IsNullOrEmpty(LocLevTextbox.Text) && !string.IsNullOrWhiteSpace(LocLevTextbox.Text))
            {
                queryString += " InnerLocLevel='" + LocLevTextbox.Text + "' AND";
            }

            try
            {
                if (!queryString.Equals("Select * from `products` WHERE "))
                {
                    queryString = queryString.Remove(queryString.Length - 3);
                    Kezdolap.termekek_Form.Listaz(queryString);
                }
                else
                {
                    MessageBox.Show("Minden beviteli mező üres!");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Error: " + exception.Message + "TermekKeresesHiba");
                string ErrorString = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " - Error during searching for product: " + exception.Message;
                Class_Logging.WriteToLogFile(ErrorString);
            }
        }

        private void VisszaButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

    }
}