﻿using System;
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
        }

        int count_click = 0;

        private void Button_Clicked(object sender, EventArgs e)
        {
            count_click++;
            txtResult.Text = count_click.ToString();
            if(count_click<5)
            {
                DisplayAlert("", count_click.ToString(), "OK");
            }
            else
            {
                /*
                Device.OnPlatform(
                    Android: image.Source = "penis.png";
                    
                );
                */
                image.Source = "penis.png";  // works only on android
            }
        }
    }
}
