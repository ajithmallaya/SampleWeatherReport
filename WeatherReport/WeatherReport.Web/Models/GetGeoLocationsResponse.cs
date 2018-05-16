using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherReport.Web.Models
{
    public class GetGeoLocationsResponse
    {
        public List<GeoLocation> GeoLocations { get; set; }
    }
}