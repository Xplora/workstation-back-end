using TripMatch.Xplore.Platform.Inquiry.Domain.Models.Entities;
using TripMatch.Xplore.Platform.Inquiry.Interfaces.REST.Resources;

namespace TripMatch.Xplore.Platform.Inquiry.Interfaces.REST.Transform;

public class ResponseResourceFromEntityAssembler
{
    public static ResponseResource ToResourceFromEntity(Response entity)
    {
        return new ResponseResource(
            entity.Id,
            entity.InquiryId,
            entity.ResponderId,
            entity.Answer,
            entity.AnsweredAt
        );
    }
    
}