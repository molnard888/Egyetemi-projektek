using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Documents;
using System.Windows.Forms;
using Library.Forms;
using MySql.Data.MySqlClient;

namespace Raktarkezelo
{
    public partial class EladTermek : Form
    {
        public List<string> KosarLista;
        string EladasPanel_SelectedItemnumber = null;
        public static SortableBindingList<TermekBasicInfo> KosarBindingList = new SortableBindingList<TermekBasicInfo>();
        private Dictionary<string, int> DictProdQuantityInDb = new Dictionary<string, int>();
        private int Vegosszeg = 0;
        System.Windows.Forms.Timer t = null;
        
        
        public EladTermek(List<string> _vasarloilista)
        {
            
            KosarLista = new List<string>(_vasarloilista);
            KosarLista.Sort();
            InitializeComponent();
            
            this.CenterToParent();
            
            if (!KosarLista.Any())
            {
                
            }
            else
            {
                DGV_feltoltes();
            }
            VegOsszegEmptyLabel.Text = Vegosszeg.ToString() + " Ft";
            StartTimer();
            EladasDGV.DataSource = KosarBindingList;
        }

        private void StartTimer()
        {
            t = new System.Windows.Forms.Timer();
            t.Interval = 1000;
            t.Tick += new EventHandler(t_Tick);
            t.Enabled = true;
        }

        void t_Tick(object sender, EventArgs e)
        {
            IdoTextbox.Text = DateTime.Now.ToString();
        }

        public void DGV_feltoltes()
        {
            KosarLista.Sort();
            KosarBindingList = new SortableBindingList<TermekBasicInfo>();
            Vegosszeg = 0;
            EladasDGV.DataSource = KosarBindingList;
            MySqlConnection databaseConn = MySQLadapter.CreateDbConnection();

            for (int i = 0; i < KosarLista.Count; i++)
            {
                string queryString = "select * from raktarkezelo.products where ItemNumber='" + KosarLista[i] + "';";
                MySqlCommand SqlSelectCommand = new MySqlCommand(queryString, databaseConn);
                SqlSelectCommand.CommandTimeout = 60;

                try
                {
                    databaseConn.Open();

                    MySqlDataReader myReader = SqlSelectCommand.ExecuteReader();

                    if (myReader.HasRows) // Ha jó az input
                    {
                        // "ItemNumber | StorageID | Brand | Type | Category | Price | Quantity | InnerLocRow | InnerLocColumn | InnerLocLevel\n";
                        while (myReader.Read())
                        {
                            KosarBindingList.Add(new TermekBasicInfo(myReader.GetString(0), myReader.GetString(2), myReader.GetString(3), myReader.GetString(4), myReader.GetString(5)));

                            try
                            {
                                Vegosszeg += Int32.Parse(myReader.GetString(5));
                            }
                            catch (FormatException e)
                            {
                                Console.WriteLine(e.Message);
                                string ErrorString = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " - Error during EladTermek rtb feltoltes func.: " + e.Message;
                                Class_Logging.WriteToLogFile(ErrorString);
                            }
                        }
                    }

                    databaseConn.Close();
                    EladasDGV.DataSource = KosarBindingList;
                }

                catch (Exception exception)
                {
                    if (databaseConn != null)
                    {
                        databaseConn.Close();
                    }
                    MessageBox.Show("Error: " + exception.Message + " ; " + queryString);
                    string ErrorString = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " - Error during filling up EladTermek form: " + exception.Message;
                    Class_Logging.WriteToLogFile(ErrorString);

                }
            }
            VegOsszegEmptyLabel.Text = Vegosszeg.ToString() + " Ft";
        }

