using System;

using Xamarin.Forms;

namespace Cheesed.Local
{
	public class App : Application
	{
		public App ()
		{
			RecentRatingsView ratingsPage = new RecentRatingsView ();
				
			MainPage = new NavigationPage (ratingsPage);
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

