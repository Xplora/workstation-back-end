using TripMatch.Xplore.Platform.Inquiry.Domain.Models.Entities;
using TripMatch.Xplore.Platform.Shared.Domain.Repositories;

namespace TripMatch.Xplore.Platform.Inquiry.Domain.Repository;

public interface IResponseRepository : IBaseRepository<Response>
{
    Task<Response?> FindByInquiryIdAsync(int inquiryId);
}