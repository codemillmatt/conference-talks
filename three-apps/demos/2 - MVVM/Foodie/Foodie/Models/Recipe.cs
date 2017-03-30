using System;
namespace Foodie
{
	public class Recipe
	{
		public string RecipeName { get; set; }

		public string CookTime { get; set; }

		public bool MakeAgain { get; set; }

		public Guid RecipeId { get; set; }
	}
}
