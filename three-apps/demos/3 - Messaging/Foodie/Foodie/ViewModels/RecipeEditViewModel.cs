using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Input;
using Xamarin.Forms;
namespace Foodie
{
	public class RecipeEditViewModel : RecipeBaseViewModel
	{
		Guid _recipeId;
		RecipeDataService _dataSvc;
		INavigation _nav;
		bool _isNew = true;

		public RecipeEditViewModel(INavigation nav)
		{
			_nav = nav;
			_recipeId = Guid.NewGuid();

			_dataSvc = new RecipeDataService();
		}

		public RecipeEditViewModel(Guid recipeId, INavigation nav) : this(nav)
		{
			_recipeId = recipeId;

			var recipe = _dataSvc.GetSingleRecipe(_recipeId);
			RecipeName = recipe.RecipeName;
			CookTime = recipe.CookTime;
			MakeAgain = recipe.MakeAgain;

			_isNew = false;
		}

		ICommand _saveRecipe;
		public ICommand SaveRecipe
		{
			get
			{
				if (_saveRecipe == null)
				{
					_saveRecipe = new Command(async () =>
				   {
					   var recipe = new Recipe { RecipeId = _recipeId, CookTime = this.CookTime, MakeAgain = this.MakeAgain, RecipeName = this.RecipeName };

					   if (_isNew)
						   _dataSvc.InsertRecipe(recipe);
					   else
						   _dataSvc.UpdateRecipe(recipe);

					   MessagingCenter.Send(this, RecipeSavedMessage);

					   if (_isNew)
						   await _nav.PopModalAsync(true);
					   else
						   await _nav.PopAsync(true);
				   });
				}
				return _saveRecipe;
			}
		}
	}
}
