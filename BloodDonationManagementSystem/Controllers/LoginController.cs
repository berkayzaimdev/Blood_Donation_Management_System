using Microsoft.AspNetCore.Mvc;

namespace BloodDonationManagementSystem.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
