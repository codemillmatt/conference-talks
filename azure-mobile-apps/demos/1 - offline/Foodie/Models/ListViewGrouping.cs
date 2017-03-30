using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
namespace Foodie
{
	public class ListViewGrouping<T> : ObservableCollection<T>
	{
		public string Title
		{
			get;
			set;
		}

		public string ShortName
		{
			get;
			set;
		}

		public ListViewGrouping(string title, string shortName)
		{
			Title = title;
			ShortName = shortName;
		}
	}

	public static class ObservableCollectionExtensions
	{
		public static void AddRange<T>(this ObservableCollection<T> collection, IEnumerable<T> toAdd)
		{
			foreach (var item in toAdd)
			{
				collection.Add(item);
			}
		}
	}
}
