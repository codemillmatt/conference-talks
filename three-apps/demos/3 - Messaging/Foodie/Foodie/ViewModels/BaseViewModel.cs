using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Foodie
{
	public class BaseViewModel : INotifyPropertyChanged
	{
		protected const string RecipeSavedMessage = "recipesaved";

		public event PropertyChangedEventHandler PropertyChanged;

		protected void OnPropertyChanged([CallerMemberName]string propertyName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
