using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Phoenix.TicketManagement.Identity.Models;

namespace Phoenix.TicketManagement.Identity
{
    public class PhoenixIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public PhoenixIdentityDbContext() { }

        public PhoenixIdentityDbContext(DbContextOptions<PhoenixIdentityDbContext> options) : base(options)
        {
            
        }
    }
}
