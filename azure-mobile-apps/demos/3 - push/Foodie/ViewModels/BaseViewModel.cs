using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
namespace Foodie
{
	public class BaseViewModel : INotifyPropertyChanged
	{
		internal const string RecipeSavedMessage = "RecipeSaved";

		public event PropertyChangedEventHandler PropertyChanged;

		public void OnPropertyChanged(string memberName) => 
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberName));

        protected void SetProperty<T>(ref T orig, T value, [CallerMemberName]string  propertyName = "")
        {
            orig = value;

            OnPropertyChanged(propertyName);
        }

        bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set { SetProperty(ref _isBusy, value, nameof(IsBusy)); }
        }
	}
}
