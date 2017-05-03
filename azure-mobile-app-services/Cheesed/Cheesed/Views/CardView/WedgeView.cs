using System;

using Xamarin.Forms;

namespace Cheesed.Local
{
	public class WedgeView : ContentView
	{
		Image wedge1;
		Image wedge2;
		Image wedge3;
		Image wedge4;
		Image wedge5;

		public WedgeView ()
		{
			wedge1 = new Image () { Source = "Wedge", IsVisible = false };
			wedge2 = new Image () { Source = "Wedge", IsVisible = false };
			wedge3 = new Image () { Source = "Wedge", IsVisible = false };
			wedge4 = new Image () { Source = "Wedge", IsVisible = false };
			wedge5 = new Image () { Source = "Wedge", IsVisible = false };

			var stack = new StackLayout () { 
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Orientation = StackOrientation.Horizontal,
				Padding = new Thickness(10,0,0,0),
				Children = {
					wedge1,
					wedge2,
					wedge3,
					wedge4,
					wedge5
				}
			};

			Content = stack;
		}

		public void RateStack(int wedgeRating) {
			wedge1.IsVisible = false;
			wedge2.IsVisible = false;
			wedge3.IsVisible = false;
			wedge4.IsVisible = false;
			wedge5.IsVisible = false;

			switch (wedgeRating) {
			case 1:
				wedge1.IsVisible = true;
				break;
			case 2:
				wedge1.IsVisible = true;
				wedge2.IsVisible = true;
				break;
			case 3:
				wedge1.IsVisible = true;
				wedge2.IsVisible = true;
				wedge3.IsVisible = true;
				break;
			case 4:
				wedge1.IsVisible = true;
				wedge2.IsVisible = true;
				wedge3.IsVisible = true;
				wedge4.IsVisible = true;
				break;
			case 5:
				wedge1.IsVisible = true;
				wedge2.IsVisible = true;
				wedge3.IsVisible = true;
				wedge4.IsVisible = true;
				wedge5.IsVisible = true;
				break;
			default:
				wedge1.IsVisible = false;
				wedge2.IsVisible = false;
				wedge3.IsVisible = false;
				wedge4.IsVisible = false;
				wedge5.IsVisible = false;
				break;
			
			}
		}
	}
}


