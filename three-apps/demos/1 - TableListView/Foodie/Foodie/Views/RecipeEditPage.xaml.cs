using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Foodie
{
	public partial class RecipeEditPage : ContentPage
	{
		Recipe _recipe;
		public RecipeEditPage()
		{
			InitializeComponent();
		}

		public RecipeEditPage(Recipe forEdit) 
		{
			InitializeComponent();

			_recipe = forEdit;

			recipeName.Text = _recipe.RecipeName;
			cookTime.Text = _recipe.CookTime;

		}
	}
}
