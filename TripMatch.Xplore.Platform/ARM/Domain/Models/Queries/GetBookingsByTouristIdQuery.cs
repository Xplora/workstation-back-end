namespace TripMatch.Xplore.Platform.ARM.Domain.Models.Queries;

/**
 * <summary>
 * Consulta para obtener todas las reservas de un tourist específico.
 * </summary>
 * <param name="TouristId">ID del user tourist.</param>
 */
public record GetBookingsByTouristIdQuery(Guid TouristId);