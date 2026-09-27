namespace BookingHall.Domain.Models;

public class HallItem
{
    public int Id { get; set; }

    public int HallId { get; set; }
    public Hall Hall { get; set; } = null!;

    public int ServiceId { get; set; }
    public Service Service { get; set; } = null!;
}
