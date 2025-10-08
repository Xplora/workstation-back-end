namespace TripMatch.Xplore.Platform.Profile.Domain.Models.Commands;


public record CreateAgencyCommand(
    Guid UserId,
    string Ruc,
    string Description,
    string LinkFacebook,
    string LinkInstagram
);