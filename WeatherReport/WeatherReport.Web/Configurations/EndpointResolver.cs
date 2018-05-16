using System.Configuration;

namespace WeatherReport.Web.Configurations
{
    interface IEndPointResolver
    {
        string BaseAddress { get; set; }
        string UserName { get; set; }
        string Password { get; set; }
    }

    public class EndPointResolver : IEndPointResolver
    {
        public string BaseAddress { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public EndPointResolver(string configurationKey)
        {
            var configurationString = ConfigurationManager.AppSettings[configurationKey];
            if (configurationString == null)
            {
                throw new ConfigurationErrorsException(
                    string.Format(
                        "An appSetting with the name '{0}' could not be found.",
                        configurationKey));
            }

            var parameters = configurationString.Split(new[] { ';' }, 3);

            if (parameters.Length != 3)
            {
                throw new ConfigurationErrorsException(
                    "The API request configuration string must contain exactly 3 parts (<URL>, UserName, Password).");
            }

            BaseAddress = parameters[0];
            var indexOneKeyValuePair = parameters[1].Split(new[] { '=' }, 2);
            var indexTwoKeyValuePair = parameters[2].Split(new[] { '=' }, 2);

            if (indexOneKeyValuePair.Length == 2 && indexTwoKeyValuePair.Length == 2)
            {
                if (indexOneKeyValuePair[0] == "UserName")
                {
                    UserName = indexOneKeyValuePair[1];
                    Password = indexTwoKeyValuePair[1];
                }
                else if (indexOneKeyValuePair[0] == "Password")
                {
                    UserName = indexTwoKeyValuePair[1];
                    Password = indexOneKeyValuePair[1];
                }
            }
            else
            {
                throw new ConfigurationErrorsException(
                    "The API request configuration string is missing 'UserName' or 'Password'.");
            }
        }
    }
}