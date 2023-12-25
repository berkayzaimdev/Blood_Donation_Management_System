using BloodDonationManagementSystem.Models;
using BloodDonationManagementSystem.Models.Hasta;
using BloodDonationManagementSystem.Repositories.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using System.Globalization;

namespace BloodDonationManagementSystem.Mappers
{
    public class HastaTalepMapper
    {
        public static HastaTalep Map(SqlDataReader reader)
        {
            return new HastaTalep
            {
                TalepTarihi = ((DateTime)reader["TalepTarihi"]).ToShortDateString()
            };
        }
    }
}
