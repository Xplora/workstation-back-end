using TripMatch.Xplore.Platform.Reviews.Domain.Models.Entities;
using TripMatch.Xplore.Platform.Reviews.Interfaces.REST.Resources;

namespace TripMatch.Xplore.Platform.Reviews.Interfaces.REST.Transform;

public static class ReviewAssembler
{
    public static ReviewResource ToResourceFromEntity(Review entity)
    {
        var touristName = entity.TouristUser != null ? $"{entity.TouristUser.FirstName} {entity.TouristUser.LastName}" : "User Anónimo"; 
        var touristAvatarUrl = entity.TouristUser?.Tourist?.AvatarUrl; 

        return new ReviewResource(
            entity.Id,
            entity.Rating,
            entity.Comment,
            entity.ReviewDate,      
            entity.TouristUserId,  
            touristName,
            touristAvatarUrl,
            entity.AgencyUserId   
        );
    }
}