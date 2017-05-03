using System;

namespace RxBLE
{
	public class BroodMinderReading
	{
		public BroodMinderReading ()
		{
		}

		public BroodMinderReading (BroodtoothDevice broodTooth)
		{
			var uuid = broodTooth.UUID.Trim ();

			Address = uuid.Substring (9, 8);

			// make sure it has a legit UUID
			if ((Address.Substring (2, 1) == ":")) {
				Elapsed = broodTooth.Elapsed;
				Humidity = broodTooth.Humidity;
				ReadDate = DateTime.Now;
				HiveName = string.Empty;
			}
		}
			
		public string DisplayName {
			get {
				return $"Addr: {Address} - {Elapsed}";
			}
		}
			
		public string DisplayUUIDName {
			get {
				return Address;
			}
		}
			
		public string Address {
			get;
			set;
		}
				
		public int Elapsed {
			get;
			set;
		}

		public string HiveName {
			get;
			set;
		}
			
		public DateTime ReadDate {
			get;
			set;
		}
			
		public int Humidity {
			get;
			set;
		}		
			
	}
}

