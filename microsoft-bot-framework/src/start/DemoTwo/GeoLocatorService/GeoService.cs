using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeocodeSharp.Google;
using GeocodeSharp;
using System.Net;

namespace GeoLocatorService
{
    public class GeoService : IGeoService
    {
        public async Task<List<CoordinateInfo>> FindCoordinates(string locationName)
        {
            var locationResults = new List<CoordinateInfo>();

            var client = new GeocodeClient(new OldGoogleForwarderProxy(), "");

            // we only want US addresses
            var countryFilter = new ComponentFilter()
            {
                Country = "US"
            };

            // Let Google figure out the geocoded address
            var geocodedResults = await client.GeocodeAddress(locationName, null, countryFilter);

            // Only do something if Google says we're OK
            if (geocodedResults.Status == GeocodeStatus.Ok)
            {
                // Make sure the results are based on a city name
                var allCityResults = geocodedResults.Results.Where(gr => gr.PartialMatch == false && gr.Types.Any(t => t.Equals("locality")));

                // Build up the locationResults list
                foreach (var city in allCityResults)
                {
                    // Grab the lat & long
                    var coordInfo = new CoordinateInfo() { Latitude = city.Geometry.Location.Latitude, Longitude = city.Geometry.Location.Longitude };

                    // Grab the city & state name out from the address component of the results
                    coordInfo.CityName = city.AddressComponents.First(ac => ac.Types.Any(t => t.Equals("locality"))).ShortName;
                    coordInfo.State = city.AddressComponents.First(ac => ac.Types.Any(t => t.Equals("administrative_area_level_1"))).ShortName;

                    locationResults.Add(coordInfo);
                }
            }

            return locationResults;
        }


        internal class OldGoogleForwarderProxy : IGeocodeProxyProvider
        {
            public HttpWebRequest CreateRequest(string url)
            {
                url = $"{url}&new_forward_geocoder=false";

                return WebRequest.CreateHttp(url);
            }
        }
    }
}
