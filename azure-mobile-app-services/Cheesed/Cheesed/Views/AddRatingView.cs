using System;

using Xamarin.Forms;

namespace Cheesed.Local
{
	public class AddRatingView : ContentPage
	{
		AddRatingViewModel _viewModel;

		public AddRatingView (Cheese cheese)
		{
			_viewModel = new AddRatingViewModel (cheese, this);
			BindingContext = _viewModel;


			var cheeseName = new Label ();
			cheeseName.Text = string.Format ("The cheese name is {0}", _viewModel.RatingToAdd.CheeseName);				

			var dairyName = new Label () { Text = "Dairy Name" };
			dairyName.Text = string.Format ("The dairy name is {0}", _viewModel.RatingToAdd.DairyName);

			var ratingLabel = new Label () { Text = "Rating:" };
			var notesLabel = new Label () { Text = "Notes:" };


			var ratingView = new RatingView (true);
			ratingView.SetBinding (RatingView.WedgeRatingProperty, "RatingToAdd.WedgeRating");

			var notesEntry = new Entry () { };
			notesEntry.SetBinding (Entry.TextProperty, "RatingToAdd.Notes");

			var entryGrid = new Grid () {
				ColumnSpacing = 0,
				RowSpacing = 2,
				VerticalOptions = LayoutOptions.Start
			};

			entryGrid.RowDefinitions.Add (new RowDefinition (){ Height = GridLength.Auto });
			entryGrid.RowDefinitions.Add (new RowDefinition () { Height = GridLength.Auto });

			entryGrid.ColumnDefinitions.Add (new ColumnDefinition () { Width = GridLength.Auto });
			entryGrid.ColumnDefinitions.Add (new ColumnDefinition (){ Width = new GridLength (1, GridUnitType.Star) });

			entryGrid.Children.Add (ratingLabel, 0, 0);
			entryGrid.Children.Add (ratingView, 1, 0);
			entryGrid.Children.Add (notesLabel, 0, 1);
			entryGrid.Children.Add (notesEntry, 1, 1);

			var saveButton = new Button () { 
				Text = "Save",
				FontAttributes = FontAttributes.Bold,
				BackgroundColor = CheeseColors.RED,
				TextColor = Color.White,
				FontSize = 18,
				BorderRadius = 0
			};
			saveButton.Command = _viewModel.AddRatingCommand;

			var cancelButton = new Button () { 
				Text = "Cancel",
				FontAttributes = FontAttributes.Bold,
				BackgroundColor = CheeseColors.GRAY,
				TextColor = Color.White,
				FontSize = 18,
				BorderRadius = 0
			};

			var grid = new Grid () {
				RowDefinitions = { new RowDefinition { Height = new GridLength (40, GridUnitType.Star) } },
				ColumnDefinitions = {
					new ColumnDefinition () { Width = new GridLength (.5, GridUnitType.Star) },
					new ColumnDefinition () { Width = new GridLength (.5, GridUnitType.Star) }
				},
				Padding = new Thickness (0, 0, 0, 0),
				RowSpacing = 0,
				ColumnSpacing = 0
			};

			grid.Children.Add (saveButton, 0, 0);
			grid.Children.Add (cancelButton, 1, 0);

			cancelButton.Clicked += async (sender, e) => {
				await Navigation.PopAsync(true);
			};

			var scroll = new ScrollView ();

			scroll.Content = new StackLayout { 
				Children = {
					cheeseName,
					dairyName,
					entryGrid,
					grid
				}
			};

			var headerImage = new Image { Source = "Header.png" };

			Content = new StackLayout() { 
				Children = {
					headerImage,
					scroll
				}
			};
		}
	}
}


