using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Library.Forms;
using MySql.Data.MySqlClient;

namespace Raktarkezelo
{
    public partial class Eladasok : Form
    {
        private string RichtextboxSelectedDatetime = "";
        private string RichtextboxSelectedPhone = "";
        private string Talalat = "";
        
        public Eladasok()
        {
            InitializeComponent();
            this.CenterToParent();
            Listaz();
        }
        
        
        public void Listaz(string queryString = "SELECT * FROM `sales` ORDER BY SaleDatetime DESC")
        {
            RichtextboxSelectedPhone = "";
            RichtextboxSelectedDatetime = "";
            EladasokDGV.DataSource = null;
            SortableBindingList<Class_Eladas> EladasokList = new SortableBindingList<Class_Eladas>();
            
            
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
                        EladasokList.Add(new Class_Eladas(myReader.GetString(0), myReader.GetString(1), myReader.GetString(2),
                            myReader.GetInt32(3), myReader.GetString(4), myReader.GetString(5), myReader.GetInt32(6),
                            myReader.GetDateTime(7).ToString("yyyy-MM-dd HH:mm:ss")));
                        
                    }
                }
                databaseConn.Close();
                EladasokDGV.DataSource = EladasokList;
            }
            catch (Exception exception)
            {
                MessageBox.Show("Error: " + exception.Message +" ; "+ queryString);
                string ErrorString = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " - Error during searching for sales: " + exception.Message;
                Class_Logging.WriteToLogFile(ErrorString);
            }

        }
        
        

        private void TorlesButton_Click(object sender, EventArgs e)
        {
            
            if (!string.IsNullOrWhiteSpace(RichtextboxSelectedDatetime) &&
                                                         !string.IsNullOrWhiteSpace(RichtextboxSelectedDatetime)
                                                         && !string.IsNullOrWhiteSpace(RichtextboxSelectedPhone) &&
                                                         !string.IsNullOrWhiteSpace(RichtextboxSelectedPhone))
            {
                string VasarlasID = RichtextboxSelectedDatetime + RichtextboxSelectedPhone;
                string SqlExecuteCommand = "Delete from `sales` WHERE SaleID='" + VasarlasID + "'; ";

                string returnedAnswer = MySQLadapter.ExecuteSqlCommand(SqlExecuteCommand, "Deleted Sale", VasarlasID);

                MessageBox.Show(returnedAnswer);
                Listaz();
            }
            else
            {
                MessageBox.Show("Nincs kiválasztott elem!");
            }
            
            RichtextboxSelectedDatetime = "";
            RichtextboxSelectedPhone = "";
        }

        private void ModositButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(RichtextboxSelectedDatetime) &&
                                                         !string.IsNullOrWhiteSpace(RichtextboxSelectedDatetime)
                                                         && !string.IsNullOrWhiteSpace(RichtextboxSelectedPhone) &&
                                                         !string.IsNullOrWhiteSpace(RichtextboxSelectedPhone))
            {
                EladasModosit eladasMod_Form = new EladasModosit(RichtextboxSelectedDatetime+"_"+RichtextboxSelectedPhone);
                eladasMod_Form.ShowDialog();
            }
                        
            RichtextboxSelectedDatetime = "";
            RichtextboxSelectedPhone = "";
        }

        private void KeresesButton_Click(object sender, EventArgs e)
        {
            EladasokKereses eladasokKereses = new EladasokKereses();
            eladasokKereses.ShowDialog();
        }

        private void VisszaButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void EladasokDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (EladasokDGV.SelectedRows.Count == 1 )
            {
                DataGridViewRow row = this.EladasokDGV.SelectedRows[0];
                RichtextboxSelectedDatetime = row.Cells["VasarlasIdo"].Value.ToString();
                RichtextboxSelectedPhone = row.Cells["Telefon"].Value.ToString();
            }
        }

        private void EladasokDGV_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewColumn newColumn = EladasokDGV.Columns[e.ColumnIndex];
            DataGridViewColumn oldColumn = EladasokDGV.SortedColumn;
            ListSortDirection direction;
            
            if (oldColumn != null)
            {
                if (oldColumn == newColumn &&
                    EladasokDGV.SortOrder == SortOrder.Ascending)
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

           
            EladasokDGV.Sort(newColumn, direction);
            newColumn.HeaderCell.SortGlyphDirection =
                direction == ListSortDirection.Ascending ?
                    SortOrder.Ascending : SortOrder.Descending;
        }

        private void EladasokDGV_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewColumn column in EladasokDGV.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Programmatic;
            }
        }
    }

   
}