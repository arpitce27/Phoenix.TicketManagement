using MediatR;
using Microsoft.AspNetCore.Mvc;
using Phoenix.TicketManagement.Application.Features.Orders.Queries.GetOrdersForMonth;

namespace Phoenix.TicketManagement.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private readonly IMediator _mediator;
        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("/getpagedordersformonth", Name = "GetPagedOrdersForMonth")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<PagedOrdersForMonthVm>> GetPagedOrdersForMonth(DateTime date, int page, int size)
        {
            var getOrdersForMonthQuery = new GetOrdersForMonthQuery() { Date = date, Page = page, Size = size };
            var dtos = await _mediator.Send(getOrdersForMonthQuery);

            return Ok(dtos);
        }
    }
}
