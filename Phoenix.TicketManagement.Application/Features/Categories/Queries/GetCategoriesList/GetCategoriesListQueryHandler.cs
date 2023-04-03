using AutoMapper;
using MediatR;
using Phoenix.TicketManagement.Application.Contracts.Persistance;
using Phoenix.TicketManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix.TicketManagement.Application.Features.Categories.Queries.GetCategoriesList
{
    public class GetCategoriesListQueryHandler : IRequestHandler<GetCategoriesListQuery, List<CategoriesListVm>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetCategoriesListQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<List<CategoriesListVm>> Handle(GetCategoriesListQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<List<CategoriesListVm>>((await _categoryRepository.ListAllAsync()).OrderBy(i => i.Name));
        }
    }
}
