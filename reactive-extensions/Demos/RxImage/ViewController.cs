using System;

using UIKit;
using CoreGraphics;
using System.Reactive.Linq;

namespace RxImage
{
	public partial class ViewController : UIViewController
	{
		public ViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.

			var backImage = UIImage.FromBundle ("Background");
			this.View.BackgroundColor = UIColor.FromPatternImage (backImage);

			// Put the image onto the screen
			var cow = new CowImageView();
			cow.Frame = CGRect.FromLTRB (50, 50, 50 + cow.Image.Size.Width, 50 + cow.Image.Size.Height);
			cow.UserInteractionEnabled = true;

			this.View.AddSubview (cow);

			// Grab the observable (what we want "pushed" to us)
			var moveObservable = cow.MovementObservable;

			// Apply any operations
			var moveStream = moveObservable
				.Select (imd => new {X = imd.ParentCoordinate.X, Y = imd.ParentCoordinate.Y})
				.Where (l => l.X < this.View.Frame.Width / 2)
				.Where (l => l.Y < this.View.Frame.Height / 2);

			// Subscribe to the stream - nothing happens until we subscribe
			moveStream.Subscribe (l => 
				cow.Frame = CGRect.FromLTRB (
				l.X, l.Y,
				l.X + cow.Image.Size.Width,
				l.Y + cow.Image.Size.Height
			));
					
		}

	}
}

