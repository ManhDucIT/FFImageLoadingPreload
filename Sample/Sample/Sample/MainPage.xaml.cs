using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Sample
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        void Handle_ClickedPreload(object sender, System.EventArgs e)
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
        }

        async void Handle_ClickedNext(object sender, System.EventArgs e)
        {
            await NavigationHelper.GetInstance().NavigateTo(new FirstPage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            label.Text = "Please click Preload button first to simulate Preload feature, " +
            	"then click Go To Next Page button to see the display of the cached image on the FirstPage";
        }

    }
}
