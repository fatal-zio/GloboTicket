using Application.Contracts.Persistence;
using AutoMapper;
using MediatR;

namespace Application.Features.Categories.Queries.GetCategoriesListWithEvents
{
    public class GetCategoriesListWithEventsQueryHandler(IMapper mapper, ICategoryRepository categoryRepository) : IRequestHandler<GetCategoriesListWithEventsQuery, List<CategoryEventListViewModel>>
    {
        private readonly IMapper _mapper = mapper;
        private readonly ICategoryRepository _categoryRepository = categoryRepository;

        public async Task<List<CategoryEventListViewModel>> Handle(GetCategoriesListWithEventsQuery request, CancellationToken cancellationToken)
        {
            var list = await _categoryRepository.GetCategoriesWithEvents(request.IncludeHistory);

            return _mapper.Map<List<CategoryEventListViewModel>>(list);
        }
    }
}
