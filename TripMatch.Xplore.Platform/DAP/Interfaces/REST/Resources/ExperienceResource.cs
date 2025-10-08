using TripMatch.Xplore.Platform.Profile.Interfaces.REST.Resources;

namespace TripMatch.Xplore.Platform.DAP.Interfaces.REST.Resources;

public record ExperienceResource (    
    int Id,
    string Title,
    string Description,
    string Location,
    int Duration,
    decimal Price,
    string Frequencies,
    int CategoryId,
    List<ExperienceImageResource> ExperienceImages,
    List<IncludeResource> Includes, 
    List<ScheduleResource> Schedule,
    CategoryResource Category,
    AgencyResource Agency)
{
    
}