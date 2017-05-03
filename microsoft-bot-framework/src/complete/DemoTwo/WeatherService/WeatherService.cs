using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DarkSkyApi.Models;
using DarkSkyApi;

namespace WeatherService
{
    public class WeatherService
    {
        public enum PrecipitationTypes
        {
            [Description("rain")]
            Rain,
            [Description("snow")]
            Snow,
            [Description("sleet")]
            Sleet
        } 

        public async Task<WeatherInfo> GetCurrentConditions(double lat, double longitude)
        {
            var forecast = await GetDarkSkyForecast(lat, longitude); 

            var info = new WeatherInfo();
            info.CurrentTemp = Math.Ceiling(forecast.Currently.ApparentTemperature);
            info.ForecastDate = forecast.Currently.Time;
            info.Icon = forecast.Currently.Icon;
            info.PrecipitationType = forecast.Currently.PrecipitationType;
            info.Summary = forecast.Currently.Summary;

            return info;
        }

        public async Task<FutureWeatherInfo> GetConditionsForDate(double lat, double longitude, DateTimeOffset date)
        {
            var forecast = await GetDarkSkyForecast(lat, longitude);

            var theDate = forecast.Daily.Days.First(d => d.Time.Equals(date));

            var info = new FutureWeatherInfo()
            {
                MaxTemp = Math.Ceiling(theDate.ApparentMaxTemperature),
                MinTemp = Math.Ceiling(theDate.ApparentMinTemperature),
                ForecastDate = theDate.Time,
                Icon = theDate.Icon,
                PrecipitationType = theDate.PrecipitationType,
                Summary = theDate.Summary
            };

            return info;
        }

        private static async Task<Forecast> GetDarkSkyForecast(double lat, double longitude)
        {
            var ds = new DarkSkyService("");
            var forecast = await ds.GetWeatherDataAsync(lat, longitude);
            return forecast;
        }

        public async Task<DateTimeOffset> WhenWillItPrecipitateNext(double lat, double longitude, PrecipitationTypes precipType)
        {
            var forecast = await GetDarkSkyForecast(lat, longitude);

            var theDate = forecast.Daily.Days.FirstOrDefault(ddp => ddp.PrecipitationType.Equals(precipType.ToString()));

			return theDate?.Time ?? DateTimeOffset.MinValue;
        }
    }
}
