using Microsoft.EntityFrameworkCore;
using TripMatch.Xplore.Platform.Inquiry.Domain.Repository;
using TripMatch.Xplore.Platform.Shared.Infrastructure.Persistence.EFC.Configuration;
using TripMatch.Xplore.Platform.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace TripMatch.Xplore.Platform.Inquiry.Infraestructure.Persistence.EFC.Repositories;

public class InquiryRepository(AppDbContext context): BaseRepository<Domain.Models.Entities.Inquiry>(context), IInquiryRepository
{

    public async Task<IEnumerable<Domain.Models.Entities.Inquiry>> FindByExperienceIdAsync(int experienceId)
    {
        return await Context.Set<Domain.Models.Entities.Inquiry>().Where(i => i.ExperienceId == experienceId).ToListAsync();
    }
}