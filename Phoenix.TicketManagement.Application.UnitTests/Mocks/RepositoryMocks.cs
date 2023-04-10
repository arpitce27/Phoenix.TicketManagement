using Moq;
using Phoenix.TicketManagement.Application.Contracts.Persistance;
using Phoenix.TicketManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix.TicketManagement.Application.UnitTests.Mocks
{
    public class RepositoryMocks
    {
        public static Mock<IAsyncRepository<Category>> GetCategoryRepository()
        {
            var concertGuid = Guid.Parse("{09B80B1D-C4B9-4383-BCCE-16DD70993313}");
            var musicalGuid = Guid.Parse("{3A654DC2-E836-4FE4-BD5A-F655CF849450}");
            var playGuid = Guid.Parse("{F5C4F2A9-FE7A-42B9-A367-D0EED8566D79}");
            var conferenceGuid = Guid.Parse("{E940C2A9-CFB4-4A38-BE28-82BF57CA9553}");

            var categories = new List<Category>
            {
                new Category
                {
                    CategoryId = concertGuid,
                    Name = "Concerts"
                },
                new Category
                {
                    CategoryId = musicalGuid,
                    Name = "Musicals"
                },
                new Category
                {
                    CategoryId = conferenceGuid,
                    Name = "Conferences"
                },
                 new Category
                {
                    CategoryId = playGuid,
                    Name = "Plays"
                }
            };

            var mockCategoryRepository = new Mock<IAsyncRepository<Category>>();
            mockCategoryRepository.Setup(repo => repo.ListAllAsync()).ReturnsAsync(categories);

            mockCategoryRepository.Setup(repo => repo.AddAsync(It.IsAny<Category>())).ReturnsAsync(
                (Category category) =>
                {
                    categories.Add(category);
                    return category;
                });

            return mockCategoryRepository;
        }
    }
}
