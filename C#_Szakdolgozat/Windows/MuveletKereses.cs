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
    public partial class MuveletKereses : Form
    {
        public MuveletKereses()
        {
            InitializeComponent();
            this.CenterToParent();
        }

        private void KeresesButton_Click(object sender, EventArgs e)
        {

            string queryString = "Select * from `log` WHERE ";

            if (!string.IsNullOrEmpty(StorageIdTextbox.Text) && !string.IsNullOrWhiteSpace(StorageIdTextbox.Text))
            {
                queryString += " Storage='" + StorageIdTextbox.Text + "' AND";
            }

            if (!string.IsNullOrEmpty(UsernameTextbox.Text) && !string.IsNullOrWhiteSpace(UsernameTextbox.Text))
            {
                queryString += " UserName='" + UsernameTextbox.Text + "' AND";
            }

            if (!string.IsNullOrEmpty(DateFromTextbox.Text) && !string.IsNullOrWhiteSpace(DateFromTextbox.Text))
            {
                queryString += " DateTime>='" + DateFromTextbox.Text + "' AND";
            }

            if (!string.IsNullOrEmpty(DateToTextBox.Text) && !string.IsNullOrWhiteSpace(DateToTextBox.Text))
            {
                queryString += " DateTime<='" + DateToTextBox.Text + "' AND";
            }

            if (!string.IsNullOrEmpty(ProcessTextbox.Text) && !string.IsNullOrWhiteSpace(ProcessTextbox.Text))
            {
                queryString += " Proc='" + ProcessTextbox.Text + "' AND";
            }

            if (!string.IsNullOrEmpty(DetailsTextbox.Text) && !string.IsNullOrWhiteSpace(DetailsTextbox.Text))
            {
                queryString += " Details='" + DetailsTextbox.Text + "' AND";
            }
            

            try
            {
                if(!queryString.Equals("Select * from `log` WHERE "))
                {
                    queryString = queryString.Remove(queryString.Length - 3);
                    Kezdolap.naplo_Form.Listaz(queryString);
                }
                else
                {
                    MessageBox.Show("Minden beviteli mező üres!");
                }
                
            }
            catch (Exception exception)
            {
                MessageBox.Show("Error: " + exception.Message + "MuveletKeresesHiba");
                string ErrorString = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " - Error during searching for product: " + exception.Message;
                Class_Logging.WriteToLogFile(ErrorString);
            }

        }
    }
}
