using TripMatch.Xplore.Platform.Profile.Domain.Models.Entities;
using TripMatch.Xplore.Platform.Profile.Interfaces.REST.Resources;

namespace TripMatch.Xplore.Platform.Profile.Interfaces.REST.Transform;


public static class UserResourceFromEntityAssembler
{
    public static UserResource ToResource(User user)
    {
        return new UserResource
        {
            UserId = user.UserId,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Number = user.Number,
            Email = user.Email,
            EsAgency = user.Agency != null,
            EsTourist = user.Tourist != null
        };
    }
}