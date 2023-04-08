using MediatR;
using Microsoft.AspNetCore.Mvc;

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
    }
}
