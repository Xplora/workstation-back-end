using FluentValidation;
using Microsoft.EntityFrameworkCore;
using TripMatch.Xplore.Platform.Inquiry.Domain.Models.Commands;
using TripMatch.Xplore.Platform.Inquiry.Domain.Models.Entities;
using TripMatch.Xplore.Platform.Inquiry.Domain.Repository;
using TripMatch.Xplore.Platform.Inquiry.Domain.Services;
using TripMatch.Xplore.Platform.Shared.Domain.Repositories;
using TripMatch.Xplore.Platform.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace TripMatch.Xplore.Platform.Inquiry.Application.Internal.CommandServices;

public class ResponseCommandService : IResponseCommandService
{
    private readonly IResponseRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<CreateResponseCommand> _validator;
    private readonly AppDbContext _context;
    public ResponseCommandService(IResponseRepository repo, IUnitOfWork unit, IValidator<CreateResponseCommand> val,AppDbContext context)
    {
        _repository = repo;
        _unitOfWork = unit;
        _validator = val;
        _context = context; 
    }

    public async Task<Response> Handle(CreateResponseCommand command)
    {
        var result = await _validator.ValidateAsync(command);
        if (!result.IsValid)
            throw new ValidationException(result.Errors);
        
        var inquiry = await _context.Set<Domain.Models.Entities.Inquiry>()
            .Include(i => i.Response)
            .FirstOrDefaultAsync(i => i.Id == command.InquiryId);

        if (inquiry == null)
            throw new Exception($"Inquiry with Id {command.InquiryId} not found");

        var response = new Response
        {
            ResponderId = command.ResponderId,
            Answer = command.Answer,
            AnsweredAt = command.AnsweredAt,
            CreatedDate = DateTime.UtcNow,
            IsActive = true,
            Inquiry = inquiry
        };
        
        await _context.Set<Domain.Models.Entities.Response>().AddAsync(response);
        await _context.SaveChangesAsync();

        return response;
    }
}