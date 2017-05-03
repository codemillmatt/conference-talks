using System;
using UIKit;
using System.Reactive.Subjects;
using System.Reactive.Linq;

namespace RxImage
{
	public class CowImageView : UIImageView
	{
		public IObservable<ImageMotionData> MovementObservable {
			get { return _movementSubject.AsObservable (); }	
		}

		readonly Subject<ImageMotionData> _movementSubject;

		public CowImageView ()
		{
			Image = UIImage.FromBundle ("CowImage");

			_movementSubject = new Subject<ImageMotionData> ();
		}

		public override void TouchesMoved (Foundation.NSSet touches, UIEvent evt)
		{			
			base.TouchesMoved (touches, evt);

			UITouch touch = touches.AnyObject as UITouch;

			if (touch != null) {
				
				// Create a new "complicated" data object
				var data = new ImageMotionData () {
					ImageCoordinate = touch.LocationInView (this),
					ParentCoordinate = touch.LocationInView (this.Superview),
					PreviousImageCoordinate = touch.PreviousLocationInView(this),
					PreviousParentCoordinate = touch.PreviousLocationInView(this.Superview)
				};

				// Broadcast another data element is available
				_movementSubject.OnNext (data);

			} else {
				// Broadcast an exception has occurred
				_movementSubject.OnError (new Exception ("Could not find a touch event"));
			}
		}
	}
}

