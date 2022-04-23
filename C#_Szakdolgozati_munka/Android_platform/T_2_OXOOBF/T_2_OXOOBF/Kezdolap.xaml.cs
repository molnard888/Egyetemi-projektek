using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Kezdolap(bool IsAdmin, string Username)
        {
            InitializeComponent();

            UsernameLbl.Text = "Belépve: " + Username;

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
            (Application.Current).MainPage = new NavigationPage(new Page1());
        }

        
        private void Ujfelhasznalobtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new UjFelhasznalo(UsernameLbl.Text));
        }

        private void Felhasznalokbtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new FelhasznalokLV(UsernameLbl.Text));
        }

        private void Eladásokbtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new eladasokLV(UsernameLbl.Text));
        }

        private void Ujtermekbtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new UjTermek(UsernameLbl.Text));
        }

        private void Beolvasbtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Qr_olvaso(UsernameLbl.Text, false));
        }

        private void Termekekbtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TermekekLV(UsernameLbl.Text));
        }

        private void LogBttn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NaploPage(UsernameLbl.Text));
        }
    }
}