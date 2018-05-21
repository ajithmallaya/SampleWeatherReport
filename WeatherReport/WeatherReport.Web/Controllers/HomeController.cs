using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Helpers;
using System.Web.Http.Description;
using System.Web.Mvc;
using WeatherReport.Web.Helper;
using WeatherReport.Web.Models;
using WeatherReport.Web.Services;

namespace WeatherReport.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWeatherService _weatherService;

        public HomeController()
        {
            _weatherService = new WeatherService(new ApiHelper(new HttpClient()));
        }
        public HomeController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [HttpGet]
        [Route("Weather/{country}/{city}")]
        public JsonResult GetWeather(string country, string city)
        {
            var data = _weatherService.GetWeather(country, city);
            return Json(new { data = data}, JsonRequestBehavior.AllowGet );
        }

        public ActionResult Index()
        {
            var geoLocationsResponse = _weatherService.GetGeoLocations();
            return View(geoLocationsResponse);
        }
    }
}