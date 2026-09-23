namespace BookingHall.Domain.Models;

// BookingItem - промежуточная сущность для услуг и бронирования,
// чтобы у каждого зала и у каждого бронирования были отдельные услуги

public class BookingItem
{
    public int Id { get; set; }

    public int BookingId { get; set; }
    public Booking Booking { get; set; } = null!;

    public int ServiceId { get; set; }
    public Service Service { get; set; } = null!;

    public decimal Price { get; set; }
}
