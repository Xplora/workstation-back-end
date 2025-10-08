namespace TripMatch.Xplore.Platform.Shared.Domain.Model.Entities;

public class BaseEntity
{
    public DateTime CreatedDate { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public bool IsActive { get; set; }
}