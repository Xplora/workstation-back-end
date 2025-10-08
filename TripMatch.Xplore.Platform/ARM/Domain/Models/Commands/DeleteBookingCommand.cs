namespace TripMatch.Xplore.Platform.ARM.Domain.Models.Commands;

/**
 * <summary>
 * Comando para eliminar una reserva.
 * </summary>
 * <param name="BookingId">ID de la reserva a eliminar.</param>
 */
public record DeleteBookingCommand(int BookingId);