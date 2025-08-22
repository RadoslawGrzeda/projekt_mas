//using System.Diagnostics;
//using MAS.Models;
//using Microsoft.AspNetCore.Mvc;

//namespace MAS.Controllers
//{
//    public class HomeController : Controller
//    {
//        private readonly ILogger<HomeController> _logger;

//        public HomeController(ILogger<HomeController> logger)
//        {
//            _logger = logger;
//        }

//        // Jedna strona z zak³adkami
//        public IActionResult Index()
//        {
//            return View();
//        }

//        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
//        public IActionResult Error()
//        {
//            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
//        }
//    }
//}
using MAS.DTOs.View;
using MAS.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MAS.Controllers
{
    public class HomeController : Controller
    {
        private readonly PersonService _personService;
        private readonly CarService _carService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(PersonService personService,CarService carService, ILogger<HomeController> logger)
        {
            _personService = personService;
            _carService = carService;
            _logger = logger;
        }

        // ============== ZAK£ADKA: LISTA SAMOCHODÓW ==============
        [HttpGet]
        public async Task<IActionResult> Cars()
        {
            ViewBag.ActiveTab = "cars";
            //var vm = new CarBrowseVm
            //{
            //    StartDate = DateOnly.FromDateTime(DateTime.Today.AddDays(1)),
            //    NumberOfDays = 3
            //};
            var allCars = await _carService.showCars();



            var vm = new CarBrowseVm
            {
                Cars = allCars.Select(c => new CarCardVm
                {
                    Id = c.id,
                    Brand = c.brand,
                    Model = c.model,
                    DailyRate = c.dailyRate,
                    Deposit = c.deposit
                }).ToList()
            };
            // Assuming this is a synchronous call for simplicity  
            return View(vm); // Views/Home/Cars.cshtml
        }
   


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CarsSearch(CarBrowseVm vm)
        {
            ViewBag.ActiveTab = "cars";

            if (!ModelState.IsValid)
                return View("Cars", vm);

            var cars = await _personService.showAvailableCars(vm.StartDate, vm.NumberOfDays);
            vm.Cars = cars.Select(c => new CarCardVm
            {
                Id = c.id,
                Brand = c.brand,
                Model = c.model,
                DailyRate = c.dailyRate,
                Deposit = c.deposit
            }).ToList();

            if (!vm.Cars.Any())
                vm.Message = "Brak aut w podanym terminie.";

            return View("Cars", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CarsReserve(int carId, DateOnly startDate, int numberOfDays)
        {
            try
            {
                await _personService.makeReservation(carId, startDate, numberOfDays);
                TempData["Success"] = $"Zarezerwowano auto (ID {carId}) na {numberOfDays} dni od {startDate}.";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Reserve failed");
                TempData["Error"] = ex.Message;
            }
            return RedirectToAction(nameof(Cars));
        }

        // ============== ZAK£ADKA: REZERWACJE ==============
        [HttpGet]
        public IActionResult Reservations()
        {
            ViewBag.ActiveTab = "reservations";
            return View(); // Views/Home/Reservations.cshtml
        }

        // (opcjonalnie) POST-y do anulowania itp. te¿ tutaj

        // ============== ZAK£ADKA: HISTORIA ==============
        [HttpGet]
        public IActionResult History()
        {
            ViewBag.ActiveTab = "history";
            return View(); // Views/Home/History.cshtml
        }
    }
}
