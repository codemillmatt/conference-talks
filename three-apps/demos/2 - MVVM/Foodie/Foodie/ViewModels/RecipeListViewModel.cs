using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
namespace Foodie
{
	public class RecipeListViewModel
	{
		RecipeDataService _dataSvc;
		public RecipeListViewModel()
		{
			_dataSvc = new RecipeDataService();

			AllRecipes = new ObservableCollection<Recipe>();
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
	}
}
