using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeatherReport.Web.Models;

namespace WeatherReport.Web.Mock
{
    public  static class GeoLocationBlueprint
    {
        public static List<GeoLocation> Build()
        {
            List<GeoLocation> locations = BuildMultipleGeoLocations();
            locations.Add(BuildSingleLocation("Australia", "Canberra"));
            locations.Add(BuildSingleLocation("UK", "London"));
            locations.Add(BuildSingleLocation("UK", "Norwich"));
            locations.Add(BuildSingleLocation("UK", "Sydney"));
            return locations;
        }
        private static GeoLocation BuildSingleLocation(string country,string city)
        {
            return new GeoLocation()
            {
                Country = country,
                Cities = new List<City>()
                {
                    new City()
                    {
                        Name  = city
                    }
                }
            };
        }

        public static List<GeoLocation> BuildMultipleGeoLocations()
        {
            return new List<GeoLocation>()
            {
                new GeoLocation()
                {
                    Country = "Australia",
                    Id =1,
                    Cities = new List<City>()
                    {
                        new City()
                        {
                            Id = 1,
                            Name = "Sydney"
                        }
                    }
                },
                new GeoLocation()
                {
                    Country = "US",
                    Id =2,
                    Cities = new List<City>()
                    {
                        new City()
                        {
                            Id = 1,
                            Name = "NewYork"
                        }
                    }
                },
                new GeoLocation()
                {
                    Country = "Australia",
                    Id =1,
                    Cities = new List<City>()
                    {
                        new City()
                        {
                            Id = 2,
                            Name = "Melbourne"
                        }
                    }
                },
                new GeoLocation()
                {
                    Country = "US",
                    Id =2,
                    Cities = new List<City>()
                    {
                        new City()
                        {
                            Id = 2,
                            Name = "London"
                        }
                    }
                },
                new GeoLocation()
                {
                    Country = "Australia",
                    Id =1,
                    Cities = new List<City>()
                    {
                        new City()
                        {
                            Id = 3,
                            Name = "Brisbane"
                        }
                    }
                },
                new GeoLocation()
                {
                    Country = "US",
                    Id =2,
                    Cities = new List<City>()
                    {
                        new City()
                        {
                            Id = 3,
                            Name = "Chicago"
                        }
                    }
                }

            };
        }
    }
}