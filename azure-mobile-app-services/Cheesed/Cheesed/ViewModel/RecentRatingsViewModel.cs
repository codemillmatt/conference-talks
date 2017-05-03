using System;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Linq;

namespace Cheesed.Local
{
	public class RecentRatingsViewModel
	{
		readonly ICheeseDataService _dataService;
		public readonly string Title;
		ContentPage Page;

		public ObservableCollection<CheeseAndRating> RatingList {
			get;
			set;
		}

		public RecentRatingsViewModel (ContentPage page)
		{
			_dataService = DependencyService.Get<ICheeseDataService> ();
			Title = "Cheesed!";
			Page = page;

			RatingList = new ObservableCollection<CheeseAndRating> ();
		}

		private async Task ExecuteGetRecentRatingsCommand ()
		{
			try {
				GetRecentRatingsCommand.ChangeCanExecute ();

				var recentRatings = await _dataService.GetRecentRatedCheesesAsync ();

				foreach (var rating in recentRatings) {
					if (RatingList.Any (r => r.RatingId == rating.RatingId) == false) {						
						RatingList.Insert (0, rating);
					}
				}
			} catch (NoInternetException) {
				await Page.DisplayAlert ("No Internet!", "Cannot Access The Internet!", "Darn!");
			} finally {
				GetRecentRatingsCommand.ChangeCanExecute ();
			}
		}

		private Command _getRecentRatingsCommand;

		public Command GetRecentRatingsCommand {
			get {
				return _getRecentRatingsCommand ??
				(_getRecentRatingsCommand = new Command (async () => 
						await ExecuteGetRecentRatingsCommand ()
				));
			}
		}
	}
}

