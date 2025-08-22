using MAS.DTOs.View;
using MAS.Services;
using Microsoft.AspNetCore.Mvc;

namespace MAS.Controllers
{
    public class FrontListOfCar : Controller
    {
         private readonly PersonService _personService;
    public FrontListOfCar(PersonService personService) => _personService = personService;

    [HttpGet]
    public IActionResult Index()
    {
        return View(new 
        {
            StartDate = DateOnly.FromDateTime(DateTime.Today.AddDays(1)),
            NumberOfDays = 2
        });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Search(CarBrowseVm vm)
    {
        if (!ModelState.IsValid) return View("Index", vm);

        var cars = await _personService.showAvailableCars(vm.StartDate, vm.NumberOfDays);
        vm.Cars = cars.Select(c => new CarCardVm
        {
            Id = c.id,
            Brand = c.brand,
            Model = c.model,
            DailyRate = c.dailyRate,
            Deposit = c.deposit
        }).ToList();

        if (vm.Cars.Count == 0) vm.Message = "Brak dostępnych aut w tym terminie.";
        return View("Index", vm);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Reserve(int carId, DateOnly startDate, int numberOfDays)
    {
        try
        {
            await _personService.makeReservation(carId, startDate, numberOfDays);
            TempData["Success"] = "Rezerwacja utworzona.";
        }
        catch (Exception ex)
        {
            TempData["Error"] = ex.Message;
        }
        return RedirectToAction(nameof(Index));
    }
}

}
