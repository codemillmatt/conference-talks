using System;
namespace Foodie
{
	public class RecipeBaseViewModel : BaseViewModel
	{
		public RecipeBaseViewModel()
		{
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
	}
}
