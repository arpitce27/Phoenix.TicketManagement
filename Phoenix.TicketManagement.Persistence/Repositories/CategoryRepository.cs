using Microsoft.EntityFrameworkCore;
using Phoenix.TicketManagement.Application.Contracts.Persistance;
using Phoenix.TicketManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix.TicketManagement.Persistence.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(PhoenixTicketDbContext dbContext) : base(dbContext)
        {
            
        }
        public async Task<List<Category>> GetCategoriesWithEvents(bool includePastEvents)
        {
            var allCategories = await _dbContext.Categories.Include(i => i.Events).ToListAsync();

            if (!includePastEvents)
            {
                allCategories.ForEach(c => c.Events.ToList().RemoveAll(i => i.Date < DateTime.Now));
            }

            return allCategories;
        }
    }
}
