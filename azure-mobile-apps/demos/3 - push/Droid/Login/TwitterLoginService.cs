using System;
using Xamarin.Forms;
using Foodie.Droid;
using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;
using Android.Content;
using Gcm.Client;
using TaskList.Droid.Services;
using Gcm;
using System.Net.Http;
using System.Collections.Generic;
using Android.Util;

[assembly: Dependency(typeof(TwitterLoginService))]
namespace Foodie.Droid
{
	public class TwitterLoginService : ILoginProvider
	{
		Context context;

		public void Init(Context context)
		{
			this.context = context;

			// Push notification registration
			try
			{
				GcmClient.CheckDevice(this.context);
				GcmClient.CheckManifest(this.context);

				GcmClient.Register(this.context, GcmHandler.SenderId);
			}
			catch (Exception ex)
			{

			}
		}

		public async Task Login(MobileServiceClient client)
		{
			await client.LoginAsync(context, "twitter");
		}

		public async Task RegisterForPushNotifications(MobileServiceClient client)
		{
			if (GcmClient.IsRegistered(this.context))
			{
				try
				{
					var registrationId = GcmClient.GetRegistrationId(this.context);
					var push = client.GetPush();
					await push.RegisterAsync(registrationId);


					var installation = new DeviceInstallation
					{
						InstallationId = client.InstallationId,
						Platform = "gcm",
						PushChannel = registrationId
					};
					// Set up tags to request
					installation.Tags.Add("new-recipes");
					// Set up templates to request
					PushTemplate genericTemplate = new PushTemplate
					{
						Body = @"{""data"":{""message"":""$(message)""}}"
					};
					installation.Templates.Add("genericTemplate", genericTemplate);

					// Register with NH
					var response = await client.InvokeApiAsync<DeviceInstallation, DeviceInstallation>(
						$"/push/installations/{client.InstallationId}",
						installation,
						HttpMethod.Put,
						new Dictionary<string, string>());
				}
				catch (Exception ex)
				{
					Log.Error("DroidPlatformProvider", $"Could not register with NH: {ex.Message}");
				}
			}
			else
			{
				Log.Error("DroidPlatformProvider", $"Not registered with FCM");
			}
		}
	}
}
