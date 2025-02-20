using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Library.Forms;
using MySql.Data.MySqlClient;
using Raktarkezelo;

namespace Raktarkezelo
{
    public partial class Termekek : Form
    {
        
        string TermekekPanel_SelectedItemnumber = null;
        private string ProductSearchQuery = null;
        SortableBindingList<Class_Termek> ProdList = new SortableBindingList<Class_Termek>();
        public static List<string> VasarloiLista = new List<string>();
        public static EladTermek elad_Form;
        public static TermekKereses termekKereses_Form;

        public Termekek()
        {
            InitializeComponent();
            this.CenterToParent();
            TermekekDGV.DataSource = ProdList;
            
        }

        

        public Termekek(string query)
        {
            if(!query.Equals("Select * from `products` WHERE "))
                ProductSearchQuery = query;
            InitializeComponent();
            this.CenterToParent();
            TermekekDGV.DataSource = ProdList;
            TermekekDGV.MultiSelect = false;
            TermekekDGV.DataSource = null;

        }
        

        private void Termekek_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
            Listaz();
        }

        private void VisszaButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public void Listaz(string queryString = null)
        {
            ProdList = new SortableBindingList<Class_Termek>();                   // A függvény által visszaadandó terméklista és a többi változó
            TermekekPanel_SelectedItemnumber = null;                                                        
            TermekekDGV.DataSource = null;

            if (!string.IsNullOrEmpty(queryString) && !string.IsNullOrWhiteSpace(queryString))        // Ha keresés által hívódik meg
            {
                queryString = queryString + " ORDER BY `products`.`ItemNumber` ASC";
            }
            else                                                                                                    // Ha normál módon hívódik meg      
            {
                queryString = "SELECT * FROM `products` ORDER BY `products`.`ItemNumber` ASC";
            }

            MySqlConnection databaseConn = null;

            try
            {
                databaseConn  = MySQLadapter.CreateDbConnection();                                                  // Adatbáziskapcsolat                 
                MySqlCommand SqlSelectCommand = new MySqlCommand(queryString, databaseConn);
                SqlSelectCommand.CommandTimeout = 60;
                databaseConn.Open();
                MySqlDataReader myReader = SqlSelectCommand.ExecuteReader();                                        // Lekérdezés az adatbázisból
                
                if (myReader.HasRows) // Ha jó az input
                {
                    // ItemNumber | StorageID | Brand | Type | Category | Price | Quantity | InnerLocRow | InnerLocColumn | InnerLocLevel    --   products tábla mezői
                    while (myReader.Read())
                    {
                        ProdList.Add(new Class_Termek(myReader.GetString(0),                                        // Lista feltöltése
                                                            myReader.GetInt16(1), 
                                                            myReader.GetString(2), 
                                                            myReader.GetString(3), 
                                                            myReader.GetString(4), 
                                                            myReader.GetInt32(5), 
                                                            myReader.GetInt32(6), 
                                                            myReader.GetInt32(7), 
                                                            myReader.GetInt32(8), 
                                                            myReader.GetInt32(9)));
                        
                    }
                }
                databaseConn.Close();                                                                               // Kapcsolat bontása
                TermekekDGV.DataSource = ProdList;
            }
            catch (Exception exception)
            {
                if(databaseConn != null)
                {
                    databaseConn.Close();
                }   
                MessageBox.Show("Error: " + exception.Message +" ; "+ queryString);                                // Hiba kiírása és naplófájlba rögzítése                                    
                string ErrorString = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " - Error during Selecting the products from Database: " + exception.Message +" ; "+ queryString ;
                Class_Logging.WriteToLogFile(ErrorString);
            }                                                                                  // Lista visszaadása          
        }




        private void TorlesButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TermekekPanel_SelectedItemnumber) && !string.IsNullOrWhiteSpace(TermekekPanel_SelectedItemnumber))
            {
                MySqlConnection databaseConn = MySQLadapter.CreateDbConnection();
                string SqlExecuteCommand = "Delete from `products` WHERE ItemNumber='" + TermekekPanel_SelectedItemnumber + "'"; 
                string returnedAnswer = MySQLadapter.ExecuteSqlCommand(SqlExecuteCommand, "Deleted Product", TermekekPanel_SelectedItemnumber);
                MessageBox.Show(returnedAnswer);
            }
            else
            {
                MessageBox.Show("Nincs kiválasztva termék!");
            }
            TermekekPanel_SelectedItemnumber = null;
            Listaz();
        }

        private void ModositButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TermekekPanel_SelectedItemnumber) || string.IsNullOrWhiteSpace(TermekekPanel_SelectedItemnumber))
            {
                MessageBox.Show("Nincs kiválasztva termék!");
            }
            else
            {
                TermekMod termMod_Form = new TermekMod(TermekekPanel_SelectedItemnumber);
                termMod_Form.ShowDialog();
            }
            TermekekPanel_SelectedItemnumber = null;
            
        }

        private void KeresesButton_Click(object sender, EventArgs e)
        {
            termekKereses_Form = new TermekKereses();
            termekKereses_Form.ShowDialog();
        }


        private void EladButton_Click(object sender, EventArgs e)
        {
                elad_Form = new EladTermek(VasarloiLista);
                elad_Form.ShowDialog();
                VasarloiLista.Clear();
                KosarbaButton.Text = "Kosárba (" + VasarloiLista.Count + ")";
        }

        private void KosárbaButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TermekekPanel_SelectedItemnumber) &&
                !string.IsNullOrWhiteSpace(TermekekPanel_SelectedItemnumber))
            {
                VasarloiLista.Add(TermekekPanel_SelectedItemnumber);
                KosarbaButton.Text = "Kosárba (" + VasarloiLista.Count + ")";
                TermekekPanel_SelectedItemnumber = "";
            }
            else
            {
                KosarbaButton.Text = "Kosárba (" + VasarloiLista.Count + ")";
                MessageBox.Show("Nincs kiválasztva termék!");
                TermekekPanel_SelectedItemnumber = "";
            }
        }

        public void ujElad_Form()
        {
            EladButton.PerformClick();
        }

        private void TermekekDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (TermekekDGV.SelectedRows.Count == 1 )
            {
                DataGridViewRow row = this.TermekekDGV.SelectedRows[0];
                //MessageBox.Show(row.Cells["Azonosito"].Value.ToString());
                TermekekPanel_SelectedItemnumber = row.Cells["Azonosito"].Value.ToString();
            }
            
        }

        private void TermekekDGV_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewColumn newColumn = TermekekDGV.Columns[e.ColumnIndex];
            DataGridViewColumn oldColumn = TermekekDGV.SortedColumn;
            ListSortDirection direction;
           
            if (oldColumn != null)
            {
                if (oldColumn == newColumn &&
                    TermekekDGV.SortOrder == SortOrder.Ascending)
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

            TermekekDGV.Sort(newColumn, direction);
            newColumn.HeaderCell.SortGlyphDirection =
                direction == ListSortDirection.Ascending ?
                    SortOrder.Ascending : SortOrder.Descending;
        }

        private void TermekekDGV_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewColumn column in TermekekDGV.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Programmatic;
            }
        }
    }
}