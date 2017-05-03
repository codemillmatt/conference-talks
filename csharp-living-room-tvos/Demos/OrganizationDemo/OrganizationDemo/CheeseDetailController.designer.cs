// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace OrganizationDemo
{
    [Register ("CheeseDetailController")]
    partial class CheeseDetailController
    {
        [Outlet]
        UIKit.UILabel cheeseName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel dairlyLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton dairyButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel descriptionLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton makingButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel makingOfLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton pairingButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel pairingsLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        OrganizationDemo.FocusImage wedgeOfApproval { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (cheeseName != null) {
                cheeseName.Dispose ();
                cheeseName = null;
            }

            if (dairlyLabel != null) {
                dairlyLabel.Dispose ();
                dairlyLabel = null;
            }

            if (dairyButton != null) {
                dairyButton.Dispose ();
                dairyButton = null;
            }

            if (descriptionLabel != null) {
                descriptionLabel.Dispose ();
                descriptionLabel = null;
            }

            if (makingButton != null) {
                makingButton.Dispose ();
                makingButton = null;
            }

            if (makingOfLabel != null) {
                makingOfLabel.Dispose ();
                makingOfLabel = null;
            }

            if (pairingButton != null) {
                pairingButton.Dispose ();
                pairingButton = null;
            }

            if (pairingsLabel != null) {
                pairingsLabel.Dispose ();
                pairingsLabel = null;
            }

            if (wedgeOfApproval != null) {
                wedgeOfApproval.Dispose ();
                wedgeOfApproval = null;
            }
        }
    }
}