using BloodDonationManagementSystem.Models.Hasta;
using BloodDonationManagementSystem.Repositories.Concrete;
using BloodDonationManagementSystem.ViewComponents.Hasta;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.Json;

namespace BloodDonationManagementSystem.ViewComponents.Doktor
{
    [ViewComponent]
    public class DoktorViewComponent : ViewComponent
    {
        private readonly BolumRepository bolumRepository;
        private readonly HastaTalepRepository hastaTalepRepository;
        public DoktorViewComponent(BolumRepository bolumRepository, HastaTalepRepository hastaTalepRepository)
        {
            this.bolumRepository = bolumRepository;
            this.hastaTalepRepository = hastaTalepRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            return View();
        }
    }
}
