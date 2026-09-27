using BookingHall.Application.DTO;
using BookingHall.Domain.Models;

namespace BookingHall.Application.Abstractions;

public interface IHallRepository
{
    Task AddASync(Hall hall);
    Task DeleteAsync(int id);
    Task EditAsync(int id, Hall newHall);
    Task<FilterResult<Hall>> GetHallsAsync(HallFilter filter);
}
