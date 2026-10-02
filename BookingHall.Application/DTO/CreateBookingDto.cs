namespace BookingHall.Application.DTO;

public class CreateBookingDto
{
    public int HallId { get; set; }
    public DateTime BookingStart { get; set; }
    public TimeSpan Duration { get; set; }

    public ICollection<CreateBookingItemDto> BookingItems { get; set; } = [];
}
