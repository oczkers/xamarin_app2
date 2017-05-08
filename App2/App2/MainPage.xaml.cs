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
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            image.Source = core.LoadImage();
        }
    }
}
