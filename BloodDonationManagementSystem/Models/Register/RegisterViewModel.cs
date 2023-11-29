namespace BloodDonationManagementSystem.Models.Register
{
    public class RegisterViewModel
    {
        public IEnumerable<Bolum>? Bolumler { get; set; }
        public IEnumerable<KullaniciTipi>? KullaniciTipleri { get; set; }
        public Uye Uye { get; set; }
        public int BolumId { get; set; }
    }
}
