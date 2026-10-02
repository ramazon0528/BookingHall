using BookingHall.Domain.Models;

namespace BookingHall.Application.Abstractions;

public interface IBookingRepository
{
    Task AddASync(Booking booking);
    Task<Hall?> GetHall(int hallId);
}
