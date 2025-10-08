namespace TripMatch.Xplore.Platform.Inquiry.Interfaces.REST.Resources;

public record InquiryResource(int Id, int ExperienceId, Guid UserId, string? Question, DateTime? AnsweredAt);