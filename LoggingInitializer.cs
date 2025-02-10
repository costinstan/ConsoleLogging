using System;
using Microsoft.Extensions.Logging;
using OpenTelemetry;
using OpenTelemetry.Logs;
using OpenTelemetry.Resources;

namespace OpenTelemetryConsoleApp
{
    public static class LoggingService
    {
        public static ILogger CreateLogger<T>()
        {
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
                builder.AddOpenTelemetry(
                    options =>
                    {
                        options.SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("MatrixLogging"))
                        .AddProcessor(new SimpleLogRecordExportProcessor(new FileExporter("logFile.txt")));
                    });
            });

            return loggerFactory.CreateLogger<T>();
        }

        public static void LogInformation(ILogger logger, string message)
        {
            logger.LogInformation(message);
        }
    }
}
