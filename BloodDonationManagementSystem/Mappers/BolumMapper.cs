using BloodDonationManagementSystem.Models.Register;
using Microsoft.Data.SqlClient;

namespace BloodDonationManagementSystem.Mappers
{
    public class BolumMapper
    {
        public static Bolum Map(SqlDataReader reader)
        {
            return new Bolum
            {
                Id = (int)reader["Id"],
                Isim = (string)reader["Isim"]
            };
        }
    }
}
