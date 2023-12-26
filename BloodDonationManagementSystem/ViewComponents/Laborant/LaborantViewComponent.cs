using BloodDonationManagementSystem.Repositories.Concrete;
using BloodDonationManagementSystem.ViewComponents.Hasta;
using Microsoft.AspNetCore.Mvc;

namespace BloodDonationManagementSystem.ViewComponents.Laborant
{
    [ViewComponent]
    public class LaborantViewComponent : ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            return View();
        }
    }
}
