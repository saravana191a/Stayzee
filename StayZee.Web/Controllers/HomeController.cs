using Microsoft.AspNetCore.Mvc;
using StayZee.Application.Interfaces.IServices;
using StayZee.Domain.Entities;

namespace StayZee.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IHomeService _homeService;

        public HomeController(IHomeService homeService)
        {
            _homeService = homeService;
        }

        [HttpGet("available")]
        public async Task<IActionResult> GetAvailableHomes()
        {
            var homes = await _homeService.GetAvailableHomesAsync();
            return Ok(homes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetHome(Guid id)
        {
            var home = await _homeService.GetHomeByIdAsync(id);
            if (home == null) return NotFound();
            return Ok(home);
        }
    }
}
