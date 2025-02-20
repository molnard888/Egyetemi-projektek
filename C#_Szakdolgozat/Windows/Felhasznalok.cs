using System;
using System.ComponentModel;
using System.Windows.Forms;
using Library.Forms;
using MySql.Data.MySqlClient;

namespace Raktarkezelo
{
    public partial class Felhasznalok : Form
    {
        string FelhasznalokPanel_RichtextboxSelectedUsername = "";
        private string Talalat = "";
        
        public Felhasznalok()
        {
            InitializeComponent();
            this.CenterToParent();
            Listaz();
        }
        
        public Felhasznalok(string talalat)
        {
            InitializeComponent();
            
            this.CenterToParent();
            
            if (!talalat.Equals("Select * from `products` WHERE "))
            {
                Talalat = talalat;
                KeresByQuery(talalat);
            }
        }

        public void KeresByQuery(string _queryString)
        {
            FelhasznalokDGV.DataSource = null;
            SortableBindingList<Class_Felhasznalo> FelhasznaloList = new SortableBindingList<Class_Felhasznalo>();

            if (!string.IsNullOrEmpty(_queryString) && !string.IsNullOrWhiteSpace(_queryString))
            {
                FelhasznalokPanel_RichtextboxSelectedUsername = "";
                FelhasznalokDGV.DataSource = null;

                MySqlConnection databaseConn = MySQLadapter.CreateDbConnection();
                MySqlCommand SqlSelectCommand = new MySqlCommand(_queryString, databaseConn);
                SqlSelectCommand.CommandTimeout = 60;

                try
                {
                    databaseConn.Open();
                    MySqlDataReader myReader = SqlSelectCommand.ExecuteReader();

                    if (myReader.HasRows) // Ha jó az input
                    {
                        while (myReader.Read())
                        {
                            FelhasznaloList.Add(new Class_Felhasznalo(myReader.GetString(0),
                                                            myReader.GetInt32(1),
                                                            myReader.GetString(2),
                                                            myReader.GetInt16(3),
                                                            myReader.GetString(4),
                                                            myReader.GetString(5),
                                                            myReader.GetString(6),
                                                            myReader.GetString(7)));
                        }
                    }
                    databaseConn.Close();
                    FelhasznalokDGV.DataSource = FelhasznaloList;
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Error: " + exception.Message +" ; "+ _queryString);
                    string ErrorString = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " - Error during searching for product: " + exception.Message;
                    Class_Logging.WriteToLogFile(ErrorString);
                }
            }
        }

        public void Listaz(string queryString = "SELECT * FROM `users` ORDER BY `users`.`Username` ASC")
        {
            FelhasznalokPanel_RichtextboxSelectedUsername = "";
            //richTextBox1.Text = "";
            SortableBindingList<Class_Felhasznalo> FelhasznaloList = new SortableBindingList<Class_Felhasznalo>();
            FelhasznalokDGV.DataSource = null;
            
            

            MySqlConnection databaseConn = MySQLadapter.CreateDbConnection();
            MySqlCommand SqlSelectCommand = new MySqlCommand(queryString, databaseConn);
            SqlSelectCommand.CommandTimeout = 60;

            try
            {
                databaseConn.Open();
                MySqlDataReader myReader = SqlSelectCommand.ExecuteReader();

                if (myReader.HasRows) // Ha jó az input
                {
                    while (myReader.Read())
                    {
                        
                        FelhasznaloList.Add(new Class_Felhasznalo(myReader.GetString(0),
                                                            myReader.GetInt32(1),
                                                            myReader.GetString(2),
                                                            myReader.GetInt16(3),
                                                            myReader.GetString(4),
                                                            myReader.GetString(5),
                                                            myReader.GetString(6),
                                                            myReader.GetString(7)));
                    }
                }
                databaseConn.Close();
                FelhasznalokDGV.DataSource = FelhasznaloList;
            }
            catch (Exception exception)
            {
                MessageBox.Show("Error: " + exception.Message +" ; "+ queryString);
                string ErrorString = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " - Error during getting users from Db: " + exception.Message;
                Class_Logging.WriteToLogFile(ErrorString);
            }
        }

        private void RendezesCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Listaz();
        }


        private void KeresesButton_Click(object sender, EventArgs e)
        {
            FelhasznaloKereses FelhKeres_Form = new FelhasznaloKereses();
            FelhKeres_Form.ShowDialog();
        }

        private void ModositButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(FelhasznalokPanel_RichtextboxSelectedUsername) &&
                !string.IsNullOrWhiteSpace(FelhasznalokPanel_RichtextboxSelectedUsername))
            {
                FelhasznaloModosit FelhMod_Form = new FelhasznaloModosit(FelhasznalokPanel_RichtextboxSelectedUsername);
                FelhMod_Form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Nincs kiválasztva felhasználó!");
            }
        }


        private void TorlesButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(FelhasznalokPanel_RichtextboxSelectedUsername) &&
                !string.IsNullOrWhiteSpace(FelhasznalokPanel_RichtextboxSelectedUsername))
            {
                string SqlExecuteCommand = "Delete from `users` WHERE Username='" + FelhasznalokPanel_RichtextboxSelectedUsername + "'"; 

                string returnedAnswer = MySQLadapter.ExecuteSqlCommand(SqlExecuteCommand, "Deleted User", FelhasznalokPanel_RichtextboxSelectedUsername);

                MessageBox.Show(returnedAnswer);
                Listaz();
            }
                
            else
            {
                MessageBox.Show("Nincs kiválasztva felhasználó!");
            }
            FelhasznalokPanel_RichtextboxSelectedUsername = "";
            FelhasznalokDGV.CurrentCell = null;
            }


        private void VisszaButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Felhasznalok_Load(object sender, EventArgs e)
        {
            
        }

        private void FelhasznalokDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (FelhasznalokDGV.SelectedRows.Count == 1 )
            {
                DataGridViewRow row = this.FelhasznalokDGV.SelectedRows[0];
                //MessageBox.Show(row.Cells["ItemNumber"].Value.ToString());
                FelhasznalokPanel_RichtextboxSelectedUsername = row.Cells["FelhasznaloNev"].Value.ToString();
            }
        }


        private void FelhasznalokDGV_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewColumn newColumn = FelhasznalokDGV.Columns[e.ColumnIndex];
            DataGridViewColumn oldColumn = FelhasznalokDGV.SortedColumn;
            ListSortDirection direction;
                       
            if (oldColumn != null)
            {
                if (oldColumn == newColumn &&
                    FelhasznalokDGV.SortOrder == SortOrder.Ascending)
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

            FelhasznalokDGV.Sort(newColumn, direction);
            newColumn.HeaderCell.SortGlyphDirection =
                direction == ListSortDirection.Ascending ?
                    SortOrder.Ascending : SortOrder.Descending;
        }
        
        private void FelhasznalokDGV_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewColumn column in FelhasznalokDGV.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Programmatic;
            }
        }
    }
}