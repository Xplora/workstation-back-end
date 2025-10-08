using TripMatch.Xplore.Platform.Shared.Domain.Model.Entities;

namespace TripMatch.Xplore.Platform.DAP.Domain.Models.Entities;

public class Include : BaseEntity
{
    public string Description { get; set; }
    
    public int Id { get; set; }
    public int ExperienceId { get; set; }
    public TripMatch.Xplore.Platform.DAP.Domain.Models.Entities.Experience Experience { get; set; }
}