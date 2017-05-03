using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoLocatorService
{
    public interface IGeoService
    {
        Task<List<CoordinateInfo>> FindCoordinates(string locationName);
    }
}
