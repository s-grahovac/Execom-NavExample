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
    [Register ("MainViewController")]
    partial class MainViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton firstNavigateButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton secondNavigateButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel valueReturnedLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel valuesPassedLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (firstNavigateButton != null) {
                firstNavigateButton.Dispose ();
                firstNavigateButton = null;
            }

            if (secondNavigateButton != null) {
                secondNavigateButton.Dispose ();
                secondNavigateButton = null;
            }

            if (valueReturnedLabel != null) {
                valueReturnedLabel.Dispose ();
                valueReturnedLabel = null;
            }

            if (valuesPassedLabel != null) {
                valuesPassedLabel.Dispose ();
                valuesPassedLabel = null;
            }
        }
    }
}