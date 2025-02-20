using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace T_2_OXOOBF
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Kezdolap : ContentPage
    {
        public Kezdolap()
        {
            InitializeComponent();
        }

        public Kezdolap(bool IsAdmin)
        {
            InitializeComponent();

            UsernameLbl.Text = Class_Common.getLoggedInUser();

            if (IsAdmin)
            {

            }
            else
            {
                ujfelhasznalobtn.IsVisible = false;
                felhasznalokbtn.IsVisible = false;
            }

        }

        private void LogOut(object sender, EventArgs e)
        {
            Class_Common.LogOutWriteToDb();
            (Application.Current).MainPage = new NavigationPage(new LoginPage());
        }

        
        private void Ujfelhasznalobtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new UjFelhasznalo(0));
        }

        private void Felhasznalokbtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new FelhasznalokLV());
        }

        private void Eladásokbtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new eladasokLV());
        }

        private void Ujtermekbtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new UjTermek(0));
        }

        private void Beolvasbtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Qr_olvaso(false));
        }

        private void Termekekbtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TermekekLV());
        }

        private void LogBttn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Lv_Naplo());
        }
    }
}