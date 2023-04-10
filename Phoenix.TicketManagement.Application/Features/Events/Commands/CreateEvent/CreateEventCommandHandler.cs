using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Phoenix.TicketManagement.Application.Contracts.Infrastructure;
using Phoenix.TicketManagement.Application.Contracts.Persistance;
using Phoenix.TicketManagement.Application.Models.Mail;
using Phoenix.TicketManagement.Domain.Entities;

namespace Phoenix.TicketManagement.Application.Features.Events.Commands.CreateEvent
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, Guid>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<CreateEventCommand> _logger;
        public CreateEventCommandHandler(IEventRepository eventRepository, IMapper mapper, 
            IEmailService emailService, ILogger<CreateEventCommand> logger)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
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

            var email = new Email()
            {
                To = "arpit.ce27@gmail.com",
                Body = $"A new event was created: {request}",
                Subject = "A new event was created"
            };

            try
            {
                await _emailService.SendEmail(email);
            }
            catch (Exception ex) 
            {
                _logger.LogError($"Mailing about event {newEvent.EventId} failed due to an error with the mail service: {ex.Message}");
            }

            return newEvent.EventId;
        }
    }
}
