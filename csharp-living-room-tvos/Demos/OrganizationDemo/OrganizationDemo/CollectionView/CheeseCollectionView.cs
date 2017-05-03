// This file has been autogenerated from a class added in the UI designer.

using System;

using Foundation;
using UIKit;

namespace OrganizationDemo
{
	public partial class CheeseCollectionView : UICollectionView
	{		
		#region Properties 

		public static AppDelegate App
		{
			get
			{
				return (AppDelegate)UIApplication.SharedApplication.Delegate;
			}
		}

		public CheeseDataSource CheeseSource
		{
			get
			{
				return DataSource as CheeseDataSource;
			}
		}

		public CheeseCollectionController ParentController { get; set; }

		#endregion

		public CheeseCollectionView (IntPtr handle) : base (handle)
		{
			RegisterClassForCell(typeof(CheeseViewCell), CheeseDataSource.CellId);
			DataSource = new CheeseDataSource(this);
			Delegate = new CheeseDelegate();
		}

		public override nint NumberOfSections()
		{
			return 1;
		}

		#region Focus Updates

		public override void DidUpdateFocus(UIFocusUpdateContext context, UIFocusAnimationCoordinator coordinator)
		{
			var prev = context.PreviouslyFocusedView as CheeseViewCell;
			if (prev != null)
			{				
				Animate(0.2, () =>
				{
					prev.CheeseName.Alpha = 0.0f;
					prev.CheeseImage.Layer.BorderWidth = (nfloat)4.0;
				});
			}

			var next = context.NextFocusedView as CheeseViewCell;
			if (next != null)
			{
				Animate(0.2, () =>
				{
					next.CheeseName.Alpha = 1.0f;
					next.CheeseImage.Layer.BorderWidth = (nfloat)0.0;
				});
			}
		}

		#endregion
	}
}
