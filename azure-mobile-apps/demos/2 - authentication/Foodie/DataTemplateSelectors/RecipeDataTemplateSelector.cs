using System;
using Xamarin.Forms;
namespace Foodie
{
	public class RecipeDataTemplateSelector : DataTemplateSelector
	{
		DataTemplate recipeTemplate;
		DataTemplate recommendedTemplate;

		public RecipeDataTemplateSelector()
		{
			recipeTemplate = new DataTemplate(typeof(RecipeCell));
			recommendedTemplate = new DataTemplate(typeof(RecommendedRecipeCell));
		}
		protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
		{
			var recipe = item as SecureRecipe;

			if (recipe == null)
				return null;

			return recipe.IsRecommended ? recommendedTemplate : recipeTemplate;
		}
	}
}
