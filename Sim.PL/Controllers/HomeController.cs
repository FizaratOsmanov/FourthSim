using Microsoft.AspNetCore.Mvc;

namespace Sim.PL.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
