using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherReport.Web.Exceptions;
using WeatherReport.Web.Helper;
using WeatherReport.Web.Mock;
using WeatherReport.Web.Models;

namespace WeatherReport.Web.Services
{
    public interface IWeatherService
    {
         GetWeatherResponse GetWeather(string country, string city);
        GetGeoLocationsResponse GetGeoLocations();
    }
    public class WeatherService : IWeatherService
    {
        private readonly IApiHelper _apiHelper;
        private readonly string _isMockedResponse;
        public WeatherService(IApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
            _isMockedResponse = ConfigurationManager.AppSettings["IsMockedResponse"]; //Actual Weather Api not working

        }
        public GetWeatherResponse GetWeather(string country, string city)
        {
            try
            {
                if (_isMockedResponse.Equals("false"))
                {
                    var urlpath = $"?op=GetWeather&&country={country}&&city={city}";
                    var response = _apiHelper.ExecuteApiCallAsync(urlpath);

                    return new GetWeatherResponse()
                    {
                        WeatherModel = response.Content.ReadAsAsync<Weather>().Result
                    };
                }

                return new GetWeatherResponse()
                {
                    WeatherModel = WeatherReportBluePrint.GetWeatherData().FirstOrDefault(x => x.Country.ToLower().Equals(country.ToLower()) && x.City.Name.ToLower().Equals(city.ToLower()))
                };
            }
            catch (Exception ex)
            {
                throw new  WeatherReportException(true, "GetWeatherAsync",ex);
            }
        }

        public GetGeoLocationsResponse GetGeoLocations()
        {
            try
            {
                if (_isMockedResponse.Equals("false"))
                {
                    var urlpath = $"?op=GetGeoLocations";
                    var response = _apiHelper.ExecuteApiCallAsync(urlpath);

                    return new GetGeoLocationsResponse()
                    {
                        GeoLocations =
                            response.EnsureSuccessStatusCode().Content.ReadAsAsync<List<GeoLocation>>().Result
                    };
                }

                return new GetGeoLocationsResponse()
                {
                    GeoLocations = GeoLocationBlueprint.Build()
                };

            }
            catch (Exception ex)
            {
                throw new WeatherReportException(true, "GetCitiesByCountry", ex);
            }
        }
    }
}