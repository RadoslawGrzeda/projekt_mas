using MAS.Models;
using MAS.Services;
using Microsoft.AspNetCore.Mvc;

namespace MAS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly PersonService _personService;

        public PersonController(PersonService personService)
        {
            this._personService = personService;
        }

        [HttpGet("get")]
        public async Task<IActionResult> getAll()
        {
            var person = _personService.GetAllPerson();
            return Ok(person);
        }

        [HttpGet("test")]
        public async Task<IActionResult> getTestk()
        {
            var tekst = "TEETTEETE";
            return Ok(tekst);
        }


        [HttpPost]
        public async Task<IActionResult> createPerson(Person Person)
        {
            var newPerson = await _personService.CreatePerson(Person);
            return Ok(newPerson);
            //return CreatedAtAction(nameof(GetById), new { id = newPerson.id }, newPerson);
        }

        [HttpPost("make_reservation")]
        public async Task<IActionResult> makeReservation(int carId, DateOnly startDate, int numberOfDays)
        {
            try
            {
                var reservation = await _personService.makeReservation(carId, startDate, numberOfDays);
                return Ok(reservation);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
