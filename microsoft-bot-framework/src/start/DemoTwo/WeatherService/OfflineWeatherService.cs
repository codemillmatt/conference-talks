using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherService
{
    public class OfflineWeatherService : IWeatherService
    {
        public async Task<WeatherInfo> GetCurrentConditions(double latitude, double longitude)
        {
            await Task.Delay(10);

            var wi = new WeatherInfo() { CurrentTemp = 57.2, ForecastDate = DateTimeOffset.Now, Summary = "Partly Cloudy" };

            return wi;
        }
    }
}
