using Application.Contracts.Persistence;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Categories.Queries.GetCategoriesList
{
    public class GetCategoriesListQueryHandler(IAsyncRepository<Category> categoryRepository, IMapper mapper) : IRequestHandler<GetCategoriesListQuery, List<CategoryListViewModel>>
    {
        private readonly IAsyncRepository<Category> _categoryRepository = categoryRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<List<CategoryListViewModel>> Handle(GetCategoriesListQuery request, CancellationToken cancellationToken)
        {
            var allCategories = (await _categoryRepository.ListAllAsync()).OrderBy(o => o.Name);
            return _mapper.Map<List<CategoryListViewModel>>(allCategories);
        }
    }
}
