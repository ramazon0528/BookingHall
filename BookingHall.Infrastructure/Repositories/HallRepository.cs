using System.Security.Cryptography.X509Certificates;
using BookingHall.Application.Abstractions;
using BookingHall.Application.DTO;
using BookingHall.Domain.Models;
using BookingHall.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BookingHall.Infrastructure.Repositories;

public class HallRepository : IHallRepository
{
    private AppDbContext _context;

    public HallRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddASync(Hall hall)
    {
        await _context.Halls.AddAsync(hall);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var hall = await _context.Halls.FindAsync(id);

        if (hall != null)
        {
            _context.Halls.Remove(hall);
            await _context.SaveChangesAsync();
        }
    }

    public async Task EditAsync(int id, Hall newHall)
    {
        var hall = await _context.Halls.FindAsync(id);

        if (hall != null)
        {
            hall.Name = newHall.Name;
            hall.Capacity = newHall.Capacity;
            hall.PricePerHour = newHall.PricePerHour;

            hall.HallItems.Clear();

            foreach (var item in newHall.HallItems)
                hall.HallItems.Add(item);

            _context.Halls.Update(hall);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<FilterResult<Hall>> GetHallsAsync(HallFilter filter)
    {
        IQueryable<Hall> query = _context.Halls.Include(x => x.HallItems);

        if (filter.BookingStart.HasValue && filter.Duration.HasValue)
        {
            var bookingStart = filter.BookingStart.Value;
            var bookingEnd = bookingStart + filter.Duration.Value;

            query = query.Where(x =>
                !x.Bookings.Any(b =>
                    b.BookingStart < bookingEnd && b.BookingStart + b.Duration > bookingStart
                )
            );
        }

        if (filter.Capacity.HasValue)
        {
            query = query.Where(x => x.Capacity >= filter.Capacity);
        }

        var items = await query.ToListAsync();

        return new FilterResult<Hall> { Items = items };
    }
}
