using AutoMapper;
using MediatR;
using Phoenix.TicketManagement.Application.Contracts.Persistance;
using Phoenix.TicketManagement.Domain.Entities;

namespace Phoenix.TicketManagement.Application.Features.Events.Queries.GetEventDetail
{
    public class GetEventDetailQueryHandler : IRequestHandler<GetEventDetailQuery, EventDetailVm>
    {
        private readonly IAsyncRepository<Event> _eventRepository;
        private readonly IAsyncRepository<Category> _categoryRepository;
        private IMapper _mapper;
        public GetEventDetailQueryHandler(IAsyncRepository<Event> eventRepository,
            IAsyncRepository<Category> categoryRepository,
            IMapper mapper)
        {
            _eventRepository = eventRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<EventDetailVm> Handle(GetEventDetailQuery request, CancellationToken cancellationToken)
        {
            var eve = await _eventRepository.GetByIdAsync(request.EventId);
            var eventResult = _mapper.Map<EventDetailVm>(eve);

            var category = await _categoryRepository.GetByIdAsync(eve.CategoryId);
            eventResult.Category = _mapper.Map<CategoryDto>(category);

            return eventResult;
        }
    }
}
