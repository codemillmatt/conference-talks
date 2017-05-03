using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using GeoLocatorService;

namespace DemoTwo.Dialogs
{
	[Serializable]
	public class LocationDialog : IDialog<string>
	{
		public async Task StartAsync(IDialogContext context)
		{
			context.Wait<List<CoordinateInfo>>(MessageReceived);
		}

		public async Task MessageReceived(IDialogContext context, IAwaitable<List<CoordinateInfo>> coordinates)
		{
			// Wait for the incoming
			var theCoords = await coordinates;

			var allCities = new List<string>();
			foreach (var city in theCoords)
			{
				allCities.Add(city.CityState);
			}

			PromptDialog.Choice<string>(context, PromptDone, allCities, "Multiple matching cities found, pick one:",
				"I didn't get that, please enter that again", 2);
		}

		public async Task PromptDone(IDialogContext context, IAwaitable<string> cityName)
		{
			var city = await cityName;

			context.Done(city);
		}
	}
}