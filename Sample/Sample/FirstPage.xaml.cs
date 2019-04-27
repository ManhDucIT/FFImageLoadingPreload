using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Sample
{
    public partial class FirstPage : ContentPage
    {
        public FirstPage(string filePath)
        {
            InitializeComponent();

            image.WidthRequest = Application.Current.MainPage.Width;
            image.HeightRequest = Application.Current.MainPage.HeightRequest;

            image.Source = ImageSource.FromFile(filePath);
        }
    }
}
