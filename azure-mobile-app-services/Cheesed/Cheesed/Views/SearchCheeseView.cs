using System;

using Xamarin.Forms;

namespace Cheesed.Local
{
	public class SearchCheeseView : ContentPage
	{
		SearchCheeseViewModel _viewModel;

		public SearchCheeseView ()
		{
			_viewModel = new SearchCheeseViewModel (this);

			BindingContext = _viewModel;

			Title = _viewModel.Title;

			BackgroundColor = Color.White;;

			var searchBar = new SearchBar { 
				Placeholder = "Search for your Cheese!", 
				BackgroundColor = CheeseColors.GRAY
			};

			searchBar.SearchButtonPressed += (object sender, EventArgs e) => {
				_viewModel.SearchCheesesCommand.Execute (searchBar.Text);
			};


			var resultsList = new ListView ();
			resultsList.SetBinding (ListView.ItemsSourceProperty, "Cheeses");

			resultsList.ItemSelected += async (sender, e) => {
				var selectedCheese = e.SelectedItem as Cheese;

				if (selectedCheese != null) {
					var addRatingView = new AddRatingView (selectedCheese);

					await Navigation.PushAsync (addRatingView);
				}
			};

			var cell = new DataTemplate (typeof(TextCell));
			cell.SetBinding (TextCell.TextProperty, "CheeseName");


			resultsList.ItemTemplate = cell;

			var cancelButton = new Button { 
				Text = "Cancel",
				BackgroundColor = CheeseColors.GRAY,
				TextColor = Color.White,
				FontSize = 18,
				FontAttributes = FontAttributes.Bold,
				BorderRadius = 0
			};

			var addNewButton = new Button { 
				Text = "Add New",
				BackgroundColor = CheeseColors.RED ,
				TextColor = Color.White,
				FontSize = 18,
				FontAttributes = FontAttributes.Bold,
				BorderRadius = 0
			};

			cancelButton.Clicked += async (sender, e) => {
				await Navigation.PopModalAsync ();
			};

			addNewButton.Clicked += async (sender, e) => {
				await Navigation.PushAsync (new AddCheeseAndRatingView ());
			};
				
			var grid = new Grid () {
				RowDefinitions = { new RowDefinition { Height = new GridLength (80, GridUnitType.Star) } },
				ColumnDefinitions = {
					new ColumnDefinition () { Width = new GridLength (.5, GridUnitType.Star) },
					new ColumnDefinition () { Width = new GridLength (.5, GridUnitType.Star) }
				},
				Padding = new Thickness (0, 0, 0, 0),
				RowSpacing = 0,
				ColumnSpacing = 0
			};
				
			grid.Children.Add (addNewButton, 0, 0);
			grid.Children.Add (cancelButton, 1, 0);

			Content = new StackLayout { 
				Children = {			
					searchBar,
					resultsList,
					grid
				},
				Padding = new Thickness (0, 0, 0, 0)
			};
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();

			_viewModel.GetRecentCheesesCommand.Execute (null);
		}
	}
}


