using Microsoft.EntityFrameworkCore;
using TripMatch.Xplore.Platform.Profile.Domain;
using TripMatch.Xplore.Platform.Profile.Domain.Models.Entities;
using TripMatch.Xplore.Platform.Shared.Infrastructure.Persistence.EFC.Configuration;
using TripMatch.Xplore.Platform.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace TripMatch.Xplore.Platform.Profile.Infrastructure.Persistence.EFC.Repositories;


public class UserRepository(AppDbContext context) :BaseRepository<User>(context), IUserRepository
{

    public async Task AddAsync(User entity)
    {
        await Context.Set<User>().AddAsync(entity);
    }

    public async Task<User?> FindByIdAsync(int id)
    {
        return await Context.Set<User>().FindAsync(id);
    }

    public async Task<User?> FindByGuidAsync(Guid userId)
    {
        return await Context.Set<User>()
            .Include(u => u.Tourist)
            .Include(u => u.Agency)
            .FirstOrDefaultAsync(u => u.UserId == userId);
    }

    public void Remove(User entity)
    {
        Context.Set<User>().Remove(entity);
    }

    public void Update(User entity)
    {
        Context.Set<User>().Update(entity);
    }

    public async Task<IEnumerable<User>> ListAsync()
    {
        return await Context.Set<User>().ToListAsync();
    }

    public async Task AddAgencyAsync(Agency agency)
    {
        await Context.Set<Agency>().AddAsync(agency);
    }

    public async Task AddTouristAsync(Tourist tourist)
    {
        await Context.Set<Tourist>().AddAsync(tourist);
    }
    public async Task<User?> FindByEmailAsync(string email)
    {
        return await Context.Set<User>()
            .Include(u => u.Tourist)
            .Include(u => u.Agency)
            .FirstOrDefaultAsync(u => u.Email == email);
    }
    public void UpdateAgency(Agency agency)
    {
        Context.Set<Agency>().Update(agency);
    }

    public void UpdateTourist(Tourist tourist)
    {
        Context.Set<Tourist>().Update(tourist);
    }
    
}