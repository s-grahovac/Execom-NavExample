using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Binding;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using MvvmCross.Platforms.Ios.Views;
using NavExample.Core.ViewModels;
using System;

namespace NavExample.iOS.Views
{
    [MvxFromStoryboard("FirstViewController")]
    [MvxChildPresentation]
    public partial class FirstViewController : MvxViewController<FirstViewModel>
    {
        public FirstViewController(IntPtr handle) 
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

            // Disabling the back gesture to force the usage of the button invoked navigation action.
            NavigationController.InteractivePopGestureRecognizer.Enabled = false;

            // Perform any additional setup after loading the view, typically from a nib.
            var set = this.CreateBindingSet<FirstViewController, FirstViewModel>();

            set.Bind(closeButton).To(vm => vm.CloseCommand);
            set.Bind(closeButton).For(v => v.BindTitle()).To(vm => vm.CloseButtonText);

            set.Apply();
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            
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