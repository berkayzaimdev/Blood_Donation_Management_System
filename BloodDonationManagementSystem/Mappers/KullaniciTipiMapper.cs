using BloodDonationManagementSystem.Models;
using Microsoft.Data.SqlClient;

namespace BloodDonationManagementSystem.Mappers
{
    public class KullaniciTipiMapper
    {
        public static KullaniciTipi Map(SqlDataReader reader)
        {
            return new KullaniciTipi
            {
                Id = (int)reader["Id"],
                Isim = (string)reader["Isim"]
            };
        }
    }
}
