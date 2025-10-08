using Microsoft.EntityFrameworkCore;
using TripMatch.Xplore.Platform.Reviews.Domain.Models.Entities;
using TripMatch.Xplore.Platform.Reviews.Domain.Repository;
using TripMatch.Xplore.Platform.Shared.Infrastructure.Persistence.EFC.Configuration;
using TripMatch.Xplore.Platform.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace TripMatch.Xplore.Platform.Reviews.Infrastructure.Persistence.EFC.Repositories;

public class ReviewRepository(AppDbContext context) : BaseRepository<Review>(context), IReviewRepository
{

    public async Task<IEnumerable<Review>> FindByAgencyUserIdAsync(Guid agencyUserId)
    {
        return await Context.Set<Review>()
            .Where(r => r.AgencyUserId == agencyUserId)
            .Include(r => r.TouristUser)
            .ThenInclude(u => u.Tourist) 
            .ToListAsync();
    }

    public async Task<Review?> FindByAgencyAndTouristUserAsync(Guid agencyUserId, Guid touristUserId)
    {
        return await Context.Set<Review>()
            .FirstOrDefaultAsync(r => r.AgencyUserId == agencyUserId && r.TouristUserId == touristUserId);
    }

    public async Task<IEnumerable<Review>> FindAllReviewsForAgency(Guid agencyUserId)
    {
        return await Context.Set<Review>()
            .Where(r => r.AgencyUserId == agencyUserId)
            .ToListAsync();
    }
    
    public async Task<Review?> FindByIdAsync(int id)
    {
        return await Context.Set<Review>()
            .Where(r => r.Id == id)
            .Include(r => r.TouristUser)   
            .ThenInclude(u => u.Tourist)   
            .FirstOrDefaultAsync();     
    }
}