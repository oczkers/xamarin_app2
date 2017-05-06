using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using Xamarin.Forms;

namespace App2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            image.Source = "http://www.meteo.pl/um/metco/mgram_pict.php?ntype=0u&fdate=2017050612&row=406&col=250&lang=en";
            // TODO: change url based (only?) on datatime
        }
    }
}
