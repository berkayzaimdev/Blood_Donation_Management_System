using BloodDonationManagementSystem.Models.Register;
using BloodDonationManagementSystem.Models;
using BloodDonationManagementSystem.Repositories.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using BloodDonationManagementSystem.Models.Login;

namespace BloodDonationManagementSystem.Controllers
{
    public class LoginController : Controller
    {
        private readonly KullaniciTipiRepository kullaniciTipiRepository;

        public LoginController(KullaniciTipiRepository kullaniciTipiRepository)
        {
            this.kullaniciTipiRepository = kullaniciTipiRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = new LoginViewModel
            {
                KullaniciTipleri = kullaniciTipiRepository.GetAll()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                List<Claim> claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, "testId"),
                    new Claim(ClaimTypes.Name, "testUname"),
                    new Claim(ClaimTypes.GivenName, "testName"),
                    new Claim(ClaimTypes.Surname, "testSurname")
                };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = model.BeniHatirla
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout() 
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
