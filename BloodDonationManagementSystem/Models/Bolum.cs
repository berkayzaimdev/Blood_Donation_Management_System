﻿namespace BloodDonationManagementSystem.Models
{
    public class Bolum
    {
        public int Id { get; set; }
        public string Isim { get; set; }
        public IEnumerable<Doktor.Doktor> Doktorlar { get; set; }
    }
}
