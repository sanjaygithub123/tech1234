using System;
using Pms.Core.Logging;
using Serilog.Context;

namespace ProductMicroservice.Logging
{
    public class SerilogLogger : ILogger
    {
        private const string ExceptionFormat = "{0} || {1}";
        private readonly Serilog.ILogger _serilogLogger;

        public SerilogLogger(Serilog.ILogger serilogLogger)
        {
            _serilogLogger = serilogLogger;
        }

        public void Debug(string callingAssemblyName, LoggingEvent loggingEvent, string message)
            => GetEnrichedLogger(callingAssemblyName, loggingEvent, LogLevel.Debug, true).Debug(message);

        // public void Error(Exception exception, string message) => _serilogLogger
        //     .ForContext("Tx", HandlerContext.Request.TransactionId ?? string.Empty)
        //     .ForContext("User", HandlerContext.Request.UserInfo?.Id ?? string.Empty)
        //     .ForContext("Sev", LogLevel.Error.ToString().ToUpper())
        //     .ForContext("Index", "true")
        //     .Error(string.Format(ExceptionFormat, message, exception.ToString().Replace(Environment.NewLine,
        //      " || ", StringComparison.OrdinalIgnoreCase)));

        // public void Fatal(Exception exception, string message) => _serilogLogger
        //     .ForContext("Tx", HandlerContext.Request.TransactionId ?? string.Empty)
        //     .ForContext("User", HandlerContext.Request.UserInfo?.Id ?? string.Empty)
        //     .ForContext("Sev", LogLevel.Emergency.ToString().ToUpper())
        //     .ForContext("Index", "true")
        //     .Fatal(string.Format(ExceptionFormat, message, exception.ToString().Replace(Environment.NewLine,
        //      " || ", StringComparison.OrdinalIgnoreCase)));

        public void Information(string callingAssemblyName, LoggingEvent loggingEvent, string message)
            => GetEnrichedLogger(callingAssemblyName, loggingEvent, LogLevel.Info, true).Information(message);

        public bool IsEnabled(LogEventLevel logEventLevel)
        {
            var serilogLogLevel = logEventLevel switch
            {
                LogEventLevel.Verbose => Serilog.Events.LogEventLevel.Verbose,
                LogEventLevel.Debug => Serilog.Events.LogEventLevel.Debug,
                LogEventLevel.Warning => Serilog.Events.LogEventLevel.Warning,
                LogEventLevel.Error => Serilog.Events.LogEventLevel.Error,
                LogEventLevel.Fatal => Serilog.Events.LogEventLevel.Fatal,
                LogEventLevel.Information => Serilog.Events.LogEventLevel.Information,
                _ => Serilog.Events.LogEventLevel.Information,
            };
            return _serilogLogger.IsEnabled(serilogLogLevel);
        }

        public IDisposable AddContextProperty(string name, object value) => LogContext.PushProperty(name, value);

        public void Verbose(string callingAssemblyName, LoggingEvent loggingEvent, string message)
            => GetEnrichedLogger(callingAssemblyName, loggingEvent, LogLevel.Notice, true).Verbose(EscapeBraces(message));

        public void Warning(string callingAssemblyName, LoggingEvent loggingEvent, string message)
            => GetEnrichedLogger(callingAssemblyName, loggingEvent, LogLevel.Warning, true).Warning(message);

        private static string EscapeBraces(string message) => message.Replace("{", "{{", StringComparison.Ordinal).Replace("}", "}}", StringComparison.Ordinal);

        private Serilog.ILogger GetEnrichedLogger(string callingAssemblyName, LoggingEvent loggingEvent, LogLevel logLevel, bool shouldIndex)
            => _serilogLogger.ForContext("SourceContext", callingAssemblyName)
            .ForContext("Event", loggingEvent)
            .ForContext("Tx", string.Empty)
            .ForContext("User", string.Empty)
            .ForContext("Sev", logLevel.ToString().ToUpper())
            .ForContext("Index", shouldIndex.ToString().ToLower());
    }
}