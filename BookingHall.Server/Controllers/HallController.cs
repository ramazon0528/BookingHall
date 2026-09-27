using Microsoft.AspNetCore.Mvc;

namespace BookingHall.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HallController : ControllerBase
{
    public string Get()
    {
        return "heelo";
    }
}
