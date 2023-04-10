using AutoMapper;
using Phoenix.TicketManagement.Application.Features.Categories.Commands.CreateCategory;
using Phoenix.TicketManagement.Application.Features.Categories.Queries.GetCategoriesList;
using Phoenix.TicketManagement.Application.Features.Categories.Queries.GetCategoriesListWithEvent;
using Phoenix.TicketManagement.Application.Features.Events.Commands.CreateEvent;
using Phoenix.TicketManagement.Application.Features.Events.Commands.DeleteEvent;
using Phoenix.TicketManagement.Application.Features.Events.Commands.UpdateEvent;
using Phoenix.TicketManagement.Application.Features.Events.Queries.ExportEvents;
using Phoenix.TicketManagement.Application.Features.Events.Queries.GetEventDetail;
using Phoenix.TicketManagement.Application.Features.Events.Queries.GetEventList;
using Phoenix.TicketManagement.Domain.Entities;

namespace Phoenix.TicketManagement.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Event, EventListVm>().ReverseMap();
            CreateMap<Event, EventDetailVm>().ReverseMap();

            CreateMap<Category, CategoryDto>();
            CreateMap<Category, CategoriesListVm>();
            CreateMap<Category, CategoryEventListVm>();

            CreateMap<Event, CreateEventCommand>().ReverseMap();
            CreateMap<Event, UpdateEventCommand>().ReverseMap();
            CreateMap<Event, DeleteEventCommand>().ReverseMap(); 
            CreateMap<Event, EventExportDto>().ReverseMap(); 

            CreateMap<Category, CreateCategoryCommand>();
            CreateMap<Category, CreateCategoryDto>();
        }
    }
}
