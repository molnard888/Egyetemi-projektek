using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

using MySql.Data.MySqlClient;


namespace Raktarkezelo
{
    public partial class Form1 : Form
    {
        private Dictionary<string, Panel> Panelek = new Dictionary<string, Panel>();
        private string DispProdPanel_RichtextboxSelectedItemnumber = "";
        private int SelectedProdQuantity;
        private List<Panel> PanelList = new List<Panel>();
        public static Termekek termekek_Form;
        public static Felhasznalok felhasznalok_Form;
          
        

        void HideAllPanels()
        {
            foreach (Panel PanelFromList in PanelList)
            {
                if (!PanelFromList.Name.Equals("WorkerBasePanel"))
                {
                    PanelFromList.Hide();
                }
            }
        }
        
        void ShowingPanelFront(Panel p)
        {
            foreach (Panel PanelFromList in PanelList)
            {
                if (PanelFromList.Name.Equals(p.Name))
                {
                    PanelFromList.Show();
                    PanelFromList.BringToFront();
                }
            }
        }
        
        public Form1()
        {
            InitializeComponent();
            HideAllPanels();
            ShowingPanelFront(LoginPanel);
            PWTxtB.PasswordChar = '*';
        }
        
        
        private void LoginButton_Click(object sender, EventArgs e)
        {
            string InputUsername = UsernameTxtB.Text;
            string InputPassword = PWTxtB.Text;
            string MySQLConnString = "datasource=127.0.0.1;port=3306;username=root;password=;database=raktarkezelo";
            MySqlConnection databaseConn = new MySqlConnection(MySQLConnString);
            string queryString = "Select * from `users` WHERE Username='" + InputUsername + "'";
            MySqlCommand commandCheckInputUsers = new MySqlCommand(queryString, databaseConn);
            commandCheckInputUsers.CommandTimeout = 60;

            try
            {
                databaseConn.Open();
                MessageBox.Show("Kapcsolat létrejött!");
                MySqlDataReader myReader = commandCheckInputUsers.ExecuteReader();
                
                if (myReader.HasRows && myReader.Read() && InputPassword==myReader.GetString(2) )   // Ha jó az input
                {
                    if (Convert.ToBoolean(myReader.GetString(3)))  // Ha admin
                    {
                        HideAllPanels();
                        ShowingPanelFront(WorkerBasePanel);
                        WbPanelSignedInAsUserLabel.Text = InputUsername;
                        WbPanelAddNewUserButton.Show();
                        WbPanelDisplayUsersButton.Show();
                        //WbPanelDispProductsButton.PerformClick();
                    }
                    else     // Ha dolgozó
                    {
                        // dolgozopanel
                        
                        HideAllPanels();
                        ShowingPanelFront(WorkerBasePanel);
                        WbPanelSignedInAsUserLabel.Text = InputUsername;
                        WbPanelAddNewUserButton.Hide();
                        WbPanelDisplayUsersButton.Hide();
                        //WbPanelDispProductsButton.PerformClick();
                        
                    }
                }
                else     // hibás input
                {
                    MessageBox.Show("Invalid Username or Password");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Error: " + exception.Message);
            }
            databaseConn.Close();

            UsernameTxtB.Text = "";
            PWTxtB.Text = "";
        }
        private void EditProductPanelEditButton_Click(object sender, EventArgs e)
        {
            /*
            string MySQLConnString = "datasource=127.0.0.1;port=3306;username=root;password=;database=raktarkezelo";
            MySqlConnection databaseConn = new MySqlConnection(MySQLConnString);
            string queryString = "update raktarkezelo.products set StorageID='" + EditProductPanelStoragIdTextbox.Text + "', Brand='" + EditProductPanelBrandTextbox.Text 
                                 + "', Type='" + EditProductPanelTypeTextbox.Text + "', Category='" + EditProductPanelCategoryTextbox.Text  + "', Price='" + EditProductPanelPriceTextbox.Text 
                                 + "', Quantity='" + EditProductPanelQuantityTextbox.Text + "', InnerLocRow='" + EditProductPanelLocRowTextbox.Text  + "', InnerLocColumn='" + EditProductPanelLocColTextbox.Text
                                 + "', InnerLocLevel='" + EditProductPanelLocLevTextbox.Text + "' where ItemNumber='" + EditProductPanelItemNumFilledLabel.Text + "';";

            // Edit -> Update
            MySqlCommand commandUpdateProds = new MySqlCommand(queryString, databaseConn);
            commandUpdateProds.CommandTimeout = 60;
            
            try
            {
                MySqlDataReader myReader;
                databaseConn.Open();
                myReader = commandUpdateProds.ExecuteReader();
                MessageBox.Show("Data of item: " + DispProdPanel_RichtextboxSelectedItemnumber + " updated successfully!");  
                while (myReader.Read())  
                {  
                }
                databaseConn.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Error: " + exception.Message);
            }
            DispProdPanel_RichtextboxSelectedItemnumber = "";
            WbPanelDispProductsButton.PerformClick();   */
            
        }


        private void EditProductPanelCancelButton_Click(object sender, EventArgs e)
        {
            /* HideAllPanels();
            ShowingPanelFront(WorkerBasePanel);
            ShowingPanelFront(DisplayProductsPanel);
            DispProdPanel_RichtextboxSelectedItemnumber = ""; */
        }

        private void AddNewProductPanelAddNewButton_Click(object sender, EventArgs e)
        {
            /* if (!string.IsNullOrEmpty(AddNewProductPanelItemNumTextbox.Text) || !string.IsNullOrWhiteSpace(AddNewProductPanelItemNumTextbox.Text) ||
                !string.IsNullOrEmpty(AddNewProductPanelStorageIdTextbox.Text) || !string.IsNullOrWhiteSpace(AddNewProductPanelStorageIdTextbox.Text) ||
                !string.IsNullOrEmpty(AddNewProductPanelBrandTextbox.Text) || !string.IsNullOrWhiteSpace(AddNewProductPanelBrandTextbox.Text) ||
                !string.IsNullOrEmpty(AddNewProductPanelTypeTextbox.Text) || !string.IsNullOrWhiteSpace(AddNewProductPanelTypeTextbox.Text) ||
                !string.IsNullOrEmpty(AddNewProductPanelCategoryTextbox.Text) || !string.IsNullOrWhiteSpace(AddNewProductPanelCategoryTextbox.Text) ||
                !string.IsNullOrEmpty(AddNewProductPanelPriceTextbox.Text) || !string.IsNullOrWhiteSpace(AddNewProductPanelPriceTextbox.Text) ||
                !string.IsNullOrEmpty(AddNewProductPanelQuantityTextbox.Text) || !string.IsNullOrWhiteSpace(AddNewProductPanelQuantityTextbox.Text) ||
                !string.IsNullOrEmpty(AddNewProductPanelLocRowTextbox.Text) || !string.IsNullOrWhiteSpace(AddNewProductPanelLocRowTextbox.Text) ||
                !string.IsNullOrEmpty(AddNewProductPanelLocColTextbox.Text) || !string.IsNullOrWhiteSpace(AddNewProductPanelLocColTextbox.Text) ||
                !string.IsNullOrEmpty(AddNewProductPanelLocLevTextbox.Text) || !string.IsNullOrWhiteSpace(AddNewProductPanelLocLevTextbox.Text))
            {
                string MySQLConnString = "datasource=127.0.0.1;port=3306;username=root;password=;database=raktarkezelo";
                MySqlConnection databaseConn = new MySqlConnection(MySQLConnString);
                
                // insert !!!
                string queryString = "INSERT INTO raktarkezelo.products VALUES ('" + AddNewProductPanelItemNumTextbox.Text + "', '" + AddNewProductPanelStorageIdTextbox.Text + "', '" 
                                     + AddNewProductPanelBrandTextbox.Text + "', '" + AddNewProductPanelTypeTextbox.Text + "', '" + AddNewProductPanelCategoryTextbox.Text  + "', '" 
                                     + AddNewProductPanelPriceTextbox.Text + "', '" + AddNewProductPanelQuantityTextbox.Text + "', '" + AddNewProductPanelLocRowTextbox.Text  + "', '" 
                                     + AddNewProductPanelLocColTextbox.Text + "', '" + AddNewProductPanelLocLevTextbox.Text  + "');"; 
                // Edit -> Insert
                MySqlCommand commandUpdateProds = new MySqlCommand(queryString, databaseConn);
                commandUpdateProds.CommandTimeout = 60;
            
                try
                {
                    MySqlDataReader myReader;
                    databaseConn.Open();
                    myReader = commandUpdateProds.ExecuteReader();
                    MessageBox.Show("Product Inserted!");  
                    while (myReader.Read())  
                    {  
                    }
                    databaseConn.Close();
                    
                    WbPanelAddNewProductsButton.PerformClick();
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Error: " + exception.Message);
                }
            }
            else
            {
                MessageBox.Show("Invalid ipnut data!");  
            }  */
        }      

        private void WbPanelSignOutButton_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            WorkerBasePanel.Hide();
            ShowingPanelFront(LoginPanel);
            UsernameTxtB.Text = "";
            PWTxtB.Text = "";
        }

