using TripMatch.Xplore.Platform.DAP.Domain.Models.Entities;
using TripMatch.Xplore.Platform.Shared.Domain.Model.Entities;

namespace TripMatch.Xplore.Platform.Profile.Domain.Models.Entities;


/// <summary>
/// Representa a un user con perfil de agency.
/// </summary>
public class Agency : BaseEntity
{
    public Guid UserId { get; set; }

    public string AgencyName { get; set; }

    public string Ruc { get; set; }

    public string Description { get; set; }

    public float Rating { get; set; }

    public int ReviewCount { get; set; }

    public int ReservationCount { get; set; }

    public string? AvatarUrl { get; set; }

    public string? ContactEmail { get; set; }

    public string? ContactPhone { get; set; }

    public string? SocialLinkFacebook { get; set; }

    public string? SocialLinkInstagram { get; set; }

    public string? SocialLinkWhatsapp { get; set; }

    public User? User { get; set; }
    
    public ICollection<Experience> Experiences { get; set; } = new List<Experience>();
}