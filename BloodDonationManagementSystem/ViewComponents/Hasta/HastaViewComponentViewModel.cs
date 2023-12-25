using BloodDonationManagementSystem.Models;
using BloodDonationManagementSystem.Models.Hasta;

namespace BloodDonationManagementSystem.ViewComponents.Hasta
{
    public class HastaViewComponentViewModel
    {
        public IEnumerable<Bolum> Bolumler { get; set; }
        public IEnumerable<HastaTalep> Talepler { get; set; }
    }
}
