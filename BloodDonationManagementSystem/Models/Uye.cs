namespace BloodDonationManagementSystem.Models
{
    public class Uye
    {
        public int Id { get; set; }
        public KullaniciTipi KullaniciTipi { get; set; }
        public string TcKimlikNo { get; set; }
        public string Isim { get; set; }
        public string Soyisim { get; set; }
        public string Yas { get; set; }
        public string Telefon { get; set; }
    }
}
