using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Foodie
{
	public partial class RecipesListPage : ContentPage
	{
		public List<Recipe> AllRecipes { get; set; }

		public RecipesListPage()
		{
			InitializeComponent();

			AllRecipes = new List<Recipe>() {
				new Recipe { RecipeName = "Eggs", CookTime = "10 min" , MakeAgain = true },
				new Recipe { RecipeName = "Burger", CookTime = "30 min", MakeAgain = true },
				new Recipe { RecipeName = "Fries", CookTime = "10 min", MakeAgain = true },
				new Recipe { RecipeName = "Cake", CookTime = "60 min", MakeAgain = true }
			};

			recipesList.ItemsSource = AllRecipes;
		}

		async void Recipe_Selected(object sender, SelectedItemChangedEventArgs e)
		{
			if (e.SelectedItem == null)
				return;

			var recipe = e.SelectedItem as Recipe;

			if (recipe == null)
				return;

			await Navigation.PushAsync(new RecipeDetailPage(recipe));

			recipesList.SelectedItem = null;
		}
	}
}
