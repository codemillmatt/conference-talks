using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Foodie
{
	public partial class RecommendedRecipeCell : ViewCell
	{
		public RecommendedRecipeCell()
		{
			InitializeComponent();

			// Initially set the dynamic styles
			overallContent.Resources["BannerStyle"] = App.Current.Resources["RecommendedBannerStyle"];
			overallContent.Resources["CellContentStyle"] = App.Current.Resources["OverallCellContentStyle"];
			overallContent.Resources["NameStyle"] = App.Current.Resources["RecipeNameStyle"];
			overallContent.Resources["DetailsStyle"] = App.Current.Resources["CellPrepDetailsStyle"];

			MessagingCenter.Subscribe<RecipeListPage>(this, "change", (obj) => ChangeStyles());
		}

		bool isBold = false;
		void ChangeStyles()
		{
			if (isBold)
			{
				// Revert to normal
				overallContent.Resources["BannerStyle"] = App.Current.Resources["RecommendedBannerStyle"];
				overallContent.Resources["CellContentStyle"] = App.Current.Resources["OverallCellContentStyle"];
				overallContent.Resources["NameStyle"] = App.Current.Resources["RecipeNameStyle"];
				overallContent.Resources["DetailsStyle"] = App.Current.Resources["CellPrepDetailsStyle"];
			}
			else
			{
				// Show the bold colors
				overallContent.Resources["BannerStyle"] = overallContent.Resources["BoldRecommendedBannerStyle"];
				overallContent.Resources["CellContentStyle"] = overallContent.Resources["BoldOverallCellContentStyle"];
				overallContent.Resources["NameStyle"] = overallContent.Resources["BoldRecipeNameStyle"];
				overallContent.Resources["DetailsStyle"] = overallContent.Resources["BoldCellPrepDetailsStyle"];
			}

			isBold = !isBold;
		}
	}
}
