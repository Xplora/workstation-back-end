namespace TripMatch.Xplore.Platform.Profile.Domain.Models.Queries;


public record GetUserByIdQuery
{
    public GetUserByIdQuery(Guid userId)
    {
        UserId = userId;
    }

    public Guid UserId { get; init; }
}