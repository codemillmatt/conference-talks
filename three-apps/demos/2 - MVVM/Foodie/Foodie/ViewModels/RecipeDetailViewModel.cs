using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
namespace Foodie
{
	public class RecipeDetailViewModel : INotifyPropertyChanged
	{

		Recipe _theRecipe;

		public event PropertyChangedEventHandler PropertyChanged;

		public RecipeDetailViewModel(Guid recipeId)
		{
			RecipeId = recipeId;
		}

		void LoadRecipeInformation()
		{
			var svc = new RecipeDataService();
			_theRecipe = svc.GetSingleRecipe(RecipeId);
		}

		public void RefreshRecipe()
		{
			LoadRecipeInformation();

			RecipeName = _theRecipe.RecipeName;
			CookTime = $"Cook time is {_theRecipe.CookTime}";
			MakeAgain = _theRecipe.MakeAgain;
		}

		public Guid RecipeId { get; set; }

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
