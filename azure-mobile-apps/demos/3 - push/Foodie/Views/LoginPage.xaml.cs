using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Foodie
{
	public partial class LoginPage : ContentPage
	{
		public LoginPage()
		{
			InitializeComponent();

			BindingContext = new LoginViewModel();
		}
	}
}
