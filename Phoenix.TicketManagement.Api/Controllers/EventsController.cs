using MediatR;
using Microsoft.AspNetCore.Mvc;
using Phoenix.TicketManagement.Application.Features.Events.Commands.CreateEvent;
using Phoenix.TicketManagement.Application.Features.Events.Commands.DeleteEvent;
using Phoenix.TicketManagement.Application.Features.Events.Queries.GetEventDetail;
using Phoenix.TicketManagement.Application.Features.Events.Queries.GetEventList;

namespace Phoenix.TicketManagement.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : Controller
    {
        private readonly IMediator _mediator;
        public EventsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAllEvents")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<EventListVm>>> GetAllEvents()
        {
            var result = await _mediator.Send(new GetEventsListQuery());
            return Ok(result);
        }

        [HttpGet("{id}", Name = "GetEventById")]
        public async Task<ActionResult<EventDetailVm>> GetEventById(Guid id)
        {
            var result = await _mediator.Send(new GetEventDetailQuery() { EventId = id });
            return Ok(result);
        }

        [HttpPost(Name = "AddEvent")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateEventCommand input)
        {
            var result = await _mediator.Send(input);
            return Ok(result);
        }

        [HttpPut(Name = "UpdateEvent")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Guid>> Update([FromBody] CreateEventCommand input)
        {
            await _mediator.Send(input);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeletEvent")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Guid>> Delete(Guid id)
        {
            await _mediator.Send(new DeleteEventCommand() { EventId = id });
            return NoContent();
        }

    }
}
