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
            this.CenterToParent();
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
                string SqlExecuteCommand = "INSERT INTO raktarkezelo.products VALUES ('" + ItemNumTextbox.Text + "', '" + StorageIdTextbox.Text + "', '" 
                                     + BrandTextbox.Text + "', '" + TypeTextbox.Text + "', '" + CategoryTextbox.Text  + "', '" 
                                     + PriceTextbox.Text + "', '" + QuantityTextbox.Text + "', '" + LocRowTextbox.Text  + "', '" 
                                     + LocColTextbox.Text + "', '" + LocLevTextbox.Text  + "');";

                string returnedAnswer = MySQLadapter.ExecuteSqlCommand(SqlExecuteCommand, "Added Product", ItemNumTextbox.Text);

                MessageBox.Show(returnedAnswer); 

                this.Dispose();
                Kezdolap.termekek_Form = new Termekek();
                Kezdolap.termekek_Form.ShowDialog();
             }
                
        }
    }
}

























































