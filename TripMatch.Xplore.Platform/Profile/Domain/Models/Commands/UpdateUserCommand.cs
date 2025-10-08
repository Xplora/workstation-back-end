namespace TripMatch.Xplore.Platform.Profile.Domain.Models.Commands;

public record UpdateUserCommand(
    string FirstName,
    string LastName,
    string Number
);