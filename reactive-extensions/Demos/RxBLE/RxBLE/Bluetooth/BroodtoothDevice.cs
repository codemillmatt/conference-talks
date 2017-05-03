using System;

namespace RxBLE
{
	public class BroodtoothDevice
	{
		public BroodtoothDevice ()
		{
		}

		public string UUID {
			get;
			set;
		}

		public byte[] AdvertisementData {
			get;
			set;
		}

		public int Elapsed {
			get {
				return AdvertisementData [15] +
					(AdvertisementData [16] << 8);
			}
		}

		public int Humidity {
			get {
				return AdvertisementData [24];
			}
		}
	}
}

