using BloodDonationManagementSystem.Models.Hasta;
using BloodDonationManagementSystem.Repositories.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text.Json;

namespace BloodDonationManagementSystem.Controllers
{
    public class HastaController : Controller
    {
        private readonly HastaTalepRepository hastaTalepRepository;

        public HastaController(HastaTalepRepository hastaTalepRepository)
        {
            this.hastaTalepRepository = hastaTalepRepository;
        }

        [HttpPost]
        public JsonResult TalepGonder(int doktorId, string talepNedeni)
        {
            var hastaId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            hastaTalepRepository.Add(hastaId, doktorId, talepNedeni);
            return Json(new { success = true, message = "Data received successfully" });
        }

        [HttpPost]
        public JsonResult TalepGetir()
        {
            var hastaId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            IEnumerable<HastaTalep> talepler = hastaTalepRepository.GetAllByHastaId(hastaId);
            return Json(JsonSerializer.Serialize(talepler));
        }
    }
}
