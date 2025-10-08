using Microsoft.AspNetCore.Mvc;
using TripMatch.Xplore.Platform.ARM.Domain;
using TripMatch.Xplore.Platform.Profile.Domain.Models.Commands;
using TripMatch.Xplore.Platform.Profile.Domain.Models.Queries;
using TripMatch.Xplore.Platform.Profile.Domain.Services;
using TripMatch.Xplore.Platform.Profile.Interfaces.REST.Transform;

namespace TripMatch.Xplore.Platform.Profile.Interfaces.REST;

[ApiController]
[Route("api/v1/profile/user/[controller]")]
public class AgencyController : ControllerBase
{
    private readonly IUserQueryService _queryService;
    private readonly IUserCommandService _commandService;
    private readonly IBookingRepository _bookingRepository;

    public AgencyController(IUserQueryService queryService, IUserCommandService commandService, IBookingRepository bookingRepository)
    {
        _queryService = queryService;
        _commandService = commandService;
        _bookingRepository = bookingRepository;
    }

    /// <summary>
    /// Get agency profile by user ID
    /// </summary>
    [HttpGet("{userId:guid}")]
    public async Task<IActionResult> GetById(Guid userId)
    {
        var user = await _queryService.Handle(new GetUserByIdQuery(userId));
        if (user?.Agency == null) return NotFound();
        
        var bookings = await _bookingRepository.ListAllWithExperienceAsync();
        var reservationCount = bookings.Count(b =>
            b.Experience.Agency != null &&
            b.Experience.Agency.UserId == userId &&
            b.Status == "Confirmada");

        var resource = AgencyResourceAssembler.ToResource(user.Agency);
        resource.ReservationCount = reservationCount;

        return Ok(resource);
    }

    /// <summary>
    /// Update agency profile
    /// </summary>
    [HttpPut("{userId:guid}")]
    public async Task<IActionResult> Update(Guid userId, [FromBody] UpdateAgencyCommand command)
    {
        var user = await _queryService.Handle(new GetUserByIdQuery(userId));
        if (user?.Agency == null) return NotFound();

        var agency = user.Agency;

        agency.AgencyName = command.AgencyName ?? agency.AgencyName;
        agency.Ruc = command.Ruc ?? agency.Ruc;
        agency.Description = command.Description ?? agency.Description;
        agency.AvatarUrl = command.AvatarUrl ?? agency.AvatarUrl;
        agency.ContactEmail = command.ContactEmail ?? agency.ContactEmail;
        agency.ContactPhone = command.ContactPhone ?? agency.ContactPhone;
        agency.SocialLinkFacebook = command.SocialLinkFacebook ?? agency.SocialLinkFacebook;
        agency.SocialLinkInstagram = command.SocialLinkInstagram ?? agency.SocialLinkInstagram;
        agency.SocialLinkWhatsapp = command.SocialLinkWhatsapp ?? agency.SocialLinkWhatsapp;

        await _commandService.UpdateAgencyAsync(userId,command);
        return Ok(AgencyResourceAssembler.ToResource(agency));
    }
}