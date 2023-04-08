using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix.TicketManagement.Application.Features.Events.Queries.ExportEvents
{
    public class GetEventsExportQuery : IRequest<EventsExportFileVm>
    {
    }
}
