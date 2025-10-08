﻿using TripMatch.Xplore.Platform.Inquiry.Interfaces.REST.Resources;

namespace TripMatch.Xplore.Platform.Inquiry.Interfaces.REST.Transform;

public class InquiryResourceFromEntityAssembler
{
    public static InquiryResource ToResourceFromEntity(TripMatch.Xplore.Platform.Inquiry.Domain.Models.Entities.Inquiry entity)
    {
        return new InquiryResource(
            entity.Id,
            entity.ExperienceId,
            entity.UserId,
            entity.Question,
            entity.AskedAt);
    }
}