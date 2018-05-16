using System;

namespace WeatherReport.Web.Exceptions
{
    public class WeatherReportException : ApplicationException
    {
        public WeatherReportException(bool isFatal, string operation, Exception exception)
            : base($"WeatherReport error encountered - isFatal: { isFatal } | operation: { operation }", exception)
        {
        }
    }
}