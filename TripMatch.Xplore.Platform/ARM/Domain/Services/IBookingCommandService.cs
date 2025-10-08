using TripMatch.Xplore.Platform.ARM.Domain.Models.Commands;
using TripMatch.Xplore.Platform.ARM.Domain.Models.Entities;

namespace TripMatch.Xplore.Platform.ARM.Domain.Services;

/**
 * <summary>
 * Interfaz para los servicios de comandos de Booking. Define las operaciones que modifican el estado.
 * </summary>
 */
public interface IBookingCommandService
{
    /**
     * <summary>
     * Maneja el comando para crear una nueva reserva.
     * </summary>
     * <param name="command">El comando con los datos de la reserva.</param>
     * <returns>La entidad de la reserva creada o null si falla.</returns>
     */
    Task<Booking?> Handle(CreateBookingCommand command);

    /**
     * <summary>
     * Maneja el comando para actualizar el estado de una reserva.
     * </summary>
     * <param name="command">El comando con el ID de la reserva y el nuevo estado.</param>
     * <returns>La entidad de la reserva actualizada o null si no se encuentra.</returns>
     */
    Task<Booking?> Handle(UpdateBookingStatusCommand command);

    /**
     * <summary>
     * Maneja el comando para eliminar una reserva.
     * </summary>
     * <param name="command">El comando con el ID de la reserva a eliminar.</param>
     * <returns>True si la eliminación fue exitosa, de lo contrario false.</returns>
     */
    Task<bool> Handle(DeleteBookingCommand command);
}