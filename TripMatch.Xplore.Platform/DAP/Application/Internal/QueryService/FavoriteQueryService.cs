using TripMatch.Xplore.Platform.DAP.Domain.Models.Entities;
using TripMatch.Xplore.Platform.DAP.Domain.Models.Queries;
using TripMatch.Xplore.Platform.DAP.Domain.Repositories;
using TripMatch.Xplore.Platform.DAP.Domain.Services;

namespace TripMatch.Xplore.Platform.DAP.Application.Internal.QueryService
{
    public class FavoriteQueryService : IFavoriteQueryService
    {
        private readonly IFavoriteRepository _favoriteRepository;

        public FavoriteQueryService(IFavoriteRepository favoriteRepository)
        {
            _favoriteRepository = favoriteRepository;
        }

        public async Task<IEnumerable<Favorite>> Handle(GetFavoritesByUserIdQuery query)
        {
            return await _favoriteRepository.FindByTouristIdAsync(query.TouristId);
        }
    }
}