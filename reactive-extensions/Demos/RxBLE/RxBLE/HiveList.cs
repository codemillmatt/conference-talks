using System;

using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Reactive.Linq;

namespace RxBLE
{
	public class HiveList : ContentPage
	{
		ListView listOfReadings;
		ObservableCollection<BroodMinderReading> ListReadings = new ObservableCollection<BroodMinderReading>();
		IBluetoothScanner scanner;

		public HiveList ()
		{
			this.Title = "BROODMINDER";
			scanner = DependencyService.Get<IBluetoothScanner> ();

			SetupUI ();

			// Original - see all
//			scanner.BroodObservable.Subscribe (btd => 
//				Device.BeginInvokeOnMainThread (() => 
//					ListReadings.Add (new BroodMinderReading (btd))
//				));

			// group by device - distinct elapsed
			var broodObservable = scanner.BroodObservable;

			// Operate
			var broodStream = broodObservable
				.GroupBy (bt => bt.UUID)
				.SelectMany (bt => 
					bt.DistinctUntilChanged (bte => bte.Elapsed));

			broodStream.Subscribe (bt => 
				Device.BeginInvokeOnMainThread (() => 
					ListReadings.Add (new BroodMinderReading (bt)
			)));

		}

		#region Display

		private void SetupUI()
		{
			BackgroundColor = Color.White;

			var cell = new DataTemplate (typeof(HiveListCell));
			cell.SetBinding (HiveListCell.HeadingTextProperty, "DisplayName");
			cell.SetBinding (HiveListCell.MiddleTextProperty, "ReadDate");
			cell.SetBinding (HiveListCell.LowerTextProperty, "Humidity");
//			cell.SetBinding (HiveListCell.BottomTextProperty, "Humidity");
			//cell.SetBinding (HiveListCell.BottomUUIDProperty, "DisplayUUIDName");
			//cell.SetBinding (HiveListCell.HiveAddressProperty, "Address");



			listOfReadings = new ListView (ListViewCachingStrategy.RetainElement);
			listOfReadings.HasUnevenRows = true;
			listOfReadings.BindingContext = ListReadings;
			listOfReadings.SetBinding (ListView.ItemsSourceProperty, ".");		
			listOfReadings.ItemTemplate = cell;
			listOfReadings.BackgroundColor = Color.White;

			Content = new StackLayout { 
				Children = {
					listOfReadings
				},
				Padding = new Thickness (0, 0, 0, 1)
			};
										
		}
			
		#endregion

		#region Lifecycle Events

		protected override void OnDisappearing ()
		{
			base.OnDisappearing ();
			scanner.StopScan ();
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();
			scanner.ScanForDevices ();
		}

		#endregion
	}
}


