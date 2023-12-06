using BloodDonationManagementSystem.Models;
using Microsoft.Data.SqlClient;

namespace BloodDonationManagementSystem.Mappers
{
    public class KanGrubuMapper
    {
        public static KanGrubu Map(SqlDataReader reader)
        {
            return new KanGrubu
            {
                Id = (int)reader["Id"],
                Isim = (string)reader["Isim"],
                Rh = (reader["Rh"]).ToString()
            };
        }
    }
}
