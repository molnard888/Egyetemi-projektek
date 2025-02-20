using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Raktarkezelo
{
    public partial class EladasokKereses : Form
    {
        public EladasokKereses()
        {
            InitializeComponent();
        }


        private void KeresesButton_Click(object sender, EventArgs e)
        {
            string queryString = "Select * from `sales` WHERE ";

            if (!string.IsNullOrEmpty(NameTextbox.Text) && !string.IsNullOrWhiteSpace(NameTextbox.Text))
            {
                queryString += " Name= '" + NameTextbox.Text + "' AND";
            }

            if (!string.IsNullOrEmpty(TelefonTextbox.Text) && !string.IsNullOrWhiteSpace(TelefonTextbox.Text))
            {
                queryString += " Phone= '" + TelefonTextbox.Text + "' AND";
            }

            if (!string.IsNullOrEmpty(AddressTextbox.Text) && !string.IsNullOrWhiteSpace(AddressTextbox.Text))
            {
                queryString += " Address= '" + AddressTextbox.Text + "' AND";
            }

            if (!string.IsNullOrEmpty(ItemNumberTextBox.Text) && !string.IsNullOrWhiteSpace(ItemNumberTextBox.Text))
            {
                queryString += " ItemNumbers= '" + ItemNumberTextBox.Text + "' AND";
            }

            if (!string.IsNullOrEmpty(SaleIDTextBox.Text) && !string.IsNullOrWhiteSpace(SaleIDTextBox.Text))
            {
                queryString += " SaleID= '" + SaleIDTextBox.Text + "' AND";
            }

            if (!string.IsNullOrEmpty(SumFromTextbox.Text) && !string.IsNullOrWhiteSpace(SumFromTextbox.Text))
            {
                queryString += " Sum>='" + SumFromTextbox.Text + "' AND";
            }
            if (!string.IsNullOrEmpty(SumToTextbox.Text) && !string.IsNullOrWhiteSpace(SumToTextbox.Text))
            {
                queryString += " Sum<='" + SumToTextbox.Text + "' AND";
            }

            if (!string.IsNullOrEmpty(DateFromTextbox.Text) && !string.IsNullOrWhiteSpace(DateFromTextbox.Text))
            {
                queryString += " SaleDateTime>='" + DateFromTextbox.Text + "' AND";
            }
            if (!string.IsNullOrEmpty(DateToTextBox.Text) && !string.IsNullOrWhiteSpace(DateToTextBox.Text))
            {
                queryString += " SaleDateTime<='" + DateToTextBox.Text + "' AND";
            }

            
            try
            {
                if (!queryString.Equals("Select * from `sales` WHERE "))
                {
                    queryString = queryString.Remove(queryString.Length - 3);
                    Kezdolap.eladasok_Form.Listaz(queryString);
                }
                else
                {
                    MessageBox.Show("Minden beviteli mező üres!");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Error: " + exception.Message + "VasarlasKeresesHiba");
                string ErrorString = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " - Error during searching for sales: " + exception.Message;
                Class_Logging.WriteToLogFile(ErrorString);
            }
        }
    }
}
