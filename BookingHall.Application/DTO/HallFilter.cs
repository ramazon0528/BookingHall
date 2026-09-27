namespace BookingHall.Application.DTO;

public class HallFilter
{
    public DateTime? BookingStart { get; set; }
    public TimeSpan? Duration { get; set; }
    public int? Capacity { get; set; }
}
