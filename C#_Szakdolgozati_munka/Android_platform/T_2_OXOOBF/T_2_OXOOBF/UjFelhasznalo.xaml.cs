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
    public partial class UjFelhasznalo : ContentPage
    {
        public UjFelhasznalo(string UsernameLbltext)
        {
            InitializeComponent();

            UsernameLbl.Text = UsernameLbltext;
        }

        private void MentesBttn_Clicked(object sender, EventArgs e)
        {

        }

        private void LogOutBtn_Clicked(object sender, EventArgs e)
        {

        }
    }
}