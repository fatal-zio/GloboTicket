using Application.Contracts.Persistence;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class CategoryRepository(GloboTicketDbContext dbContext) : BaseRepository<Category>(dbContext), ICategoryRepository
    {
        public async Task<List<Category>> GetCategoriesWithEvents(bool includeHistory)
        {
            return includeHistory ? 
                await _dbContext.Categories.Include(x => x.Events).ToListAsync() :
                await _dbContext.Categories.Include(x => x.Events.Where(e => e.Date < DateTime.Today)).ToListAsync();
        }
    }
}
