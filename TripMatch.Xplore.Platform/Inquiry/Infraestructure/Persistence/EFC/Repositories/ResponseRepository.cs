using Microsoft.EntityFrameworkCore;
using TripMatch.Xplore.Platform.Inquiry.Domain.Models.Entities;
using TripMatch.Xplore.Platform.Inquiry.Domain.Repository;
using TripMatch.Xplore.Platform.Shared.Infrastructure.Persistence.EFC.Configuration;
using TripMatch.Xplore.Platform.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace TripMatch.Xplore.Platform.Inquiry.Infraestructure.Persistence.EFC.Repositories;

public class ResponseRepository : BaseRepository<Response>, IResponseRepository
{
    public ResponseRepository(AppDbContext context) : base(context) { }

    public async Task<Response?> FindByInquiryIdAsync(int inquiryId)
    {
        return await Context.Set<Response>()
            .FirstOrDefaultAsync(r => r.InquiryId == inquiryId);
    }
}