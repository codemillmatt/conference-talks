using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Collections.Generic;
using SQLite.Net.Async;
using SQLite.Net;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Connectivity.Plugin;

//[assembly: Dependency (typeof(Cheesed.Local.OfflineCheeseDataService))]
namespace Cheesed.Local
{
	public class OfflineCheeseDataService : ICheeseDataService
	{
		#region Local Variables

		bool _isInitialized = false;
		MobileServiceClient _client;


		#endregion

		public OfflineCheeseDataService ()
		{
		}

		#region ICheeseDataService implementation

		public async Task InitializeDataStore ()
		{
			// Create the mobile client
			_isInitialized = true;

			_client = new MobileServiceClient ("YOUR_URL_HERE", 
				"YOUR_KEY_HERE");

			// Define the SQLite Store
			var store = new MobileServiceSQLiteStore ("cheese.db3");

			// Create the tables in the local database
			store.DefineTable<Cheese> ();
			store.DefineTable<Rating> ();

			// Register the local SQLite database with Azure's synchronization context
			await _client.SyncContext.InitializeAsync (store);
		}

		public async Task<IEnumerable<Cheese>> SearchCheeseAsync (string cheeseName)
		{
			if (!_isInitialized)
				await InitializeDataStore ();

			var cheeseSync = _client.GetSyncTable<Cheese> ();

			if (CrossConnectivity.Current.IsConnected) {
				// Pull data from Azure matching the query - by giving it a query name that matches
				// the cheese name - it allows Azure to cache
				await cheeseSync.PullAsync (cheeseName, 
					cheeseSync.Where (c => c.CheeseName.StartsWith (cheeseName)));
			}
				
			return await cheeseSync
					.Where (c => c.CheeseName.StartsWith (cheeseName)).ToListAsync ();	
		}

		public async Task<Rating> RateCheeseAsync (Rating ratedCheese)
		{
			if (!_isInitialized)
				await InitializeDataStore ();

			var rateSync = _client.GetSyncTable<Rating> ();

			await rateSync.InsertAsync (ratedCheese);

			// Push to Azure if connected
			if (CrossConnectivity.Current.IsConnected) {
				await _client.SyncContext.PushAsync ();
			}

			return ratedCheese;
		}

		public async Task<IEnumerable<CheeseAndRating>> GetRecentRatedCheesesAsync ()
		{			
			if (!_isInitialized)
				await InitializeDataStore ();

			var tenDaysAgo = DateTime.Now.AddDays (-10);

			var rateSync = _client.GetSyncTable<Rating> ();
			var cheeseSync = _client.GetSyncTable<Cheese> ();

			var recents = new List<CheeseAndRating> ();

			if (CrossConnectivity.Current.IsConnected) {
				await rateSync.PullAsync ("tendaysago",
					rateSync.Where (r => r.DateRated >= tenDaysAgo)).ConfigureAwait (false);

				await cheeseSync.PullAsync ("all", cheeseSync.CreateQuery ()).ConfigureAwait (false);	
			}

			var ratings = await rateSync.Where (r => r.DateRated >= tenDaysAgo).ToListAsync ().ConfigureAwait (false);

			foreach (var item in ratings) {
				var theCheese = (await cheeseSync.Where (c => c.CheeseId == item.CheeseId).ToListAsync ()) [0];

				recents.Add(new CheeseAndRating() {
					CheeseId = theCheese.CheeseId,
					CheeseName = theCheese.CheeseName,
					DairyName = theCheese.DairyName,
					DateRated = item.DateRated,
					Notes = item.Notes,
					RatingId = item.RatingId,
					WedgeRating = item.WedgeRating
				});
			}

			return recents;
//
//			return await rateSync.Where (r => r.DateRated >= tenDaysAgo).ToListAsync ();
		}

		public async Task<Cheese> AddCheeseAsync (Cheese newCheese)
		{
			if (!_isInitialized)
				await InitializeDataStore ();

			var cheeseSync = _client.GetSyncTable<Cheese> ();

			await cheeseSync.InsertAsync (newCheese);

			if (CrossConnectivity.Current.IsConnected) {
				await _client.SyncContext.PushAsync ();
			}

			return newCheese;
		}

		public async Task<Cheese> GetCheeseDetailsAsync (string cheeseId)
		{
			if (!_isInitialized)
				await InitializeDataStore ();

			var cheeseSync = _client.GetSyncTable<Cheese> ();

			if (CrossConnectivity.Current.IsConnected) {
				// This will cause a push first of any local modified data
				await cheeseSync.PullAsync (cheeseId,
					cheeseSync.Where (c => c.CheeseId == cheeseId));

			}

			var matchingCheeses = await cheeseSync
				.Where (c => c.CheeseId == cheeseId).ToListAsync ().ConfigureAwait (false);

			if (matchingCheeses.Count > 0) {
				return matchingCheeses [0];
			} else {
				return null;
			}
				
		}

		public async Task<IEnumerable<Cheese>> GetRecentCheesesAsync ()
		{
			if (!_isInitialized)
				await InitializeDataStore ();

			var cheeseSync = _client.GetSyncTable<Cheese> ();

			if (CrossConnectivity.Current.IsConnected) {
				await cheeseSync.PullAsync ("recent",
					cheeseSync.CreateQuery());
			}

			return await cheeseSync.OrderByDescending (c => c.DateAdded).Take (10).ToListAsync ();
		}

		#endregion
	}
}

