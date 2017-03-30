using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Foodie
{
	public partial class RecipesListPage : ContentPage
	{
		RecipeListViewModel ViewModel = new RecipeListViewModel();

		public RecipesListPage()
		{
			InitializeComponent();

			BindingContext = ViewModel;
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			ViewModel.RefreshRecipes();
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
