using TripMatch.Xplore.Platform.Shared.Domain.Model.Entities;

namespace TripMatch.Xplore.Platform.DAP.Domain.Models.Entities;

public class Schedule : BaseEntity
{
    public String Time { get; set; }= string.Empty;
    
    public int Id { get; set; }
    public int ExperienceId { get; set; }
    public TripMatch.Xplore.Platform.DAP.Domain.Models.Entities.Experience Experience { get; set; }
}