using BookingHall.Application.DTO;
using BookingHall.Application.Services;
using BookingHall.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookingHall.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookingController : ControllerBase
{
    private readonly BookingService _bookingService;

    public BookingController(BookingService bookingService)
    {
        _bookingService = bookingService;
    }

    [HttpPost]
    public async Task<ActionResult> AddAsync([FromBody] CreateBookingDto dto)
    {
        var booking = await _bookingService.AddAsync(dto);

        return Ok(
            new
            {
                booking.Id,
                booking.BookingStart,
                booking.BookingEnd,
                booking.TotalSum,
            }
        );
    }
}
