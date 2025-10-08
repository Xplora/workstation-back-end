using TripMatch.Xplore.Platform.Inquiry.Domain.Models.Entities;
using TripMatch.Xplore.Platform.Inquiry.Domain.Models.Queries;
using TripMatch.Xplore.Platform.Inquiry.Domain.Repository;
using TripMatch.Xplore.Platform.Inquiry.Domain.Services;

namespace TripMatch.Xplore.Platform.Inquiry.Application.Internal.QueryServices;

public class ResponseQueryService : IResponseQueryService
{
    private readonly IResponseRepository _repository;

    public ResponseQueryService(IResponseRepository repo) => _repository = repo;

    public async Task<Response?> Handle(GetResponseByInquiryIdQuery query)
    {
        return await _repository.FindByInquiryIdAsync(query.InquiryId);
    }    
}