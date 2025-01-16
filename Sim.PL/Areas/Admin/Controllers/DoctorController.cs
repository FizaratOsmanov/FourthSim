using Microsoft.AspNetCore.Mvc;

namespace Sim.PL.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DoctorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
