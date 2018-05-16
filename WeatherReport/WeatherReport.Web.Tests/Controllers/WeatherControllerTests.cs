using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WeatherReport.Web.Helper;
using WeatherReport.Web.Services;
using NSubstitute;
using NUnit.Framework;
using WeatherReport.Web.Controllers;
using WeatherReport.Web.Models;
using System.Web.Http;
using WeatherReport.Web.Exceptions;

namespace WeatherReport.Web.Tests.Controllers
{
    [TestFixture]
    class WeatherControllerTests
    {
        private IWeatherService _weatherService;
        private IApiHelper _apiHelper;
        private WeatherController _weatherController;
        [SetUp]
        public void SetUp()
        {
            _apiHelper = Substitute.For<IApiHelper>();
            _weatherService = new WeatherService(_apiHelper);
            _weatherController = new WeatherController(_weatherService)
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration() 
            };
        }

        [TestCase("Australia", "Sydney")]
        [TestCase("Australia", "Brisbane")]
        [TestCase("UK", "London")]
        [TestCase("US", "Chicago")]
        public void GetWeatherTest(string country, string city)
        {
            var response = _weatherController.GetWeather(country, city);
            Assert.NotNull(response.Content.ReadAsAsync<GetWeatherResponse>().Result.WeatherModel.Temperature);
            Assert.AreEqual(city, response.Content.ReadAsAsync<GetWeatherResponse>().Result.WeatherModel.City.Name.ToString());
        }

        [TestCase("US")]
       public void GetWeatherTestException(string country)
        {
           Assert.Throws<WeatherReportException>(() => _weatherController.GetWeather(country, null));
        }

        [Test]
        public void GetLocationsTest()
        {
            var response = _weatherController.GetCitiesByCountry();
            Assert.NotNull(response.Content.ReadAsAsync<GetGeoLocationsResponse>().Result.GeoLocations);
            Assert.NotNull(response.Content.ReadAsAsync<GetGeoLocationsResponse>().Result.GeoLocations.FirstOrDefault()?.Country);
        }

        [Test]
        public void GetLocationsTestWithActualCall()
        {
            UpdateAppSettings();
            _weatherService = new WeatherService(new ApiHelper(Substitute.For<HttpClient>()));
            _weatherController = new WeatherController(_weatherService)
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            //No Proper APi - so exception
            Assert.Throws<WeatherReportException>(() => _weatherController.GetCitiesByCountry());
        }

        private static void UpdateAppSettings()
        {
           Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            AppSettingsSection csSection = config.AppSettings;

            csSection.Settings.Remove("IsMockedResponse");
            csSection.Settings.Add("IsMockedResponse", "false");
            config.Save(ConfigurationSaveMode.Modified);

            ConfigurationManager.RefreshSection("AppSettings");
        }

    }
}
