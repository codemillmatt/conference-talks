using System;
using Xamarin.Forms;
using Foodie.iOS;
using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;
using UIKit;

[assembly: Dependency(typeof(TwitterLoginService))]
namespace Foodie.iOS
{
	
	public class TwitterLoginService : ILoginProvider
	{
		public TwitterLoginService()
		{
		}

		public UIViewController RootView => UIApplication.SharedApplication.KeyWindow.RootViewController;

		public async Task Login(MobileServiceClient client)
		{
			await client.LoginAsync(RootView, "twitter");
		}
	}
}
