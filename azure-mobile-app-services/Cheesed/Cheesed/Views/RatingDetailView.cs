using System;

using Xamarin.Forms;

namespace Cheesed.Local
{
	public class RatingDetailView : ContentPage
	{
		RatingDetailViewModel _viewModel;

		public RatingDetailView (CheeseAndRating theRating)
		{
			_viewModel = new RatingDetailViewModel (theRating, this);
			BindingContext = _viewModel;

			this.SetBinding (ContentPage.TitleProperty, "Title");

			AbsoluteLayout cheeseInfoLayout = new AbsoluteLayout {
				HeightRequest = 250,
				BackgroundColor = CheeseColors.PURPLE
			};

			var cheeseName = new Label {				
				FontSize = 30,
				FontFamily = "AvenirNext-DemiBold",
				TextColor = Color.White
			};
			cheeseName.SetBinding (Label.TextProperty, "CheeseName");

			var dairyName = new Label { 				
				TextColor = Color.FromHex ("#ddd"),
				FontFamily = "AvenirNextCondensed-Medium" 
			};
			dairyName.SetBinding (Label.TextProperty, "DairyName");

			var image = new Image () {
				Source = ImageSource.FromFile ("Dairy_cow.jpg"),
				Aspect = Aspect.AspectFill,
			};

			var overlay = new BoxView () {
				Color = Color.Black.MultiplyAlpha (.7f)
			};
					
			var notesLabel = new Label () {
				FontSize = 14,
				TextColor = Color.FromHex("#ddd")
			};

			notesLabel.SetBinding (Label.TextProperty, "RatingDescription");

			var description = new Frame () {
				Padding = new Thickness (10, 5),
				HasShadow = false,
				BackgroundColor = Color.Transparent,
				Content = notesLabel
			};

			AbsoluteLayout.SetLayoutFlags (overlay, AbsoluteLayoutFlags.All);
			AbsoluteLayout.SetLayoutBounds (overlay, new Rectangle (0, 1, 1, 0.3));

			AbsoluteLayout.SetLayoutFlags (image, AbsoluteLayoutFlags.All);
			AbsoluteLayout.SetLayoutBounds (image, new Rectangle (0f, 0f, 1f, 1f));

			AbsoluteLayout.SetLayoutFlags (cheeseName, AbsoluteLayoutFlags.PositionProportional);
			AbsoluteLayout.SetLayoutBounds (cheeseName, 
				new Rectangle (0.1, 0.85, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize)
			);

			AbsoluteLayout.SetLayoutFlags (dairyName, AbsoluteLayoutFlags.PositionProportional);
			AbsoluteLayout.SetLayoutBounds (dairyName, 
				new Rectangle (0.1, 0.95, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize)
			);
				
			cheeseInfoLayout.Children.Add (image);
			cheeseInfoLayout.Children.Add (overlay);
			cheeseInfoLayout.Children.Add (cheeseName);
			cheeseInfoLayout.Children.Add (dairyName);
//			cheeseInfoLayout.Children.Add (pin);

//			var page = new ContentPage { Content = new StackLayout () {
//					BackgroundColor = Color.FromHex ("#333"),
//					Children = {
//						cheeseInfoLayout,
//						description,
//					}	
//				}
//			};
//
//			Content = page;

			Content = new StackLayout () {
				BackgroundColor = Color.FromHex ("#333"),
				Children = {
					cheeseInfoLayout, description
				}
			};


		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();

			_viewModel.GetRatingDetailsCommand.Execute (null);
		}
	}
}


