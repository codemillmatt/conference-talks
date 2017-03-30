using System;
using System.Collections.Generic;
using System.Linq;

namespace Foodie
{
	public static class RecipeData
	{
		static List<Recipe> _allRecipes;
		public static List<Recipe> AllRecipes
		{
			get
			{
				if (_allRecipes == null)
				{
					_allRecipes = new List<Recipe>
					{
						new Recipe {
							RecipeName="Eggs Benedict",
							CookTime="24 min",
							PreparationTime="5 min",
							NumberOfServings=8,
							WillMakeAgain=true,
							MealType=MealType.Breakfast,
							Difficulty=Difficulty.Easy,
							Directions="1. Fill a large saucepan with about 4 inches of water, add vinegar, and bring to a boil. Fill a shallow dish or pie plate with warm water. Reduce heat under saucepan to medium, so water is just barely simmering. Break 1 egg at a time into a small heat-proof bowl. Gently tip bowl into water; carefully slide egg into water. Repeat with remaining eggs.\n\n2. When eggs begin to become opaque, remove them from the saucepan with a slotted spoon in the order in which they were added. Transfer the eggs to the dish of warm water. This process should take about 3 minutes.\n\n3. Prepare the hollandaise sauce, and set aside, keeping it warm.\n\n4. Heat a medium skillet over medium heat. Add Canadian bacon, and cook until well browned on both sides. Divide bacon among the English-muffin halves. For each serving, use a slotted spoon to remove one egg from warm water; set spoon and egg briefly on a clean cloth or paper towel to drain. Gently place the egg on a bacon-topped muffin, and spoon the reserved warm hollandaise sauce over the top.",
							Ingredients="1 tablespoon white vinegar" + Environment.NewLine +
								"8 large eggs\nHollandaise Sauce" + Environment.NewLine +
								"1/2 pound (16 slices) Canadian bacon" + Environment.NewLine +
								"4 English muffins, split in half, toasted",
							ImageName = "eggs-benedict.jpg",
							IsRecommended = false
						},
						new Recipe {
							RecipeName="Blueberry Muffins",
							CookTime="25 min",
							PreparationTime="10 min",
							NumberOfServings=12,
							WillMakeAgain=false,
							MealType=MealType.Breakfast,
							Difficulty=Difficulty.Medium,
							Directions="Preheat oven to 350 degrees.\n\nCombine dry ingredients and strain into a large bowl. Create a reservoir in the center. Combine liquid ingredients. Pour wet ingredients in the reservoir and gently fold ingredients together. Gently fold in the blueberries.\n\nPut 1/4 to 1/3 cup batter in each muffin cup.\n\n*Optional* sprinkle oats and sunflower seeds on top of batter and place in oven.\n\nAllow muffins to bake for 20-25 minutes. Remove from oven when muffin top appears golden and a toothpick put into muffin comes out clean.",
							Ingredients="1 cup whole wheat white flour\n1 tbsp baking powder\n1 tbsp cinnamon\n1 1/2 cup milk\n2 beaten eggs\n1 stick of butter, melted\n1 cup fresh blueberries\n1 tsp vanilla extract\n12 paper muffin cups liners\nwhole oats and sunflower seeds to sprinkle (optional)",
							ImageName = "blueberry-muffins.jpg",
							IsRecommended = true
						},
						new Recipe {
							RecipeName="Burger",
							CookTime="20 min",
							PreparationTime="5 min",
							NumberOfServings=4,
							WillMakeAgain=true,
							MealType=MealType.Lunch,
							Difficulty=Difficulty.Medium,
							Directions="Fire up the grill\n\nPut the burgers on and cook until desired temperature\n\nServe with bun and condiments.",
							Ingredients="Burgers, bun and condiments",
							ImageName = "burger.jpg"
						},
						new Recipe {
							RecipeName="Potato Salad",
							CookTime="40 mins",
							PreparationTime="20 min",
							NumberOfServings=12,
							WillMakeAgain=false,
							MealType=MealType.Dinner,
							Difficulty=Difficulty.Hard,
							Directions="Cook potatoes until boiling and cook 30-35 minutes or until tender.\n\nDrain and when cooled off enough, peel and slice\n\nFry bacon until crisp.\n\nCook and stir onion in bacon drippings until tender and golden brown,\n\nstir in flour, sugar, salt, celery seed and pepper.  Cook over low heat stirring\n\nuntil bubbly.  Remove from heat, stir in water and vinegar, heat to boiling, stirring\n\nconstantly, boil for about a minute.\n\nCrumble bacon over sliced potatoes and carefully pour the hot mixture over\n\nthe bacon and potatoes, stirring to cover the potato slices.",
							Ingredients="3 lbs of small red potatoes (salad potatoes)\n6 slices bacon\n3/4 cup chopped onion\n2 tbsp flour\n2 tbsp sugar\n2 tsp salt\n1/2 tsp celery seed\ndash pepper\n3/4 cup of water\n1/3 cup vinegar",
							ImageName = "potato-salad.jpg"
						},
						new Recipe {
							RecipeName="Spicy Ham",
							CookTime="50 mins",
							PreparationTime="15 mins",
							NumberOfServings=18,
							WillMakeAgain=true,
							MealType=MealType.Dinner,
							Difficulty=Difficulty.Hard,
							Directions="Preheat oven to 425°.\n\nTrim fat and rind from ham half. Score outside of ham in a diamond pattern. Place ham on a broiler pan coated with cooking spray. Combine jelly and remaining ingredients, stirring with a whisk until well blended. Brush about one-third of jelly mixture over ham.\n\nBake at 425° for 5 minutes. Reduce oven temperature to 325° (do not remove ham from oven); bake an additional 45 minutes, basting ham with jelly mixture every 15 minutes. Transfer ham to a serving platter; let stand 15 minutes before slicing.",
							Ingredients="1 (5 1/2- to 6-pound) 33%-less-sodium smoked, fully cooked ham half\nCooking spray\n1/2 cup red pepper jelly\n1/2 cup pineapple preserves\n1/4 cup packed brown sugar\n1/4 teaspoon ground cloves",
							ImageName = "ham.jpg"
						}
					};
				}
				return _allRecipes;
			}
		}

		static List<ListViewGrouping<Recipe>> _allRecipesGrouped;
		public static List<ListViewGrouping<Recipe>> AllRecipesGrouped
		{
			get
			{
				if (_allRecipesGrouped == null)
				{
					var easyGrouping = new ListViewGrouping<Recipe>("Easy", "E");
					easyGrouping.AddRange(RecipeData.AllRecipes.Where(r => r.Difficulty == Difficulty.Easy));

					var mediumGrouping = new ListViewGrouping<Recipe>("Medium", "M");
					mediumGrouping.AddRange(RecipeData.AllRecipes.Where(r => r.Difficulty == Difficulty.Medium));

					var hardGrouping = new ListViewGrouping<Recipe>("Hard", "H");
					hardGrouping.AddRange(RecipeData.AllRecipes.Where(r => r.Difficulty == Difficulty.Hard));

					_allRecipesGrouped = new List<ListViewGrouping<Recipe>> {
						easyGrouping,
						mediumGrouping,
						hardGrouping
					};
				}

				return _allRecipesGrouped;
			}
		}
	}
}
