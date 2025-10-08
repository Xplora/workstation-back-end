using TripMatch.Xplore.Platform.Reviews.Domain.Models.Entities;
using TripMatch.Xplore.Platform.Reviews.Domain.Models.Queries;
using TripMatch.Xplore.Platform.Reviews.Domain.Repository;
using TripMatch.Xplore.Platform.Reviews.Domain.Services;

namespace TripMatch.Xplore.Platform.Reviews.Application.QueryService;

public class ReviewQueryService : IReviewQueryService
{
    private readonly IReviewRepository _reviewRepository;

    public ReviewQueryService(IReviewRepository reviewRepository)
    {
        _reviewRepository = reviewRepository;
    }

    public async Task<IEnumerable<Review>> Handle(GetReviewsByAgencyIdQuery query)
    {

        return await _reviewRepository.FindByAgencyUserIdAsync(query.AgencyUserId); 
    }

    public async Task<Review?> Handle(GetReviewByIdQuery query)
    {
        return await _reviewRepository.FindByIdAsync(query.ReviewId);
    }
}