        private void WbPanelDispProductsButton_Click(object sender, EventArgs e)
        {
            termekek_Form = new Termekek();
            termekek_Form.Show();
            /* DispProdPanel_RichtextboxSelectedItemnumber = "";
            string queryString = "SELECT * FROM `products` ORDER BY `products`.`ItemNumber` ASC";
            HideAllPanels();
            ShowingPanelFront(WorkerBasePanel);
            ShowingPanelFront(DisplayProductsPanel); 
            
            switch (DisplayProductsPanelOrderCombobox.SelectedIndex)
            {
                case 0:
                    queryString = "SELECT * FROM `products` ORDER BY `products`.`ItemNumber` ASC";
                    break;
                case 1:
                    queryString = "SELECT * FROM `products` ORDER BY `products`.`ItemNumber` DESC";
                    break;
                case 2:
                    queryString = "SELECT * FROM `products` ORDER BY `products`.`Brand` ASC";
                    break;
                case 3:
                    queryString = "SELECT * FROM `products` ORDER BY `products`.`Brand` DESC";
                    break;
                case 4:
                    queryString = "SELECT * FROM `products` ORDER BY `products`.`Quantity` ASC";
                    break;
                case 5:
                    queryString = "SELECT * FROM `products` ORDER BY `products`.`Quantity` DESC";
                    break;
            }
            
            string MySQLConnString = "datasource=127.0.0.1;port=3306;username=root;password=;database=raktarkezelo";
            MySqlConnection databaseConn = new MySqlConnection(MySQLConnString);
            MySqlCommand commandCheckInputUsers = new MySqlCommand(queryString, databaseConn);
            commandCheckInputUsers.CommandTimeout = 60;

            try
            {
                databaseConn.Open();
                MySqlDataReader myReader = commandCheckInputUsers.ExecuteReader();

                if (myReader.HasRows) // Ha jó az input
                {
                    DisplayProductsPanelRichtextbox.Text =
                        "ItemNumber | StorageID | Brand | Type | Category | Price | Quantity | InnerLocRow | InnerLocColumn | InnerLocLevel\n";
                    while (myReader.Read())
                    {
                        DisplayProductsPanelRichtextbox.Text += myReader.GetString(0) + " | " + myReader.GetString(1) + " | " +
                                                                myReader.GetString(2) +
                                                                " | " + myReader.GetString(3) + " | " + myReader.GetString(4)
                                                                + " | " + myReader.GetString(5) + " | " + myReader.GetString(6) + " | [" +
                                                                myReader.GetString(7) + ";" + myReader.GetString(8) + ";" +
                                                                myReader.GetString(9) + "]\n";
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Error: " + exception.Message);
            }
            databaseConn.Close();   */
        }

