using Xamarin.Forms;
using System.Linq.Expressions;

namespace Foodie
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			//MainPage = new NavigationPage(new EditRecipePage());
			MainPage = new NavigationPage(new RecipeListPage());
			//MainPage = new NavigationPage(new RecipeDetailPage());
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
