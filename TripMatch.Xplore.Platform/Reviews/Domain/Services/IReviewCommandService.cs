using TripMatch.Xplore.Platform.Reviews.Domain.Models.Commands;
using TripMatch.Xplore.Platform.Reviews.Domain.Models.Entities;

namespace TripMatch.Xplore.Platform.Reviews.Domain.Services;

public interface IReviewCommandService
{
    /**
     * <summary>
     * Maneja el comando para crear una nueva reseña.
     * </summary>
     * <param name="command">El comando con los datos de la reseña.</param>
     * <returns>La entidad de la reseña creada o null si falla la creación.</returns>
     */
    Task<Review?> Handle(CreateReviewCommand command);
}