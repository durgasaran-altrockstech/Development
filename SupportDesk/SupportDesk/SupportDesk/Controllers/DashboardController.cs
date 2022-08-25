using Microsoft.AspNetCore.Mvc;

namespace SupportDesk.Controllers
{
    public class DashboardController : Controller
    {
        [ActionName("Projects")]
        public IActionResult Projects()
        {
            return View();
        }

        [ActionName("Tickets")]
        public IActionResult Tickets()
        {
            return View();
        }
    }
}
