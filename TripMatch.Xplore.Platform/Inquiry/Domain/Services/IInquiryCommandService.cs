using TripMatch.Xplore.Platform.Inquiry.Domain.Models.Commands;

namespace TripMatch.Xplore.Platform.Inquiry.Domain.Services;

public interface IInquiryCommandService
{
    Task<Models.Entities.Inquiry> Handle(CreateInquiryCommand command);
}