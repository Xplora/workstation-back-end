using FluentValidation;
using TripMatch.Xplore.Platform.DAP.Domain.Models.Commands;
using TripMatch.Xplore.Platform.DAP.Domain.Models.Queries;
using TripMatch.Xplore.Platform.DAP.Domain.Services;
using TripMatch.Xplore.Platform.Profile.Domain.Models.Queries;
using TripMatch.Xplore.Platform.Profile.Domain.Services;

namespace TripMatch.Xplore.Platform.DAP.Domain.Models.Validators;

public class CreateFavoriteCommandValidator : AbstractValidator<CreateFavoriteCommand>
{
    private readonly IExperienceQueryService _experienceQueryService;
    private readonly IUserQueryService _userQueryService;

    public CreateFavoriteCommandValidator(
        IExperienceQueryService experienceQueryService,
        IUserQueryService userQueryService)
    {
        _experienceQueryService = experienceQueryService;
        _userQueryService = userQueryService;

        RuleFor(x => x.TouristId)
            .NotEmpty().WithMessage("Tourist ID is required.")
            .MustAsync(UserExists).WithMessage("The specified tourist does not exist.");

        RuleFor(x => x.ExperienceId)
            .NotEmpty().WithMessage("Experience ID is required.")
            .MustAsync(ExperienceExists).WithMessage("The specified experience does not exist.");
    }

    private async Task<bool> UserExists(Guid userId, CancellationToken _)
    {
        var user = await _userQueryService.Handle(new GetUserByIdQuery(userId));
        return user is not null;
    }

    private async Task<bool> ExperienceExists(int experienceId, CancellationToken _)
    {
        var exp = await _experienceQueryService.Handle(new GetExperienceByIdQuery(experienceId));
        return exp is not null;
    }
}