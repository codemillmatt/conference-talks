using System;
using FabLib;
using Xamarin.Forms;

namespace Foodie.iOS
{
	public class FoodieFab : FabButton
	{
		public Command Command { get; set; }

		public FoodieFab()
		{
			ButtonPressed += (sender, e) =>
			{
				Command?.Execute(null);
			};
		}
	}
}
