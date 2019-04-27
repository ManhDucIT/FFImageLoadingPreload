using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Sample
{
    public class NavigationHelper
    {

        private static NavigationHelper _navigationHelper;

        private NavigationPage _navigationPage;

        private NavigationHelper()
        {
        }

        public static NavigationHelper GetInstance()
        {
            return _navigationHelper ?? (_navigationHelper = new NavigationHelper());
        }

        public void Initialize(NavigationPage navigationPage)
        {
            this._navigationPage = navigationPage;
        }

        public async Task NavigateTo(Page targetPage)
        {
            await _navigationPage?.PushAsync(targetPage);
        }

    }
}
