using Phoenix.TicketManagement.API.IntegrationTests.Base;
using Phoenix.TicketManagement.Application.Features.Categories.Queries.GetCategoriesList;
using System.Text.Json;

namespace Phoenix.TicketManagement.API.IntegrationTests.Controllers
{
    public class CategoryControllerTests : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly CustomWebApplicationFactory<Program> _factory;

        public CategoryControllerTests(CustomWebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task ReturnsSuccessResult()
        {
            var client = _factory.GetAnonymousClient();

            var response = await client.GetAsync("/api/category/all");

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<List<CategoriesListVm>>(responseString);

            Assert.IsType<List<CategoriesListVm>>(result);
            Assert.NotEmpty(result);
        }
    }
}
