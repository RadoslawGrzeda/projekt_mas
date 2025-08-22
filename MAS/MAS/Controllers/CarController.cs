using MAS.DTOs.View;
using MAS.Services;
using Microsoft.AspNetCore.Mvc;

namespace MAS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarController : ControllerBase
    {
        private readonly CarService _carService;

        public CarController(CarService carService)
        {
            _carService = carService;
        }

        [HttpGet("showCars")]
        //[Route("showCars")]
        public async Task<IActionResult> showCars()
        {
            var cars =  await _carService.showCars();
            return Ok(cars);
        }


    }
}
