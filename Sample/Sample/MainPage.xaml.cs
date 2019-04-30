using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FFImageLoading;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Xamarin.Forms;
using System.Diagnostics;

namespace Sample
{
    public partial class MainPage : ContentPage
    {

        private string _filePath;
        private int width, height;
        private bool isPageAppearingInvoked;

        public MainPage()
        {
            InitializeComponent();
        }

        void Handle_ClickedPreload(object sender, EventArgs e)
        {
            width = (int)Application.Current.MainPage.Width;
            height = (int)Application.Current.MainPage.Height;

            ImageService.Instance.LoadCompiledResource("ball.jpg")
               .DownSample(0, 0, true)
               .Success((info, result) =>
               {
                   Debug.WriteLine($"Preloading finished! Key: {info.CacheKey}");
                   Device.BeginInvokeOnMainThread(() => { label.Text = "OK"; });
               })
               .Preload();
        }

        async void Handle_ClickedNext(object sender, EventArgs e)
        {
            isPageAppearingInvoked = false;

            await NavigationHelper.GetInstance().NavigateTo(new FirstPage(_filePath, width, height));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (!isPageAppearingInvoked)
            {
                isPageAppearingInvoked = true;

                label.Text = "Please click Preload button first to simulate Preload feature, " +
                "then click Go To Next Page button to see the display of the cached image on the FirstPage";
            }
        }

    }
}
