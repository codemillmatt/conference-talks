using System;
using Xamarin.Forms;
using Foodie.Droid;
using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;
using Android.Content;

[assembly: Dependency(typeof(TwitterLoginService))]
namespace Foodie.Droid
{
	public class TwitterLoginService : ILoginProvider
	{
		Context context;

		public void Init(Context context)
		{
			this.context = context;
		}

		public async Task Login(MobileServiceClient client)
		{
			await client.LoginAsync(context, "twitter");
		}
	}
}
