using TripMatch.Xplore.Platform.Inquiry.Domain.Models.Entities;
using TripMatch.Xplore.Platform.Inquiry.Domain.Models.Queries;

namespace TripMatch.Xplore.Platform.Inquiry.Domain.Services;

public interface  IResponseQueryService
{
    Task<Response?> Handle(GetResponseByInquiryIdQuery query);
}