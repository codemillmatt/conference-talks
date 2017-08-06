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
	[Register ("LandmarkViewController")]
	partial class LandmarkViewController
	{
		[Outlet]
		UIKit.UILabel descriptionLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIKit.UIButton photoButton { get; set; }

		[Outlet]
		UIKit.UIImageView selectedPhoto { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (photoButton != null) {
				photoButton.Dispose ();
				photoButton = null;
			}

			if (selectedPhoto != null) {
				selectedPhoto.Dispose ();
				selectedPhoto = null;
			}

			if (descriptionLabel != null) {
				descriptionLabel.Dispose ();
				descriptionLabel = null;
			}
		}
	}
}
