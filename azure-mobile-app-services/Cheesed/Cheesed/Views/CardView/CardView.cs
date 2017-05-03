using System;

using Xamarin.Forms;


namespace Cheesed.Local
{
	public class CardView : ViewCell
	{		
		#region Bindable Properties 

		public string Notes {
			get {
				return (string)GetValue (NotesProperty);
			}
			set {
				SetValue (NotesProperty, value);
				detailsView.LayoutDetails (null, null, value);
			}
		}
				
		public static readonly BindableProperty NotesProperty = 
			BindableProperty.Create<CardView, string> (
				p => p.Notes,
				defaultValue: string.Empty,
				defaultBindingMode: BindingMode.OneWay,
				propertyChanging: (bindable, oldValue, newValue) => {
					var ctrl = (CardView)bindable;
					ctrl.Notes = newValue;
				});


		public string CheeseName {
			get { return (string)GetValue (CheeseNameProperty); }
			set {
				SetValue (CheeseNameProperty, value);
				detailsView.LayoutDetails (value, null, null);
			}
		}

		public static readonly BindableProperty CheeseNameProperty = 
			BindableProperty.Create<CardView, string> (
				p => p.CheeseName,
				defaultValue: string.Empty,
				defaultBindingMode: BindingMode.OneWay,
				propertyChanging: (bindable, oldValue, newValue) => {
					var ctrl = (CardView)bindable;
					ctrl.CheeseName = newValue;
				});

		public string DairyName {
			get { return (string)GetValue (DairyNameProperty); }
			set {
				SetValue (DairyNameProperty, value);
				detailsView.LayoutDetails (null, value, null);
			}
		}

		public static readonly BindableProperty DairyNameProperty = 
			BindableProperty.Create<CardView, string> (
				p => p.DairyName,
				defaultValue: string.Empty,
				defaultBindingMode: BindingMode.OneWay,
				propertyChanging: (bindable, oldValue, newValue) => {
					var ctrl = (CardView)bindable;
					ctrl.DairyName = newValue;
				});


		public int WedgeRating {
			get { 
				return (int)GetValue (WedgeRatingProperty);
			}
			set {
				SetValue (WedgeRatingProperty, value);
				ratingView.WedgeRating = value;
			}
		}

		public static readonly BindableProperty WedgeRatingProperty = 
			BindableProperty.Create<CardView, int> (
				p => p.WedgeRating,
				defaultValue: 1,
				defaultBindingMode: BindingMode.OneWay,
				propertyChanging: (bindable, oldValue, newValue) => {
					var ctrl = (CardView)bindable;
					ctrl.WedgeRating = newValue;
				}
			);

		#endregion

		CardDetailsView detailsView;
		CardStatusView statusView;
		RatingView ratingView;

		public CardView ()
		{
			Grid grid = new Grid {
				Padding = new Thickness (0, 1, 1, 1),
				RowSpacing = 1,
				ColumnSpacing = 1,		
				BackgroundColor = CheeseColors.WHITE,
				VerticalOptions = LayoutOptions.FillAndExpand,
				RowDefinitions = {
					new RowDefinition { Height = new GridLength (70, GridUnitType.Absolute) },
					new RowDefinition { Height = new GridLength (30, GridUnitType.Absolute) }
				},
				ColumnDefinitions = {
					new ColumnDefinition { Width = new GridLength (4, GridUnitType.Absolute) },
					new ColumnDefinition { Width = new GridLength (1, GridUnitType.Star) },
					new ColumnDefinition { Width = new GridLength (150, GridUnitType.Absolute) },
				}
			};
				
			statusView = new CardStatusView ();
			detailsView = new CardDetailsView ();
			ratingView = new RatingView(false);

			// Add the colored status view content
			grid.Children.Add (
				statusView
				, 0, 1, 0, 2);

			// Add the cheese details content
			grid.Children.Add (detailsView, 1, 4, 0, 1);

			grid.Children.Add (
				ratingView
				, 1, 1);


			var stack = new StackLayout () {
				Children = {grid},
				Padding = new Thickness (0, 5, 0, 5)
			};

			this.View = stack;
		}
	}

}


