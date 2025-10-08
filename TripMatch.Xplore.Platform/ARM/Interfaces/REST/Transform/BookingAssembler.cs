using TripMatch.Xplore.Platform.ARM.Domain.Models.Entities;
using TripMatch.Xplore.Platform.ARM.Interfaces.REST.Resources;
using TripMatch.Xplore.Platform.DAP.Interfaces.REST.Resources;
using TripMatch.Xplore.Platform.DAP.Interfaces.REST.Transform;

namespace TripMatch.Xplore.Platform.ARM.Interfaces.REST.Transform;

/**
 * <summary>
 * Clase estática para transformar la entidad Booking a su recurso correspondiente.
 * </summary>
 */
public static class BookingAssembler
{
    public static BookingResource ToResourceFromEntity(Booking entity)
    {

        ExperienceResource experienceResource = null;
        if (entity.Experience != null)
        {
            experienceResource = ExperienceResourceFromEntityAssembler.ToResourceFromEntity(entity.Experience); 
        }

        return new BookingResource(
            entity.Id,
            entity.BookingDate,
            entity.NumberOfPeople,
            entity.Price,
            entity.Status,
            entity.ExperienceId,
            entity.TouristId,
            entity.Time,
            experienceResource 
        );
    }
}