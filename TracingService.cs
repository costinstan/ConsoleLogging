using OpenTelemetry;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace OpenTelemetryConsoleApp
{
    public static class TracingService
    {
        public static TracerProvider SetupTracerProvider()
        {
            return Sdk.CreateTracerProviderBuilder()
                .AddSource("MyApp")
                .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("MyService"))
                .AddConsoleExporter()
                .Build();
        }
    }
}
