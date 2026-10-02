using BookingHall.Domain.Models;

namespace BookingHall.Application.Abstractions;

public interface IServiceRepository
{
    Task AddASync(Service service);
    Task DeleteAsync(int id);
    Task EditAsync(int id, Service newService);
    Task<ICollection<Service>> GetServicesAsync();
}
