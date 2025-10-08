using TripMatch.Xplore.Platform.DAP.Domain.Models.Commands;
using TripMatch.Xplore.Platform.DAP.Domain.Models.Entities;

namespace TripMatch.Xplore.Platform.DAP.Domain.Services;

public interface IExperienceCommandService
{
    Task<Experience> Handle(CreateExperienceCommand command);
    Task<Experience> Handle(UpdateExperienceCommand command);
    Task<bool> Handle(DeleteExperienceCommand command);
}