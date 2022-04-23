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
        }


        private void SearchButton_Click(object sender, EventArgs e)
        {
            string TalalatString = "";
            string queryString = "Select * from `products` WHERE 1 ";

            if (!string.IsNullOrEmpty(ItemNumTextbox.Text) && !string.IsNullOrWhiteSpace(ItemNumTextbox.Text))
            {
                /* if (queryString.Last().Equals("1"))
                {
                    queryString = queryString.Remove(queryString.Length - 1);
                    queryString += ItemNumTextbox.Text
                }
                else
                {
                    ItemNumber = '" + DispProdPanel_RichtextboxSelectedItemnumber + "'";   // ItemNumber 
                } */
                queryString += "AND ItemNumber='" + ItemNumTextbox.Text + "' ";
            }

            if (!string.IsNullOrEmpty(StorageIdTextbox.Text) && !string.IsNullOrWhiteSpace(StorageIdTextbox.Text))
            {
                queryString += "AND StorageID='" + StorageIdTextbox.Text + "' ";
            }

            if (!string.IsNullOrEmpty(BrandTextbox.Text) && !string.IsNullOrWhiteSpace(BrandTextbox.Text))
            {
                queryString += "AND Brand='" + BrandTextbox.Text + "' ";
            }

            if (!string.IsNullOrEmpty(TypeTextbox.Text) && !string.IsNullOrWhiteSpace(TypeTextbox.Text))
            {
                queryString += "AND Type='" + TypeTextbox.Text + "' ";
            }

            if (!string.IsNullOrEmpty(CategoryTextbox.Text) && !string.IsNullOrWhiteSpace(CategoryTextbox.Text))
            {
                queryString += "AND Category='" + CategoryTextbox.Text + "' ";
            }

            if (!string.IsNullOrEmpty(PriceFromTextbox.Text) && !string.IsNullOrWhiteSpace(PriceFromTextbox.Text) &&
                !string.IsNullOrEmpty(PriceToTextbox.Text) && !string.IsNullOrWhiteSpace(PriceToTextbox.Text))
            {
                queryString += "AND Price>='" + PriceFromTextbox.Text + "' ";
                queryString += "AND Price<='" + PriceToTextbox.Text + "' ";
            }

            if (!string.IsNullOrEmpty(QuantityTextbox.Text) && !string.IsNullOrWhiteSpace(QuantityTextbox.Text))
            {
                queryString += "AND Quantity='" + QuantityTextbox.Text + "' ";
            }

            if (!string.IsNullOrEmpty(LocRowTextbox.Text) && !string.IsNullOrWhiteSpace(LocRowTextbox.Text))
            {
                queryString += "AND InnerLocRow='" + LocRowTextbox.Text + "' ";
            }

            if (!string.IsNullOrEmpty(LocColTextbox.Text) && !string.IsNullOrWhiteSpace(LocColTextbox.Text))
            {
                queryString += "AND InnerLocColumn='" + StorageIdTextbox.Text + "' ";
            }

            if (!string.IsNullOrEmpty(LocLevTextbox.Text) && !string.IsNullOrWhiteSpace(LocLevTextbox.Text))
            {
                queryString += "AND InnerLocLevel='" + LocLevTextbox.Text + "' ";
            }


            try
            {
                Termekek termekek_Form = new Termekek(queryString);
                termekek_Form.Show();
                this.Dispose();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Error: " + exception.Message + "termekkeresHiba");
            }
        }

        private void VisszaButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Termekek termekek_Form = new Termekek();
            termekek_Form.Show();
        }

    }
}