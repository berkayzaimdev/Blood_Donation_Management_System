using BloodDonationManagementSystem.Models.Hasta;
using BloodDonationManagementSystem.Repositories.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.Json;

namespace BloodDonationManagementSystem.Controllers
{
    public class DoktorController : Controller
    {
        private readonly HastaTalepRepository hastaTalepRepository;

        public DoktorController(HastaTalepRepository hastaTalepRepository)
        {
            this.hastaTalepRepository = hastaTalepRepository;
        }

        [HttpPost]
        public JsonResult TalepGetir()
        {
            var doktorId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            IEnumerable<HastaTalep> talepler = hastaTalepRepository.GetAllBekleyenByDoktorId(doktorId);
            return Json(JsonSerializer.Serialize(talepler));
        }

        [HttpPost]
        public JsonResult TesteGonder(int talepId)
        {
            hastaTalepRepository.AddToBekleyenTalep(talepId);
            return Json(new {});
        }
    }
}
