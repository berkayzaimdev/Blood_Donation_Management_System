using BloodDonationManagementSystem.Models;
using BloodDonationManagementSystem.Models.Doktor;
using BloodDonationManagementSystem.Repositories.Concrete;
using Microsoft.Data.SqlClient;

namespace BloodDonationManagementSystem.Mappers
{
    public class TalepDoktorMapper
    {
        public static TalepDoktor Map(SqlDataReader reader,BolumRepository bolumRepository)
        {
            return new TalepDoktor
            {
                Isim = (string)reader["Isim"],
                Soyisim = (string)reader["Soyisim"],
                Bolum = bolumRepository.GetBolumNameOfDoktor((int)reader["Id"]),
                Yas = Convert.ToInt32((string)reader["Yas"]),
                Telefon = (string)reader["Telefon"]
            };
        }
    }
}
