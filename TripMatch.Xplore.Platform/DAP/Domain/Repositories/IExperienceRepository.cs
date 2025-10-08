using TripMatch.Xplore.Platform.DAP.Domain.Models.Entities;
using TripMatch.Xplore.Platform.Shared.Domain.Repositories;

namespace TripMatch.Xplore.Platform.DAP.Domain.Repositories;

public interface IExperienceRepository : IBaseRepository<Experience>
{
    Task<IEnumerable<Experience>> ListByCategoryIdAsync(int categoryId);
    
    Task<IEnumerable<Experience>> FindByAgencyUserIdAsync(Guid agencyUserId);
    Task<Experience?> FindByIdAsync(int id);
}