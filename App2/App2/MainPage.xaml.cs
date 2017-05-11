using System;  // String
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using App2.models;  // core
using Xamarin.Forms;
//using System.Net.Http;


namespace App2
{
    public partial class MainPage : MasterDetailPage
    {
        Core core = new Core();
        int row = 406;
        int col = 250;

        public MainPage()
        {
            InitializeComponent();
            // bind buttons
            toolbar_settings.Clicked += SettingsClicked;
            toolbar_refresh.Clicked += RefreshClicked;
            menu.ItemSelected += MenuItemSelected;
            menu_footer.ItemTapped += MenuFooterItemTapped;

            menu.ItemsSource = new string[]  // TODO: dynamic list created by user
            {
                "Białystok",
                "Warszawa",
                "Kraków",
            };
            menu_footer.ItemsSource = new string[]
            {
                "Licencje",
            };

            Refresh();
        }

        private async void Refresh()
        {
            image.Source = null;
            activity.IsRunning = true;
            image.Source = await core.LoadImage(row, col);
            activity.IsRunning = false;
        }

        private void SettingsClicked(object sender, EventArgs e)
        {
            Detail.Navigation.PushAsync(new views.settings());
            IsPresented = false;  // just to make sure
        }

        private void LicensesClicked(object sender, EventArgs e)
        {
            Detail.Navigation.PushAsync(new views.licenses());
            //IsPresented = false;  // just to make sure
        }

        private void RefreshClicked(object sender, EventArgs e)
        {
            Refresh();
            debug.Text = "reloaded";
        }

        private void MenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            IsPresented = false;  // hide master page
            // TODO: drop this switch, object based
            switch (e.SelectedItem.ToString())
            {
                case "Białystok":
                    row = 379;
                    col = 285;
                    break;
                case "Warszawa":
                    row = 406;
                    col = 250;
                    break;
                case "Kraków":
                    row = 466;
                    col = 232;
                    break;
            }
            debug.Text = String.Format("row: {0}\n col: {1}", row, col);
            Refresh();
            //image.Source = core.LoadImage(row, col);
            //Detail = new NavigationPage()
        }

        private void MenuFooterItemTapped(object sender, ItemTappedEventArgs e)
        {
            Detail.Navigation.PushAsync(new views.licenses());
            IsPresented = false;
            menu_footer.SelectedItem = null;
        }
    }
}
