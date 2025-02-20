using System;
using System.Drawing;
using System.Timers;
using System.Windows.Forms;
using AForge;
using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;
using ZXing.QrCode;



namespace Raktarkezelo
{
    public partial class WebcamQrScanner : Form
    {
        
        FilterInfoCollection capturedev;
        private VideoCaptureDevice finalframe;
        private string BeolvasHivas = "";
        
        public WebcamQrScanner()
        {
            InitializeComponent();
            
            this.CenterToParent();
        }
        
        public WebcamQrScanner(string _boolBeolv)
        {
            InitializeComponent();
            
            this.CenterToParent();
            if (!string.IsNullOrEmpty(_boolBeolv) && !string.IsNullOrWhiteSpace(_boolBeolv))
            {
                BeolvasHivas = _boolBeolv;
            }
        }
        
        private void WebcamQrScanner_Load(object sender, EventArgs e)
        {
            
            this.CenterToParent();
            // load cams into combobox
            capturedev = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            WebcamTextbox.Text = capturedev[0].Name;
        }
        private void FinalFrame_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            try
            {
                pictureBox1.Image = (Bitmap)eventArgs.Frame.Clone();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                string ErrorString = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " - Error during QR FinalFrame_NewFrame(): " + ex.Message ;
                Class_Logging.WriteToLogFile(ErrorString);
            }
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(BeolvasHivas) && !string.IsNullOrWhiteSpace(BeolvasHivas))
            {
                BarcodeReader bcreader = new BarcodeReader();
                if (pictureBox1.Image !=null)
                {
                    // Decoding the barcode/QR code
                    Result res = bcreader.Decode((Bitmap)pictureBox1.Image);
                    try
                    {
                        if (res != null)
                        {
                            timer1.Stop();
                            string itemNumber = res.ToString().Trim();
                            ResultTextbox.Text = itemNumber;
                            string query = "Select * from `products` WHERE ItemNumber='" + itemNumber + "' ";
                            Termekek termekekForm = new Termekek(query);
                            termekekForm.ShowDialog();
                            termekekForm.KeresesButton.Hide();
                            this.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                        string ErrorString = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " - Error during decoding the QR code: " + ex.Message ;
                        Class_Logging.WriteToLogFile(ErrorString);
                    }
                } 
            }
            else
            {
                BarcodeReader bcreader = new BarcodeReader();
                if (pictureBox1.Image !=null)
                {
                    // Decoding the barcode/QR code
                    Result res = bcreader.Decode((Bitmap)pictureBox1.Image);
                    try
                    {
                        if (res != null)
                        {
                            timer1.Stop();
                            string itemNumber = res.ToString().Trim();
                            ResultTextbox.Text = itemNumber;
                            Termekek.elad_Form.KosarLista.Add(itemNumber);
                            Termekek.elad_Form.DGV_feltoltes();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                        string ErrorString = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " - Error during decoding the QR code: " + ex.Message ;
                        Class_Logging.WriteToLogFile(ErrorString);
                    }
                } 
            }
        } 

        private void WebcamQrScanner_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (finalframe !=null)
                if (finalframe.IsRunning ==true)
                {
                    finalframe.Stop();
                }
        }

        private void BeolvasButton_Click(object sender, EventArgs e)
        {
            ResultTextbox.Text = "";
            finalframe = new VideoCaptureDevice(capturedev[0].MonikerString);
            finalframe.NewFrame += new NewFrameEventHandler(FinalFrame_NewFrame);
            finalframe.Start();
            timer1.Enabled = true;
            timer1.Start();
        }

        private void VisszaButton_Click(object sender, EventArgs e)
        {
            if (finalframe !=null)
                if (finalframe.IsRunning ==true)
                {
                    finalframe.Stop();
                }
            this.Close();
        }
    }
}