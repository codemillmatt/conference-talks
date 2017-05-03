using System;

using Xamarin.Forms;

namespace Cheesed.Local
{
	public class RecentRatingsView : ContentPage
	{
		RecentRatingsViewModel _viewModel;

		public RecentRatingsView ()
		{
			_viewModel = new RecentRatingsViewModel (this);
			BindingContext = _viewModel;

			Title = _viewModel.Title;

			BackgroundColor = Color.White;

			var cell = new DataTemplate (typeof(CardView));
			cell.SetBinding (CardView.CheeseNameProperty, "CheeseName");
			cell.SetBinding (CardView.DairyNameProperty, "DairyName");
			cell.SetBinding (CardView.NotesProperty, "Notes");
			cell.SetBinding (CardView.WedgeRatingProperty, "WedgeRating");


			ListView listOfRatings = new ListView ();
			listOfRatings.HasUnevenRows = true;
			listOfRatings.SetBinding (ListView.ItemsSourceProperty, "RatingList");
			listOfRatings.ItemTemplate = cell;
			listOfRatings.BackgroundColor = Color.White;
			listOfRatings.SeparatorVisibility = SeparatorVisibility.None;

			listOfRatings.ItemSelected += async (sender, e) => {
				var selectedRating = e.SelectedItem as CheeseAndRating;

				if (selectedRating != null) {
					await Navigation.PushAsync (new RatingDetailView (selectedRating));

					listOfRatings.SelectedItem = null;
				}
			};

			var addNewButton = new Button { 
				Text = "Add New Rating",
				BackgroundColor = CheeseColors.RED,
				TextColor = Color.White,
				FontSize = 18,
				FontAttributes = FontAttributes.Bold,
				BorderRadius = 0
			};
			addNewButton.Clicked += AddNewCheese;

			var headerImage = new Image { Source = "Rectangle1.png" };

			Content = new StackLayout { 
				Children = {
					headerImage,
					listOfRatings,
					addNewButton
				}, 
				Padding = new Thickness (0, 0, 0, 1)
			};
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();

			_viewModel.GetRecentRatingsCommand.Execute (null);
		}

		protected async void AddNewCheese (object sender, EventArgs e)
		{
			var searchCheeses = new SearchCheeseView ();

			await Navigation.PushModalAsync (new NavigationPage (searchCheeses));
		}
	}
}