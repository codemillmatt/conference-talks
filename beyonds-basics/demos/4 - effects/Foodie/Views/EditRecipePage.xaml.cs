using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Linq;

namespace Foodie
{
	public partial class EditRecipePage : ContentPage
	{
		Recipe _recipe;
		Recipe _originalRecipe;

		bool isNew = false;

		public EditRecipePage()
		{
			InitializeComponent();

			_recipe = new Recipe();
			BindingContext = _recipe;

			isNew = true;
		}

		public EditRecipePage(Recipe recipe)
		{
			InitializeComponent();

			_recipe = recipe;
			_originalRecipe = recipe.Copy();

			mealPicker.SelectedIndex = mealPicker.Items.IndexOf(_recipe.MealType);
			difficultyPicker.SelectedIndex = difficultyPicker.Items.IndexOf(_recipe.Difficulty);

			BindingContext = _recipe;
		}

		async void HandleSave_Clicked(object sender, System.EventArgs e)
		{
			_recipe.Difficulty = difficultyPicker.Items[difficultyPicker.SelectedIndex];
			_recipe.MealType = mealPicker.Items[mealPicker.SelectedIndex];

			if (isNew)
			{
				var grouping = RecipeData.AllRecipesGrouped.First(arg => arg.Title == _recipe.Difficulty);
				grouping.Add(_recipe);
			}
			await Navigation.PopModalAsync();
		}

		async void HandleCancel_Clicked(object sender, System.EventArgs e)
		{
			if (!isNew)
			{
				_recipe.CookTime = _originalRecipe.CookTime;
				_recipe.Difficulty = _originalRecipe.Difficulty;
				_recipe.Directions = _originalRecipe.Directions;
				_recipe.Ingredients = _originalRecipe.Ingredients;
				_recipe.IsRecommended = _originalRecipe.IsRecommended;
				_recipe.MealType = _originalRecipe.MealType;
				_recipe.NumberOfServings = _originalRecipe.NumberOfServings;
				_recipe.PreparationTime = _originalRecipe.PreparationTime;
				_recipe.RecipeName = _originalRecipe.RecipeName;
				_recipe.WillMakeAgain = _originalRecipe.WillMakeAgain;
			}

			await Navigation.PopModalAsync();
		}
	}
}
