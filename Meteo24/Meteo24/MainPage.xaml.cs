using System;  // String
using System.Collections.Generic;
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

        // TODO: move menu to separate view
        Dictionary<string, List<int>> menu_items = new Dictionary<string, List<int>>
            {
                { "Warszawa", new List<int>{406, 250} },
                { "Kraków", new List<int>{466, 232} },
                { "Łódź", new List<int>{418, 223} },
                { "Wrocław", new List<int>{436, 181} },
                { "Poznań", new List<int>{400, 180} },
                { "Gdańsk", new List<int>{346, 210} },
                { "Szczecin", new List<int>{370, 142} },
                { "Bydgoszcz", new List<int>{381, 199} },
                { "Lublin", new List<int>{432, 277} },
                { "Katowice", new List<int>{461, 215} },
                // { "Białystok", new List<int>{379, 285} },
            };

        public MainPage()
        {
            InitializeComponent();
            // bind buttons
            toolbar_settings.Clicked += SettingsClicked;
            toolbar_refresh.Clicked += RefreshClicked;
            menu.ItemSelected += MenuItemSelected;
            menu_footer.ItemTapped += MenuFooterItemTapped;

            menu.ItemsSource = menu_items.Keys;
            menu_footer.ItemsSource = new string[]
            {
                "Komentarz",  // TODO: comment as a selectable item instead of tap
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
            catch  // catch(Exception ex)
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
            row = menu_items[e.SelectedItem.ToString()][0];
            col = menu_items[e.SelectedItem.ToString()][1];
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
