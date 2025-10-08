using Microsoft.EntityFrameworkCore;
using TripMatch.Xplore.Platform.DAP.Domain.Models.Entities;
using TripMatch.Xplore.Platform.DAP.Domain.Repositories;
using TripMatch.Xplore.Platform.Shared.Infrastructure.Persistence.EFC.Configuration;
using TripMatch.Xplore.Platform.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace TripMatch.Xplore.Platform.DAP.Infraestructure.Persistence.EFC.Repositories
{
    public class FavoriteRepository(AppDbContext context) : BaseRepository<Favorite>(context), IFavoriteRepository
    {

        public async Task<Favorite?> FindByTouristIdAndExperienceIdAsync(Guid touristId, int experienceId)
        {
            return await Context.Set<Favorite>()
                .FirstOrDefaultAsync(f => f.TouristId == touristId && f.ExperienceId == experienceId);
        }

        public async Task<IEnumerable<Favorite>> FindByTouristIdAsync(Guid touristId)
        {
            return await Context.Set<Favorite>().
                Include(f => f.Experience)
                .Where(f => f.TouristId == touristId)
                .ToListAsync();
        }

        public async Task<bool> ExistsAsync(Guid touristId, int experienceId)
        {
            return await Context.Set<Favorite>()
                .AnyAsync(f => f.TouristId == touristId && f.ExperienceId == experienceId);
        }
    }
}