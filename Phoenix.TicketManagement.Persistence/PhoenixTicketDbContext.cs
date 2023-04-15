using Microsoft.EntityFrameworkCore;
using Phoenix.TicketManagement.Application.Contracts;
using Phoenix.TicketManagement.Domain.Common;
using Phoenix.TicketManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix.TicketManagement.Persistence
{
    public class PhoenixTicketDbContext : DbContext
    {
        private readonly ILoggedInUserService? _loggedInUserService;
        public PhoenixTicketDbContext(DbContextOptions<PhoenixTicketDbContext> options, ILoggedInUserService loggedInUserService) : base(options)
        {
            _loggedInUserService = loggedInUserService;
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PhoenixTicketDbContext).Assembly);

            // Seeding Data:
            var concertGuid = Guid.Parse("9983A002-ED2D-4754-821A-BBA7414EAF56");
            var musicalGuid = Guid.Parse("6AA56663-47D2-4E38-A5BD-376F2E05CDB1");
            var payGuid = Guid.Parse("B836B3D4-4057-41E6-A41D-AB078CB3383E");
            var conferenceGuid = Guid.Parse("D076EC67-8E10-4A27-92B1-125F74834EE3");

            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = concertGuid,
                Name = "Concerts"
            });

            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = musicalGuid,
                Name = "Musicals"
            });

            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = payGuid,
                Name = "Plays"
            });

            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = conferenceGuid,
                Name = "Converences"
            });

            modelBuilder.Entity<Event>().HasData(new Event
            {
                EventId = Guid.Parse("F2B17009-8A66-489A-A0A8-70AFCF57E4DD"),
                Name = "J B E Live",
                Price = 65,
                Artist = "John Eienstine",
                Date = DateTime.Now.AddMonths(6),
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
                ImageURL = "https://www.billboard.com/wp-content/uploads/2021/08/Princess-Nokia-by-Roger-Ho-for-Lollapalooza-2021-billboard-1548-1628011374.jpg",
                CategoryId = concertGuid
            });

            modelBuilder.Entity<Event>().HasData(new Event
            {
                EventId = Guid.Parse("E2C5A011-5BF2-48D8-9865-60F78439EEE2"),
                Name = "The Artist: Michel Jordan",
                Price = 100,
                Artist = "Micheal Jordan",
                Date = DateTime.Now.AddMonths(4),
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
                ImageURL = "https://cdn.vox-cdn.com/thumbor/nuohEKEEjxBm3nj4VUUwvmloOhg=/1400x788/filters:format(jpeg)/cdn.vox-cdn.com/uploads/chorus_asset/file/15795164/concert.0.1462605431.jpg",
                CategoryId = concertGuid
            });

            modelBuilder.Entity<Event>().HasData(new Event
            {
                EventId = Guid.Parse("8C65344A-450A-40B8-9C07-77A0713845AC"),
                Name = "The DJ: Mike",
                Price = 150,
                Artist = "Mike Doe",
                Date = DateTime.Now.AddMonths(4),
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
                ImageURL = "https://mmo.aiircdn.com/248/611aae2ddb3ff.jpg",
                CategoryId = concertGuid
            });

            modelBuilder.Entity<Event>().HasData(new Event
            {
                EventId = Guid.Parse("9A6D5E78-F41F-4B6A-B293-334AF471FE43"),
                Name = "Clash of the DJ Clanes",
                Price = 90,
                Artist = "James Bond",
                Date = DateTime.Now.AddMonths(3),
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
                ImageURL = "https://static.lpnt.fr/images/2021/05/29/21769500lpw-21769504-article-concert-covid19-indochine-jpg_7994906_660x281.jpg",
                CategoryId = concertGuid
            });

            modelBuilder.Entity<Order>().HasData(new Order
            {
                OrderId = Guid.Parse("D66F6719-543A-4632-84D5-DD513C55EAB1"),
                OrderTotal = 400,
                OrderPaid = true,
                DatePlaced = DateTime.Now,
                UserId = Guid.Parse("6FA95748-C491-4D78-9C6C-915AF51445AE")
            });

            modelBuilder.Entity<Order>().HasData(new Order
            {
                OrderId = Guid.Parse("FFA495FA-06D9-41AA-B701-6776B26DBE1B"),
                OrderTotal = 180,
                OrderPaid = true,
                DatePlaced = DateTime.Now,
                UserId = Guid.Parse("6EEB8AFC-0660-4008-A4DE-A74744C49183")
            });

            modelBuilder.Entity<Order>().HasData(new Order
            {
                OrderId = Guid.Parse("7B88A61E-A89D-4205-AA2C-A99BEF759C7C"),
                OrderTotal = 135,
                OrderPaid = true,
                DatePlaced = DateTime.Now,
                UserId = Guid.Parse("9337C530-EA04-43CA-BBE2-23947F80B53F")
            });

        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var item in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (item.State)
                {
                    case EntityState.Modified:
                        item.Entity.LastModifiedDate = DateTime.Now;
                        item.Entity.LastModifiedBy = _loggedInUserService.UserId;
                        break;
                    case EntityState.Added:
                        item.Entity.CreatedDate = DateTime.Now;
                        item.Entity.CreatedBy = _loggedInUserService.UserId;
                        break; 
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

    }
}
