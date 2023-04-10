using AutoMapper;
using Moq;
using Phoenix.TicketManagement.Application.Contracts.Persistance;
using Phoenix.TicketManagement.Application.Features.Categories.Commands.CreateCategory;
using Phoenix.TicketManagement.Application.Profiles;
using Phoenix.TicketManagement.Application.UnitTests.Mocks;
using Phoenix.TicketManagement.Domain.Entities;
using Shouldly;
using Xunit;

namespace Phoenix.TicketManagement.Application.UnitTests.Categories.Commands
{
    public class CreateCategoryTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IAsyncRepository<Category>> _mockCategoryRepo;

        public CreateCategoryTest()
        {
            _mockCategoryRepo = RepositoryMocks.GetCategoryRepository();
            var configProvider = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = configProvider.CreateMapper();
        }

        [Fact]
        public async Task Handle_CreateCategoryToRepo()
        {
            var handler = new CreateCategoryCommandHandler(_mockCategoryRepo.Object, _mapper);

            await handler.Handle(new CreateCategoryCommand() { Name = "AP TEST Category" }, CancellationToken.None);

            var allCategories = await _mockCategoryRepo.Object.ListAllAsync();
            allCategories.Count.ShouldBe(5);
        }

    }
}
