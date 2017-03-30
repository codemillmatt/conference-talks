using System;
namespace Foodie
{
	public class BaseRecipeViewModel : BaseViewModel
	{
		public BaseRecipeViewModel()
		{
		}

		string _recipeName;
		public string RecipeName
		{
			get
			{
				return _recipeName;
			}
			set
			{
                SetProperty(ref _recipeName, value, nameof(RecipeName));
			}
		}

		string _preparationTime;
		public string PreparationTime
		{
			get { return _preparationTime; }
			set
			{
                SetProperty(ref _preparationTime, value, nameof(PreparationTime));
			}
		}

		string _cookTime;
		public string CookTime
		{
			get
			{
				return _cookTime;
			}
			set
			{
                SetProperty(ref _cookTime, value, nameof(CookTime));
			}
		}

		int _numberOfServings;
		public int NumberOfServings
		{
			get
			{
				return _numberOfServings;
			}
			set
			{
                SetProperty(ref _numberOfServings, value, nameof(NumberOfServings));
			}
		}

		bool _willMakeAgain;
		public bool WillMakeAgain
		{
			get
			{
				return _willMakeAgain;
			}
			set
			{
                SetProperty(ref _willMakeAgain, value, nameof(WillMakeAgain));
			}
		}

		string _mealType;
		public string MealType
		{
			get
			{
				return _mealType;
			}
			set
			{
                SetProperty(ref _mealType, value, nameof(MealType));
			}
		}

		string _difficulty;
		public string Difficulty
		{
			get
			{
				return _difficulty;
			}
			set
			{
                SetProperty(ref _difficulty, value, nameof(Difficulty));
			}
		}

		string _ingredient;
		public string Ingredients
		{
			get
			{
				return _ingredient;
			}
			set
			{
                SetProperty(ref _ingredient, value, nameof(Ingredients));
			}
		}

		string _directions;
		public string Directions
		{
			get
			{
				return _directions;
			}
			set
			{
                SetProperty(ref _directions, value, nameof(Directions)); 
			}
		}

		string _imageName;
		public string ImageName
		{
			get
			{
				return _imageName;
			}
			set
			{
                SetProperty(ref _imageName, value, nameof(ImageName));
			}
		}

		bool _isRecommended;
		public bool IsRecommended
		{
			get
			{
				return _isRecommended;
			}
			set
			{
                SetProperty(ref _isRecommended, value, nameof(IsRecommended));
			}
		}
	}
}
