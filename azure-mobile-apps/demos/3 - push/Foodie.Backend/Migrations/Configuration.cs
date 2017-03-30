namespace Foodie.Backend.Migrations
{
    using DataObjects;
    using Microsoft.Azure.Mobile.Server.Tables;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Foodie.Backend.Models.MobileServiceContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            SetSqlGenerator("System.Data.SqlClient", new EntityTableSqlGenerator());
        }

        protected override void Seed(Foodie.Backend.Models.MobileServiceContext context)
        {
            foreach (var item in GetRecipes())
            {
                context.Set<Recipe>().AddOrUpdate(item);
            }

            foreach (var item in GetSecureRecipes())
            {
                context.Set<SecureRecipe>().AddOrUpdate(item);
            }

            base.Seed(context);
        }

        List<Recipe> GetRecipes()
        {
            var eggs = new Recipe
            {
                Id = Guid.NewGuid().ToString(),
                RecipeName = "Eggs Benedict is great!!",
                CookTime = "24 min",
                PreparationTime = "5 min",
                NumberOfServings = 8,
                WillMakeAgain = true,
                MealType = "Breakfast",
                Difficulty = "Easy",
                Directions = "1. Fill a large saucepan with about 4 inches of water, add vinegar, and bring to a boil. Fill a shallow dish or pie plate with warm water. Reduce heat under saucepan to medium, so water is just barely simmering. Break 1 egg at a time into a small heat-proof bowl. Gently tip bowl into water; carefully slide egg into water. Repeat with remaining eggs.\n\n2. When eggs begin to become opaque, remove them from the saucepan with a slotted spoon in the order in which they were added. Transfer the eggs to the dish of warm water. This process should take about 3 minutes.\n\n3. Prepare the hollandaise sauce, and set aside, keeping it warm.\n\n4. Heat a medium skillet over medium heat. Add Canadian bacon, and cook until well browned on both sides. Divide bacon among the English-muffin halves. For each serving, use a slotted spoon to remove one egg from warm water; set spoon and egg briefly on a clean cloth or paper towel to drain. Gently place the egg on a bacon-topped muffin, and spoon the reserved warm hollandaise sauce over the top.",
                Ingredients = "1 tablespoon white vinegar" + Environment.NewLine +
                                                 "8 large eggs\nHollandaise Sauce" + Environment.NewLine +
                                                 "1/2 pound (16 slices) Canadian bacon" + Environment.NewLine +
                                                 "4 English muffins, split in half, toasted",
                ImageName = "eggs-benedict.jpg",
                IsRecommended = false
            };

            var muffin = new Recipe
            {
                Id = Guid.NewGuid().ToString(),
                RecipeName = "Blueberry Muffins",
                CookTime = "25 min",
                PreparationTime = "10 min",
                NumberOfServings = 12,
                WillMakeAgain = false,
                MealType = "Breakfast",
                Difficulty = "Easy",
                Directions = "Preheat oven to 350 degrees.\n\nCombine dry ingredients and strain into a large bowl. Create a reservoir in the center. Combine liquid ingredients. Pour wet ingredients in the reservoir and gently fold ingredients together. Gently fold in the blueberries.\n\nPut 1/4 to 1/3 cup batter in each muffin cup.\n\n*Optional* sprinkle oats and sunflower seeds on top of batter and place in oven.\n\nAllow muffins to bake for 20-25 minutes. Remove from oven when muffin top appears golden and a toothpick put into muffin comes out clean.",
                Ingredients = "1 cup whole wheat white flour\n1 tbsp baking powder\n1 tbsp cinnamon\n1 1/2 cup milk\n2 beaten eggs\n1 stick of butter, melted\n1 cup fresh blueberries\n1 tsp vanilla extract\n12 paper muffin cups liners\nwhole oats and sunflower seeds to sprinkle (optional)",
                ImageName = "blueberry-muffins.jpg",
                IsRecommended = true
            };

            List<Recipe> recipes = new List<Recipe>()
            {
                eggs,
                muffin
            };

            return recipes;
        }

        List<SecureRecipe> GetSecureRecipes()
        {
            var eggs = new SecureRecipe
            {
                Id = Guid.NewGuid().ToString(),
                RecipeName = "Eggs Benedict is great!!",
                CookTime = "24 min",
                PreparationTime = "5 min",
                NumberOfServings = 8,
                WillMakeAgain = true,
                MealType = "Breakfast",
                Difficulty = "Easy",
                Directions = "1. Fill a large saucepan with about 4 inches of water, add vinegar, and bring to a boil. Fill a shallow dish or pie plate with warm water. Reduce heat under saucepan to medium, so water is just barely simmering. Break 1 egg at a time into a small heat-proof bowl. Gently tip bowl into water; carefully slide egg into water. Repeat with remaining eggs.\n\n2. When eggs begin to become opaque, remove them from the saucepan with a slotted spoon in the order in which they were added. Transfer the eggs to the dish of warm water. This process should take about 3 minutes.\n\n3. Prepare the hollandaise sauce, and set aside, keeping it warm.\n\n4. Heat a medium skillet over medium heat. Add Canadian bacon, and cook until well browned on both sides. Divide bacon among the English-muffin halves. For each serving, use a slotted spoon to remove one egg from warm water; set spoon and egg briefly on a clean cloth or paper towel to drain. Gently place the egg on a bacon-topped muffin, and spoon the reserved warm hollandaise sauce over the top.",
                Ingredients = "1 tablespoon white vinegar" + Environment.NewLine +
                                      "8 large eggs\nHollandaise Sauce" + Environment.NewLine +
                                      "1/2 pound (16 slices) Canadian bacon" + Environment.NewLine +
                                      "4 English muffins, split in half, toasted",
                ImageName = "eggs-benedict.jpg",
                IsRecommended = false
            };

            var muffin = new SecureRecipe
            {
                Id = Guid.NewGuid().ToString(),
                RecipeName = "Blueberry Muffins",
                CookTime = "25 min",
                PreparationTime = "10 min",
                NumberOfServings = 12,
                WillMakeAgain = false,
                MealType = "Breakfast",
                Difficulty = "Easy",
                Directions = "Preheat oven to 350 degrees.\n\nCombine dry ingredients and strain into a large bowl. Create a reservoir in the center. Combine liquid ingredients. Pour wet ingredients in the reservoir and gently fold ingredients together. Gently fold in the blueberries.\n\nPut 1/4 to 1/3 cup batter in each muffin cup.\n\n*Optional* sprinkle oats and sunflower seeds on top of batter and place in oven.\n\nAllow muffins to bake for 20-25 minutes. Remove from oven when muffin top appears golden and a toothpick put into muffin comes out clean.",
                Ingredients = "1 cup whole wheat white flour\n1 tbsp baking powder\n1 tbsp cinnamon\n1 1/2 cup milk\n2 beaten eggs\n1 stick of butter, melted\n1 cup fresh blueberries\n1 tsp vanilla extract\n12 paper muffin cups liners\nwhole oats and sunflower seeds to sprinkle (optional)",
                ImageName = "blueberry-muffins.jpg",
                IsRecommended = true
            };

            List<SecureRecipe> recipes = new List<SecureRecipe>()
            {
                eggs,
                muffin
            };

            return recipes;
        }
    }
}
