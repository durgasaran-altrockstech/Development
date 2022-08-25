using Microsoft.AspNetCore.Mvc;

namespace SupportDesk.Controllers
{
    public class SupportTicketsController : Controller
    {
        [ActionName("CreateTicket")]
        public IActionResult CreateTicket()
        {
            return View();
        }
    }
}
