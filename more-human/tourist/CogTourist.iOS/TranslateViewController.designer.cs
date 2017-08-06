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
	[Register ("TranslateViewController")]
	partial class TranslateViewController
	{
		[Outlet]
		UIKit.UIButton askQuestion { get; set; }

		[Outlet]
		UIKit.UITextView englishText { get; set; }

		[Outlet]
		UIKit.UITextView translatedText { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (askQuestion != null) {
				askQuestion.Dispose ();
				askQuestion = null;
			}

			if (englishText != null) {
				englishText.Dispose ();
				englishText = null;
			}

			if (translatedText != null) {
				translatedText.Dispose ();
				translatedText = null;
			}
		}
	}
}
