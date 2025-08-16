using Microsoft.AspNetCore.Mvc;

namespace MAS.Controllers
{
    public class PersonController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
