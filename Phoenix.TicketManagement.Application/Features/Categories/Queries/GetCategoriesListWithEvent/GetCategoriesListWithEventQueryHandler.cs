using AutoMapper;
using MediatR;
using Phoenix.TicketManagement.Application.Contracts.Persistance;
using Phoenix.TicketManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix.TicketManagement.Application.Features.Categories.Queries.GetCategoriesListWithEvent
{
    public class GetCategoriesListWithEventQueryHandler : IRequestHandler<GetCategoriesListWithEventQuery, List<CategoryEventListVm>>
    {
        private readonly IEventRepository _eventRspository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetCategoriesListWithEventQueryHandler(IEventRepository eventRspository,
            ICategoryRepository categoryRepository,
            IMapper mapper)
        {

            _eventRspository = eventRspository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<List<CategoryEventListVm>> Handle(GetCategoriesListWithEventQuery request, CancellationToken cancellationToken)
        {
            var allCategories = await _categoryRepository.GetCategoriesWithEvents(request.IncludeHistory);
            return _mapper.Map<List<CategoryEventListVm>>(allCategories);
        }
    }
}
