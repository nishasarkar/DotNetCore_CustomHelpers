using Microsoft.AspNetCore.Mvc;

namespace Lab_CustomHelpers.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
