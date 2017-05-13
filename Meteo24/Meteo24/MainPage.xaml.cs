using System;  // String
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using Meteo24.models;  // core
using Xamarin.Forms;
//using System.Net.Http;


namespace Meteo24
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
                "Warszawa",
                "Kraków",
                "Łódź",
                "Wrocław",
                "Poznań",
                "Gdańsk",
                "Szczecin",
                "Bydgoszcz",
                "Lublin",
                "Katowice"
            };
            menu_footer.ItemsSource = new string[]
            {
                "Komentarz",
                "Legenda",
                "Licencje",
            };
            menu_footer.HeightRequest = menu_footer.RowHeight * 3 + 1;  // +1 disables scolling

            menu.SelectedItem = "Warszawa";
        }

        private async void Refresh()
        {
            image.Source = null;  // TODO: save last link for every city.
            activity.IsRunning = true;
            try
            {
                image.Source = await core.LoadImage(row, col);
            }
            catch  // (Exception ex)
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
                case "Warszawa":
                    row = 406;
                    col = 250;
                    break;
                case "Kraków":
                    row = 466;
                    col = 232;
                    break;
                case "Łódź":
                    row = 418;
                    col = 223;
                    break;
                case "Wrocław":
                    row = 436;
                    col = 181;
                    break;
                case "Poznań":
                    row = 400;
                    col = 180;
                    break;
                case "Gdańsk":
                    row = 346;
                    col = 210;
                    break;
                case "Szczecin":
                    row = 370;
                    col = 142;
                    break;
                case "Bydgoszcz":
                    row = 381;
                    col = 199;
                    break;
                case "Lublin":
                    row = 432;
                    col = 277;
                    break;
                case "Katowice":
                    row = 461;
                    col = 215;
                    break;
                /*
                case "Białystok":
                    row = 379;
                    col = 285;
                    break;
                */
            }
            debug.Text = String.Format("row: {0}\n col: {1}", row, col);
            Refresh();
        }

        private async void MenuFooterItemTapped(object sender, ItemTappedEventArgs e)
        {
            switch (e.Item.ToString())
            {
                case "Komentarz":
                    await Detail.Navigation.PushAsync(new views.comment());
                    break;
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
