using FluentValidation;
using TripMatch.Xplore.Platform.Inquiry.Domain.Models.Commands;
using TripMatch.Xplore.Platform.Inquiry.Domain.Repository;
using TripMatch.Xplore.Platform.Inquiry.Domain.Services;
using TripMatch.Xplore.Platform.Shared.Domain.Repositories;

namespace TripMatch.Xplore.Platform.Inquiry.Application.Internal.CommandServices;

public class InquiryCommandService : IInquiryCommandService
{
    private readonly IInquiryRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<CreateInquiryCommand> _validator;

    public InquiryCommandService(IInquiryRepository repo, IUnitOfWork unit, IValidator<CreateInquiryCommand> val)
    {
        _repository = repo;
        _unitOfWork = unit;
        _validator = val;
    }

    public async Task<TripMatch.Xplore.Platform.Inquiry.Domain.Models.Entities.Inquiry> Handle(CreateInquiryCommand command)
    {
        var validation = await _validator.ValidateAsync(command);
        if (!validation.IsValid)
            throw new ValidationException(validation.Errors);

        var inquiry = new TripMatch.Xplore.Platform.Inquiry.Domain.Models.Entities.Inquiry
        {
            ExperienceId = command.ExperienceId,
            UserId = command.UserId,
            Question = command.Question,
            AskedAt = command.AskedAt,
            IsActive = true,
            CreatedDate = DateTime.UtcNow
        };

        await _repository.AddAsync(inquiry);
        await _unitOfWork.CompleteAsync();
        return inquiry;
    }
}