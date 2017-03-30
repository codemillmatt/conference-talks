using System;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using CoreGraphics;
using Xamarin.Forms;
using System.Linq;

using Foodie.iOS;

[assembly: ResolutionGroupName("com.codemilltech")]
[assembly: ExportEffect(typeof(LabelShadowEffect), "ShadowEffect")]
namespace Foodie.iOS
{
	public class LabelShadowEffect : PlatformEffect
	{
		UIColor oldColor;
		CGSize oldOffset;

		protected override void OnAttached()
		{
			var c = Control as UILabel;
			oldColor = c.ShadowColor;
			oldOffset = c.ShadowOffset;

			var routingEffect = (ShadowEffect)Element.Effects.First((arg) => arg is ShadowEffect);
			var shadowColor = routingEffect.ShadowColor;

			c.ShadowColor = shadowColor.ToUIColor();
			c.ShadowOffset = new CGSize(2, 2);
		}

		protected override void OnDetached()
		{
			var c = Control as UILabel;
			c.ShadowColor = oldColor;
			c.ShadowOffset = oldOffset;
		}

	}
}
