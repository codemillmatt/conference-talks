using System;
using Foundation;
using UIKit;

namespace HelloEvolve
{
	public partial class ViewController : UIViewController
	{
		public ViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			// Adding a primary action directly from code
			evolveButton.PrimaryActionTriggered += (sender, e) =>
			{
				helloLabel.Text = "Hello from the other button!";
			};

			// Adding a top gesture recognizer
			var upTap = new UITapGestureRecognizer(() => helloLabel.Text = "Up tapped!");
			upTap.AllowedPressTypes = new NSNumber[] {
				(long)UIPressType.UpArrow
			};
			View.AddGestureRecognizer(upTap);
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

		partial void helloAction(UIButton sender)
		{
			helloLabel.Text = "Hello Evolve!";
		}
	}
}


