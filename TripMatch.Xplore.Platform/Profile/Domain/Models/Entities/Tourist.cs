
using TripMatch.Xplore.Platform.Shared.Domain.Model.Entities;

namespace TripMatch.Xplore.Platform.Profile.Domain.Models.Entities;


/// <summary>
/// Representa a un user con perfil de tourist.
/// </summary>
public class Tourist : BaseEntity
{
    public Guid UserId { get; set; }

    public string? AvatarUrl { get; set; }

    public User? User { get; set; }
}