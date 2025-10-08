using TripMatch.Xplore.Platform.Reviews.Domain.Models.Entities;
using TripMatch.Xplore.Platform.Reviews.Domain.Models.Queries;

namespace TripMatch.Xplore.Platform.Reviews.Domain.Services;

public interface IReviewQueryService
{
    /**
     * <summary>
     * Maneja la consulta para obtener todas las reseñas de una agency.
     * </summary>
     * <param name="query">La consulta con el ID de la agency.</param>
     * <returns>Una colección de reseñas.</returns>
     */
    Task<IEnumerable<Review>> Handle(GetReviewsByAgencyIdQuery query);
    Task<Review?> Handle(GetReviewByIdQuery query);
}
