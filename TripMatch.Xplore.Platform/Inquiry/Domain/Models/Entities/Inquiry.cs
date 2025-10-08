using TripMatch.Xplore.Platform.DAP.Domain.Models.Entities;
using TripMatch.Xplore.Platform.Profile.Domain.Models.Entities;
using TripMatch.Xplore.Platform.Shared.Domain.Model.Entities;

namespace TripMatch.Xplore.Platform.Inquiry.Domain.Models.Entities;

public class Inquiry : BaseEntity
{
    public int Id { get; set; }
    public int ExperienceId { get; set; }
    public Experience Experience { get; set; }

    public Guid UserId { get; set; } 
    public User User { get; set; }
    
    public string Question { get; set; } = string.Empty;

    public DateTime? AskedAt { get; set; }
    public Response? Response { get; set; }
}