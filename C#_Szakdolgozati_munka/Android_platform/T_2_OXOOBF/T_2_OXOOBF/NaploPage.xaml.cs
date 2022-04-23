using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;

namespace T_2_OXOOBF
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NaploPage : ContentPage
    {
        ObservableCollection<string> Items = new ObservableCollection<string>{};
    public NaploPage(string user)
        {
            InitializeComponent();

            UsernameLbl.Text = user;

            Items.Add("Admin | 2021-11-12 | 16:00:49 | Bejelentkezes | PC \n");
            Items.Add("Admin | 2021-11-12 | 16:05:34 | Eladas | 1 \n");
            Items.Add("Admin | 2021-11-12 | 16:06:07 | Kijelentkezes | PC \n");
            Items.Add("Admin | 2021-11-12 | 16:22:13 | Bejelentkezes | Mobil \n");

            MyListView.ItemsSource = Items;
        }

        private void LogOutBtn_Clicked(object sender, EventArgs e)
        {

        }

       
    }
}