using Foodie.Abstractions;
using Foodie.DataService;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Microsoft.WindowsAzure.MobileServices.Sync;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(AzureDataService))]
namespace Foodie.DataService
{
    public class AzureDataService : IAzureService
    {
        const string url = "https://indy-code-practice.azurewebsites.net";
        MobileServiceClient azureClient;
		IMobileServiceSyncTable<Recipe> recipeTable;

        public AzureDataService()
        {
            azureClient = new MobileServiceClient(url);
        }

        async Task InitializeDataStore()
        {
            if (azureClient.SyncContext.IsInitialized)
                return;

            var store = new MobileServiceSQLiteStore("foodie.db");

            store.DefineTable<Recipe>();

			await azureClient.SyncContext.InitializeAsync(store);

			recipeTable = azureClient.GetSyncTable<Recipe>();

            await SyncOfflineCache();
        }

        public async Task SyncOfflineCache()
        {
            await InitializeDataStore();

            // SHOULD REALLY CHECK CONNECTIVITY HERE!

            // First push all pending changes up
            try
            {
                await azureClient.SyncContext.PushAsync();
            }
            catch (MobileServicePushFailedException ex)
            {
                foreach (var error in ex.PushResult.Errors)
                {
                    // Always have the server win
                    await error.CancelAndDiscardItemAsync();
                }
            }

			// Next pull anything down
			await PullRecipe();
        }

		public async Task DeleteRecipe(Recipe item)
		{
			await recipeTable.DeleteAsync(item);
		}

		public async Task<ICollection<Recipe>> GetAllRecipes()
		{
			return await recipeTable.ToListAsync();
		}

		public async Task<ICollection<Recipe>> GetRecipes(int start, int end)
		{
			return await recipeTable.Skip(start).Take(end).ToListAsync();
		}

		public async Task<Recipe> GetSingleRecipe(string id)
		{
			return await recipeTable.LookupAsync(id);
		}

		public async Task<Recipe> InsertRecipe(Recipe item)
		{
			await recipeTable.InsertAsync(item);

			return item;
		}

		public async Task PullRecipe()
		{
			// having the query name enables an incremental pull
			string pullQueryName = "sync_Recipe";

			await recipeTable.PullAsync(pullQueryName,
										recipeTable.CreateQuery());
		}

		public async Task<Recipe> UpdateRecipe(Recipe item)
		{
			await recipeTable.UpdateAsync(item);

			return item;
		}
    }
}
