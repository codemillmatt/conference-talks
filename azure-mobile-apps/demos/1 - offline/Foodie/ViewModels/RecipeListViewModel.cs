using Foodie.Abstractions;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
namespace Foodie
{
	public class RecipeListViewModel : BaseViewModel
	{
		IAzureService _dataSvc;
		public RecipeListViewModel()
		{
			InitializeAllRecipesGrouped();

			_dataSvc = DependencyService.Get<IAzureService>(DependencyFetchTarget.GlobalInstance);

			// Listen to save message
			MessagingCenter.Subscribe<EditRecipeViewModel>(this, RecipeSavedMessage, async (obj) => await ReadRecipeData());
		}

		void InitializeAllRecipesGrouped()
		{
			if (_allRecipesGrouped == null)
			{
				var easyGrouping = new ListViewGrouping<Recipe>("Easy", "E");
				var mediumGrouping = new ListViewGrouping<Recipe>("Medium", "M");
				var hardGrouping = new ListViewGrouping<Recipe>("Hard", "H");

				// Add the groupings to the list view
				_allRecipesGrouped = new ObservableCollection<ListViewGrouping<Recipe>> {
						easyGrouping,
						mediumGrouping,
						hardGrouping
					};
			}
		}

		ObservableCollection<ListViewGrouping<Recipe>> _allRecipesGrouped;
		public ObservableCollection<ListViewGrouping<Recipe>> AllRecipes
		{
			get
			{
				return _allRecipesGrouped;
			}
		}

		public async Task ReadRecipeData()
		{
			await _dataSvc.SyncOfflineCache();
			var recipes = await _dataSvc.GetAllRecipes();

			// iOS doesn't like things to be added on anything but the main thread
			Device.BeginInvokeOnMainThread(() =>
			{
				var easyGrouping = AllRecipes.First((arg) => arg.Title == Difficulty.Easy);
				var medGrouping = AllRecipes.First((arg) => arg.Title == Difficulty.Medium);
				var hardGrouping = AllRecipes.First((arg) => arg.Title == Difficulty.Hard);

				// This goes through and does a wholesale clean of the groupings
				easyGrouping.Clear();
				medGrouping.Clear();
				hardGrouping.Clear();

				// Then adds everything back in
				foreach (var item in recipes)
				{
					if (item.Difficulty == Difficulty.Easy)
						easyGrouping.Add(item);
					else if (item.Difficulty == Difficulty.Medium)
						medGrouping.Add(item);
					else if (item.Difficulty == Difficulty.Hard)
						hardGrouping.Add(item);
				}
			});
		}

		ICommand _addCommand;
		public ICommand AddRecipeCommand
		{
			get
			{
				if (_addCommand == null)
				{
					_addCommand = new Command(async (obj) => await App.Current.MainPage.Navigation.PushModalAsync(
						new NavigationPage(new EditRecipePage())));

				}
				return _addCommand;
			}
		}
	}
}
