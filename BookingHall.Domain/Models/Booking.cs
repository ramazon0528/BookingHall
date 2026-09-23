namespace BookingHall.Domain.Models;

public class Booking
{
    public int Id { get; set; }
    public DateTime BookingStart { get; set; }
    public TimeSpan Duration { get; set; }

    public int HallId { get; set; }
    public Hall Hall { get; set; } = null!;

    public ICollection<BookingItem> BookingItems { get; set; } = [];

    public decimal TotalSum =>
        Hall.PricePerHour * (decimal)Duration.TotalHours + BookingItems.Sum(x => x.Price);
}
