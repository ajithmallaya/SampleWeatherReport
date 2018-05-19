using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http.Description;
using System.Web.Mvc;
using WeatherReport.Web.Models;
using WeatherReport.Web.Services;

namespace WeatherReport.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWeatherService _weatherService;
        public HomeController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [System.Web.Http.Route("GetWeather/{country}/{city}")]
        public ActionResult GetWeather(string country, string city)
        {

            return new JsonResult()
            {
                Data = _weatherService.GetWeather(country, city)
            };
        }

        public ActionResult Index()
        {
            ViewBag.GeoLocationsResponse = _weatherService.GetGeoLocations();
            return View("_Layout");
        }
    }
}