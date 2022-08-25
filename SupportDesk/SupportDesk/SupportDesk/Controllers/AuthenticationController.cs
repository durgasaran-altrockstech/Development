using Microsoft.AspNetCore.Mvc;

namespace SupportDesk.Controllers
{
    public class AuthenticationController : Controller
    {
        [ActionName("SignIn")]
        public IActionResult Index()
        {
            return View();
        }

        [ActionName("PasswordReset")]
        public IActionResult PasswordResetBasic()
        {
            return View();
        }

        [ActionName("LockScreen")]
        public IActionResult LockScreen()
        {
            return View();
        }
        [ActionName("Logout")]
        public IActionResult Logout()
        {
            return View();
        }
    }
}
