using TripMatch.Xplore.Platform.Profile.Domain.Models.Entities;
using TripMatch.Xplore.Platform.Profile.Interfaces.REST.Resources;

namespace TripMatch.Xplore.Platform.Profile.Interfaces.REST.Transform;


public static class AgencyResourceAssembler
{
    public static AgencyResource ToResource(Agency agency)
    {
        return new AgencyResource
        {
            UserId = agency.UserId,
            AgencyName = agency.AgencyName,
            Ruc = agency.Ruc,
            Description = agency.Description,
            Rating = agency.Rating,
            ReviewCount = agency.ReviewCount,
            ReservationCount = agency.ReservationCount,
            AvatarUrl = agency.AvatarUrl,
            ContactEmail = agency.ContactEmail,
            ContactPhone = agency.ContactPhone,
            SocialLinkFacebook = agency.SocialLinkFacebook,
            SocialLinkInstagram = agency.SocialLinkInstagram,
            SocialLinkWhatsapp = agency.SocialLinkWhatsapp
        };
    }
}