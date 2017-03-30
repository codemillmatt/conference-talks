using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Foodie
{
	public partial class RecipeDetailPage : ContentPage
	{
		Recipe _selectedRecipe;
		public RecipeDetailPage(Recipe selectedRecipe)
		{
			InitializeComponent();

			_selectedRecipe = selectedRecipe;

			BindingContext = selectedRecipe;
		}

		async void EditRecipe_Clicked(object sender, System.EventArgs e)
		{
			var editPage = new NavigationPage(new EditRecipePage(_selectedRecipe));

			await Navigation.PushModalAsync(editPage);
		}
	}
}
