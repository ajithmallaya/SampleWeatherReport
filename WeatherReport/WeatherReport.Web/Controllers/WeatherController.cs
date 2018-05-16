using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WeatherReport.Web.Models;
using WeatherReport.Web.Services;

namespace WeatherReport.Web.Controllers
{
    public class WeatherController : ApiController
    {
        private readonly IWeatherService _weatherService;
        public WeatherController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [Route("GetWeather/{country}/{city}")]
        [ResponseType(typeof(GetWeatherResponse))]
        public HttpResponseMessage GetWeather(string country, string city)
        {

            return  Request.CreateResponse(_weatherService.GetWeather(country, city));
        }

        [Route("(GetGeoLocations")]
        [ResponseType(typeof(GetGeoLocationsResponse))]
        public HttpResponseMessage GetCitiesByCountry()
        {
            return Request.CreateResponse(_weatherService.GetGeoLocations());
        }
    }
}