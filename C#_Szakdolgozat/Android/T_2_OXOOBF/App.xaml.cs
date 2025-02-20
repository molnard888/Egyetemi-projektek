//#define NOL_LOGIN_REQUIRED


using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;



namespace T_2_OXOOBF
{

    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
#if NOL_LOGIN_REQUIRED
            Class_Common.setLoggedInUser("Admin");
            MainPage = new NavigationPage(new Kezdolap(true));
#else
            MainPage = new NavigationPage(new LoginPage());
#endif

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
