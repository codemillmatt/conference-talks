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
	[Register ("EmotionViewController")]
	partial class EmotionViewController
	{
		[Outlet]
		UIKit.UIButton askForHelp { get; set; }

		[Outlet]
		UIKit.UIImageView personPhoto { get; set; }

		[Outlet]
		UIKit.UILabel primaryEmotion { get; set; }

		[Outlet]
		UIKit.UIButton takePhoto { get; set; }

		[Outlet]
		UIKit.UILabel theEmotion { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (askForHelp != null) {
				askForHelp.Dispose ();
				askForHelp = null;
			}

			if (personPhoto != null) {
				personPhoto.Dispose ();
				personPhoto = null;
			}

			if (primaryEmotion != null) {
				primaryEmotion.Dispose ();
				primaryEmotion = null;
			}

			if (takePhoto != null) {
				takePhoto.Dispose ();
				takePhoto = null;
			}

			if (theEmotion != null) {
				theEmotion.Dispose ();
				theEmotion = null;
			}
		}
	}
}
