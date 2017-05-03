using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace Cheesed.Local.iOS
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			UINavigationBar.Appearance.BarTintColor = UIColor.FromRGB (220, 55, 44);
			UINavigationBar.Appearance.TintColor = UIColor.FromRGB (255, 255, 255);
			UINavigationBar.Appearance.SetTitleTextAttributes (new UITextAttributes () {
				TextColor = UIColor.FromRGB (255, 255, 255)
			});
			// Remove the border between the header and the image
			UINavigationBar.Appearance.SetBackgroundImage (new UIImage(), UIBarMetrics.Default);
			UINavigationBar.Appearance.ShadowImage = new UIImage ();

			global::Xamarin.Forms.Forms.Init ();

			Microsoft.WindowsAzure.MobileServices.CurrentPlatform.Init ();

			SQLitePCL.CurrentPlatform.Init ();

			LoadApplication (new App ());

			return base.FinishedLaunching (app, options);
		}
	}
}

