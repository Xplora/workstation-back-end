using TripMatch.Xplore.Platform.DAP.Domain.Models.Commands;
using TripMatch.Xplore.Platform.DAP.Domain.Models.Entities;

namespace TripMatch.Xplore.Platform.DAP.Domain.Services
{
    public interface IFavoriteCommandService
    {
        Task<Favorite?> Handle(CreateFavoriteCommand command);
        Task<bool> Handle(DeleteFavoriteCommand command);
    }
}