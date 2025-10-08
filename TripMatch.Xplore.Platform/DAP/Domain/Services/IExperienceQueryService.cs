using TripMatch.Xplore.Platform.DAP.Domain.Models.Entities;
using TripMatch.Xplore.Platform.DAP.Domain.Models.Queries;

namespace TripMatch.Xplore.Platform.DAP.Domain.Services;

public interface IExperienceQueryService
{
    Task<IEnumerable<Experience>> Handle(GetAllExperiencesQuery query);
    Task<IEnumerable<Experience>> Handle(GetExperiencesByCategoryQuery query);
    Task<Experience?> Handle(GetExperienceByIdQuery query);
    Task<IEnumerable<Experience>> Handle(GetExperiencesByAgencyQuery query);
    
}