        private void WbPanelAddNewProductsButton_Click(object sender, EventArgs e)
        {
            UjTermek ujTermek_Form = new UjTermek();
            ujTermek_Form.Show();
            /* HideAllPanels();
            ShowingPanelFront(WorkerBasePanel);
            ShowingPanelFront(AddNewProductPanel); 
            
            AddNewProductPanelItemNumTextbox.Text = ""; 
            AddNewProductPanelStorageIdTextbox.Text = ""; 
            AddNewProductPanelBrandTextbox.Text = ""; 
            AddNewProductPanelTypeTextbox.Text = ""; 
            AddNewProductPanelCategoryTextbox.Text = ""; 
            AddNewProductPanelPriceTextbox.Text = ""; 
            AddNewProductPanelQuantityTextbox.Text = ""; 
            AddNewProductPanelLocRowTextbox.Text = ""; 
            AddNewProductPanelLocColTextbox.Text = ""; 
            AddNewProductPanelLocLevTextbox.Text = "";   */
        }

        private void WbPanelDisplayUsersButton_Click(object sender, EventArgs e)
        {
            felhasznalok_Form = new Felhasznalok();
            felhasznalok_Form.Show();
        }

        private void WbPanelSearchProductsButton_Click(object sender, EventArgs e)
        {
            
        }

