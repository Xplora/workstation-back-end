using TripMatch.Xplore.Platform.DAP.Domain.Models.Entities;
using TripMatch.Xplore.Platform.Profile.Domain.Models.Entities;
using TripMatch.Xplore.Platform.Shared.Domain.Model.Entities;

namespace TripMatch.Xplore.Platform.ARM.Domain.Models.Entities;

public class Booking : BaseEntity
{
    public int Id { get; set; }
    public DateTime BookingDate { get; set; }
    public int NumberOfPeople { get; set; }
    public decimal Price { get; set; }
    public string Status { get; set; } = string.Empty;
    
    public string Time { get; set; } = string.Empty;

    // Foreign keys
    public int ExperienceId { get; set; }
    public Experience Experience { get; set; } = null!;
    public Guid TouristId { get; set; }       
    public User Tourist { get; set; } = null!;

    public Booking() { }

    public Booking(
        Guid touristId,
        int experienceId,
        DateTime bookingDate,
        int numberOfPeople,
        decimal price,
        string status,
        string time
    )
    {
        TouristId = touristId;
        ExperienceId = experienceId;
        BookingDate = bookingDate;
        NumberOfPeople = numberOfPeople;
        Price = price;
        Status = status;
        Time = time;
    }
}