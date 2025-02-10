using System;
using Microsoft.Extensions.Logging;
using OpenTelemetry;
using OpenTelemetry.Trace;

namespace OpenTelemetryConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Set up logging
            ILogger logger = LoggingService.CreateLogger<Program>();

            // Configure OpenTelemetry
            using var tracerProvider = TracingService.SetupTracerProvider();
            var tracer = tracerProvider.GetTracer("MyApp");

            // Start a new span
            using (var span = tracer.StartActiveSpan("Main"))
            {
                LoggingService.LogInformation(logger, "Hello, OpenTelemetry with logging!");
                span.SetAttribute("Telemetry", "OpenTelemetry");

                // Matrix summation example
                int[,] matrix1 = { { 1, 2 }, { 3, 4 } };
                int[,] matrix2 = { { 5, 6 }, { 7, 8 } };
                var matrixOperations = new MatrixOperations(logger);
                int[,] result = matrixOperations.SumMatrices(matrix1, matrix2);

                LoggingService.LogInformation(logger, "Matrix Summation Result:");
                matrixOperations.PrintMatrix(result);
            }

            LoggingService.LogInformation(logger, "Application is running. Press any key to exit...");
            Console.ReadKey();
        }
    }
}
