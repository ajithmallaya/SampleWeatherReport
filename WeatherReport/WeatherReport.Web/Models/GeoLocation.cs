using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherReport.Web.Models
{
    public class GeoLocation
    {
        public string Country { get; set; }
        public int Id { get; set; }
        public List<City> Cities { get; set; }
    }

    public class City
    {
        public string Name { get; set; }
        public int Id { get; set; }
    }
}