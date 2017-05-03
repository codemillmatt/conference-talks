using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Collections.Generic;
using SQLite.Net.Async;
using SQLite.Net;
using Connectivity.Plugin;
using Microsoft.WindowsAzure.MobileServices;

//[assembly: Dependency (typeof(Cheesed.Local.AzureCheeseDataService))]
namespace Cheesed.Local
{
	public class AzureCheeseDataService : ICheeseDataService
	{
		#region Local Variables

		bool _isInitialized = false;
		MobileServiceClient _client;

		#endregion

		public AzureCheeseDataService ()
		{
		}

		#region ICheeseDataService implementation

		public async Task InitializeDataStore ()
		{
			if (!CrossConnectivity.Current.IsConnected)
				throw new NoInternetException();
			
			await Task.Run (() => {
				_isInitialized = true;

				_client = new MobileServiceClient ("YOUR_URL_HERE", 							
					"YOUR_KEY_HERE");
			});
		}

		public async Task<IEnumerable<Cheese>> SearchCheeseAsync (string cheeseName)
		{
			if (!CrossConnectivity.Current.IsConnected)
				throw new NoInternetException();
			
			if (!_isInitialized)
				await InitializeDataStore ();

			return await _client.GetTable<Cheese> ()
				.Where (c => c.CheeseName.StartsWith (cheeseName)).ToListAsync ();
		}

		public async Task<Rating> RateCheeseAsync (Rating ratedCheese)
		{
			if (!CrossConnectivity.Current.IsConnected)
				throw new NoInternetException();

			if (!_isInitialized)
				await InitializeDataStore ();

			await _client.GetTable<Rating> ().InsertAsync (ratedCheese);

			return ratedCheese;
		}

		public async Task<IEnumerable<CheeseAndRating>> GetRecentRatedCheesesAsync ()
		{			
			if (!CrossConnectivity.Current.IsConnected)
				throw new NoInternetException();

			if (!_isInitialized)
				await InitializeDataStore ();

			// Get cheeses rated within the last 10 days
			var tenDaysAgo = DateTime.Now.AddDays (-10);

			var ratings =  await _client.GetTable<Rating> ().Where (r => r.DateRated >= tenDaysAgo).ToListAsync ();

			var recents = new List<CheeseAndRating> ();

			foreach (var item in ratings) {
				var theCheeses = (await _client.GetTable<Cheese> ().Where (c => c.CheeseId == item.CheeseId).ToListAsync ()) [0];

				recents.Add (new CheeseAndRating () {
					CheeseId = theCheeses.CheeseId,
					CheeseName = theCheeses.CheeseName,
					DairyName = theCheeses.DairyName,
					DateRated = item.DateRated,
					Notes = item.Notes,
					RatingId = item.RatingId,
					WedgeRating = item.WedgeRating
				});
						
			}

			return recents;
		}

		public async Task<Cheese> AddCheeseAsync (Cheese newCheese)
		{
			if (!CrossConnectivity.Current.IsConnected)
				throw new NoInternetException();

			if (!_isInitialized)
				await InitializeDataStore ();

			await _client.GetTable<Cheese> ().InsertAsync (newCheese).ConfigureAwait (false);

			return newCheese;
		}

		public async Task<Cheese> GetCheeseDetailsAsync (string cheeseId)
		{
			if (!CrossConnectivity.Current.IsConnected)
				throw new NoInternetException();

			if (!_isInitialized)
				await InitializeDataStore ();

			var cheeses = await _client.GetTable<Cheese> ()
				.Where (c => c.CheeseId == cheeseId).Take (1).ToListAsync ().ConfigureAwait (false);

			return cheeses [0];
		}

		public async Task<IEnumerable<Cheese>> GetRecentCheesesAsync ()
		{
			if (!CrossConnectivity.Current.IsConnected)
				throw new NoInternetException();

			if (!_isInitialized)
				await InitializeDataStore ();

			return await _client.GetTable<Cheese> ().OrderByDescending (c => c.DateAdded).Take (10).ToListAsync ();
		}

		#endregion
	}
}

