using TripMatch.Xplore.Platform.IAM.Domain.Models.Commands;
using TripMatch.Xplore.Platform.IAM.Domain.Models.Results;
using TripMatch.Xplore.Platform.Profile.Domain.Models.Entities;

namespace TripMatch.Xplore.Platform.IAM.Domain.Services;

public interface IAuthService
{
    Task<User> SignUpAsync(SignUpCommand command);
    Task<AuthResult> SignInAsync(SignInCommand command);
}