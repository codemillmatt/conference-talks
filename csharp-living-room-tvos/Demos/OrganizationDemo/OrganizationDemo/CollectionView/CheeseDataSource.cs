using System;
using System.Collections.Generic;
using Foundation;
using UIKit;

namespace OrganizationDemo
{
	public class CheeseDataSource : UICollectionViewDataSource
	{
		public static NSString CellId = new NSString("CheeseCell");

		public static AppDelegate App
		{
			get { return (AppDelegate)UIApplication.SharedApplication.Delegate; }
		}

		public CheeseCollectionView ViewController { get; set; }
		public List<CheeseDetail> Cheeses { get; set; } = new List<CheeseDetail>();

		public CheeseDataSource(CheeseCollectionView vc)
		{
			ViewController = vc;

			var qtyAvailGenerator = new Random();

			Cheeses.Add(new CheeseDetail() { 
				CheeseName = "Little Boy Blue", 
				QuantityAvailable = qtyAvailGenerator.Next(1, 4), 
				Image="LittleBoyBlue" });
			
			Cheeses.Add(new CheeseDetail() { 
				CheeseName = "St Jenifer", 
				QuantityAvailable = qtyAvailGenerator.Next(1, 4),
				Image="Alpine" });
			
			Cheeses.Add(new CheeseDetail() { 
				CheeseName = "Crave Bros Mozz", 
				QuantityAvailable = qtyAvailGenerator.Next(1, 4),
				Image = "Mozzerella" });

			Cheeses.Add(new CheeseDetail()
			{
				CheeseName = "Sarvechio",
				QuantityAvailable = qtyAvailGenerator.Next(1, 4),
				Image = "Parmesan"
			});

			Cheeses.Add(new CheeseDetail() { 
				CheeseName = "Blue Paradise", 
				QuantityAvailable = qtyAvailGenerator.Next(1, 4),
				Image = "BlueCheese"
			});



		}

		public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
		{			
			var cell = collectionView.DequeueReusableCell(CellId, indexPath) as CheeseViewCell;

			var cheese = Cheeses[indexPath.Row];


			cell.TheCheese = cheese;

			return cell;
		}

		public override nint GetItemsCount(UICollectionView collectionView, nint section)
		{
			return Cheeses.Count;
		}

		public override nint NumberOfSections(UICollectionView collectionView)
		{
			return 1;
		}
	}
}

