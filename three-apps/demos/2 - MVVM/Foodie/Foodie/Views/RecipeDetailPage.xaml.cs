using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Runtime.Remoting.Channels;

namespace Foodie
{
	public partial class RecipeDetailPage : ContentPage
	{
		RecipeDetailViewModel ViewModel;
		public RecipeDetailPage(Guid recipeId)
		{
			InitializeComponent();

			ViewModel = new RecipeDetailViewModel(recipeId);
			BindingContext = ViewModel;

			editRecipe.Clicked += async (sender, args) => await Navigation.PushAsync(new RecipeEditPage(ViewModel.RecipeId));
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			ViewModel.RefreshRecipe();
		}
	}
}
