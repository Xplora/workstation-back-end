using TripMatch.Xplore.Platform.Inquiry.Domain.Models.Queries;

namespace TripMatch.Xplore.Platform.Inquiry.Domain.Services;

public interface IInquiryQueryService
{
    Task<IEnumerable<TripMatch.Xplore.Platform.Inquiry.Domain.Models.Entities.Inquiry>> Handle(GetAllInquiriesQuery query);
    Task<IEnumerable<TripMatch.Xplore.Platform.Inquiry.Domain.Models.Entities.Inquiry>> Handle(GetAllInquiriesByExperienceQuery query);
    Task<IEnumerable<TripMatch.Xplore.Platform.Inquiry.Domain.Models.Entities.Inquiry>> HandleByAgency(GetAllInquiriesByAgencyQuery query);
}