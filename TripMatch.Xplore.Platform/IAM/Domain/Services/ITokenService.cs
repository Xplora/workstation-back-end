using TripMatch.Xplore.Platform.Profile.Domain.Models.Entities;

namespace TripMatch.Xplore.Platform.IAM.Domain.Services;

public interface ITokenService
{
    string GenerateToken(User user);
}