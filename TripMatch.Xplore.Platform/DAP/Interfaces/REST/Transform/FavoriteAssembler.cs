using TripMatch.Xplore.Platform.DAP.Domain.Models.Entities;
using TripMatch.Xplore.Platform.DAP.Interfaces.REST.Resources;

namespace TripMatch.Xplore.Platform.DAP.Interfaces.REST.Transform;

/// <summary>
/// Clase para transformar entidades de favorito a recursos REST.
/// </summary>
public static class FavoriteAssembler
{
    public static FavoriteResource ToResourceFromEntity(Favorite entity)
    {
        ExperienceResource experienceResource = null;
        if (entity.Experience is not null)
        {
            experienceResource = ExperienceResourceFromEntityAssembler.ToResourceFromEntity(entity.Experience);
        }

        return new FavoriteResource(
            entity.Id,
            entity.TouristId,
            entity.ExperienceId,
            experienceResource
        );
    }
}