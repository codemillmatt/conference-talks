using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Foodie
{
	public partial class RecipeDetailPage : ContentPage
	{
		public RecipeDetailPage(Recipe selectedRecipe)
		{
			InitializeComponent();

			var viewModel = new RecipeDetailViewModel(selectedRecipe, Navigation);

			BindingContext = viewModel;
		}
	}
}
