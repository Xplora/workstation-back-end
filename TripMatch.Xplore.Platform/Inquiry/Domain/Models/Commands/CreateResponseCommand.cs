namespace TripMatch.Xplore.Platform.Inquiry.Domain.Models.Commands;

public class CreateResponseCommand
{
    public int InquiryId { get; set; }
    public Guid ResponderId { get; set; }
    public string Answer { get; set; } = null!;
    public DateTime AnsweredAt { get; set; }
}