using System;
using UIKit;
using Xamurai.iOS;
[assembly: Xamarin.Forms.Dependency(typeof(StatusBarImplementation))]
namespace Xamurai.iOS
{
    public class StatusBarImplementation : IStatusBar
    {

        public void HideStatusBar()
        {
            UIApplication.SharedApplication.StatusBarHidden = true;
        }

        public void ShowStatusBar()
        {
            UIApplication.SharedApplication.StatusBarHidden = false;
        }

    }
}

