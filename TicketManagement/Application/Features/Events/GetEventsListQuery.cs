using MediatR;

namespace Application.Features.Events
{
    public class GetEventsListQuery : IRequest<List<EventListViewModel>>
    {
    }
}
