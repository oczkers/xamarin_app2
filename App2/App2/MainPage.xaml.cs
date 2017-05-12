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
                "Legenda",
                "Licencje",
            };
            menu.SelectedItem = "Warszawa";

            Refresh();
        }

        private async void Refresh()
        {
            image.Source = null;
            activity.IsRunning = true;
            try
            {
                image.Source = await core.LoadImage(row, col);
            }
            catch (Exception ex)
            {
                //debug.Text = ex.Message;
                debug.Text = "Błąd połączenia z serwerem meteo.pl";
            }
            activity.IsRunning = false;
        }

        private async void SettingsClicked(object sender, EventArgs e)
        {
            await Detail.Navigation.PushAsync(new views.settings());
        }

        private async void LicensesClicked(object sender, EventArgs e)
        {
            await Detail.Navigation.PushAsync(new views.licenses());
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
        }

        private async void MenuFooterItemTapped(object sender, ItemTappedEventArgs e)
        {
            switch (e.Item.ToString())
            {
                case "Legenda":
                    await Detail.Navigation.PushAsync(new views.legend());
                    break;
                case "Licencje":
                    await Detail.Navigation.PushAsync(new views.licenses());
                    break;
            }
            IsPresented = false;
            menu_footer.SelectedItem = null;
        }
    }
}
