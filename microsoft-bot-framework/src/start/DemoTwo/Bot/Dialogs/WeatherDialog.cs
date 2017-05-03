using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using WeatherService;
using GeoLocatorService;
using Autofac;

namespace DemoTwo.Dialogs
{
    [Serializable]
    public class WeatherDialog : IDialog<object>
    {
        //IGeoService _geoService;
        //IWeatherService _weatherService;

        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);
        }

        public async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> argument)
        {
            // Get the message out
            var message = await argument;
            var activityMessage = message as Activity;

            if (activityMessage.MentionsRecipient())
            {
                using (var scope = WebApiApplication.Container.BeginLifetimeScope())
                {
                    var _geoService = scope.Resolve<IGeoService>();
                    var matches = await _geoService.FindCoordinates(activityMessage.RemoveRecipientMention());


                    if (matches.Count > 1)
                    {
                        await context.Forward(new LocationDialog(), LocationPicked, matches, new System.Threading.CancellationToken());
                    }
                    else if (matches.Count == 1)
                    {
                        await DisplayWeather(context, matches[0]);
                        context.Wait(MessageReceivedAsync);
                    }
                    else
                    {
                        await context.PostAsync($"Could not find the weather for {activityMessage.RemoveRecipientMention()}");
                        context.Wait(MessageReceivedAsync);
                    }
                }
            }
            else
            {
                context.Wait(MessageReceivedAsync);
            }
        }

        // Callback for when a location has been picked
        public async Task LocationPicked(IDialogContext context, IAwaitable<string> argument)
        {
            var location = await argument;

            var geo = new GeoLocatorService.GeoService();
            var city = (await geo.FindCoordinates(location)).First();
            await DisplayWeather(context, city);

            context.Wait(MessageReceivedAsync);
        }

        #region Find weather and display

        async Task DisplayWeather(IDialogContext context, GeoLocatorService.CoordinateInfo coord)
        {
            using (var scope = WebApiApplication.Container.BeginLifetimeScope())
            {
                var _weatherService = scope.Resolve<IWeatherService>();

                var forecast = await _weatherService.GetCurrentConditions(coord.Latitude, coord.Longitude);

                await context.PostAsync($"The current conditions for {coord.CityState} are {forecast.Summary} and {forecast.CurrentTemp}.");
            }
        }

        #endregion


    }
}