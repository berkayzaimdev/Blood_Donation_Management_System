using BloodDonationManagementSystem.Models.Register;
using BloodDonationManagementSystem.Models;
using BloodDonationManagementSystem.Repositories.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using BloodDonationManagementSystem.Models.Login;
using BloodDonationManagementSystem.Helpers;

namespace BloodDonationManagementSystem.Controllers
{
    public class LoginController : Controller
    {
        private readonly KullaniciTipiRepository kullaniciTipiRepository;
        private readonly UyeRepository uyeRepository;

        public LoginController(KullaniciTipiRepository kullaniciTipiRepository, UyeRepository uyeRepository)
        {
            this.kullaniciTipiRepository = kullaniciTipiRepository;
            this.uyeRepository = uyeRepository;
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
                var uye = uyeRepository.Get(model.Uye);
                if(uye is null)
                {
                    return RedirectToAction("Index", "Home");
                }
                var claims = AuthHelper.GetClaims(uye);
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = AuthHelper.GetAuthProperties(model.BeniHatirla);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    claims,
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
