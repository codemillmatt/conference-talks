// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace describe
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		UIKit.UIButton theButton { get; set; }

		[Outlet]
		UIKit.UIImageView thePhoto { get; set; }

		[Outlet]
		UIKit.UITextView theText { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (thePhoto != null) {
				thePhoto.Dispose ();
				thePhoto = null;
			}

			if (theText != null) {
				theText.Dispose ();
				theText = null;
			}

			if (theButton != null) {
				theButton.Dispose ();
				theButton = null;
			}
		}
	}
}
