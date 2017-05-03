using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoLocatorService
{
    public class OfflineGeoService : IGeoService
    {
        public async Task<List<CoordinateInfo>> FindCoordinates(string locationName)
        {
            await Task.Delay(10);

            var desMoinesIA = new CoordinateInfo()
            {
                CityName = "Des Moines",
                Latitude = 123.1,
                Longitude = 321.1,
                State = "IA"
            };

            var desMoinesWA = new CoordinateInfo()
            {
                CityName = "Des Moines",
                Latitude = 123,
                Longitude = 21,
                State = "WA"
            };

            var desMoinesNM = new CoordinateInfo()
            {
                CityName = "des Moines",
                Latitude = 31,
                Longitude = 14,
                State = "NM"
            };

            var ci = new CoordinateInfo[] { desMoinesWA, desMoinesWA, desMoinesIA };
            return ci.ToList();
        }
    }
}
