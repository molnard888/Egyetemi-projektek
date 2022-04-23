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
        /* private FilterInfoCollection filterInfColl;
        private VideoCaptureDevice captureDevice;
        
        
        

        private void BeolvasButton_Click(object sender, EventArgs e)
        {
            captureDevice = new VideoCaptureDevice(filterInfColl[0].MonikerString);
            captureDevice.NewFrame += new NewFrameEventHandler(FinalFrame_NewFrame);
            captureDevice.Start();
            timer1.Enabled = true;
            timer1.Start();
        }

        private void VisszaButton_Click(object sender, EventArgs e)
        {
            if (captureDevice != null)
            {
                if (captureDevice.IsRunning == true)
                {
                    captureDevice.Stop();
                }
            }
            this.Dispose();
        }

        private void WebcamQrScanner_Load(object sender, EventArgs e)
        {
            filterInfColl = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            
        }


        private void timer1_Tick(object sender, ElapsedEventArgs e)
        {
            BarcodeReader BcReader = new BarcodeReader();
            if (pictureBox1.Image != null)
            {
                Result res = BcReader.Decode((Bitmap) pictureBox1.Image);
                try
                {
                    string dec = res.ToString().Trim();
                    if (dec == "abubaker")
                    {
                        timer1.Stop();
                        MessageBox.Show("abubaker");
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(e.ToString());
                }
            }
        }

        private void FinalFrame_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            try
            {
                pictureBox1.Image = (Bitmap) eventArgs.Frame.Clone();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }


        private void WebcamQrScanner_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (captureDevice != null)
            {
                if (captureDevice.IsRunning == true)
                {
                    captureDevice.Stop();
                }
            }
        }
        */
        
        FilterInfoCollection capturedev;
        private VideoCaptureDevice finalframe;
        private string boolBeolvasHivas = "";
        
        public WebcamQrScanner()
        {
            InitializeComponent();
        }
        
        public WebcamQrScanner(string _boolBeolv)
        {
            InitializeComponent();
            if (!string.IsNullOrEmpty(_boolBeolv) && !string.IsNullOrWhiteSpace(_boolBeolv))
            {
                boolBeolvasHivas = _boolBeolv;
            }
        }
        
        private void WebcamQrScanner_Load(object sender, EventArgs e)
        {
            // load cams into combobox
            capturedev = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            WebcamTextbox.Text = capturedev[1].Name;
        }
        private void FinalFrame_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            try
            {
                pictureBox1.Image = (Bitmap)eventArgs.Frame.Clone();
            }
            catch (Exception ex)
            {
            }
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(boolBeolvasHivas) && !string.IsNullOrWhiteSpace(boolBeolvasHivas))
            {
                BarcodeReader red = new BarcodeReader();
                if (pictureBox1.Image !=null)
                {
                    // here decode the qr
                    Result res = red.Decode((Bitmap)pictureBox1.Image);
                    try
                    {
                        string dec = res.ToString().Trim();
                        ResultTextbox.Text = dec;
                        string query = "Select * from `products` WHERE ItemNumber='" + dec + "' ";
                        Termekek termekek_Form = new Termekek(query);
                        termekek_Form.Show();
                        termekek_Form.KeresesButton.Hide();
                        termekek_Form.RendezesCombobox.Hide();
                        termekek_Form.RendezesLabel.Hide();
                        timer1.Stop();
                        this.Close();
                    }
                    catch( Exception ex)
                    {}
                } 
            }
            else
            {
                BarcodeReader red = new BarcodeReader();
                if (pictureBox1.Image !=null)
                {
                    // here decode the qr
                    Result res = red.Decode((Bitmap)pictureBox1.Image);
                    try
                    {
                        string dec = res.ToString().Trim();
                        ResultTextbox.Text = dec;
                        Termekek.elad_Form.KosarLista.Add(dec);
                        Termekek.elad_Form.Richtextbox1_feltoltes();
                        timer1.Stop();
                    }
                    catch( Exception ex)
                    {}
                } 
            }
            
        } 

        /* Here is the code of comboBox1 SelectedIndexChanged :
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            finalframe = new
                VideoCaptureDevice(capturedev[comboBox1.SelectedIndex].MonikerString);
            finalframe.NewFrame += new NewFrameEventHandler(FinalFrame_NewFrame);
            finalframe.Start();
            timer1.Enabled = true;
            timer1.Start();
        }
         And finally the code of form closing: */

        
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
            finalframe = new VideoCaptureDevice(capturedev[1].MonikerString);
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