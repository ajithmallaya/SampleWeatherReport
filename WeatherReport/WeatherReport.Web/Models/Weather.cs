namespace WeatherReport.Web.Models
{
    public class Weather
    {
        public string Country { get; set; }
        public string CountryId { get; set; }
        public City City { get; set; }
        public string Time { get; set; }
        public string Wind { get; set; }
        public string Visibility { get; set; }
        public string SkyConditions { get; set; }
        public string Temperature { get; set; }
        public string DewPoint { get; set; }
        public string RelativeHumidity { get; set; }
        public string Pressure { get; set; }
    }
}