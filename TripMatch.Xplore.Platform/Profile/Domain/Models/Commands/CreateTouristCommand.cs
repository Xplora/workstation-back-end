namespace TripMatch.Xplore.Platform.Profile.Domain.Models.Commands;


public record CreateTouristCommand(
    Guid UserId,
    int Age,
    string Gender,
    string Language,
    string Preferences
);