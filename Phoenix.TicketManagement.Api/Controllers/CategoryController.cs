using MediatR;
using Microsoft.AspNetCore.Mvc;
using Phoenix.TicketManagement.Application.Features.Categories.Commands.CreateCategory;
using Phoenix.TicketManagement.Application.Features.Categories.Queries.GetCategoriesList;
using Phoenix.TicketManagement.Application.Features.Categories.Queries.GetCategoriesListWithEvent;

namespace Phoenix.TicketManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all", Name = "GetAllCategories")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CategoriesListVm>>> GetAllCategories()
        {
            var dtos = await _mediator.Send(new GetCategoriesListQuery());
            return Ok(dtos);
        }

        [HttpGet("allwithevents", Name = "GetCategoriesWithEvents")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CategoriesListVm>>> GetCategoriesWithEvents()
        {
            var dtos = await _mediator.Send(new GetCategoriesListWithEventQuery()
            {
                IncludeHistory = true
            }); 

            return Ok(dtos);
        }

        [HttpPost(Name = "AddCategory")]
        public async Task<ActionResult<CreateCategoryCommandResponse>> Create([FromBody] CreateCategoryCommand input)
        {
            var response = await _mediator.Send(input);
            return Ok(response);
        }

    }
}
