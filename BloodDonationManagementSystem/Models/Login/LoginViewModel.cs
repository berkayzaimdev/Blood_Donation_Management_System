namespace BloodDonationManagementSystem.Models.Login
{
    public class LoginViewModel
    {
        public IEnumerable<KullaniciTipi>? KullaniciTipleri { get; set; }
        public LoginUyeViewModel Uye { get; set; }
        public bool BeniHatirla { get; set; }
    }
}
