using Microsoft.EntityFrameworkCore;
using TripMatch.Xplore.Platform.DAP.Domain.Models.Entities;
using TripMatch.Xplore.Platform.DAP.Domain.Repositories;
using TripMatch.Xplore.Platform.Shared.Infrastructure.Persistence.EFC.Configuration;
using TripMatch.Xplore.Platform.Shared.Infrastructure.Persistence.EFC.Repositories;

public class ExperienceRepository(AppDbContext context) : BaseRepository<Experience>(context), IExperienceRepository
{
    public async Task<IEnumerable<Experience>> ListAsync()
    {
        return await Context.Set<Experience>()
            .Include(e => e.Agency)
            .Include(e => e.ExperienceImages)
            .Include(e => e.Category)
            .Include(e => e.Includes)
            .Include(e => e.Schedules)
            .Include(e => e.Agency)
            .Include(e => e.Category)
            .ToListAsync();
    }
    

    public async Task<IEnumerable<Experience>> ListByCategoryIdAsync(int categoryId)
    {
        return await Context.Set<Experience>()
            .Where(e => e.CategoryId == categoryId && e.IsActive)
            .Include(e => e.Agency) 
            .Include(e => e.ExperienceImages)
            .Include(e => e.Includes)
            .Include(e => e.Schedules)
            .Include(e => e.Category)
            .ToListAsync();
    }
    
    public async Task<Experience?> FindByIdAsync(int id)
    {
        return await Context.Set<Experience>()
            .Include(e => e.Schedules)
            .Include(e => e.Agency)
            .Include(e => e.Category)
            .Include(e => e.ExperienceImages)
            .Include(e => e.Includes)
            .FirstOrDefaultAsync(e => e.Id == id);
    }
    
    public async Task<IEnumerable<Experience>> FindByAgencyUserIdAsync(Guid agencyUserId)
    {
        return await Context.Set<Experience>()
            .Where(e => e.AgencyUserId == agencyUserId && e.IsActive) 
            .Include(e => e.ExperienceImages) 
            .Include(e => e.Agency) 
            .Include(e => e.Includes)
            .Include(e => e.Category)
            .Include(e => e.Schedules)
            .ToListAsync();
    }
}