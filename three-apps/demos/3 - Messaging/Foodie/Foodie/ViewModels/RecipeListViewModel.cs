using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Windows.Input;
namespace Foodie
{
	public class RecipeListViewModel : BaseViewModel
	{
		RecipeDataService _dataSvc;
		INavigation _nav;
		public RecipeListViewModel(INavigation nav)
		{
			_nav = nav;
			_dataSvc = new RecipeDataService();

			AllRecipes = new ObservableCollection<Recipe>();

			MessagingCenter.Subscribe<RecipeEditViewModel>(this, RecipeSavedMessage, (obj) => RefreshRecipes());
		}

		public void RefreshRecipes()
		{
			AllRecipes.Clear();

			foreach (var item in _dataSvc.GetAllRecipes())
			{
				AllRecipes.Add(item);
			}
		}

		public ObservableCollection<Recipe> AllRecipes { get; set; }

		ICommand _addRecipeCommand;
		public ICommand AddRecipeCommand
		{
			get
			{
				if (_addRecipeCommand == null)
				{
					_addRecipeCommand = new Command(async () =>
					{
						await _nav.PushModalAsync(new NavigationPage(new RecipeEditPage()));
					});
				}
				return _addRecipeCommand;
			}
		}

	}
}
