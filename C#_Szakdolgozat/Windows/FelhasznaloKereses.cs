using System;
using System.Windows.Forms;

namespace Raktarkezelo
{
    public partial class FelhasznaloKereses : Form
    {
        public FelhasznaloKereses()
        {
            InitializeComponent();
            
            this.CenterToParent();
        }

        private void KeresesButton_Click(object sender, EventArgs e)
        {
            string queryString = "Select * from `users` WHERE ";

            if (!string.IsNullOrEmpty(UsernameTextbox.Text) && !string.IsNullOrWhiteSpace(UsernameTextbox.Text))
            {
                queryString += " Username='" + UsernameTextbox.Text + "' AND";
            }

            if (!string.IsNullOrEmpty(StorageIdTextbox.Text) && !string.IsNullOrWhiteSpace(StorageIdTextbox.Text))
            {
                queryString += " StorageID='" + StorageIdTextbox.Text + "' AND";
            }

            if (!string.IsNullOrEmpty(PasswordTextbox.Text) && !string.IsNullOrWhiteSpace(PasswordTextbox.Text))
            {
                queryString += " Password='" + PasswordTextbox.Text + "' AND";
            }

            if (!string.IsNullOrEmpty(IsAdminTextbox.Text) && !string.IsNullOrWhiteSpace(IsAdminTextbox.Text))
            {
                queryString += " IsAdmin='" + IsAdminTextbox.Text + "' AND";
            }

            if (!string.IsNullOrEmpty(LastnameTextbox.Text) && !string.IsNullOrWhiteSpace(LastnameTextbox.Text))
            {
                queryString += " LastName='" + LastnameTextbox.Text + "' AND";
            }

            if (!string.IsNullOrEmpty(FirstnameTextbox.Text) && !string.IsNullOrWhiteSpace(FirstnameTextbox.Text))
            {
                queryString += " FirstName='" + FirstnameTextbox.Text + "' AND";
            }

            if (!string.IsNullOrEmpty(TelefonTextbox.Text) && !string.IsNullOrWhiteSpace(TelefonTextbox.Text))
            {
                queryString += " PhoneNumber='" + TelefonTextbox.Text + "' AND";
            }

            if (!string.IsNullOrEmpty(EmailTextbox.Text) && !string.IsNullOrWhiteSpace(EmailTextbox.Text))
            {
                queryString += " InnerLocColumn='" + EmailTextbox.Text + "' AND";
            }

            
            try
            {
                if (!queryString.Equals("Select * from `users` WHERE "))
                {
                    queryString = queryString.Remove(queryString.Length - 3);
                    Kezdolap.felhasznalok_Form.Listaz(queryString);
                }
                else
                {
                    MessageBox.Show("Minden beviteli mező üres!");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Error: " + exception.Message + " felhasznaloKeresesHiba");
                string ErrorString = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " - Error during searching for user: " + exception.Message;
                Class_Logging.WriteToLogFile(ErrorString);
            }
        }
    }
}