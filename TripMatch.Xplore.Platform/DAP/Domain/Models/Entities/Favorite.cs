using TripMatch.Xplore.Platform.Profile.Domain.Models.Entities;
using TripMatch.Xplore.Platform.Shared.Domain.Model.Entities;
using ExperienceEntity = TripMatch.Xplore.Platform.DAP.Domain.Models.Entities.Experience;
namespace TripMatch.Xplore.Platform.DAP.Domain.Models.Entities;

/// <summary>
/// Entidad que representa un favorito, conectando un turista con una experiencia.
/// </summary>
public class Favorite : BaseEntity
{
    public int Id { get; set; }

    public Guid TouristId { get; set; }
    public int ExperienceId { get; set; }

    public Favorite() { }
    
    public Tourist Tourist { get; set; } = null!;
    
    public ExperienceEntity Experience { get; set; } = null!;

    public Favorite(Guid touristId, int experienceId)
    {
        TouristId = touristId;
        ExperienceId = experienceId;
    }
}