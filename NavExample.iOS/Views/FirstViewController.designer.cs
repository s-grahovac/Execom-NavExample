// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace NavExample.iOS.Views
{
    [Register ("FirstViewController")]
    partial class FirstViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView backgroundView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton closeButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel firstViewTitleLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (backgroundView != null) {
                backgroundView.Dispose ();
                backgroundView = null;
            }

            if (closeButton != null) {
                closeButton.Dispose ();
                closeButton = null;
            }

            if (firstViewTitleLabel != null) {
                firstViewTitleLabel.Dispose ();
                firstViewTitleLabel = null;
            }
        }
    }
}