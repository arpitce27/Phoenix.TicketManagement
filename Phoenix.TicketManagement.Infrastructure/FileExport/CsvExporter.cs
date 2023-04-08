using CsvHelper;
using Phoenix.TicketManagement.Application.Contracts.Infrastructure;
using Phoenix.TicketManagement.Application.Features.Events.Queries.ExportEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix.TicketManagement.Infrastructure.FileExport
{
    public class CsvExporter : ICsvExporter
    {
        public byte[] ExportEventsToCsv(List<EventExportDto> eventExportDtos)
        {
            using var memoryStream = new MemoryStream();
            using (var streamWriter = new StreamWriter(memoryStream))
            {
                using var csvWriter = new CsvWriter(streamWriter, new System.Globalization.CultureInfo("en-us"));
                csvWriter.WriteRecords(eventExportDtos);
            }
            return memoryStream.ToArray();
        }
    }
}