        private void WbPanelAddNewUserButton_Click(object sender, EventArgs e)
        {
            UjFelhasznalo ujFelh_Form = new UjFelhasznalo();
            ujFelh_Form.Show();
        }

        private void DisplayProductsPanelEditbutton_Click(object sender, EventArgs e)
        {
            /* if (!string.IsNullOrEmpty(DispProdPanel_RichtextboxSelectedItemnumber))
            {   
                HideAllPanels();
                ShowingPanelFront(WorkerBasePanel);
                ShowingPanelFront(EditProductPanel);
                
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
                            EditProductPanelItemNumFilledLabel.Text = myReader.GetString(0);
                            EditProductPanelStoragIdTextbox.Text = myReader.GetString(1);
                            EditProductPanelBrandTextbox.Text = myReader.GetString(2);
                            EditProductPanelTypeTextbox.Text = myReader.GetString(3);
                            EditProductPanelCategoryTextbox.Text = myReader.GetString(4);
                            EditProductPanelPriceTextbox.Text = myReader.GetString(5);
                            EditProductPanelQuantityTextbox.Text = myReader.GetString(6);
                            EditProductPanelLocRowTextbox.Text = myReader.GetString(7);
                            EditProductPanelLocColTextbox.Text = myReader.GetString(8);
                            EditProductPanelLocLevTextbox.Text = myReader.GetString(9);
                        }
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Error: " + exception.Message);
                }
                databaseConn.Close();    
            }
            else
            {
                MessageBox.Show("Please select a product!");
            } */

        }

        private void DisplayProductsPanelSellButton_Click(object sender, EventArgs e)
        {
            /* if (!string.IsNullOrEmpty(DispProdPanel_RichtextboxSelectedItemnumber))
            {
                
                string MySQLConnString = "datasource=127.0.0.1;port=3306;username=root;password=;database=raktarkezelo";
                MySqlConnection databaseConn = new MySqlConnection(MySQLConnString);
                string queryString = "Select * from `products` WHERE ItemNumber='" + DispProdPanel_RichtextboxSelectedItemnumber + "'";   // ItemNumber 
                MySqlCommand commandSelectedProdQuantity = new MySqlCommand(queryString, databaseConn);
                commandSelectedProdQuantity.CommandTimeout = 60;

                try
                {
                    databaseConn.Open();
                    MySqlDataReader myReader = commandSelectedProdQuantity.ExecuteReader();

                    if (myReader.HasRows) // Ha jó az input
                    {
                        while (myReader.Read())
                        {
                            SelectedProdQuantity = Convert.ToInt32(myReader.GetString(6));
                        }
                    }
                    databaseConn.Close();
                    if (SelectedProdQuantity > 0)
                    {
                        queryString = "update raktarkezelo.products set Quantity='" +
                                      Convert.ToString(SelectedProdQuantity - 1) + "' where ItemNumber='" +
                                      DispProdPanel_RichtextboxSelectedItemnumber + "';";
                        // Sell -> Update
                        commandSelectedProdQuantity = new MySqlCommand(queryString, databaseConn);
                        commandSelectedProdQuantity.CommandTimeout = 60;
                        databaseConn.Open();
                        myReader = commandSelectedProdQuantity.ExecuteReader();
                        MessageBox.Show("Item: " + DispProdPanel_RichtextboxSelectedItemnumber + " sold successfully!");
                        while (myReader.Read())
                        {
                        }
                        databaseConn.Close();
                        WbPanelDispProductsButton.PerformClick();
                    }
                    else
                    {
                        MessageBox.Show("Product is out of stock!");
                    }
                    
                    
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Error: " + exception.Message);
                }
                  
            }
            else
            {
                MessageBox.Show("Please select a product!");
            }
            DispProdPanel_RichtextboxSelectedItemnumber = "";   */
            
        }

