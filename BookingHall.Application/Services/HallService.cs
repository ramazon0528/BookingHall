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

    public async Task AddAsync(CreateHallDto dto)
    {
        var item = new Hall()
        {
            Name = dto.Name,
            Capacity = dto.Capacity,
            PricePerHour = dto.PricePerHour,

            HallItems = dto
                .HallItems.Select(x => new HallItem() { ServiceId = x.ServiceId })
                .ToList(),
        };

        await _repository.AddASync(item);
    }

    public async Task DeleteAsync(int id) => await _repository.DeleteAsync(id);

    public async Task EditAsync(int id, CreateHallDto newHall)
    {
        var hall = new Hall()
        {
            Name = newHall.Name,
            Capacity = newHall.Capacity,
            PricePerHour = newHall.PricePerHour,

            HallItems = newHall
                .HallItems.Select(x => new HallItem() { ServiceId = x.ServiceId })
                .ToList(),
        };

        await _repository.EditAsync(id, hall);
    }

    public async Task<FilterResult<GetHallDto>> GetHallsAsync(HallFilter filter)
    {
        var result = await _repository.GetHallsAsync(filter);

        return new FilterResult<GetHallDto>
        {
            Items = result
                .Items.Select(x => new GetHallDto
                {
                    Name = x.Name,
                    Capacity = x.Capacity,
                    PricePerHour = x.PricePerHour,

                    HallItemDtos = x
                        .HallItems.Select(item => new GetHallItemDto { ServiceId = item.ServiceId })
                        .ToList(),
                })
                .ToList(),
        };
    }
}
