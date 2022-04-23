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
    public partial class Eladas : ContentPage
    {
        
        public Eladas(string UsernameLbltext, List<string> InputList)
        {
            InitializeComponent();

            MyListView.ItemsSource = InputList;
            UsernameLbl.Text = UsernameLbltext;
        }


        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", e.Item.ToString(), "OK");

            //((ListView)sender).BackgroundColor = 
            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }


        private void LogOutBtn_Clicked(object sender, EventArgs e)
        {
            (Application.Current).MainPage = new NavigationPage(new Page1());
        }

        
        private void TorolBttn_Clicked(object sender, EventArgs e)
        {

        }

        private void BeolvasBttn_Clicked(object sender, EventArgs e)
        {
            // QR kod olvaso
            Navigation.PushAsync(new Qr_olvaso(UsernameLbl.Text, true));
        }

        private void OsszTorolBttn_Clicked(object sender, EventArgs e)
        {

        }

        private void EladasBttn_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("", "Sikeres vásárlás", "OK"); 
            Navigation.PushAsync(new Kezdolap(true, "Admin"));

        }
    }
}