using Phoenix.TicketManagement.Domain.Entities;
using Phoenix.TicketManagement.Persistence;

namespace Phoenix.TicketManagement.API.IntegrationTests.Base
{
    public class Utilities
    {
        public static void InitializeDbForTests(PhoenixTicketDbContext context)
        { 
            var concertGuid = Guid.Parse("{673A6AFD-1F9C-46C8-9B7E-E7900228D597}");
            var musicalGuid = Guid.Parse("{0DC5628E-894C-4A13-87F1-7E8BB52E35C2}");
            var playGuid = Guid.Parse("{2607B1E8-AEE5-4370-93CB-DD3ED19E8EE0}");
            var conferenceGuid = Guid.Parse("{D4F8735A-C064-48AA-809F-0729A99C7AFE}");

            if (!context.Categories.Any(i => i.CategoryId == concertGuid))
            { 
                context.Categories.Add(new Category
                {
                    CategoryId = concertGuid,
                    Name = "Concerts"
                });
            }
            if (!context.Categories.Any(i => i.CategoryId == musicalGuid))
            {
                context.Categories.Add(new Category
                {
                    CategoryId = musicalGuid,
                    Name = "Musicals"
                });
            }
            if (!context.Categories.Any(i => i.CategoryId == playGuid))
            {
                context.Categories.Add(new Category
                {
                    CategoryId = playGuid,
                    Name = "Plays"
                });

            }
            if (!context.Categories.Any(i => i.CategoryId == conferenceGuid))
            {
                context.Categories.Add(new Category
                {
                    CategoryId = conferenceGuid,
                    Name = "Conferences"
                });
            }

            context.SaveChanges();
        }
    }
}
