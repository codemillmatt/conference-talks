using System;

namespace Cheesed.Local
{
	public class CheeseAndRating
	{
		public CheeseAndRating ()
		{
			WedgeRating = 1;
		}

		public string CheeseId {
			get;
			set;
		}

		public string CheeseName {
			get;
			set;
		}

		public string DairyName {
			get;
			set;
		}

		public string RatingId {
			get;
			set;
		}

		public int WedgeRating {
			get;
			set;
		}

		public string Notes {
			get;
			set;
		}

		public DateTime DateRated {
			get;
			set;
		}
	}
}

