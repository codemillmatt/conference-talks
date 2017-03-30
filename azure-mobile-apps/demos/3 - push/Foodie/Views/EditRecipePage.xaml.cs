using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Linq;

using Newtonsoft.Json;

namespace Foodie
{
	public partial class EditRecipePage : ContentPage
	{
		EditRecipeViewModel _viewModel;

		public EditRecipePage()
		{
			InitializeComponent();

			_viewModel = new EditRecipeViewModel(Navigation);
			BindingContext = _viewModel;
		}

		public EditRecipePage(SecureRecipe recipe)
		{
			InitializeComponent();

			_viewModel = new EditRecipeViewModel(recipe, Navigation);

			mealPicker.SelectedIndex = mealPicker.Items.IndexOf(recipe.MealType);
			difficultyPicker.SelectedIndex = difficultyPicker.Items.IndexOf(recipe.Difficulty);

			BindingContext = _viewModel;
		}

		void Difficulty_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (_viewModel != null && difficultyPicker != null)
			{
				_viewModel.Difficulty = difficultyPicker.Items[difficultyPicker.SelectedIndex];
			}
		}

		void Meal_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (_viewModel != null && mealPicker != null)
			{
				_viewModel.MealType = mealPicker.Items[mealPicker.SelectedIndex];
			}
		}
	}
}
