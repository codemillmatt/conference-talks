using System;
using Xamarin.Forms;

namespace Foodie
{
	public class NumericEntryBehavior : Behavior<Entry>
	{
		protected override void OnAttachedTo(Entry bindable)
		{
			base.OnAttachedTo(bindable);

			bindable.TextChanged += TextChanged_Handler;
		}

		protected override void OnDetachingFrom(Entry bindable)
		{
			base.OnDetachingFrom(bindable);
		}

		void TextChanged_Handler(object sender, TextChangedEventArgs e)
		{
			// Short circuit for no value - accept it
			if (string.IsNullOrEmpty(e.NewTextValue))
				return;
			
			double _;
			if (!double.TryParse(e.NewTextValue, out _))
				((Entry)sender).Text = e.OldTextValue;
		}
	}
}
