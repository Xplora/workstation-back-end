using TripMatch.Xplore.Platform.ARM.Domain.Models.Entities;
using TripMatch.Xplore.Platform.ARM.Domain.Models.Queries;

namespace TripMatch.Xplore.Platform.ARM.Domain.Services;

/**
 * <summary>
 * Interfaz para los servicios de consulta de Booking. Define las operaciones de solo lectura.
 * </summary>
 */
public interface IBookingQueryService
{
    /**
     * <summary>
     * Maneja la consulta para obtener una reserva por su ID.
     * </summary>
     * <param name="query">La consulta con el ID de la reserva.</param>
     * <returns>La entidad de la reserva o null si no se encuentra.</returns>
     */
    Task<Booking?> Handle(GetBookingByIdQuery query);

    /**
     * <summary>
     * Maneja la consulta para obtener todas las reservas de un tourist.
     * </summary>
     * <param name="query">La consulta con el ID del tourist.</param>
     * <returns>Una colección de las reservas del tourist.</returns>
     */
    Task<IEnumerable<Booking>> Handle(GetBookingsByTouristIdQuery query);
    
    Task<IEnumerable<Booking>> Handle(GetAllBookingsQuery query);
    
}