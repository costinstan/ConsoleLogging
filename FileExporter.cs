using OpenTelemetry;
using OpenTelemetry.Logs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTelemetryConsoleApp
{
    public class FileExporter : BaseExporter<LogRecord>
    {
        private readonly string _filePath;

        public FileExporter(string filePath)
        {
            _filePath = filePath;
        }

        public override ExportResult Export(in Batch<LogRecord> batch)
        {
            using (var streamWriter = new StreamWriter(_filePath, append: true))
            {
                foreach (var logRecord in batch)
                {
                    streamWriter.WriteLine($"{logRecord.Timestamp}: ${logRecord.FormattedMessage}");
                }
            }
            return ExportResult.Success;
        }
    }
}
