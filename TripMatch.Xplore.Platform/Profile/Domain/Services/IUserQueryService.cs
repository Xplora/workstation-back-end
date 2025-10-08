
using TripMatch.Xplore.Platform.Profile.Domain.Models.Entities;
using TripMatch.Xplore.Platform.Profile.Domain.Models.Queries;

namespace TripMatch.Xplore.Platform.Profile.Domain.Services;


public interface IUserQueryService
{
    Task<User?> Handle(GetUserByIdQuery query);
}