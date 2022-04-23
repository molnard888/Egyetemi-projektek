using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MySqlConnector;

namespace T_2_OXOOBF
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Qr_olvaso : ContentPage
    {
        bool EladOrNo=false;
        public Qr_olvaso(string username, bool EladOrNot)
        {
            InitializeComponent();

            EladOrNo = EladOrNot;
            UsernameLbl.Text = username;
        }

        private void ZXingScannerView_OnScanResult(ZXing.Result result)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                
                ScanResult.Text = result.Text;
                QRscanner.IsScanning = false;
                
                //this.Navigation.RemovePage(this.Navigation.NavigationStack[this.Navigation.NavigationStack.Count - 1]);
                //this.Navigation.RemovePage(this.Navigation.NavigationStack[this.Navigation.NavigationStack.Count - 2]);
                if(EladOrNo == true)
                {
                    Helper.SelectedItems.Add(ScanResult.Text);
                    Navigation.PushAsync(new Eladas("Admin", Helper.SelectedItems));
                }
                else
                {
                    Navigation.PushAsync(new TermekekLV("Admin", ScanResult.Text));
                }
                
                
                
            });
        }

        private void LogOutBtn_Clicked(object sender, EventArgs e)
        {
            (Application.Current).MainPage = new NavigationPage(new Page1());
        }

        private void BeolvasStartStop_Clicked(object sender, EventArgs e)
        {
            if (QRscanner.IsScanning == true)
            {
                QRscanner.IsScanning = false;
            }
            else
            {
                QRscanner.IsScanning = false;
            }
        }
    }
}