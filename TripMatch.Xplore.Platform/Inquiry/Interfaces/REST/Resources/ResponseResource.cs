namespace TripMatch.Xplore.Platform.Inquiry.Interfaces.REST.Resources;

public record ResponseResource(int Id, int InquiryId, Guid ResponderId, string Answer, DateTime AnsweredAt);