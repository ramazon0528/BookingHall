namespace BookingHall.Application.DTO;

public class GetHallDto
{
    public string Name { get; set; } = string.Empty;
    public int Capacity { get; set; }
    public decimal PricePerHour { get; set; }

    public ICollection<GetHallItemDto> HallItemDtos { get; set; } = [];
}
