using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Input;
using Xamarin.Forms;
namespace Foodie
{
	public class RecipeEditViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		Guid _recipeId;
		RecipeDataService _dataSvc;
		INavigation _nav;

		public RecipeEditViewModel(Guid recipeId, INavigation nav)
		{
			_recipeId = recipeId;
			_nav = nav;

			_dataSvc = new RecipeDataService();

			var recipe = _dataSvc.GetSingleRecipe(recipeId);
			RecipeName = recipe.RecipeName;
			CookTime = recipe.CookTime;
			MakeAgain = recipe.MakeAgain;
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
					   _dataSvc.UpdateRecipe(recipe);

					   await _nav.PopAsync(true);
				   });
				}
				return _saveRecipe;
			}
		}

		string _recipeName;
		public string RecipeName
		{
			get { return _recipeName; }
			set
			{
				_recipeName = value;
				OnPropertyChanged();
			}
		}

		string _cookTime;
		public string CookTime
		{
			get { return _cookTime; }
			set
			{
				_cookTime = value;
				OnPropertyChanged();
			}
		}

		bool _makeAgain;
		public bool MakeAgain
		{
			get { return _makeAgain; }
			set
			{
				_makeAgain = value;
				OnPropertyChanged();
			}
		}

		void OnPropertyChanged([CallerMemberName]string propertyName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
