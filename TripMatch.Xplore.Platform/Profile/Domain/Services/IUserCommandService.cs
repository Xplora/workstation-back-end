
using TripMatch.Xplore.Platform.Profile.Domain.Models.Commands;
using TripMatch.Xplore.Platform.Profile.Domain.Models.Entities;

namespace TripMatch.Xplore.Platform.Profile.Domain.Services;


public interface IUserCommandService
{
    Task<User> Handle(CreateUserCommand command);
    Task UpdateAgencyAsync(Guid userId, UpdateAgencyCommand command);
    Task UpdateTouristAsync(Guid userId, UpdateTouristCommand command);
    Task DeleteUserAsync(Guid userId);
    Task<User> Handle(Guid userId, UpdateUserCommand command);

}