using System;

namespace RxBLE
{
	public interface IBluetoothScanner
	{
		void ScanForDevices();
		void StopScan();

		IObservable<BroodtoothDevice> BroodObservable { get; }
	}
}

