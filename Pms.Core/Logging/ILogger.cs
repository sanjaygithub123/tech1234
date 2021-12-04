using System;

namespace Pms.Core.Logging
{
    public interface ILogger
    {
        void Debug(string callingAssemblyName, LoggingEvent loggingEvent, string message);

        // void Error(Exception exception, string message);

        // void Fatal(Exception exception, string message);

        void Information(string callingAssemblyName, LoggingEvent loggingEvent, string message);

        bool IsEnabled(LogEventLevel logEventLevel);

        void Verbose(string callingAssemblyName, LoggingEvent loggingEvent, string message);

        void Warning(string callingAssemblyName, LoggingEvent loggingEvent, string message);

        IDisposable AddContextProperty(string name, object value);
    }
}
