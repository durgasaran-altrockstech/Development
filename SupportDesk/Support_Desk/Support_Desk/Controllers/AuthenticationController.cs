using Microsoft.AspNetCore.Mvc;

namespace Support_Desk.Controllers
{
    public class AuthenticationController : Controller
    {
        [ActionName("Login")]
        public IActionResult Login()
        {
            return View();

        }
    }
}
