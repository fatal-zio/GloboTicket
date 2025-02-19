using Application.Features.Categories.Queries.GetCategoriesList;
using Application.Features.Categories.Queries.GetCategoriesListWithEvents;
using Application.Features.Events.Queries.GetEventDetail;
using Application.Features.Events.Queries.GetEventsList;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Event, EventListViewModel>().ReverseMap();
            CreateMap<Event, EventDetailViewModel>().ReverseMap();

            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryListViewModel>();
            CreateMap<Category, CategoryEventListViewModel>();
        }
    }
}
