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
            image.Source = core.LoadImage(row, col);
            menu.ItemSelected += OnMenuItemSelected;
            //IsPresented = true;
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
        }

        private void OnMenuItemSelected (object sender, SelectedItemChangedEventArgs e)
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
            image.Source = core.LoadImage(row, col);
            //Detail = new NavigationPage()
        }

        private void Refresh_Clicked(object sender, System.EventArgs e)
        {
            image.Source = core.LoadImage(row, col);
            debug.Text = "reloaded";
        }
    }
}
