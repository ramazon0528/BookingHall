namespace BookingHall.Application.DTO;

public class FilterResult<T>
{
    public ICollection<T> Items { get; set; } = [];
}
