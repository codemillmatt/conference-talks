using Xamarin.Forms;
using System.Linq.Expressions;
using System;
using System.Linq;
using Newtonsoft.Json;

namespace Foodie
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			MainPage = new NavigationPage(new RecipeListPage());
		}

		protected override void OnStart()
		{
			// Make sure there are recipes to display
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Make sure there are recipes to display
		}
	}
}
