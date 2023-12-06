using BloodDonationManagementSystem.Repositories.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BloodDonationManagementSystem.ViewComponents.Hasta
{
    [ViewComponent]
    public class HastaViewComponent : ViewComponent
    {
        private readonly BolumRepository bolumRepository;
        public HastaViewComponent(BolumRepository bolumRepository)
        {
            this.bolumRepository = bolumRepository; 
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = new HastaViewComponentViewModel
            {
                Bolumler = bolumRepository.GetAllWithDoctors()
            };
            return View(model);
        }
    }
}
