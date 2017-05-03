using System;
using SQLite.Net.Attributes;

using Newtonsoft.Json;

namespace Cheesed.Local
{
	public class Cheese
	{
		public Cheese ()
		{
		}
			
		[PrimaryKey, JsonProperty("Id")]
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
			
		public DateTime DateAdded {
			get;
			set;
		}
	}
}

