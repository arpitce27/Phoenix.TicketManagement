using Microsoft.EntityFrameworkCore;
using Moq;
using Phoenix.TicketManagement.Application.Contracts;
using Phoenix.TicketManagement.Domain.Entities;
using Shouldly;

namespace Phoenix.TicketManagement.Persistence.IntegrationTests
{
    public class PhoenixTicketDbContextTests
    {
        private readonly PhoenixTicketDbContext _phoenixTicketDbContext;
        private readonly Mock<ILoggedInUserService> _loggedInUserService;
        private readonly string _loggedInUserId;

        public PhoenixTicketDbContextTests()
        {
            var dbContextOptions = new DbContextOptionsBuilder<PhoenixTicketDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            _loggedInUserId = "00000000-0000-0000-0000-000000000000";
            _loggedInUserService = new Mock<ILoggedInUserService>();
            _loggedInUserService.Setup(m => m.UserId).Returns(_loggedInUserId);

            _phoenixTicketDbContext = new PhoenixTicketDbContext(dbContextOptions, _loggedInUserService.Object);
        }

        [Fact]
        public void Save_SetCreatedByProperty()
        {
            var category = new Category() { CategoryId = Guid.NewGuid(), Name = "Test category" };

            _phoenixTicketDbContext.Categories.Add(category);
            _phoenixTicketDbContext.SaveChanges();

            category.CreatedBy.ShouldBe(_loggedInUserId);
        }

    }
}
