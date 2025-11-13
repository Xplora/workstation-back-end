namespace TripMatch.Xplore.Platform.Inquiry.Domain.Models.Queries;

public class GetAllInquiriesByAgencyQuery
{
    public Guid AgencyId { get; set; }

    public GetAllInquiriesByAgencyQuery(Guid agencyId)
    {
        AgencyId = agencyId;
    }
}