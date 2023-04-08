namespace Phoenix.TicketManagement.Application.Features.Events.Queries.ExportEvents
{
    public class EventsExportFileVm
    {
        public string EventExportFileName { get; set; } = string.Empty;
        public string ContentType { get; set;} = string.Empty;
        public byte[]? Data { get; set; }
    }
}
