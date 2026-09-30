using BookingHall.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookingHall.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookingController : ControllerBase
{
    public async Task<(string, decimal)> AddAsync([FromBody] Booking booking)
    {
        var bookingItem = new Booking() { };

        return ("Бронирование вышло на сумму: ", booking.TotalSum);
    }
}
