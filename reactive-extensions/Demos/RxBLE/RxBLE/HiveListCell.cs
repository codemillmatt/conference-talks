using System;

using Xamarin.Forms;
using System.Threading.Tasks;

namespace RxBLE
{
	public class HiveListCell : ViewCell
	{
		#region Bindable Properties

		public string HiveAddress {
			get { return (string)GetValue (HiveAddressProperty); }
			set {
				SetValue (HiveAddressProperty, value);
			}
		}

		public static readonly BindableProperty HiveAddressProperty = 
			BindableProperty.Create<HiveListCell, string> (
				p => p.HiveAddress,
				defaultValue: string.Empty,
				defaultBindingMode: BindingMode.OneWay,
				propertyChanging: (bindable, oldValue, newValue) => {
					var ctrl = (HiveListCell)bindable;
					ctrl.HiveAddress = newValue;
				});

		public static readonly BindableProperty HeadingTextProperty = 
			BindableProperty.Create<HiveListCell, string> (
				p => p.HeadingText,
				defaultValue: string.Empty,
				defaultBindingMode: BindingMode.OneWay,
				propertyChanging: (bindable, oldValue, newValue) => {
					var ctrl = (HiveListCell)bindable;
					ctrl.HeadingText = newValue;
				});

		public string HeadingText {
			get { return (string)GetValue (HeadingTextProperty); }
			set {
				SetValue (HeadingTextProperty, value);
				headingLabel.Text = value;
			}
		}


		public static readonly BindableProperty MiddleTextProperty = 
			BindableProperty.Create<HiveListCell, string> (
				p => p.MiddleText,
				defaultValue: string.Empty,
				defaultBindingMode: BindingMode.OneWay,
				propertyChanging: (bindable, oldValue, newValue) => {
					var ctrl = (HiveListCell)bindable;
					ctrl.MiddleText = newValue;
				});

		public string MiddleText {
			get { return (string)GetValue (MiddleTextProperty); }
			set {
				SetValue (MiddleTextProperty, value);
				middleLabel.Text = value;
			}
		}


		public static readonly BindableProperty LowerTextProperty = 
			BindableProperty.Create<HiveListCell, string> (
				p => p.LowerText,
				defaultValue: string.Empty,
				defaultBindingMode: BindingMode.OneWay,
				propertyChanging: (bindable, oldValue, newValue) => {
					var ctrl = (HiveListCell)bindable;
					ctrl.LowerText = newValue;
				});

		public string LowerText {
			get { return (string)GetValue (LowerTextProperty); }
			set {
				SetValue (LowerTextProperty, value);
				lowerLabel.Text = value;
			}
		}
			
		public static readonly BindableProperty BottomTextProperty = 
			BindableProperty.Create<HiveListCell, string> (
				p => p.BottomText,
				defaultValue: string.Empty,
				defaultBindingMode: BindingMode.OneWay,
				propertyChanging: (bindable, oldValue, newValue) => {
					var ctrl = (HiveListCell)bindable;
					ctrl.BottomText = newValue;
				});

		public string BottomText {
			get { return (string)GetValue (BottomTextProperty); }
			set {
				SetValue (BottomTextProperty, value);
				bottomLabel.Text = value;
			}
		}
			
		public static readonly BindableProperty BottomUUIDProperty = 
			BindableProperty.Create<HiveListCell, string> (
				p => p.BottomUUID,
				defaultValue: string.Empty,
				defaultBindingMode: BindingMode.OneWay,
				propertyChanging: (bindable, oldValue, newValue) => {
					var ctrl = (HiveListCell)bindable;
					ctrl.BottomUUID = newValue;
				});

		public string BottomUUID {
			get { return (string)GetValue (BottomUUIDProperty); }
			set {
				SetValue (BottomUUIDProperty, value);
				bottomUUIDLabel.Text = value;
			}
		}

		#endregion

		readonly Label headingLabel;
		readonly Label middleLabel;
		readonly Label lowerLabel;
		readonly Label bottomLabel;
		readonly Label bottomUUIDLabel;
		readonly Image hiveImage;

		public HiveListCell ()
		{
			this.Height = 150;

			var horizontalStack = new StackLayout () {
				Orientation = StackOrientation.Horizontal,
				Padding = new Thickness(8,10,10,10)
			};

			var verticalStack = new StackLayout () {
				Orientation = StackOrientation.Vertical,
				Padding = new Thickness(0,0,10,10)
			};

			hiveImage = new Image () { WidthRequest = 96, HeightRequest = 150, Aspect = Aspect.AspectFit };
			hiveImage.Source = new FileImageSource () { File = "BigLogo96" };

			// Example of setting font, size and color attributes
			headingLabel = new Label ();
			headingLabel.FontFamily = "Helvetica";
			headingLabel.FontSize = 20;
			headingLabel.TextColor = Color.FromHex("208000");

			middleLabel = new Label ();
			lowerLabel = new Label ();
			bottomLabel = new Label ();
			bottomUUIDLabel = new Label ();

			middleLabel.FontFamily = "Helvetica";
			lowerLabel.FontFamily = "Helvetica";
			bottomLabel.FontFamily = "Helvetica";
			bottomUUIDLabel.FontFamily = "Helvetica";

			middleLabel.FontSize = 24;
			lowerLabel.FontSize = 13;
			bottomLabel.FontSize = 13;
			bottomUUIDLabel.FontSize = 13;

			middleLabel.TextColor = Color.FromHex ("333333");
			lowerLabel.TextColor = Color.FromHex ("4d4d4d");
			bottomLabel.TextColor = Color.FromHex ("4d4d4d");
			bottomUUIDLabel.TextColor = Color.FromHex ("208000");

			verticalStack.Children.Add (headingLabel);
			verticalStack.Children.Add (middleLabel);
			verticalStack.Children.Add (lowerLabel);
			verticalStack.Children.Add (bottomLabel);
			verticalStack.Children.Add (bottomUUIDLabel);

			horizontalStack.Children.Add (hiveImage);
			horizontalStack.Children.Add (verticalStack);

			this.View = horizontalStack;
		}			
	}
}


