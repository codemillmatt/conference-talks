using System;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Linq;

namespace Cheesed.Local
{
	public class SearchCheeseViewModel
	{
		readonly ICheeseDataService _dataService;
		public readonly string Title;

		public ObservableCollection<Cheese> Cheeses {
			get;
			set;
		}

		public string SearchText {
			get;
			set;
		}

		ContentPage Page;

		public SearchCheeseViewModel (ContentPage page)
		{
			_dataService = DependencyService.Get<ICheeseDataService> ();
			Title = "Search Cheeses";
			Cheeses = new ObservableCollection<Cheese> ();
			Page = page;
		}

		private Command _getRecentCheesesCommand;

		public Command GetRecentCheesesCommand {
			get {
				return _getRecentCheesesCommand ?? (_getRecentCheesesCommand = new Command (
					async () => await ExecuteGetRecentCheesesCommand ()));
			}
		}

		private async Task ExecuteGetRecentCheesesCommand ()
		{
			try {
				GetRecentCheesesCommand.ChangeCanExecute ();

				var recentCheese = await _dataService.GetRecentCheesesAsync ();

				Cheeses.Clear ();

				foreach (var cheese in recentCheese) {
					Cheeses.Add (cheese);
				}

			} catch (NoInternetException) {
				await Page.DisplayAlert ("No Internet!", "Cannot Access The Internet!", "Darn!");

			} finally {
				GetRecentCheesesCommand.ChangeCanExecute ();
			}
		}

		private Command<string> _searchCheesesCommand;

		public Command<string> SearchCheesesCommand {
			get {
				return _searchCheesesCommand ??
				(_searchCheesesCommand = new Command<string> (async (s) => await ExecuteSearchCheesesCommand (s)));
			}
		}

		private async Task ExecuteSearchCheesesCommand (string s)
		{
			try {
				SearchCheesesCommand.ChangeCanExecute ();

				var searchedCheese = await _dataService.SearchCheeseAsync (s.ToString ());

				Cheeses.Clear ();

				foreach (var cheese in searchedCheese) {
					Cheeses.Add (cheese);
				}
			} catch (NoInternetException) {
				await Page.DisplayAlert ("No Internet!", "Cannot Access The Internet!", "Darn!");

			} finally {				
				SearchCheesesCommand.ChangeCanExecute ();
			}
		}
	}
}

