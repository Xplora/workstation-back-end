using TripMatch.Xplore.Platform.Profile.Domain.Models.Entities;
using TripMatch.Xplore.Platform.Shared.Domain.Repositories;

namespace TripMatch.Xplore.Platform.Profile.Domain;


public interface IUserRepository : IBaseRepository<User>
{
    Task<User?> FindByGuidAsync(Guid userId);
    Task AddAgencyAsync(Agency agency);
    Task AddTouristAsync(Tourist tourist);
    Task<User?> FindByEmailAsync(string email);
    void UpdateAgency(Agency agency);
    void UpdateTourist(Tourist tourist);
    void Remove(User entity);
}