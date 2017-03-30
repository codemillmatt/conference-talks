using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Threading.Tasks;

namespace Foodie
{
	public partial class RecipeListPage : ContentPage
	{
		RecipeListViewModel vm;
		public RecipeListPage()
		{
			InitializeComponent();
			vm = new RecipeListViewModel();

			BindingContext = vm;

			Task.Run(async () => await vm.ReadRecipeData());
		}
		async void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
		{
			var recipe = e.SelectedItem as SecureRecipe;

			if (recipe == null)
				return;

			var detailPage = new RecipeDetailPage(recipe);
			await Navigation.PushAsync(detailPage);

			recipeList.SelectedItem = null;
		}
	}
}
