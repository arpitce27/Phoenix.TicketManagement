﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix.TicketManagement.Application.Features.Categories.Queries.GetCategoriesListWithEvent
{
    public class CategoryEventListVm
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        
        public ICollection<CategoryEventDto>? Events { get; set; }
    }
}
