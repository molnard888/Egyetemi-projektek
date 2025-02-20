using Library.Forms;
using MySql.Data.MySqlClient;
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
    public partial class MuveletNaplo : Form
    {
        string NaploPanel_SelectedLog = null;
        public MuveletNaplo()
        {
            InitializeComponent();
            this.CenterToParent();
            //TermekLista = GetTermekLista();
            Listaz();
        }

        public MuveletNaplo(string query)
        {
            InitializeComponent();
            this.CenterToParent();
            NaploDGV.MultiSelect = false;
            NaploDGV.DataSource = null;
        }

        public void Listaz(string queryString = "SELECT * FROM `log` ORDER BY `log`.`DateTime` DESC")
        {
            SortableBindingList<Class_Naplo> LogList = new SortableBindingList<Class_Naplo>();                   // A függvény által visszaadandó terméklista és a többi változó
            NaploPanel_SelectedLog = null;
            NaploDGV.DataSource = null;
            MySqlConnection databaseConn = null;

            try
            {
                databaseConn = MySQLadapter.CreateDbConnection();                                                  // Adatbáziskapcsolat                 
                MySqlCommand SqlSelectCommand = new MySqlCommand(queryString, databaseConn);
                SqlSelectCommand.CommandTimeout = 60;
                databaseConn.Open();
                MySqlDataReader myReader = SqlSelectCommand.ExecuteReader();                                        // Lekérdezés az adatbázisból

                if (myReader.HasRows) // Ha jó az input
                {
                    // logID | Storage | UserName | DateTime | Process | Details   --   log tábla mezői
                    while (myReader.Read())
                    {
                        LogList.Add(new Class_Naplo(myReader.GetInt32(0),                                        // Lista feltöltése
                                                            myReader.GetInt32(1),
                                                            myReader.GetString(2),
                                                            myReader.GetString(3),
                                                            myReader.GetString(4),
                                                            myReader.GetString(5)));

                    }
                }
                databaseConn.Close();                                                                               // Kapcsolat bontása
                NaploDGV.DataSource = LogList;
            }
            catch (Exception exception)
            {
                if (databaseConn != null)
                {
                    databaseConn.Close();
                }
                MessageBox.Show("Error: " + exception.Message + " ; " + queryString);                                // Hiba kiírása és naplófájlba rögzítése                                    
                string ErrorString = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " - Error during Selecting the products from Database: " + exception.Message + " ; " + queryString;
                Class_Logging.WriteToLogFile(ErrorString);
            }                                                                                      // Lista visszaadása          
        }

        private void KeresesButton_Click(object sender, EventArgs e)
        {
            MuveletKereses MuveletKereses_Form = new MuveletKereses();
            MuveletKereses_Form.ShowDialog();
            this.Dispose();
        }
        
        private void VisszaButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void NaploDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (NaploDGV.SelectedRows.Count == 1)
            {
                DataGridViewRow row = this.NaploDGV.SelectedRows[0];
                NaploPanel_SelectedLog = row.Cells["NaploID"].Value.ToString();
            }

        }

        private void NaploDGV_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewColumn newColumn = NaploDGV.Columns[e.ColumnIndex];
            DataGridViewColumn oldColumn = NaploDGV.SortedColumn;
            ListSortDirection direction;
           
            if (oldColumn != null)
            {
                if (oldColumn == newColumn &&
                    NaploDGV.SortOrder == SortOrder.Ascending)
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

            NaploDGV.Sort(newColumn, direction);
            newColumn.HeaderCell.SortGlyphDirection =
                direction == ListSortDirection.Ascending ?
                    SortOrder.Ascending : SortOrder.Descending;
        }

        private void NaploDGV_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewColumn column in NaploDGV.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Programmatic;
            }
        }

        private void MuveletNaplo_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
            Listaz();
        }
    }
}
