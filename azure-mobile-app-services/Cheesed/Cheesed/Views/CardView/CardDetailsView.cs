using System;

using Xamarin.Forms;

namespace Cheesed.Local
{
	public class CardDetailsView : ContentView
	{		
		Label TitleText;
		Label NotesText;
		Label DairyText;

		public CardDetailsView ()
		{
			BackgroundColor = Color.White;

			TitleText = new Label () {				
				FontSize = 22,
				TextColor = Color.Black,
				FontAttributes = FontAttributes.Bold
			};

			DairyText = new Label () {
				FontSize = 16,
				TextColor = Color.Black,
				FontAttributes = FontAttributes.Bold
			};
					
			NotesText = new Label () {				
				FontSize = 14,
				TextColor = Color.Black
			};

			var stack = new StackLayout () {
				Spacing = 0,
				Padding = new Thickness (10, 0, 0, 0),
				VerticalOptions = LayoutOptions.CenterAndExpand,
				Children = {
					TitleText,
					DairyText,
					NotesText
				}
			};

			Content = stack;
		}

		public void LayoutDetails(
			string cheeseName, 
			string dairyName, 
			string notes) 
		{

			if (!string.IsNullOrEmpty (notes)) {
				var ratingNotes = notes;

				if (ratingNotes.Length > 30)
					ratingNotes = string.Format ("{0}...", ratingNotes.Substring (0, 27));

				NotesText.FormattedText = ratingNotes;
			}

			if (!string.IsNullOrEmpty (dairyName)) {
				DairyText.FormattedText = dairyName;
			}

			if (!string.IsNullOrEmpty (cheeseName)) {
				TitleText.FormattedText = cheeseName;
			}
		}
	}
}


