using System;
using System.Windows.Input;
using Xamarin.Forms;
using System.Threading.Tasks;
using Foodie.Abstractions;
namespace Foodie
{
	public class LoginViewModel : BaseViewModel
	{
		public LoginViewModel()
		{
		}

		public ICommand LoginCommand => new Command(async () => await Login());

		async Task Login()
		{
			try
			{
				var azureSvc = DependencyService.Get<IAzureService>(DependencyFetchTarget.GlobalInstance);

				await azureSvc.Login();

				if (Device.OS == TargetPlatform.Android)
				{
					// Droid needs a bit to recover from the server-flow option being shown
					await Task.Delay(1000);
				}

				App.Current.MainPage = new NavigationPage(new RecipeListPage());
			}
			catch (Exception ex)
			{
				await App.Current.MainPage.DisplayAlert("Error", "Bad login", "OK");

				System.Diagnostics.Debug.WriteLine(ex.ToString());
			}
		}
	}
}
