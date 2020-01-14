using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Meteo24
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // TODO: first-run simple content page asking to select cities (gps, warsaw, cracov etc.)
            MainPage = new NavigationPage(new Meteo24.MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
