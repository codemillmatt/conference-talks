using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherService
{
    public interface IWeatherService
    {
        Task<WeatherInfo> GetCurrentConditions(double latitude, double longitude);
    }
}
