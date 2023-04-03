using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix.TicketManagement.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommand : IRequest<CreateCategoryCommandResponse>
    {
        public string Name { get; set; } = string.Empty;
    }
}
