using Phoenix.TicketManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix.TicketManagement.Application.Features.Events.Queries.GetEventDetail
{
    public class EventDetailVm
    {
        public Guid EventId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Price { get; set; }
        public string? Artist { get; set; }
        public DateTime Date { get; set; }
        public string? Description { get; set; }
        public string? ImageURL { get; set; }
        public Guid CategoryId { get; set; }
        public CategoryDto Category { get; set; } = default!;
    }
}
