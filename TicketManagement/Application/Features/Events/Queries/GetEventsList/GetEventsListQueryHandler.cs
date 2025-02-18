using Application.Contracts.Persistence;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Events
{
    public class GetEventsListQueryHandler(IAsyncRepository<Event> eventRepository, IMapper mapper) : IRequestHandler<GetEventsListQuery, List<EventListViewModel>>
    {
        private readonly IAsyncRepository<Event> _eventRepository = eventRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<List<EventListViewModel>> Handle(GetEventsListQuery request, CancellationToken cancellationToken)
        {
            var allEvents = (await _eventRepository.ListAllAsync()).OrderBy(o => o.Date);
            return _mapper.Map<List<EventListViewModel>>(allEvents);
        }
    }
}
