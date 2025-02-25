using Application.Contracts.Persistence;
using Domain.Entities;

namespace Persistence.Repositories
{
    public class EventRepository(GloboTicketDbContext dbContext) : BaseRepository<Event>(dbContext), IEventRepository
    {
        public Task<bool> IsEventNameAndDateUnique(string name, DateTime eventDate)
        {
            var matches = _dbContext.Events.Any(e => e.Name.Equals(name) &&
                e.Date.Date.Equals(eventDate.Date));
            return Task.FromResult(matches);
        }
    }
}
