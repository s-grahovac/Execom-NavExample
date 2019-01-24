using Android.App;
using MvvmCross.Platforms.Android.Core;
using MvvmCross.Platforms.Android.Views;

namespace NavExample.Droid
{
    [Activity(
        Label = "Execom Navigation Example",
        MainLauncher = true,
        NoHistory = true)]
    public class SplashScreen : MvxSplashScreenActivity<MvxAndroidSetup<Core.App>, Core.App>
    {
        public SplashScreen()
            : base(Resource.Layout.Activity_SplashScreen)
        {
        }
    }
}