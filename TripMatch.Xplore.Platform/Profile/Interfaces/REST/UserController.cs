using Microsoft.AspNetCore.Mvc;
using TripMatch.Xplore.Platform.Profile.Domain.Models.Commands;
using TripMatch.Xplore.Platform.Profile.Domain.Models.Queries;
using TripMatch.Xplore.Platform.Profile.Domain.Services;
using TripMatch.Xplore.Platform.Profile.Interfaces.REST.Transform;

namespace TripMatch.Xplore.Platform.Profile.Interfaces.REST;

[ApiController]
[Route("api/v1/profile/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserQueryService _queryService;
    private readonly IUserCommandService _commandService;

    public UserController(IUserQueryService queryService, IUserCommandService commandService)
    {
        _queryService = queryService;
        _commandService = commandService;
    }

    /// <summary>
    /// Get a user by user ID
    /// </summary>
    [HttpGet("{userId:guid}")]
    public async Task<IActionResult> GetById(Guid userId)
    {
        var user = await _queryService.Handle(new GetUserByIdQuery(userId));
        if (user == null) return NotFound();


        if (user.Tourist != null)
        {
            return Ok(new
            {
                UserId = user.UserId,
                Name = $"{user.FirstName} {user.LastName}", 
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Phone = user.Number, 
                AvatarUrl = user.Tourist.AvatarUrl,
                Country = "" 
            });
        }
        
        
        var resource = UserResourceFromEntityAssembler.ToResource(user);
        return Ok(resource);
    }

    /// <summary>
    /// Update base user information (name and phone)
    /// </summary>
    [HttpPut("{userId:guid}")]
    public async Task<IActionResult> UpdateUser(Guid userId, [FromBody] UpdateUserCommand command)
    {
        try
        {
            var updatedUser = await _commandService.Handle(userId, command);
            var resource = UserResourceFromEntityAssembler.ToResource(updatedUser);
            return Ok(resource);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    /// <summary>
    /// Soft delete a user by ID (mark as inactive)
    /// </summary>
    [HttpDelete("{userId:guid}")]
    public async Task<IActionResult> Delete(Guid userId)
    {
        await _commandService.DeleteUserAsync(userId);
        return NoContent();
    }
}