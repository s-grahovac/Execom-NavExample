using Android.App;
using Android.OS;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using MvvmCross.Platforms.Android.Views;
using NavExample.Core.ViewModels;

namespace NavExample.Droid.Views
{
    [MvxActivityPresentation]
    [Activity(Label = "Main View Title")]
    public class MainView : MvxActivity<MainViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Activity_MainView);
        }

        public override void OnBackPressed()
        {
            return;
        }
    }
}