using System;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Cheesed.Local
{
	public class RatingDetailViewModel : INotifyPropertyChanged
	{
		readonly ICheeseDataService _dataService;
		ContentPage Page;

		public string Title {
			get;
			private set;
		}

		public CheeseAndRating RatingDetails {
			get;
			private set;
		}

		public string RatingDescription {
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

		public RatingDetailViewModel (CheeseAndRating rating, ContentPage page)
		{
			_dataService = DependencyService.Get<ICheeseDataService> ();

			Page = page;

			RatingDetails = rating;
		}

		private async Task ExecuteGetRatingDetailsCommand ()
		{
			try {
				GetRatingDetailsCommand.ChangeCanExecute ();

				var cheeseDetail = await _dataService.GetCheeseDetailsAsync (RatingDetails.CheeseId);

				RatingDetails.CheeseName = cheeseDetail.CheeseName;
				this.CheeseName = cheeseDetail.CheeseName;
				OnPropertyChanged("CheeseName");

				RatingDetails.DairyName = cheeseDetail.DairyName;
				this.DairyName = cheeseDetail.DairyName;
				OnPropertyChanged("DairyName");

				RatingDescription = string.Format ("This {0} cheese was rated on {1}, and was given {2} wedges." +
				System.Environment.NewLine + "The taste complexities were noted by the following: {3}",
					RatingDetails.CheeseName, RatingDetails.DateRated.ToShortDateString (), RatingDetails.WedgeRating,
					RatingDetails.Notes);

				OnPropertyChanged ("RatingDescription");

				Title = RatingDetails.CheeseName;
				OnPropertyChanged ("Title");

			} catch (NoInternetException) {
				await Page.DisplayAlert ("No Internet!", "Cannot Access The Internet!", "Darn!");

			} finally {
				GetRatingDetailsCommand.ChangeCanExecute ();
			}
		}

		private Command _GetRatingDetailsCommand;

		public Command GetRatingDetailsCommand {
			get {
				return _GetRatingDetailsCommand ?? (_GetRatingDetailsCommand = new Command (async () => await ExecuteGetRatingDetailsCommand ()));
			}
		}

		#region INotifyPropertyChanged implementation

		protected virtual void OnPropertyChanged (string propertyName)
		{
			if (PropertyChanged != null) {
				PropertyChanged (this, new PropertyChangedEventArgs (propertyName));
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		#endregion
	}
}

