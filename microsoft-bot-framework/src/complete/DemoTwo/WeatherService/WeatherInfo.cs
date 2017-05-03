using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherService
{
    public class WeatherInfo
    {
        public double CurrentTemp { get; set; }
        public string Summary { get; set; }
        public string Icon { get; set; }
        public string PrecipitationType { get; set; }
        public DateTimeOffset ForecastDate { get; set; }
    }
}
