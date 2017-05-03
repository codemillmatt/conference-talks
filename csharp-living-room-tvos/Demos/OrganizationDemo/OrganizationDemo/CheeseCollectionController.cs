// This file has been autogenerated from a class added in the UI designer.

using System;

using Foundation;
using UIKit;

namespace OrganizationDemo
{
	public partial class CheeseCollectionController : UICollectionViewController
	{
		public CheeseCollectionView Collection
		{
			get
			{
				return CollectionView as CheeseCollectionView;
			}
		}

		public CheeseCollectionController (IntPtr handle) : base (handle)
		{
			
		}

		public override void AwakeFromNib()
		{
			base.AwakeFromNib();

			Collection.ParentController = this;

			View.BackgroundColor = UIColor.FromPatternImage(UIImage.FromBundle("WoodBackground"));

		}
	}
}
