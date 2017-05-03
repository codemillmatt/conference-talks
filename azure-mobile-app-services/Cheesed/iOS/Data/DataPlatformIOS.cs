using System;
using System.IO;
using SQLite.Net.Interop;
using SQLite.Net.Platform.XamarinIOS;
using Xamarin.Forms;

[assembly: Dependency(typeof(Cheesed.Local.iOS.DataPlatformIOS))]
namespace Cheesed.Local.iOS
{
	
	public class DataPlatformIOS : IPlatform
	{
		public DataPlatformIOS ()
		{
		}

		#region IPlatform implementation

		public string DatabasePath {
			get {
				return Path.Combine (Environment.GetFolderPath (Environment.SpecialFolder.Personal), "cheese.db3");
			}
		}

		public ISQLitePlatform OSPlatform {
			get {
				return new SQLitePlatformIOS ();
			}
		}

		#endregion
	}
}

