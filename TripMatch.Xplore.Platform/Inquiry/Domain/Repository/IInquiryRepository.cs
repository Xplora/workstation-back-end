using TripMatch.Xplore.Platform.Shared.Domain.Repositories;

namespace TripMatch.Xplore.Platform.Inquiry.Domain.Repository;

public interface IInquiryRepository : IBaseRepository<TripMatch.Xplore.Platform.Inquiry.Domain.Models.Entities.Inquiry>
{
    Task<IEnumerable<TripMatch.Xplore.Platform.Inquiry.Domain.Models.Entities.Inquiry>> FindByExperienceIdAsync(int experienceId);
}