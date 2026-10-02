using BookingHall.Application.Abstractions;
using BookingHall.Domain.Models;
using BookingHall.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BookingHall.Infrastructure.Repositories;

public class BookingRepository : IBookingRepository
{
    private readonly AppDbContext _context;

    public BookingRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddASync(Booking booking)
    {
        await _context.Bookings.AddAsync(booking);
        await _context.SaveChangesAsync();
    }

    public async Task<Hall?> GetHall(int hallId) =>
        await _context
            .Halls.Include(x => x.HallItems)
            .ThenInclude(x => x.Service)
            .FirstOrDefaultAsync(x => x.Id == hallId);
}
