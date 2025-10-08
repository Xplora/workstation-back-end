namespace TripMatch.Xplore.Platform.ARM.Domain.Models.Queries;

/**
 * <summary>
 * Consulta para obtener una reserva específica por su ID.
 * </summary>
 * <param name="BookingId">ID de la reserva a buscar.</param>
 */
public record GetBookingByIdQuery(int BookingId);