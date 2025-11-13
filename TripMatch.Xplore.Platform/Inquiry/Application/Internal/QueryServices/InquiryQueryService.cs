using TripMatch.Xplore.Platform.Inquiry.Domain.Models.Queries;
using TripMatch.Xplore.Platform.Inquiry.Domain.Repository;
using TripMatch.Xplore.Platform.Inquiry.Domain.Services;

namespace TripMatch.Xplore.Platform.Inquiry.Application.Internal.QueryServices;

public class InquiryQueryService : IInquiryQueryService
{
    private readonly IInquiryRepository _repository;

    public InquiryQueryService(IInquiryRepository repo) => _repository = repo;

    public async Task<IEnumerable<Domain.Models.Entities.Inquiry>> Handle(GetAllInquiriesQuery query)
    {
        return await _repository.ListWithResponsesAsync();
    }

    public async Task<IEnumerable<TripMatch.Xplore.Platform.Inquiry.Domain.Models.Entities.Inquiry>> Handle(GetAllInquiriesByExperienceQuery query)
    {
        return await _repository.FindByExperienceIdAsync(query.ExperienceId);
    }    
    
    public async Task<IEnumerable<TripMatch.Xplore.Platform.Inquiry.Domain.Models.Entities.Inquiry>> HandleByAgency(GetAllInquiriesByAgencyQuery query)
    {
        return await _repository.FindByAgencyIdAsync(query.AgencyId);
    }
    
}