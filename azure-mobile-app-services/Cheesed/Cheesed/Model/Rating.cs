using System;
using SQLite.Net.Attributes;
using Newtonsoft.Json;

namespace Cheesed.Local
{
	public class Rating
	{
		public Rating ()
		{
		}
			
		[PrimaryKey, JsonProperty("Id")]
		public string RatingId {
			get;
			set;
		}

		public string CheeseId {
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

