using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Abstractions
{
    public interface IAzureService
    {
		Task<Recipe> UpdateRecipe(Recipe item);
		Task PullRecipe();
		Task<Recipe> InsertRecipe(Recipe item);
		Task<Recipe> GetSingleRecipe(string id);
		Task<ICollection<Recipe>> GetRecipes(int start, int end);
		Task<ICollection<Recipe>> GetAllRecipes();
		Task DeleteRecipe(Recipe item);
		Task SyncOfflineCache();
    }
}
