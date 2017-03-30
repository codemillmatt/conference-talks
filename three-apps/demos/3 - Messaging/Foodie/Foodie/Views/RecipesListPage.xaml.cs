using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Foodie
{
	public partial class RecipesListPage : ContentPage
	{
		RecipeListViewModel ViewModel;

		public RecipesListPage()
		{
			InitializeComponent();

			ViewModel = new RecipeListViewModel(Navigation);

			ViewModel.RefreshRecipes();

			BindingContext = ViewModel;
		}

		async void Recipe_Selected(object sender, SelectedItemChangedEventArgs e)
		{
			if (e.SelectedItem == null)
				return;

			var recipe = e.SelectedItem as Recipe;

			if (recipe == null)
				return;

			await Navigation.PushAsync(new RecipeDetailPage(recipe.RecipeId));

			recipesList.SelectedItem = null;
		}
	}
}
