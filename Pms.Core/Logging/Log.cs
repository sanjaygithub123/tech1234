using System;
using System.Reflection;

namespace Pms.Core.Logging
{
    public static class Log
    {
        private static ILogger _logger;

        public static void Construct(ILogger logger)
        {
            _logger = logger;
        }

        public static void Debug(LoggingEvent loggingEvent, string message)
        {
            string callingAssemblyName = Assembly.GetCallingAssembly().GetName().Name;

            _logger.Debug(callingAssemblyName, loggingEvent, message);
        }

        //public static void Error(Exception exception, string message) => _logger.Error(exception, message);

       // public static void Fatal(Exception exception, string message) => _logger.Fatal(exception, message);

        public static void Information(LoggingEvent loggingEvent, string message)
        {
            string callingAssemblyName = Assembly.GetCallingAssembly().GetName().Name;

            _logger.Information(callingAssemblyName, loggingEvent, message);
        }

        public static bool IsEnabled(LogEventLevel logEventLevel) => _logger.IsEnabled(logEventLevel);

        public static void Verbose(LoggingEvent loggingEvent, string message)
        {
            string callingAssemblyName = Assembly.GetCallingAssembly().GetName().Name;

            _logger.Verbose(callingAssemblyName, loggingEvent, message);
        }

        public static void Warning(LoggingEvent loggingEvent, string message)
        {
            string callingAssemblyName = Assembly.GetCallingAssembly().GetName().Name;

            _logger.Warning(callingAssemblyName, loggingEvent, message);
        }

        public static IDisposable AddContextProperty(string name, object value) => _logger.AddContextProperty(name, value);
    }
}
