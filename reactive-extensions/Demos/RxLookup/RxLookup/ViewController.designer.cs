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

namespace RxLookup
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField searchField { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (searchField != null) {
				searchField.Dispose ();
				searchField = null;
			}
		}
	}
}
