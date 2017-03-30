using Foodie.Abstractions;
using Foodie.DataService;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Microsoft.WindowsAzure.MobileServices.Sync;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(AzureDataService))]
namespace Foodie.DataService
{
	public class AzureDataService : IAzureService
	{
		const string url = "https://indy-code-practice.azurewebsites.net";
		MobileServiceClient azureClient;

		public AzureDataService()
		{
			azureClient = new MobileServiceClient(url);
		}

		async Task InitializeDataStore()
		{
			if (azureClient.SyncContext.IsInitialized)
				return;

			var store = new MobileServiceSQLiteStore("foodie.db");

			store.DefineTable<SecureRecipe>();

			await azureClient.SyncContext.InitializeAsync(store);

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
			var recipes = await GetTable<SecureRecipe>();
			await recipes.Pull();
		}

		public async Task<IAzureTable<T>> GetTable<T>() where T : TableData
		{
			await InitializeDataStore();

			return new AzureTable<T>(azureClient);
		}

		public async Task Login()
		{
			var login = DependencyService.Get<ILoginProvider>();

			await login.Login(azureClient);
		}
	}
}
