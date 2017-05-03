using System;

using Xamarin.Forms;

namespace Cheesed.Local
{
	public class AddCheeseAndRatingView : ContentPage
	{
		AddCheeseAndRatingViewModel _viewModel;

		public AddCheeseAndRatingView ()
		{
			_viewModel = new AddCheeseAndRatingViewModel (this);
			BindingContext = _viewModel;

			InitializeDisplay ();
		}

		void InitializeDisplay ()
		{
			Title = "Add Rating";

			var cheeseNameLabel = new Label () {
				Text = "Cheese Name:"
			};
			var cheeseNameText = new Entry () {
				BackgroundColor = CheeseColors.WHITE
			};				
			cheeseNameText.SetBinding (Entry.TextProperty, "CheeseToAdd.CheeseName");

			var dairyNameLabel = new Label () {
				Text = "Dairy Name:"
			};
			var dairyNameText = new Entry () {
				BackgroundColor = CheeseColors.WHITE
			};
			dairyNameText.SetBinding (Entry.TextProperty, "CheeseToAdd.DairyName");

			var ratingLabel = new Label () {
				Text = "Rating:"
			};
							
			var ratingView = new RatingView (true);
			ratingView.SetBinding (RatingView.WedgeRatingProperty, "CheeseToAdd.WedgeRating");

			var notesLabel = new Label () {
				Text = "Notes:"
			};
			var notesText = new Entry () {				
				BackgroundColor = CheeseColors.WHITE,
				VerticalOptions = LayoutOptions.Start
			};
			notesText.SetBinding (Entry.TextProperty, "CheeseToAdd.Notes");


			var addButton = new Button () {
				Text = "Add",
				Command = _viewModel.AddCheeseCommand,
				BackgroundColor = CheeseColors.RED,
				TextColor = Color.White,
				FontAttributes = FontAttributes.Bold,
				FontSize = 18,
				BorderRadius = 0
			};					
					
			var stack = new StackLayout () {
				Children = {
					cheeseNameLabel,
					cheeseNameText,
					dairyNameLabel,
					dairyNameText,
					ratingLabel,
					ratingView,
					notesLabel,
					notesText,
					addButton
				}
			};

			var scroll = new ScrollView ();
			scroll.Content = stack;

			Content = scroll;
		}
	}
}


