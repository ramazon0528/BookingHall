using BookingHall.Application.DTO;
using BookingHall.Application.Services;
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
        var items = await _hallService.GetHallsAsync(filter);

        return Ok(items);
    }

    [HttpPost]
    public async Task<ActionResult> AddAsync([FromBody] CreateHallDto hall)
    {
        await _hallService.AddAsync(hall);

        return Ok(hall);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _hallService.DeleteAsync(id);

        return Ok($"Hall c Id: {id} успешно удален!");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> EditAsync(int id, [FromBody] CreateHallDto newHall)
    {
        await _hallService.EditAsync(id, newHall);

        return Ok($"Hall c Id: {id} успешно изменен!");
    }
}
