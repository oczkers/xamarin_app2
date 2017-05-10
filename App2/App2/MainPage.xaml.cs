//using System;
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
        int row = 466;
        int col = 232;

        public MainPage()
        {
            InitializeComponent();
            image.Source = core.LoadImage(row, col);
            menu.ItemSelected += OnItemSelected;
            //IsPresented = true;
            menu.ItemsSource = new string[]  // TODO: dynamic list created by user
            {
                "Warszawa",
                "Kraków",
            };
            menu_footer.ItemsSource = new string[]
            {
                "Licencje",
            };
        }

        void OnItemSelected (object sender, SelectedItemChangedEventArgs e)
        {
            IsPresented = false;
            // TODO: drop this switch, object based
            switch (e.SelectedItem.ToString())
            {
                case "Warszawa":
                    core.LoadImage(row, col);
                    break;
                case "Kraków":
                    label.Text = "Kraków";
                    break;
            }
            //Detail = new NavigationPage()
        }
    }
}
