using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace Foodie.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			UINavigationBar.Appearance.BarTintColor = UIColor.FromRGB(57, 141, 60);
			UINavigationBar.Appearance.TintColor = UIColor.White;
			UINavigationBar.Appearance.SetTitleTextAttributes(
				new UITextAttributes() { TextColor = UIColor.White });

			UISwitch.Appearance.OnTintColor = UIColor.FromRGB(57, 141, 60);			
			
			global::Xamarin.Forms.Forms.Init();

			LoadApplication(new App());

			return base.FinishedLaunching(app, options);
		}
	}
}
