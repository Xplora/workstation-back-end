using Microsoft.EntityFrameworkCore;
using TripMatch.Xplore.Platform.Inquiry.Domain.Repository;
using TripMatch.Xplore.Platform.Shared.Infrastructure.Persistence.EFC.Configuration;
using TripMatch.Xplore.Platform.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace TripMatch.Xplore.Platform.Inquiry.Infraestructure.Persistence.EFC.Repositories;

public class InquiryRepository(AppDbContext context): BaseRepository<Domain.Models.Entities.Inquiry>(context), IInquiryRepository
{

    public async Task<IEnumerable<Domain.Models.Entities.Inquiry>> FindByExperienceIdAsync(int experienceId)
    {
        return await Context.Set<Domain.Models.Entities.Inquiry>()
            .Include(i => i.Response)  
            .Include(i => i.User)
            .Include(i => i.Experience)
            .Where(i => i.ExperienceId == experienceId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Domain.Models.Entities.Inquiry>> FindByAgencyIdAsync(Guid agencyId)
    {
        return await Context.Set<Domain.Models.Entities.Inquiry>()
            .Include(i => i.Response) 
            .Include(i => i.Experience)
            .ThenInclude(e => e.Agency)
            .Include(i => i.User)
            .Where(i => i.Experience.Agency.UserId == agencyId)
            .ToListAsync();
    }
    public async Task<IEnumerable<Domain.Models.Entities.Inquiry>> ListWithResponsesAsync()
    {
        return await Context.Set<Domain.Models.Entities.Inquiry>()
            .Include(i => i.Response) 
            .Include(i => i.User)
            .Include(i => i.Experience)
            .ToListAsync();
    }
}