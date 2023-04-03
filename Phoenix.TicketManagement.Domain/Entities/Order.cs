using Phoenix.TicketManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix.TicketManagement.Domain.Entities
{
    public class Order: AuditableEntity
    {
        public Guid OrderId { get; set; }
        public Guid UserId { get; set; }
        public int OrderTotal { get; set; }
        public DateTime DatePlaced { get; set; }
        public bool OrderPaid { get; set; }
    }
}
