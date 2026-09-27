using BookingHall.Application.Abstractions;
using BookingHall.Application.DTO;
using BookingHall.Domain.Models;

namespace BookingHall.Application.Services;

public class HallService
{
    private readonly IHallRepository _repository;

    public HallService(IHallRepository repository)
    {
        _repository = repository;
    }

    public async Task AddAsync(Hall hall) => await _repository.AddASync(hall);

    public async Task DeleteAsync(int id) => await _repository.DeleteAsync(id);

    public async Task EditAsync(int id, Hall newHall) => await _repository.EditAsync(id, newHall);

    public async Task GetHallsAsync(HallFilter filter) => await _repository.GetHallsAsync(filter);
}
