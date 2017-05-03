using System;

using Xamarin.Forms;

namespace RxBLE
{
	public class App : Application
	{
		public App ()
		{
			var hiveList = new HiveList ();

			MainPage = new NavigationPage (hiveList){
				BarBackgroundColor = Color.FromHex("208000"),
				BarTextColor = Color.White
			};
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

