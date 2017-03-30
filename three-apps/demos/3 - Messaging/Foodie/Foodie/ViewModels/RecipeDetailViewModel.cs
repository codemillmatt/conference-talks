using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace Foodie
{
	public class RecipeDetailViewModel : RecipeBaseViewModel
	{
		Recipe _theRecipe;
		public Guid RecipeId { get; set; }

		public RecipeDetailViewModel(Guid recipeId)
		{
			RecipeId = recipeId;

			MessagingCenter.Subscribe<RecipeEditViewModel>(this, RecipeSavedMessage, (obj) => RefreshRecipe());
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
	}
}
