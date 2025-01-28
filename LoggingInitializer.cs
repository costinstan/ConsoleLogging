using System;
using Microsoft.Extensions.Logging;

namespace OpenTelemetryConsoleApp
{
    public static class LoggingService
    {
        public static ILogger CreateLogger<T>()
        {
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
                builder.AddOpenTelemetry();
            });

            return loggerFactory.CreateLogger<T>();
        }

        public static void LogInformation(ILogger logger, string message)
        {
            logger.LogInformation(message);
        }
    }
}
