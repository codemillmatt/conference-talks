using System;

using SQLite.Net.Interop;

namespace Cheesed.Local
{
	public interface IPlatform
	{
		string DatabasePath { get; }
		ISQLitePlatform OSPlatform { get; }
	}
}

