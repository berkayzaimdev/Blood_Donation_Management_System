﻿using BloodDonationManagementSystem.Models.Doktor;

namespace BloodDonationManagementSystem.Models.Hasta
{
    public class HastaTalep
    {
        public enum Durum
        {
            DoktorInceleme,
            Test,
            DoktorOnay,
            DoktorRed,
            Donor,
            Tamamlandi
        }
        public int? Id { get; set; }
        public Hasta Hasta { get; set; }
        public TalepDoktor? Doktor { get; set; }
        public string TalepTarihi { get; set; }
        public Durum TalepDurumu { get; set; }
        public string? TalepNedeni { get; set; }
    }
}
