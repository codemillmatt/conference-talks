using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Runtime.Remoting.Channels;

namespace Foodie
{
	public partial class RecipeDetailPage : ContentPage
	{
		Recipe _recipe;
		public RecipeDetailPage(Recipe forDisplay)
		{
			InitializeComponent();

			_recipe = forDisplay;

			recipeNameHeader.Text = _recipe.RecipeName;
			recipeName.Text = _recipe.RecipeName;
			cookTime.Text = $"The cook time is {_recipe.CookTime}";

			editRecipe.Clicked += async (sender, args) => await Navigation.PushAsync(new RecipeEditPage(_recipe));
		}

		public  RecipeDetailPage()
		{
			InitializeComponent();
		}
	}
}
