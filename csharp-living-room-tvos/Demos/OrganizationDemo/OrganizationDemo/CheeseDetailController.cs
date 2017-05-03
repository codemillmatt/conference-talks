using Foundation;
using System;
using UIKit;

namespace OrganizationDemo
{
    public partial class CheeseDetailController : UIViewController
    {
		readonly string cheeseDescription = @"A far site from the orange and white slices in the dairy aisle, Saint Jenifer, Crème de la Coulée’s signature Munster-style cheese is inspired by the Munster traditionally made in the monasteries of Alsace-Lorraine, a region in France known for its rich cheeses and crisp white wines.";

		public static AppDelegate App
		{
			get { return (AppDelegate)UIApplication.SharedApplication.Delegate; }
		} 

        public CheeseDetailController (IntPtr handle) : base (handle)
        {
			
        }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			cheeseName.Text = App.SelectedCheese.CheeseName;
			descriptionLabel.Text = cheeseDescription;

			View.BackgroundColor = UIColor.FromPatternImage(UIImage.FromBundle("PastureBackground"));
		}

		public override UIView PreferredFocusedView
		{
			get
			{
				return wedgeOfApproval;
			}
		}

		public override void DidUpdateFocus(UIFocusUpdateContext context, UIFocusAnimationCoordinator coordinator)
		{
			pairingsLabel.TextColor = UIColor.Black;
			dairlyLabel.TextColor = UIColor.Black;
			makingOfLabel.TextColor = UIColor.Black;

			if (context.NextFocusedView == pairingButton)
			{
				pairingsLabel.TextColor = UIColor.White;
			}
			else if (context.NextFocusedView == dairyButton)
			{
				dairlyLabel.TextColor = UIColor.White;
			}
			else if (context.NextFocusedView == makingButton)
			{
				makingOfLabel.TextColor = UIColor.White;
			}

			base.DidUpdateFocus(context, coordinator);
		}
	}
}