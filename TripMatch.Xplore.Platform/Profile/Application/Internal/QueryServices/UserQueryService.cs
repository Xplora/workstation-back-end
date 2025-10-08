using TripMatch.Xplore.Platform.Profile.Domain;
using TripMatch.Xplore.Platform.Profile.Domain.Models.Entities;
using TripMatch.Xplore.Platform.Profile.Domain.Models.Queries;
using TripMatch.Xplore.Platform.Profile.Domain.Services;

namespace TripMatch.Xplore.Platform.Profile.Application.Internal.QueryServices;


public class UserQueryService : IUserQueryService
{
    private readonly IUserRepository _userRepository;

    public UserQueryService(IUserRepository userRepository)
    {
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
    }

    public async Task<User?> Handle(GetUserByIdQuery query)
    {
        return await _userRepository.FindByGuidAsync(query.UserId);
    }
}   