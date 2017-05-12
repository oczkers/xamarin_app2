//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using Xamarin.Forms;


namespace Meteo24.views
{
    public partial class licenses : ContentPage
    {
        public licenses()
        {
            InitializeComponent();

            var tapGestureMeteo = new TapGestureRecognizer();
            tapGestureMeteo.Tapped += (s, e) =>
            {
                Device.OpenUri(new System.Uri("http://meteo.pl"));
            };
            label_meteo_title.GestureRecognizers.Add(tapGestureMeteo);
            label_meteo.GestureRecognizers.Add(tapGestureMeteo);

            /*
            var tapGestureGplv3 = new TapGestureRecognizer();
            tapGestureGplv3.Tapped += (s, e) =>
            {
                Device.OpenUri(new System.Uri("http://meteo.pl"));  // TODO: gplv3 on github
            };
            label_gplv3_title.GestureRecognizers.Add(tapGestureGplv3);
            label_gplv3.GestureRecognizers.Add(tapGestureGplv3);
            */

            var tapGestureGithub = new TapGestureRecognizer();
            tapGestureGithub.Tapped += (s, e) =>
            {
                Device.OpenUri(new System.Uri("https://github.com/oczkers/xamarin_meteo24"));
            };
            label_github.GestureRecognizers.Add(tapGestureGithub);
        }
    }
}