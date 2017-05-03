using System;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace Cheesed.Local
{
	public class AddCheeseAndRatingViewModel
	{
		readonly ICheeseDataService _dataService;
		public readonly string Title;
		ContentPage Page;

		public CheeseAndRating CheeseToAdd {
			get;
			set;
		}

		public AddCheeseAndRatingViewModel (ContentPage thePage)
		{
			_dataService = DependencyService.Get<ICheeseDataService> ();
			Title = "Add That Cheese!";
			Page = thePage;

			CheeseToAdd = new CheeseAndRating ();
		}

		private Command _addCheeseCommand;

		public Command AddCheeseCommand {
			get {
				return _addCheeseCommand ??
				(_addCheeseCommand = new Command (async() => await ExecuteAddCheeseCommand ()));
			}
		}

		private async Task ExecuteAddCheeseCommand ()
		{
			try {
				AddCheeseCommand.ChangeCanExecute ();

				var newCheese = new Cheese () { 
					CheeseName = CheeseToAdd.CheeseName, 
					DairyName = CheeseToAdd.DairyName,
					DateAdded = DateTime.Now
				};

				newCheese = await _dataService.AddCheeseAsync (newCheese).ConfigureAwait (false);

				var newRating = new Rating () {
					CheeseId = newCheese.CheeseId,
					Notes = CheeseToAdd.Notes,
					WedgeRating = CheeseToAdd.WedgeRating,
					DateRated = DateTime.Now
				};

				newRating = await _dataService.RateCheeseAsync (newRating);

				CheeseToAdd.CheeseId = newRating.CheeseId;
				CheeseToAdd.RatingId = newRating.RatingId;

				Device.BeginInvokeOnMainThread (async () => {
					await Page.Navigation.PopModalAsync (true);
				});
			} catch (NoInternetException) {
				await Page.DisplayAlert ("No Internet!", "Cannot Access The Internet!", "Darn!");

			} finally {
				AddCheeseCommand.ChangeCanExecute ();
			}
		}
	}
}

