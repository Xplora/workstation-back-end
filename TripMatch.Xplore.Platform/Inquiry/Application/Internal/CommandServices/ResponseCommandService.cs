using FluentValidation;
using TripMatch.Xplore.Platform.Inquiry.Domain.Models.Commands;
using TripMatch.Xplore.Platform.Inquiry.Domain.Models.Entities;
using TripMatch.Xplore.Platform.Inquiry.Domain.Repository;
using TripMatch.Xplore.Platform.Inquiry.Domain.Services;
using TripMatch.Xplore.Platform.Shared.Domain.Repositories;

namespace TripMatch.Xplore.Platform.Inquiry.Application.Internal.CommandServices;

public class ResponseCommandService : IResponseCommandService
{
    private readonly IResponseRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<CreateResponseCommand> _validator;

    public ResponseCommandService(IResponseRepository repo, IUnitOfWork unit, IValidator<CreateResponseCommand> val)
    {
        _repository = repo;
        _unitOfWork = unit;
        _validator = val;
    }

    public async Task<Response> Handle(CreateResponseCommand command)
    {
        var result = await _validator.ValidateAsync(command);
        if (!result.IsValid)
            throw new ValidationException(result.Errors);

        var response = new Response
        {
            InquiryId = command.InquiryId,
            ResponderId = command.ResponderId,
            Answer = command.Answer,
            AnsweredAt = command.AnsweredAt,
            CreatedDate = DateTime.UtcNow,
            IsActive = true
        };

        await _repository.AddAsync(response);
        await _unitOfWork.CompleteAsync();
        return response;
    }   
}