using System;
using System.Windows.Forms;

namespace Raktarkezelo
{
    public partial class FelhasznaloKereses : Form
    {
        public FelhasznaloKereses()
        {
            InitializeComponent();
        }

        private void KeresesButton_Click(object sender, EventArgs e)
        {
            string TalalatString = "";
            string queryString = "Select * from `users` WHERE 1 ";

            if (!string.IsNullOrEmpty(UsernameTextbox.Text) && !string.IsNullOrWhiteSpace(UsernameTextbox.Text))
            {
                queryString += "AND Username='" + UsernameTextbox.Text + "' ";
            }

            if (!string.IsNullOrEmpty(StorageIdTextbox.Text) && !string.IsNullOrWhiteSpace(StorageIdTextbox.Text))
            {
                queryString += "AND StorageID='" + StorageIdTextbox.Text + "' ";
            }

            if (!string.IsNullOrEmpty(PasswordTextbox.Text) && !string.IsNullOrWhiteSpace(PasswordTextbox.Text))
            {
                queryString += "AND Password='" + PasswordTextbox.Text + "' ";
            }

            if (!string.IsNullOrEmpty(IsAdminTextbox.Text) && !string.IsNullOrWhiteSpace(IsAdminTextbox.Text))
            {
                queryString += "AND IsAdmin='" + IsAdminTextbox.Text + "' ";
            }

            if (!string.IsNullOrEmpty(LastnameTextbox.Text) && !string.IsNullOrWhiteSpace(LastnameTextbox.Text))
            {
                queryString += "AND LastName='" + LastnameTextbox.Text + "' ";
            }

            if (!string.IsNullOrEmpty(FirstnameTextbox.Text) && !string.IsNullOrWhiteSpace(FirstnameTextbox.Text))
            {
                queryString += "AND FirstName='" + FirstnameTextbox.Text + "' ";
            }

            if (!string.IsNullOrEmpty(TelefonTextbox.Text) && !string.IsNullOrWhiteSpace(TelefonTextbox.Text))
            {
                queryString += "AND PhoneNumber='" + TelefonTextbox.Text + "' ";
            }

            if (!string.IsNullOrEmpty(EmailTextbox.Text) && !string.IsNullOrWhiteSpace(EmailTextbox.Text))
            {
                queryString += "AND InnerLocColumn='" + EmailTextbox.Text + "' ";
            }


            try
            {
                Felhasznalok felhasznalok_Form = new Felhasznalok(queryString);
                felhasznalok_Form.Show();
                this.Dispose();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Error: " + exception.Message + " felhasznaloKeresesHiba");
            }
        }
    }
}