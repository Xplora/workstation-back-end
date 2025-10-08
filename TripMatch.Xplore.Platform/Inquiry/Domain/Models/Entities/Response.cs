using TripMatch.Xplore.Platform.Profile.Domain.Models.Entities;
using TripMatch.Xplore.Platform.Shared.Domain.Model.Entities;

namespace TripMatch.Xplore.Platform.Inquiry.Domain.Models.Entities;

public class Response : BaseEntity
{
    public int Id { get; set; }
    public int InquiryId { get; set; }
    public Inquiry Inquiry { get; set; }

    public Guid ResponderId { get; set; }               
    public User Responder { get; set; }            

    public string Answer { get; set; } = string.Empty;
    public DateTime AnsweredAt { get; set; }
}