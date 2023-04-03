using AutoMapper;
using MediatR;
using Phoenix.TicketManagement.Application.Contracts.Persistance;
using Phoenix.TicketManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix.TicketManagement.Application.Features.Events.Commands.UpdateEvent
{
    public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;
        public UpdateEventCommandHandler(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            var eventToUpdate = await _eventRepository.GetByIdAsync(request.EventId);

            _mapper.Map(request, eventToUpdate, typeof(UpdateEventCommand), typeof(Event));
            await _eventRepository.UpdateAsync(eventToUpdate);

            return Unit.Value;
        }
    }
}
