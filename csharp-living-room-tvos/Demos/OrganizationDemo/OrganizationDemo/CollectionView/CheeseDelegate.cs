using System;
using UIKit;
using CoreGraphics;

namespace OrganizationDemo
{
	public class CheeseDelegate : UICollectionViewDelegateFlowLayout
	{
		public static AppDelegate App
		{
			get
			{
				return (AppDelegate)UIApplication.SharedApplication.Delegate;
			}
		}

		public CheeseDelegate()
		{
		}

		public override CGSize GetSizeForItem(UICollectionView collectionView, UICollectionViewLayout layout, Foundation.NSIndexPath indexPath)
		{
			return new CGSize(525, 550);
		}

		public override void ItemSelected(UICollectionView collectionView, Foundation.NSIndexPath indexPath)
		{
			var cheeseCollectionView = collectionView as CheeseCollectionView;

			App.SelectedCheese = cheeseCollectionView.CheeseSource.Cheeses[indexPath.Row];
						
			cheeseCollectionView.ParentController.PerformSegue("pushCheeseDetail", this);
		}


	}
}

