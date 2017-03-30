using System;
using Xamarin.Forms;

namespace Foodie
{
	public class ShadowEffect : RoutingEffect 
	{
		public ShadowEffect() : base("com.codemilltech.ShadowEffect")
		{

		}

		public Color ShadowColor { get; set; } = Color.Black;
	}
}
