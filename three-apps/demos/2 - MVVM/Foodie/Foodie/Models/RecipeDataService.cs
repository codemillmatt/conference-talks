using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Runtime.Remoting.Messaging;

namespace Foodie
{
	public class RecipeDataService
	{
		public RecipeDataService()
		{
			SeedRecipes();
		}

		public List<Recipe> GetAllRecipes()
		{
			var recipeList = new List<Recipe>();

			foreach (var item in App.Current.Properties)
			{
				var recipe = JsonConvert.DeserializeObject<Recipe>(item.Value.ToString());
				recipeList.Add(recipe);
			}

			return recipeList;
		}

		public void InsertRecipe(Recipe recipe) =>
			App.Current.Properties.Add(recipe.RecipeId.ToString(), JsonConvert.SerializeObject(recipe));

		public void UpdateRecipe(Recipe recipe) =>
			App.Current.Properties[recipe.RecipeId.ToString()] = JsonConvert.SerializeObject(recipe);

		public Recipe GetSingleRecipe(Guid recipeId)
		{
			return JsonConvert.DeserializeObject<Recipe>(App.Current.Properties[recipeId.ToString()].ToString());
		}

		void SeedRecipes()
		{
			// Assuming only recipes stored in properties - very, very fragile!
			if (App.Current.Properties.Count == 0)
			{
				// Only used to seed recipes into the private store if needed
				var eggRecipe = new Recipe { RecipeName = "Eggs", CookTime = "10 min", MakeAgain = true, RecipeId = Guid.NewGuid() };
				var burgerRecipe = new Recipe { RecipeName = "Burger", CookTime = "30 min", MakeAgain = true, RecipeId = Guid.NewGuid() };
				var friesRecipe = new Recipe { RecipeName = "Fries", CookTime = "10 min", MakeAgain = true, RecipeId = Guid.NewGuid() };
				var cakeRecipe = new Recipe { RecipeName = "Cake", CookTime = "60 min", MakeAgain = true, RecipeId = Guid.NewGuid() };

				App.Current.Properties.Add(eggRecipe.RecipeId.ToString(), JsonConvert.SerializeObject(eggRecipe));
				App.Current.Properties.Add(burgerRecipe.RecipeId.ToString(), JsonConvert.SerializeObject(burgerRecipe));
				App.Current.Properties.Add(friesRecipe.RecipeId.ToString(), JsonConvert.SerializeObject(friesRecipe));
				App.Current.Properties.Add(cakeRecipe.RecipeId.ToString(), JsonConvert.SerializeObject(cakeRecipe));
			}
		}
	}
}
