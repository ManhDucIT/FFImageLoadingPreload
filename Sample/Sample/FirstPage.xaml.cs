using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Diagnostics;

namespace Sample
{
    public partial class FirstPage : ContentPage
    {
        public FirstPage(string filePath, int width, int height)
        {
            InitializeComponent();
            image.DownsampleWidth = width;
            image.DownsampleHeight = height;

            image.Success += (sender, e) =>
            {
                Debug.WriteLine(Enum.GetName(e.LoadingResult.GetType(), e.LoadingResult));
            };
        }
    }
}