        private void BeolvasButton_Click(object sender, EventArgs e)
        {
            WebcamQrScanner QrScan = new WebcamQrScanner();
            QrScan.ShowDialog();
        }

        
        private void TorolButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(EladasPanel_SelectedItemnumber) && !string.IsNullOrWhiteSpace(EladasPanel_SelectedItemnumber))
            {
                if (KosarBindingList.Any())
                {
                    KosarLista.Remove(EladasPanel_SelectedItemnumber);
                    DGV_feltoltes();
                }
                else
                {
                    MessageBox.Show("A tartomány üres!");
                }
                
                MessageBox.Show("Sikeres törlés!");

            }
            else
            {
                MessageBox.Show("Nincs kiválasztva termék!");
            }
            EladasPanel_SelectedItemnumber = null;
            //MessageBox.Show(KosarLista.Count().ToString());
        }
        
        private void EladButton_Click(object sender, EventArgs e)
        {
            string msgBoxError = "";
            if (!KosarLista.Any())
            {
                MessageBox.Show("A kosár üres!");
            }
            else
            {
                bool IsQuantityEnough = true;
                GetQuantityForProducts();
                var CartProdIdsAndQuantity = KosarLista.GroupBy(x => x)
                                .Select(g => new { Value = g.Key, Count = g.Count() })
                                .OrderByDescending(x => x.Count);

                foreach (var x in CartProdIdsAndQuantity)
                {
                    if (DictProdQuantityInDb[x.Value]-x.Count < 0)
                    {
                        IsQuantityEnough = false;
                        msgBoxError = "[" + x.Value + "] termékből nincs elegendő darabszám a raktárban!"; 
                    }
                }



                if (KosarBindingList.Any() && !string.IsNullOrWhiteSpace(KosarLista[0]) && !string.IsNullOrWhiteSpace(KosarLista[0]) && Vegosszeg>0)
                {
                    if (string.IsNullOrEmpty(NameTextbox.Text) || string.IsNullOrWhiteSpace(NameTextbox.Text) ||
                    string.IsNullOrEmpty(TelefonTextbox.Text) || string.IsNullOrWhiteSpace(TelefonTextbox.Text) ||
                    string.IsNullOrEmpty(AddressTextbox.Text) || string.IsNullOrWhiteSpace(AddressTextbox.Text))
                    {
                        MessageBox.Show("Érvénytelen Adat!");  
                    }
                    else if (!IsQuantityEnough)
                    {
                        MessageBox.Show(msgBoxError);
                    }
                    else
                    {
                        string SaleTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss_");
                        string VasarlasID = SaleTime + TelefonTextbox.Text;



                        string InsertSaleUpdateProdQuantityTransaction = "START TRANSACTION; \n";
                        string ProdIdsAndQuantities = "";

                        foreach (var x in CartProdIdsAndQuantity)
                        {
                            ProdIdsAndQuantities += x.Value + "(" + x.Count + "),";
                            InsertSaleUpdateProdQuantityTransaction += "UPDATE raktarkezelo.products set Quantity = Quantity - " + x.Count + " WHERE ItemNumber = '" + x.Value + "'; \n";
                        }
                        ProdIdsAndQuantities = ProdIdsAndQuantities.Remove(ProdIdsAndQuantities.Length - 1, 1);

                        InsertSaleUpdateProdQuantityTransaction += "INSERT INTO raktarkezelo.sales VALUES ('" + NameTextbox.Text + "', '" + TelefonTextbox.Text + "', '" 
                                            + AddressTextbox.Text + "', '" + Class_Common.getStorageIDforUser() + "', '" + ProdIdsAndQuantities + "', '" + VasarlasID + "', '" 
                                            + Vegosszeg + "', '" + SaleTime + "'); " ;


                        InsertSaleUpdateProdQuantityTransaction += "\nCOMMIT;";
                        string returnedAnswer = MySQLadapter.ExecuteSqlCommand(InsertSaleUpdateProdQuantityTransaction, "Added Sale", VasarlasID);

                        MessageBox.Show(returnedAnswer);
                        Kezdolap.termekek_Form.Listaz();
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("A kosár üres!");
                }
            }
        }

        private void GetQuantityForProducts()
        {
            DictProdQuantityInDb = new Dictionary<string, int>();
            List<string> KosarListaUnique = KosarLista.Distinct().ToList();

            MySqlConnection databaseConn = MySQLadapter.CreateDbConnection();
            string queryString = null;
            for (int i = 0; i < KosarListaUnique.Count; i++)
            {
                queryString = "SELECT ItemNumber, Quantity FROM raktarkezelo.products WHERE ItemNumber='" + KosarListaUnique[i] + "';";
                MySqlCommand SqlSelectCommand = new MySqlCommand(queryString, databaseConn);
                SqlSelectCommand.CommandTimeout = 60;

                try
                {
                    MySQLadapter.CreateDbConnection();
                    databaseConn.Open();

                    MySqlDataReader myReader = SqlSelectCommand.ExecuteReader();

                    if (myReader.HasRows) // Ha jó az input
                    {
                        // ItemNumber | Quantity ";
                        while (myReader.Read())
                        {
                            DictProdQuantityInDb.Add(myReader.GetString(0), myReader.GetInt32(1));
                        }
                    }

                    databaseConn.Close();
                }
                catch (Exception exception)
                {
                    if (databaseConn != null)
                    {
                        databaseConn.Close();
                    }
                    MessageBox.Show("Error: " + exception.Message + " ; " + queryString);
                    string ErrorString = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " - Error during getting Quantites from Db: " + exception.Message;
                    Class_Logging.WriteToLogFile(ErrorString);
                }
            }
        }


        private void OsszTorolButton_Click(object sender, EventArgs e)
        {
            KosarLista.Clear();
            DGV_feltoltes();
        }

        private void EladasDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (EladasDGV.SelectedRows.Count == 1)
            {
                DataGridViewRow row = this.EladasDGV.SelectedRows[0];
                EladasPanel_SelectedItemnumber = row.Cells["Azonosito"].Value.ToString();
            }

        }

        private void EladasDGV_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewColumn newColumn = EladasDGV.Columns[e.ColumnIndex];
            DataGridViewColumn oldColumn = EladasDGV.SortedColumn;
            ListSortDirection direction;
            
            if (oldColumn != null)
            {
                if (oldColumn == newColumn &&
                    EladasDGV.SortOrder == SortOrder.Ascending)
                {
                    direction = ListSortDirection.Descending;
                }
                else
                {
                    direction = ListSortDirection.Ascending;
                    oldColumn.HeaderCell.SortGlyphDirection = SortOrder.None;
                }
            }
            else
            {
                direction = ListSortDirection.Ascending;
            }

            EladasDGV.Sort(newColumn, direction);
            newColumn.HeaderCell.SortGlyphDirection =
                direction == ListSortDirection.Ascending ?
                    SortOrder.Ascending : SortOrder.Descending;
        }

        private void EladasDGV_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewColumn column in EladasDGV.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Programmatic;
            }
        }



    }
}