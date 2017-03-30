using Foodie.Abstractions;
using System;

namespace Foodie
{
	public class SecureRecipe : TableData
	{
		public string RecipeName { get; set; }

		public string PreparationTime { get; set; }

		public string CookTime { get; set; }

		public int NumberOfServings { get; set; }

		public bool WillMakeAgain { get; set; }

		public string MealType { get; set; }

		public string Difficulty { get; set; }

		public string Ingredients { get; set; }

		public string Directions { get; set; }

		public string ImageName { get; set; }

		public bool IsRecommended { get; set; }
	}

	#region Dropdown Helpers

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

	#endregion


}
