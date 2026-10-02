namespace BookingHall.Application.DTO;

public class CreateHallDto
{
    public string Name { get; set; } = string.Empty;
    public int Capacity { get; set; }
    public decimal PricePerHour { get; set; }

    public ICollection<CreateHallItemDto> HallItems { get; set; } = [];
}
