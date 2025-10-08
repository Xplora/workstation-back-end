using TripMatch.Xplore.Platform.DAP.Domain.Models.Entities;
using TripMatch.Xplore.Platform.DAP.Domain.Models.Queries;

namespace TripMatch.Xplore.Platform.DAP.Domain.Services
{
    public interface IFavoriteQueryService
    {
        Task<IEnumerable<Favorite>> Handle(GetFavoritesByUserIdQuery query);
    }
}