using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Cheesed.Local
{
	public interface ICheeseDataService
	{
		Task InitializeDataStore();

		Task<IEnumerable<Cheese>> SearchCheeseAsync (string cheeseName);

		Task<Rating> RateCheeseAsync (Rating ratedCheese);

		Task<IEnumerable<CheeseAndRating>> GetRecentRatedCheesesAsync ();

		Task<Cheese> AddCheeseAsync (Cheese newCheese);

		Task<Cheese> GetCheeseDetailsAsync (string cheeseId);

		Task<IEnumerable<Cheese>> GetRecentCheesesAsync();
	}
}

