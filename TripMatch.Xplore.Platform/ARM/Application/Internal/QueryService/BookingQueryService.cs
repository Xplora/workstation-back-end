using TripMatch.Xplore.Platform.ARM.Domain;
using TripMatch.Xplore.Platform.ARM.Domain.Models.Entities;
using TripMatch.Xplore.Platform.ARM.Domain.Models.Queries;
using TripMatch.Xplore.Platform.ARM.Domain.Services;

namespace TripMatch.Xplore.Platform.ARM.Application.BookingQueryService;

public class BookingQueryService : IBookingQueryService
{
    private readonly IBookingRepository _bookingRepository;

    public BookingQueryService(IBookingRepository bookingRepository)
    {
        _bookingRepository = bookingRepository;
    }

    public async Task<Booking?> Handle(GetBookingByIdQuery query)
    {
        return await _bookingRepository.FindByIdWithExperienceAsync(query.BookingId);
    }

    public async Task<IEnumerable<Booking>> Handle(GetBookingsByTouristIdQuery query)
    {
        return await _bookingRepository.FindByTouristIdAsync(query.TouristId); // Esto llamará al método modificado
    }

    public async Task<IEnumerable<Booking>> Handle(GetAllBookingsQuery query)
    {
        return await _bookingRepository.ListAllWithExperienceAsync(); // Esto llamará al método modificado
    }
    
}