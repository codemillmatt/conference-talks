using System;

using UIKit;
using System.Timers;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Reactive.Linq;

namespace RxLookup
{
	public partial class ViewController : UIViewController
	{
		List<string> allCheeses;

		public ViewController (IntPtr handle) : base (handle)
		{
			allCheeses = new List<string> ();

			allCheeses.Add ("Blue");
			allCheeses.Add ("Cheddar");
			allCheeses.Add ("American");
			allCheeses.Add ("Swiss");
			allCheeses.Add ("Curds");
			allCheeses.Add ("Pepperjack");
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.

			searchField.Text = string.Empty;

			var keyStrokeTimer = new Timer (500);
			var timeElapsedSinceChanged = true;

			keyStrokeTimer.Start ();

			keyStrokeTimer.Elapsed += (sender, e) => {
				timeElapsedSinceChanged = true;
			};

			var searchText = "";
			searchField.EditingChanged += async (sender, e) => {
				keyStrokeTimer.Stop ();

				if (timeElapsedSinceChanged) {
					// Probably should do some locking
					timeElapsedSinceChanged = false;
					keyStrokeTimer.Stop ();

					if (!string.IsNullOrEmpty (searchField.Text)) {
						if (!searchText.Equals (searchField.Text)) {
							searchText = searchField.Text;

							var results = await SearchCheeses (searchText);

							foreach (var cheeseName in results) {
											Console.WriteLine ($"Cheese name: {cheeseName}");
							}
						}
					}
				}

				keyStrokeTimer.Start();
			};


//			var editing = searchField.Events ().EditingChanged;
//
//			var searchSteam = editing
//				.Select (_ => searchField.Text)
//				.Where (t => !string.IsNullOrEmpty (t))
//				.DistinctUntilChanged ()
//				.Throttle (TimeSpan.FromSeconds (0.5))
//				.SelectMany (t =>
//					SearchCheeses (t));			                  
//
//			searchSteam.Subscribe (
//				r =>
//				r.ForEach(cheeseName =>
//					Console.WriteLine($"Cheese name: {cheeseName}"))			
//			);
		}

		async Task<List<string>> SearchCheeses (string searchText)
		{
			await Task.Delay (500);

			return allCheeses.Where (c => c.Contains (searchText)).ToList ();
		}
			
	}
}

