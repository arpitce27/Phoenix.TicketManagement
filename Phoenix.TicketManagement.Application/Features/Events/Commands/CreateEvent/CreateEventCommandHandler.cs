using AutoMapper;
using MediatR;
using Phoenix.TicketManagement.Application.Contracts.Persistance;
using Phoenix.TicketManagement.Domain.Entities;

namespace Phoenix.TicketManagement.Application.Features.Events.Commands.CreateEvent
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, Guid>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;
        public CreateEventCommandHandler(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateEventCommandValidator();
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult != null && validationResult.Errors.Count > 0)
            {
                throw new Exceptions.ValidationException(validationResult);
            }

            var newEvent = _mapper.Map<Event>(request);
            await _eventRepository.AddAsync(newEvent);

            return newEvent.EventId;
        }
    }
}
