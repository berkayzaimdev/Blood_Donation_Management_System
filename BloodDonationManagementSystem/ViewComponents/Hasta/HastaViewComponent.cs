using BloodDonationManagementSystem.Repositories.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BloodDonationManagementSystem.ViewComponents.Hasta
{
    [ViewComponent]
    public class HastaViewComponent : ViewComponent
    {
        private readonly BolumRepository bolumRepository;
        private readonly HastaTalepRepository hastaTalepRepository;
        public HastaViewComponent(BolumRepository bolumRepository, HastaTalepRepository hastaTalepRepository)
        {
            this.bolumRepository = bolumRepository;
            this.hastaTalepRepository = hastaTalepRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var model = new HastaViewComponentViewModel
            {
                Bolumler = bolumRepository.GetAllWithDoctors(),
                Talepler = hastaTalepRepository.GetAllByHastaId(id)
            };
            return View(model);
        }
    }
}
