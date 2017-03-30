using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Foodie
{
	public partial class RecipeEditPage : ContentPage
	{
		RecipeEditViewModel ViewModel;

		public RecipeEditPage(Guid recipeId) 
		{
			InitializeComponent();

			ViewModel = new RecipeEditViewModel(recipeId, Navigation);
			BindingContext = ViewModel;
		}

		public RecipeEditPage()
		{
			InitializeComponent();
			ViewModel = new RecipeEditViewModel(Navigation);
			BindingContext = ViewModel;
		}
	}
}
