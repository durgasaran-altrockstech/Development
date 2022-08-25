using Microsoft.AspNetCore.Mvc;

namespace SupportDesk.Controllers
{
    public class PagesController : Controller
    {
        [ActionName("Profile")]
        public IActionResult Profile()
        {
            return View();
        }


        [ActionName("ProfileSettings")]
        public IActionResult ProfileSettings()
        {
            return View();
        }

        [ActionName("Team")]
        public IActionResult Team()
        {
            return View();
        }

    }
}
