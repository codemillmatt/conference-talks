using System;

using System.Threading.Tasks;
using Xamarin.Forms;
using System.Collections.Generic;
using SQLite.Net.Async;
using SQLite.Net;

using System.Linq;

[assembly: Dependency (typeof(Cheesed.Local.LocalCheeseDataService))]
namespace Cheesed.Local
{
	public class LocalCheeseDataService : ICheeseDataService
	{
		#region Local Variables

		bool _isInitialized = false;
		SQLiteAsyncConnection _sqliteConn;

		#endregion

		public LocalCheeseDataService ()
		{
		}

		#region ICheeseDataService implementation

		public async Task InitializeDataStore ()
		{
			_isInitialized = true;

			// Get the platform-specific database info
			IPlatform dataPlatform = DependencyService.Get<IPlatform> ();

			// Create the connection
			_sqliteConn = new SQLiteAsyncConnection (() => new SQLiteConnectionWithLock (dataPlatform.OSPlatform,
				new SQLiteConnectionString (dataPlatform.DatabasePath, true)));

			// Create the tables
			await _sqliteConn.CreateTableAsync<Cheese> ().ConfigureAwait (false);
			await _sqliteConn.CreateTableAsync<Rating> ().ConfigureAwait (false);
		}

		public async Task<IEnumerable<Cheese>> SearchCheeseAsync (string cheeseName)
		{
			if (!_isInitialized)
				await InitializeDataStore();

			return await _sqliteConn.Table<Cheese> ()
				.Where (c => c.CheeseName.StartsWith (cheeseName))
				.OrderBy (c => c.CheeseName).ToListAsync ();
		}

		public async Task<Rating> RateCheeseAsync (Rating ratedCheese)
		{
			if (!_isInitialized)
				await InitializeDataStore();

			ratedCheese.RatingId = Guid.NewGuid ().ToString ();

			await _sqliteConn.InsertAsync (ratedCheese);

			return ratedCheese;
		}

		public async Task<IEnumerable<CheeseAndRating>> GetRecentRatedCheesesAsync ()
		{
			if (!_isInitialized)
				await InitializeDataStore();
			
			// Get cheeses rated within the last 10 days
			var tenDaysAgo = DateTime.Now.AddDays(-10);

			var ratings =  await _sqliteConn.Table<Rating> ().Where (r => r.DateRated >= tenDaysAgo).ToListAsync ().ConfigureAwait (false);

			List<CheeseAndRating> recents = new List<CheeseAndRating> ();


			// Very rudimentary join - need to get SQLite.Net extensions to make it easier
			foreach (var item in ratings) {
				var matchingCheese = await _sqliteConn.Table<Cheese> ().Where (c => c.CheeseId == item.CheeseId).FirstAsync ().ConfigureAwait (false);

				recents.Add (new CheeseAndRating () {
					CheeseId = matchingCheese.CheeseId,
					CheeseName = matchingCheese.CheeseName,
					DairyName = matchingCheese.DairyName,
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
			if (!_isInitialized)
				await InitializeDataStore();

			newCheese.CheeseId = Guid.NewGuid ().ToString ();

			await _sqliteConn.InsertAsync (newCheese).ConfigureAwait (false);

			return newCheese;
		}

		public async Task<Cheese> GetCheeseDetailsAsync (string cheeseId)
		{
			if (!_isInitialized)
				await InitializeDataStore();

			return await _sqliteConn.Table<Cheese> ()
				.Where (c => c.CheeseId == cheeseId).FirstOrDefaultAsync ().ConfigureAwait (false);
		}

		public async Task<IEnumerable<Cheese>> GetRecentCheesesAsync()
		{
			if (!_isInitialized)
				await InitializeDataStore().ConfigureAwait(false);

			return await _sqliteConn.Table<Cheese> ().OrderByDescending (c => c.DateAdded).Take (10)
				.ToListAsync ().ConfigureAwait (false);
		}

		#endregion
	}
}

