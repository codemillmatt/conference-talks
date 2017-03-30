using System;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using Android.Widget;
using System.Linq;

using Foodie.Droid;

[assembly: ResolutionGroupName("com.codemilltech")]
[assembly: ExportEffect(typeof(TextviewShadowEffect), "ShadowEffect")]
namespace Foodie.Droid
{
	public class TextviewShadowEffect : PlatformEffect
	{
		Android.Graphics.Color oldColor;
		float oldRadius;
		float oldDx;
		float oldDy;

		protected override void OnAttached()
		{
			var tv = Control as TextView;

			oldColor = tv.ShadowColor;
			oldRadius = tv.ShadowRadius;
			oldDx = tv.ShadowDx;
			oldDy = tv.ShadowDy;

			var routingEffect = (ShadowEffect)Element.Effects.First((arg) => arg is ShadowEffect);
			var shadowColor = routingEffect.ShadowColor;

			tv.SetShadowLayer(2f, 2f, 2f, shadowColor.ToAndroid());
		}

		protected override void OnDetached()
		{
			var tv = Control as TextView;
			tv.SetShadowLayer(oldRadius, oldDx, oldDy, oldColor);
		}
	}
}
