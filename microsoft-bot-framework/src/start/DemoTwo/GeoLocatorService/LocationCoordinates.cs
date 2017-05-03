using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoLocatorService
{
    public class CoordinateInfo
    {
        public string CityName { get; set; }
        public string State { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public string CityState { get { return $"{CityName}, {State}"; } }
    }
}
