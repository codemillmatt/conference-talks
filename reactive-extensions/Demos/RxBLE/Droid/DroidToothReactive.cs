using System;
using Android.Bluetooth;
using System.Reactive.Subjects;
using System.Reactive.Linq;
using Xamarin.Forms;

[assembly: Dependency (typeof(RxBLE.Droid.DroidToothReactive))]
namespace RxBLE.Droid
{
	public class DroidToothReactive : Java.Lang.Object, IBluetoothScanner, BluetoothAdapter.ILeScanCallback
	{
		protected BluetoothManager Manager;
		protected BluetoothAdapter Adapter;
		bool isScanning = false;
		readonly Subject<BroodtoothDevice> BroodSubject;

		public DroidToothReactive ()
		{
			var appContext = Android.App.Application.Context;

			// get a reference to the bluetooth system service
			this.Manager = (BluetoothManager) appContext.GetSystemService("bluetooth");
			this.Adapter = this.Manager.Adapter;

			BroodSubject = new Subject<BroodtoothDevice> ();
		}

		#region IBroodToothFinder implementation

		public event EventHandler<EventArgs> ScanTimedOut = delegate{};

		public void StopScan()
		{
			if (isScanning) {
				isScanning = false;

				Adapter.StopLeScan (this);
			}
		}

		public async void ScanForDevices ()
		{
			if (!isScanning) {
				isScanning = true;
				Adapter.StartLeScan (this);
			}
		}

		public IObservable<BroodtoothDevice> BroodObservable {
			get { return BroodSubject.AsObservable (); }
		}

		#endregion

		public void OnLeScan (BluetoothDevice device, int rssi, byte[] scanRecord)
		{						
			if (scanRecord[8] == 141 && scanRecord[9] == 2) {

				var broodDevice = new BroodtoothDevice () {
					AdvertisementData = scanRecord,
					UUID = device.Address
				};

				BroodSubject.OnNext (broodDevice);
			}
		}			
	}
}

