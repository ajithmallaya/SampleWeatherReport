using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WeatherReport.Web.Configurations;

namespace WeatherReport.Web.Helper
{

    public interface IApiHelper
    {
        HttpResponseMessage ExecuteApiCallAsync(string url,IDictionary<string, string> headers = null);
   }

    public class ApiHelper : EndPointResolver, IApiHelper
    {
        private readonly HttpClient _client;
        public ApiHelper(HttpClient client) : base("Api.WeatherReport")
        {
            _client = client;
        }
        public HttpResponseMessage ExecuteApiCallAsync(string url, IDictionary<string, string> headers= null)
        {

            _client.BaseAddress = new Uri(url);

            var response = _client.GetAsync($"{BaseAddress}{url}").Result;

            if (response.IsSuccessStatusCode)
            {
               return response;
            }

            return null;
        }
   }
}