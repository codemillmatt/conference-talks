using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Foodie
{
	public class Recipe : INotifyPropertyChanged
	{
		string _recipeName;
		public string RecipeName
		{
			get { return _recipeName; }
			set
			{
				_recipeName = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(RecipeName)));
			}
		}

		string _preparationTime;
		public string PreparationTime
		{
			get { return _preparationTime; }
			set
			{
				_preparationTime = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PreparationTime)));
			}
		}

		internal Recipe Copy()
		{
			return new Recipe
			{
				CookTime = CookTime,
				Difficulty = Difficulty,
				Directions = Directions,
				Ingredients = Ingredients,
				IsRecommended = IsRecommended,
				MealType = MealType,
				NumberOfServings = NumberOfServings,
				PreparationTime = PreparationTime,
				RecipeName = RecipeName,
				WillMakeAgain = WillMakeAgain
			};
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
				_cookTime = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CookTime)));
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
				_numberOfServings = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NumberOfServings)));
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
				_willMakeAgain = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(WillMakeAgain)));
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
				_mealType = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(MealType)));
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
				_difficulty = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Difficulty)));
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
				_ingredient = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Ingredients)));
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
				_directions = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Directions)));
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
				_imageName = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ImageName)));
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
				_isRecommended = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsRecommended)));
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;
	}

	/** Using the two classes below to set the pickers off of
		Due to pickers being unable to bind to enums, these will
		serve as an enum for the MealType and Difficulty properties
		of the Recipe class **/
	public static class Difficulty
	{
		public static string Easy = "Easy";
		public static string Medium = "Medium";
		public static string Hard = "Hard";
	}

	public static class MealType
	{
		public static string Breakfast = "Breakfast";
		public static string Lunch = "Lunch";
		public static string Dinner = "Dinner";
		public static string Snack = "Snack";
	}
}
