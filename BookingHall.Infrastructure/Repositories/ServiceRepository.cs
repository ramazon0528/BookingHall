using BookingHall.Application.Abstractions;
using BookingHall.Domain.Models;
using BookingHall.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BookingHall.Infrastructure.Repositories;

public class ServiceRepository : IServiceRepository
{
    private readonly AppDbContext _context;

    public ServiceRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddASync(Service service)
    {
        await _context.Services.AddAsync(service);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var service = await _context.Services.FindAsync(id);

        if (service != null)
        {
            _context.Services.Remove(service);
            await _context.SaveChangesAsync();
        }
    }

    public async Task EditAsync(int id, Service newService)
    {
        var service = await _context.Services.FindAsync(id);

        if (service == null)
            return;

        service.Name = newService.Name;

        _context.Services.Update(service);
        await _context.SaveChangesAsync();
    }

    public async Task<ICollection<Service>> GetServicesAsync() =>
        await _context.Services.ToListAsync();
}
