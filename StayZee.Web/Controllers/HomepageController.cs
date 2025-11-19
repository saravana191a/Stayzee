using Microsoft.AspNetCore.Mvc;
using StayZee.Application.DTOs.ResponseDTO;
using StayZee.Application.Services;

namespace StayZee.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomepageController : ControllerBase
    {
        private readonly HomepageService _homepageService;

        public HomepageController(HomepageService homepageService)
        {
            _homepageService = homepageService;
        }

        [HttpGet("homes")]
        public async Task<IActionResult> GetHomepageHomes()
        {
            var homes = await _homepageService.GetHomepageHomesAsync();
            return Ok(homes);
        }
    }
}