        private void DisplayProductsPanelDeleteButton_Click(object sender, EventArgs e)
        {
           /*  if (!string.IsNullOrEmpty(DispProdPanel_RichtextboxSelectedItemnumber))
            {
                
                string MySQLConnString = "datasource=127.0.0.1;port=3306;username=root;password=;database=raktarkezelo";
                MySqlConnection databaseConn = new MySqlConnection(MySQLConnString);
                string queryString = "Delete from `products` WHERE ItemNumber='" + DispProdPanel_RichtextboxSelectedItemnumber + "'";   // ItemNumber 
                MySqlCommand commandSelectedProdQuantity = new MySqlCommand(queryString, databaseConn);
                commandSelectedProdQuantity.CommandTimeout = 60;

                try
                {
                    databaseConn.Open();
                    MySqlDataReader myReader = commandSelectedProdQuantity.ExecuteReader();

                    if (myReader.HasRows) // Ha jó az input
                    {
                        while (myReader.Read())
                        {
                        }
                    }
                    databaseConn.Close();
                    MessageBox.Show("Item: " + DispProdPanel_RichtextboxSelectedItemnumber + " removed from database successfully!");
                    WbPanelDispProductsButton.PerformClick();
                    
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Error: " + exception.Message);
                }
                  
            }
            else
            {
                MessageBox.Show("Please select a product!");
            }
            DispProdPanel_RichtextboxSelectedItemnumber = ""; */
                    
        }
        private void DisplayProductsPanelOrderCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // WbPanelDispProductsButton.PerformClick();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            PanelList.Add(LoginPanel);               // 0
            PanelList.Add(WorkerBasePanel);          // 1
            
            HideAllPanels();
            WorkerBasePanel.Hide();
            ShowingPanelFront(LoginPanel);
        }

        

        private void DisplayProductsPanelRichtextbox_MouseClick(object sender, MouseEventArgs e)    // kijelölés
        {
            /* int firstcharindex = DisplayProductsPanelRichtextbox.GetFirstCharIndexOfCurrentLine();
            int currentline = DisplayProductsPanelRichtextbox.GetLineFromCharIndex(firstcharindex);
            string currentlinetext = DisplayProductsPanelRichtextbox.Lines[currentline];
            DisplayProductsPanelRichtextbox.Select(firstcharindex, currentlinetext.Length);

            string[] substrings = currentlinetext.Split('|');
            DispProdPanel_RichtextboxSelectedItemnumber = substrings[0].Remove(substrings[0].Length - 1, 1); */
        }

        

        private void EladasokButton_Click(object sender, EventArgs e)
        {
            Eladasok Eladasok_Form = new Eladasok();
            Eladasok_Form.Show();
        }


        private void BeolvasButton_Click(object sender, EventArgs e)
        {
            WebcamQrScanner scanner = new WebcamQrScanner("Form1caller");
            scanner.Show();
        }
    }
}