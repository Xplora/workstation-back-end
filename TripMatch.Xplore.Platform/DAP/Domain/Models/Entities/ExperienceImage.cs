using TripMatch.Xplore.Platform.Shared.Domain.Model.Entities;

namespace TripMatch.Xplore.Platform.DAP.Domain.Models.Entities;

public class ExperienceImage : BaseEntity
{
    public string Url { get; set; }
    
    public int Id { get; set; }
    public int ExperienceId { get; set; }
    public Experience Experience { get; set; }
}