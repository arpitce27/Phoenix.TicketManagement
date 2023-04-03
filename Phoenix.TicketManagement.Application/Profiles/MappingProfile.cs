using AutoMapper;
using Phoenix.TicketManagement.Application.Features.Categories.Queries.GetCategoriesList;
using Phoenix.TicketManagement.Application.Features.Categories.Queries.GetCategoriesListWithEvent;
using Phoenix.TicketManagement.Application.Features.Events.Commands.CreateEvent;
using Phoenix.TicketManagement.Application.Features.Events.Queries.GetEventDetail;
using Phoenix.TicketManagement.Application.Features.Events.Queries.GetEventList;
using Phoenix.TicketManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix.TicketManagement.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Event, EventListVm>().ReverseMap();
            CreateMap<Event, EventDetailVm>().ReverseMap();

            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoriesListVm>().ReverseMap();
            CreateMap<Category, CategoryEventListVm>().ReverseMap();

            CreateMap<Event, CreateEventCommand>().ReverseMap();
            
        }
    }
}
