﻿namespace Application.Features.Categories.Queries.GetCategoriesListWithEvents
{
    public class CategoryEventListViewModel
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<CategoryEventDto>? Events { get; set; }
    }
}
