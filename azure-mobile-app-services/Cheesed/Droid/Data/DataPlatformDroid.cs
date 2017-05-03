using System;
using System.IO;
using SQLite.Net.Interop;
using SQLite.Net.Platform.XamarinAndroid;
using Xamarin.Forms;

[assembly: Dependency(typeof(Cheesed.Local.Droid.DataPlatformDroid))]
namespace Cheesed.Local.Droid
{	
	public class DataPlatformDroid : IPlatform
	{
		public DataPlatformDroid ()
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
				return new SQLitePlatformAndroid ();
			}
		}

		#endregion
	}
}

