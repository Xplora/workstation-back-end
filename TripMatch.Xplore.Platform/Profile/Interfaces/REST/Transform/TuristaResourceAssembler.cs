using TripMatch.Xplore.Platform.Profile.Domain.Models.Entities;
using TripMatch.Xplore.Platform.Profile.Interfaces.REST.Resources;

namespace TripMatch.Xplore.Platform.Profile.Interfaces.REST.Transform;


public static class TouristResourceAssembler
{
    public static TouristResource ToResource(Tourist tourist)
    {
        return new TouristResource
        {
            UserId = tourist.UserId,
            AvatarUrl = tourist.AvatarUrl
        };
    }
}