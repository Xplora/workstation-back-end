using Microsoft.EntityFrameworkCore;
using TripMatch.Xplore.Platform.ARM.Domain;
using TripMatch.Xplore.Platform.ARM.Domain.Models.Entities;
using TripMatch.Xplore.Platform.Shared.Infrastructure.Persistence.EFC.Configuration;
using TripMatch.Xplore.Platform.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace TripMatch.Xplore.Platform.ARM.Infrastructure.Persistence.EFC.Repositories;

public class BookingRepository(AppDbContext context) : BaseRepository<Booking>(context), IBookingRepository
{

    public async Task<IEnumerable<Booking>> FindByTouristIdAsync(Guid touristId)
    {
        return await Context.Set<Booking>()
            .Where(b => b.TouristId == touristId)
            .Include(b => b.Experience) 
                .ThenInclude(e => e.ExperienceImages) 
            .Include(b => b.Experience) 
                .ThenInclude(e => e.Schedules) 
            .Include(b => b.Experience)
                .ThenInclude(e => e.Category) 
            .Include(b => b.Experience)
                .ThenInclude(e => e.Agency)
            .ToListAsync();
    }

    public async Task<Booking?> FindByIdWithExperienceAsync(int bookingId)
    {
        return await Context.Set<Booking>()
            .Include(b => b.Experience)
                .ThenInclude(e => e.ExperienceImages)
            .Include(b => b.Experience)
                .ThenInclude(e => e.Schedules)
            .Include(b => b.Experience)
                .ThenInclude(e => e.Category)
            .Include(b => b.Experience)
                .ThenInclude(e => e.Agency)
            .FirstOrDefaultAsync(b => b.Id == bookingId);
    }

    public async Task<IEnumerable<Booking>> ListAllWithExperienceAsync()
    {
        return await Context.Set<Booking>()
            .Include(b => b.Tourist) 
            .Include(b => b.Experience)
                .ThenInclude(e => e.ExperienceImages)
            .Include(b => b.Experience)
                .ThenInclude(e => e.Schedules)
            .Include(b => b.Experience)
                .ThenInclude(e => e.Category)
            .Include(b => b.Experience)
                .ThenInclude(e => e.Agency)
            .ToListAsync();
    }
    
    public async Task<IEnumerable<Booking>> FindByAgencyIdAsync(Guid agencyId)
    {
        return await Context.Set<Booking>()
            .Include(b => b.Experience)
                .ThenInclude(e => e.ExperienceImages)
            .Include(b => b.Experience)
                .ThenInclude(e => e.Schedules)
            .Include(b => b.Experience)
                .ThenInclude(e => e.Category)
            .Include(b => b.Experience)
                .ThenInclude(e => e.Agency)
            .Where(b => b.Experience.Agency.UserId == agencyId) 
            .ToListAsync();
    }

    public async Task<bool> HasCompletedBookingForAgencyViaExperienceAsync(Guid touristUserId, Guid agencyUserId)
    {
        return await Context.Set<Booking>()
            .Include(b => b.Experience)
            .ThenInclude(e => e.Agency)
            .AnyAsync(
                b => b.TouristId == touristUserId &&
                     b.Experience.Agency.UserId == agencyUserId &&
                     b.Status == "Confirmada"
            );
    }

    
}