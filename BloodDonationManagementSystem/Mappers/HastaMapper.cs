using BloodDonationManagementSystem.Models.Doktor;
using BloodDonationManagementSystem.Models.Hasta;
using Microsoft.Data.SqlClient;

namespace BloodDonationManagementSystem.Mappers
{
    public class HastaMapper
    {
        public static Hasta Map(SqlDataReader reader)
        {
            return new Hasta
            {
                Isim = (string)reader["Isim"],
                Soyisim = (string)reader["Soyisim"]
            };
        }
    }
}
