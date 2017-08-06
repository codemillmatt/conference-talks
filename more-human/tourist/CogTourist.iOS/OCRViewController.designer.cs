// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace CogTourist
{
	[Register ("OCRViewController")]
	partial class OCRViewController
	{
		[Outlet]
		UIKit.UILabel descriptionLabel { get; set; }

		[Outlet]
		UIKit.UIButton takePhotoButton { get; set; }

		[Outlet]
		UIKit.UIImageView theImage { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (descriptionLabel != null) {
				descriptionLabel.Dispose ();
				descriptionLabel = null;
			}

			if (theImage != null) {
				theImage.Dispose ();
				theImage = null;
			}

			if (takePhotoButton != null) {
				takePhotoButton.Dispose ();
				takePhotoButton = null;
			}
		}
	}
}
