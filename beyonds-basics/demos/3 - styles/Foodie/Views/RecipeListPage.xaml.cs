using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Foodie
{
	public partial class RecipeListPage : ContentPage
	{
		public RecipeListPage()
		{
			InitializeComponent();
		}

		async void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
		{
			var recipe = e.SelectedItem as Recipe;

			if (recipe == null)
				return;

			var detailPage = new RecipeDetailPage(recipe);
			await Navigation.PushAsync(detailPage);

			recipeList.SelectedItem = null;
		}

		void ChangeStyles_Click(object sender, System.EventArgs e)
		{
			// Broadcast a message that the cell should update colors
			MessagingCenter.Send(this, "change");
		}
	}
}
