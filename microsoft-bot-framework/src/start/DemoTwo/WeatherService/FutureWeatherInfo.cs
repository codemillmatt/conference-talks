using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherService
{
    public class FutureWeatherInfo : WeatherInfo
    {
        public double MaxTemp { get; set; }
        public double MinTemp { get; set; }
    }
}
