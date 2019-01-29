
using System;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Binding;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using MvvmCross.Platforms.Ios.Views;
using NavExample.Core.ViewModels;

namespace NavExample.iOS.Views
{
    [MvxFromStoryboard("MainViewController")]
    [MvxRootPresentation(WrapInNavigationController = true)]
    public partial class MainViewController : MvxViewController<MainViewModel>
    {
        public MainViewController(IntPtr handle) 
            : base(handle)
        {
        }

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        #region View lifecycle

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Perform any additional setup after loading the view, typically from a nib.
            var set = this.CreateBindingSet<MainViewController, MainViewModel>();
            set.Bind(firstNavigateButton).To(vm => vm.FirstNavigateCommandHandler);
            set.Bind(firstNavigateButton).For(v => v.BindTitle()).To(vm => vm.FirstButtonText);
            set.Bind(secondNavigateButton).To(vm => vm.SecondNavigateCommandHandler);
            set.Bind(secondNavigateButton).For(v => v.BindTitle()).To(vm => vm.SecondButtonText);
            set.Bind(valuesPassedLabel).To(vm => vm.ValuesPassed);
            set.Bind(valueReturnedLabel).To(vm => vm.ValueReturned);
            set.Apply();
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            NavigationController.NavigationBar.Hidden = true;
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
        }

        #endregion
    }
}