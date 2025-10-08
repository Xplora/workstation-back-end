using TripMatch.Xplore.Platform.DAP.Domain.Models.Entities;
using TripMatch.Xplore.Platform.Shared.Domain.Repositories;

namespace TripMatch.Xplore.Platform.DAP.Domain.Repositories
{
    public interface IFavoriteRepository : IBaseRepository<Favorite>
    {
        Task<IEnumerable<Favorite>> FindByTouristIdAsync(Guid touristId);
        Task<bool> ExistsAsync(Guid touristId, int experienceId);
        
        Task<Favorite?> FindByTouristIdAndExperienceIdAsync(Guid touristId, int experienceId);
    }
}