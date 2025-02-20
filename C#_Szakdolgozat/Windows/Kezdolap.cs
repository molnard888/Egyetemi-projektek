#define Login_Required

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

using MySql.Data.MySqlClient;



namespace Raktarkezelo
{
    public partial class Kezdolap : Form
    {
        private Dictionary<string, Panel> Panelek = new Dictionary<string, Panel>();
        //private static string DispProdPanel_RichtextboxSelectedItemnumber = "";
        private int SelectedProdQuantity;
        private List<Panel> PanelList = new List<Panel>();
        public static Termekek termekek_Form;
        public static Felhasznalok felhasznalok_Form;
        public static Eladasok eladasok_Form;
        public static MuveletNaplo naplo_Form;
          
        

        void HideAllPanels()
        {
            foreach (Panel PanelFromList in PanelList)
            {
                if (!PanelFromList.Name.Equals("WorkerBasePanel"))
                {
                    PanelFromList.Hide();
                }
            }
            MuvNaploBttn.Hide();
            WbPanelSignedInAsLabel.Hide();
            WbPanelSignOutButton.Hide();
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
        
        public Kezdolap()
        {
            InitializeComponent();
            HideAllPanels();
            
            //CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.GetCultureInfo("en-US");
        }

        public static void ClearSignedInUser()
        {
            Class_Common.setLoggedInUser(null);
        }
        
        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(UsernameTxtB.Text) || String.IsNullOrWhiteSpace(UsernameTxtB.Text) ||          // Ha valamelyik inputmező üres
                String.IsNullOrEmpty(PWTxtB.Text) || String.IsNullOrWhiteSpace(PWTxtB.Text))
            {
                MessageBox.Show("A beviteli mező üres.");
            }
            else                                                                                                    // Ha az inputmezők nem üresek
            {
                string InputUsername = UsernameTxtB.Text;
                string InputPassword = PWTxtB.Text;

                MySqlConnection databaseConn = null;

                try
                {
                    databaseConn = MySQLadapter.CreateDbConnection();                                   // Adatbázis kapcsolat
                    string queryString = "Select * from `users` WHERE Username='" + InputUsername + "'";
                    MySqlCommand SqlSelectCommand = new MySqlCommand(queryString, databaseConn);
                    SqlSelectCommand.CommandTimeout = 60;
                    databaseConn.Open();
                    MySqlDataReader myReader = SqlSelectCommand.ExecuteReader();
                    myReader.Read();

                    if (myReader.HasRows && InputPassword.Equals(Class_Encryption.Decrypt(myReader.GetString(2))))   // Ha van találat
                    {
                        if (Convert.ToBoolean(myReader.GetString(3)))   // Ha admin
                        {
                            databaseConn.Close();
                            HideAllPanels();
                            ShowingPanelFront(WorkerBasePanel);
                            WbPanelSignedInAsUserLabel.Text = InputUsername;
                            Class_Common.setLoggedInUser(InputUsername);
                            WbPanelAddNewUserButton.Show();
                            WbPanelDisplayUsersButton.Show();
                            WbPanelSignedInAsLabel.Show();
                            WbPanelSignOutButton.Show();
                            MuvNaploBttn.Show();

                        }
                        else                                            // Ha normál jogú felhasználó
                        {

                            databaseConn.Close();
                            HideAllPanels();
                            ShowingPanelFront(WorkerBasePanel);
                            WbPanelSignedInAsUserLabel.Text = InputUsername;
                            Class_Common.setLoggedInUser(InputUsername);
                            WbPanelSignedInAsLabel.Show();
                            WbPanelSignOutButton.Show();
                            WbPanelAddNewUserButton.Hide();
                            WbPanelDisplayUsersButton.Hide();
                        }
                        Class_Logging.InsertLogToDb("Signed In", Environment.MachineName);
                    }
                    else     // hibás input
                    {
                        MessageBox.Show("Helytelen felhasználónév vagy jelszó.");
                    }
                    if (databaseConn != null)       // Kapcsolat bontása
                    {
                        databaseConn.Close();
                    }
                }
                catch (Exception exception)         // Hiba esetén kapcsolat bontása és a hiba naplófáljba rögzítése
                {
                    if (databaseConn != null)
                    {
                        databaseConn.Close();
                    }
                    MessageBox.Show("Error: " + exception.Message);
                    string ErrorString = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " - Error during logging in: " + exception.Message;
                    Class_Logging.WriteToLogFile(ErrorString);
                }
                PWTxtB.Text = "";
            }
        }
        private void Bejelentkezes_Load(object sender, EventArgs e)
        {
            PanelList.Add(LoginPanel);               // 0
            PanelList.Add(WorkerBasePanel);          // 1

#if Login_Required
            HideAllPanels();
            WorkerBasePanel.Hide();
            ShowingPanelFront(LoginPanel);
            PWTxtB.PasswordChar = '*';
#else
            HideAllPanels();
            ShowingPanelFront(WorkerBasePanel);
            WbPanelSignedInAsUserLabel.Text = "No_Login_Mode";
            WbPanelAddNewUserButton.Show();
            WbPanelDisplayUsersButton.Show();
#endif
        }

        private void TermekekButton_Click(object sender, EventArgs e)
        {
            termekek_Form = new Termekek();
            termekek_Form.ShowDialog();
        }

        private void UjTermekButton_Click(object sender, EventArgs e)
        {
            UjTermek ujTermek_Form = new UjTermek();
            ujTermek_Form.ShowDialog();
        }

        private void FelhasznalokButton_Click(object sender, EventArgs e)
        {
            felhasznalok_Form = new Felhasznalok();
            felhasznalok_Form.ShowDialog();
        }

        private void UjFelhasznaloButton_Click(object sender, EventArgs e)
        {
            UjFelhasznalo ujFelh_Form = new UjFelhasznalo();
            ujFelh_Form.ShowDialog();
        }

        private void EladasokButton_Click(object sender, EventArgs e)
        {
            eladasok_Form = new Eladasok();
            eladasok_Form.ShowDialog();
        }

        private void BeolvasButton_Click(object sender, EventArgs e)
        {
            WebcamQrScanner scanner = new WebcamQrScanner("Beolvas");
            scanner.ShowDialog();
        }

        private void MuvNaploButton_Click(object sender, EventArgs e)
        {
            naplo_Form = new MuveletNaplo();
            naplo_Form.ShowDialog();
        }

        private void KijelentkezesButton_Click(object sender, EventArgs e)
        {
            if (Class_Common.getLoggedInUser() != null)
            {
                Class_Logging.InsertLogToDb("Signed Out", Environment.MachineName.ToString());
            }
            ClearSignedInUser();
            HideAllPanels();
            WorkerBasePanel.Hide();
            WbPanelSignedInAsUserLabel.Text = "";
            ShowingPanelFront(LoginPanel);
            UsernameTxtB.Text = "";
            PWTxtB.Text = "";
        }

        private void Bejelentkezes_FormClosing(object sender, FormClosingEventArgs e)
        {
            Class_Logging.InsertLogToDb("Signed Out", Environment.MachineName);
        }

        
    }
}