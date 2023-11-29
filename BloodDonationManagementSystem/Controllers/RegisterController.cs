using BloodDonationManagementSystem.Models;
using BloodDonationManagementSystem.Models.Register;
using BloodDonationManagementSystem.Repositories.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Security.Cryptography.Xml;

namespace BloodDonationManagementSystem.Controllers
{
    public class RegisterController : Controller
    {
        private readonly BolumRepository bolumRepository;
        private readonly KullaniciTipiRepository kullaniciTipiRepository;
        private readonly UyeRepository uyeRepository;
        public RegisterController(BolumRepository bolumRepository, KullaniciTipiRepository kullaniciTipiRepository, UyeRepository uyeRepository)
        {
            this.bolumRepository = bolumRepository;
            this.kullaniciTipiRepository = kullaniciTipiRepository;
            this.uyeRepository = uyeRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = new RegisterViewModel
            {
                Bolumler = bolumRepository.GetAll(),
                KullaniciTipleri = kullaniciTipiRepository.GetAll()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if(uyeRepository.Add(model.Uye,model.BolumId))
                {
                    return RedirectToAction("Index", "Home");
                }
                return RedirectToAction("Index", "Home");
            }
            model.KullaniciTipleri = kullaniciTipiRepository.GetAll();
            model.Bolumler = bolumRepository.GetAll();
            return View(model);
        }
    }
}
