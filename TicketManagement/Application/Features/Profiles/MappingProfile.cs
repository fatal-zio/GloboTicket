using Application.Features.Events;
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
        }
    }
}
