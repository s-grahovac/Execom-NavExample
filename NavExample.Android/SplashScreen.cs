using Android.App;
using MvvmCross.Platforms.Android.Core;
using MvvmCross.Platforms.Android.Views;
using NavExample.Core;

namespace NavExample.Droid
{
    [Activity(
        Label = "Execom Navigation Example",
        MainLauncher = true,
        NoHistory = true)]
    public class SplashScreen : MvxSplashScreenActivity<MvxAndroidSetup<App>, App>
    {
        public SplashScreen()
            : base(Resource.Layout.Activity_SplashScreen)
        {
        }
    }
}