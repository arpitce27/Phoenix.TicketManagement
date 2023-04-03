using Phoenix.TicketManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix.TicketManagement.Application.Contracts.Persistance
{
    public interface IEventRepository : IAsyncRepository<Event>
    {

    }
}
