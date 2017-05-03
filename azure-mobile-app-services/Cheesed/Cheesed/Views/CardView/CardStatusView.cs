using System;

using Xamarin.Forms;

namespace Cheesed.Local
{
	public class CardStatusView : ContentView
	{
		BoxView statusBoxView;


		public CardStatusView ()
		{
			statusBoxView = new BoxView {
				VerticalOptions = LayoutOptions.Fill,
				HorizontalOptions = LayoutOptions.Fill,
				BackgroundColor = CheeseColors.LIGHT_GREEN
			};
					
			Content = statusBoxView;
		}
	}
}


