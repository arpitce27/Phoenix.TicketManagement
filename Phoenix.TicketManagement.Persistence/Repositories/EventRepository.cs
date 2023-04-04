using Microsoft.EntityFrameworkCore.Diagnostics;
using Phoenix.TicketManagement.Application.Contracts.Persistance;
using Phoenix.TicketManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix.TicketManagement.Persistence.Repositories
{
    public class EventRepository : BaseRepository<Event>, IEventRepository
    {
        public EventRepository(PhoenixTicketDbContext dbContext) : base(dbContext)
        {
            
        }
        public Task<bool> IsEventNameAndDateUnique(string name, DateTime eventDate)
        {
            var matches = _dbContext.Events.Any(p => p.Name.Equals(name) && p.Date.Date.Equals(eventDate.Date));

            return Task.FromResult(matches);
        }
    }
}
