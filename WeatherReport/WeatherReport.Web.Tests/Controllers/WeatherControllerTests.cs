using System.Configuration;
using System.Linq;
using System.Net.Http;
using WeatherReport.Web.Helper;
using WeatherReport.Web.Services;
using NSubstitute;
using NUnit.Framework;
using WeatherReport.Web.Controllers;
using WeatherReport.Web.Models;
using System.Web.Mvc;
using WeatherReport.Web.Exceptions;

namespace WeatherReport.Web.Tests.Controllers
{
    [TestFixture]
    class WeatherControllerTests
    {
        private IWeatherService _weatherService;
        private IApiHelper _apiHelper;
        private HomeController _weatherController;
        [SetUp]
        public void SetUp()
        {
            _apiHelper = Substitute.For<IApiHelper>();
            _weatherService = new WeatherService(_apiHelper);
            _weatherController = new HomeController(_weatherService);
        }

        [TestCase("Australia", "Sydney")]
        [TestCase("Australia", "Brisbane")]
        [TestCase("UK", "London")]
        [TestCase("US", "Chicago")]
        public void GetWeatherTest(string country, string city)
        {
            var response = _weatherController.GetWeather(country, city) as JsonResult;
            Assert.NotNull(response.Data);
            Assert.AreEqual(city, ((GetWeatherResponse)response.Data).WeatherModel.City.Name);
        }

        [TestCase("US")]
       public void GetWeatherTestException(string country)
        {
           Assert.Throws<WeatherReportException>(() => _weatherController.GetWeather(country, null));
        }

        [Test]
        public void GetLocationsTest()
        {
          //  UpdateAppSettings(true);
            _weatherService = new WeatherService(_apiHelper);
            _weatherController = new HomeController(_weatherService);
            var response = _weatherController.Index() as ViewResult;
            Assert.NotNull(((GetGeoLocationsResponse)response.ViewBag.GeoLocationsResponse).GeoLocations);
            Assert.NotNull(((GetGeoLocationsResponse)response.ViewBag.GeoLocationsResponse).GeoLocations.FirstOrDefault()?.Country);
        }

        [Test]
        public void GetLocationsTestWithActualCall()
        {
           // UpdateAppSettings(false);
            _weatherService = new WeatherService(new ApiHelper(Substitute.For<HttpClient>()),false);
            _weatherController = new HomeController(_weatherService);

            //No Proper APi - so exception
            Assert.Throws<WeatherReportException>(() => _weatherController.Index());
        }

    }
}
