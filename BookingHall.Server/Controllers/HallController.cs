using BookingHall.Application.DTO;
using BookingHall.Application.Services;
using BookingHall.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookingHall.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HallController : ControllerBase
{
    private readonly HallService _hallService;

    public HallController(HallService hallService)
    {
        _hallService = hallService;
    }

    [HttpGet]
    public async Task<ActionResult<FilterResult<GetHallDto>>> GetHallsAsync(
        [FromQuery] HallFilter filter
    )
    {
        if (filter == null)
            filter = new();

        var items = await _hallService.GetHallsAsync(filter);

        return Ok(items.Items);
    }

    [HttpPost]
    public async Task<ActionResult> AddAsync([FromBody] CreateHallDto hall)
    {
        await _hallService.AddAsync(hall);

        return Ok(hall);
    }
}
