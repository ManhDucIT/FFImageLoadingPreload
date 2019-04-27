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

namespace Sample
{
    public partial class MainPage : ContentPage
    {

        private string _filePath;
        private bool isPageAppearingInvoked;

        public MainPage()
        {
            InitializeComponent();
        }

        async void Handle_ClickedPreload(object sender, System.EventArgs e)
        {
            // TODO: Please help me demonstrate how to implement Preload feature here
            //
            //       NOTE: 1. Please use large enough image to display fullscreen.
            //             (I have already attached an image into drawable folder, not large, but enough to show the problem ^^)
            //
            //             2. Please use eg: FileImageSource (Not URL downloading).
            //
            //             3. Please try to use a very large image with lower performance device.
            //
            //             On my test device, I used 6MB - 10MB image, and the white screen had been displyed for about 7 seconds
            //             before the image was displayed on the first time of loading (Go To Next Page).
            //
            //             If going back, then Go To Next Page again, the image will be displayed instantly.

            var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Storage);

            if (status != PermissionStatus.Granted)
            {
                if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Storage))
                {
                    await DisplayAlert("Need storage", "This sample need that storage", "OK");
                }

                var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Storage);

                if (results.ContainsKey(Permission.Storage))
                {
                    status = results[Permission.Storage];
                }
            }

            if (status == PermissionStatus.Granted)
            {
                var sdcardPath = DependencyService.Get<IFileManager>().GetPublicStorageDir();

                _filePath = Path.Combine(sdcardPath, "ball.jpg");

                if (DependencyService.Get<IFileManager>().FileExists(_filePath))
                {
                    ImageService.Instance.LoadFile(_filePath).DownSample((int)Application.Current.MainPage.Width, (int)Application.Current.MainPage.Height).Preload();

                    label.Text = "OK";
                }
                else
                {
                    label.Text = "File not found";
                }
            }
        }

        async void Handle_ClickedNext(object sender, System.EventArgs e)
        {
            isPageAppearingInvoked = false;

            await NavigationHelper.GetInstance().NavigateTo(new FirstPage(_filePath));
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
