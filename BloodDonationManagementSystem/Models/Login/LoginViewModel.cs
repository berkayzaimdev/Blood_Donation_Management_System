using BloodDonationManagementSystem.Models.Register;

namespace BloodDonationManagementSystem.Models.Login
{
    public class LoginViewModel
    {
        public IEnumerable<KullaniciTipi>? KullaniciTipleri { get; set; }
        public Uye Uye { get; set; }
        public bool BeniHatirla { get; set; }
    }
}
