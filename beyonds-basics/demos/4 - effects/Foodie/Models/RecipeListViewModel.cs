using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
namespace Foodie
{
	public class RecipeListViewModel
	{
		public ObservableCollection<ListViewGrouping<Recipe>> AllRecipes
		{
			get { return RecipeData.AllRecipesGrouped; }
		}

		public ICommand AddRecipeCommand { get; } =
			new Command(async (obj) => await App.Current.MainPage.Navigation.PushModalAsync(new NavigationPage(new EditRecipePage())));
	}
}
