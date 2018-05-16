using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeatherReport.Web.Models;

namespace WeatherReport.Web.Mock
{
    public static class WeatherReportBluePrint
    {

        public static  List<Weather> GetWeatherData()
        {
            return new List<Weather>
            {
                new Weather
                {
                    Country = "Australia",
                    City =  new City() { Name = "Sydney" },
                    Time = "4:53 pm",
                    Wind = "ENE 11km/h",
                    Visibility = "9mi",
                    SkyConditions = "Clear Dark Sky",
                    Temperature = "19.9°C",
                    DewPoint = "4.0°C",
                    RelativeHumidity = "35%",
                    Pressure = "1003.3hPa"
                },

                new Weather
                {
                    Country = "Australia",
                    City =  new City() { Name = "Melbourne" },
                    Time = "4:53 pm",
                    Wind = "ENE 11km/h",
                    Visibility = "9mi",
                    SkyConditions = "Clear Dark Sky",
                    Temperature = "19.9°C",
                    DewPoint = "4.0°C",
                    RelativeHumidity = "35%",
                    Pressure = "1003.3hPa"
                },

                new Weather
                {
                    Country = "Australia",
                    City =  new City() { Name = "Brisbane" },
                    Time = "4:53 pm",
                    Wind = "ENE 11km/h",
                    Visibility = "9mi",
                    SkyConditions = "Clear Dark Sky",
                    Temperature = "19.9°C",
                    DewPoint = "4.0°C",
                    RelativeHumidity = "35%",
                    Pressure = "1003.3hPa"
                },

                new Weather
                {
                    Country = "Australia",
                    City =  new City() { Name = "Canberra" },
                    Time = "4:53 pm",
                    Wind = "ENE 11km/h",
                    Visibility = "9mi",
                    SkyConditions = "Clear Dark Sky",
                    Temperature = "19.9°C",
                    DewPoint = "4.0°C",
                    RelativeHumidity = "35%",
                    Pressure = "1003.3hPa"
                },

                new Weather
                {
                    Country = "US",
                    City =  new City() { Name = "NewYork" },
                    Time = "4:53 pm",
                    Wind = "ENE 11km/h",
                    Visibility = "9mi",
                    SkyConditions = "Clear Dark Sky",
                    Temperature = "19.9°C",
                    DewPoint = "4.0°C",
                    RelativeHumidity = "35%",
                    Pressure = "1003.3hPa"
                },
                new Weather
                {
                    Country = "UK",
                    City =  new City() { Name = "London" },
                    Time = "4:53 pm",
                    Wind = "ENE 11km/h",
                    Visibility = "9mi",
                    SkyConditions = "Clear Dark Sky",
                    Temperature = "19.9°C",
                    DewPoint = "4.0°C",
                    RelativeHumidity = "35%",
                    Pressure = "1003.3hPa"
                },

                new Weather
                {
                    Country = "UK",
                    City =  new City() { Name = "Norwich" },
                    Time = "4:53 pm",
                    Wind = "ENE 11km/h",
                    Visibility = "9mi",
                    SkyConditions = "Clear Dark Sky",
                    Temperature = "19.9°C",
                    DewPoint = "4.0°C",
                    RelativeHumidity = "35%",
                    Pressure = "1003.3hPa"
                },

                new Weather
                {
                    Country = "UK",
                    City =  new City() { Name = "Sydney" },
                    Time = "4:53 pm",
                    Wind = "ENE 11km/h",
                    Visibility = "9mi",
                    SkyConditions = "Clear Dark Sky",
                    Temperature = "19.9°C",
                    DewPoint = "4.0°C",
                    RelativeHumidity = "35%",
                    Pressure = "1003.3hPa"
                },

                new Weather
                {
                    Country = "US",
                    City =  new City() { Name = "London" },
                    Time = "4:53 pm",
                    Wind = "ENE 11km/h",
                    Visibility = "9mi",
                    SkyConditions = "Clear Dark Sky",
                    Temperature = "19.9°C",
                    DewPoint = "4.0°C",
                    RelativeHumidity = "35%",
                    Pressure = "1003.3hPa"
                },

                new Weather
                {
                    Country = "US",
                    City =  new City() { Name = "Chicago" },
                    Time = "4:53 pm",
                    Wind = "ENE 11km/h",
                    Visibility = "9mi",
                    SkyConditions = "Clear Dark Sky",
                    Temperature = "19.9°C",
                    DewPoint = "4.0°C",
                    RelativeHumidity = "35%",
                    Pressure = "1003.3hPa"
                }

            };
        }
    }
}