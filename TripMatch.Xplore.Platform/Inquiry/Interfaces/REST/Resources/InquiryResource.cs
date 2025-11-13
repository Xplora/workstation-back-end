namespace TripMatch.Xplore.Platform.Inquiry.Interfaces.REST.Resources;

public record InquiryResource(
    int Id,
    int ExperienceId,
    Guid UserId,
    string TravelerName,
    string ExperienceTitle,
    string Question,
    string? Answer,
    DateTime? AskedAt,
    bool IsAnswered
);