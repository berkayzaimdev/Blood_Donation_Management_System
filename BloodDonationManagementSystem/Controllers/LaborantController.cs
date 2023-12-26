using BloodDonationManagementSystem.Models.Hasta;
using BloodDonationManagementSystem.Repositories.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.Json;

namespace BloodDonationManagementSystem.Controllers
{
    public class LaborantController : Controller
    {
        private readonly HastaTalepRepository hastaTalepRepository;
        public LaborantController(HastaTalepRepository hastaTalepRepository)
        {
            this.hastaTalepRepository = hastaTalepRepository;   
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult TalepGetir()
        {
            IEnumerable<HastaTalep> talepler = hastaTalepRepository.GetAllBekleyen();
            return Json(JsonSerializer.Serialize(talepler));
        }
    }
}
