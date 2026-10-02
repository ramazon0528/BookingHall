using BookingHall.Application.Abstractions;
using BookingHall.Domain.Models;

namespace BookingHall.Application.Services;

public class ServiceService
{
    private readonly IServiceRepository _serviceRepository;

    public ServiceService(IServiceRepository serviceRepository)
    {
        _serviceRepository = serviceRepository;
    }

    public async Task AddAsync(Service service) => await _serviceRepository.AddASync(service);

    public async Task DeleteAsync(int id) => await _serviceRepository.DeleteAsync(id);

    public async Task EditAsync(int id, Service service) =>
        await _serviceRepository.EditAsync(id, service);

    public async Task<ICollection<Service>> GetServicesAsync() =>
        await _serviceRepository.GetServicesAsync();
}
