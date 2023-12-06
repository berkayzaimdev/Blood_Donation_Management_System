namespace BloodDonationManagementSystem.Models.Register
{
    public class RegisterViewModel
    {
        public IEnumerable<Bolum>? Bolumler { get; set; }
        public IEnumerable<KullaniciTipi>? KullaniciTipleri { get; set; }
        public IEnumerable<KanGrubu>? KanGruplari { get; set; }
        public RegisterUyeViewModel Uye { get; set; }
        public int BolumId { get; set; }
        public int KullaniciTipiId { get; set; }
        public int KanGrubuId { get; set; }
    }
}
