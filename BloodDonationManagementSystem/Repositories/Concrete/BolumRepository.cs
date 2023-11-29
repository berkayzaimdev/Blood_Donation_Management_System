using BloodDonationManagementSystem.Helpers;
using BloodDonationManagementSystem.Mappers;
using BloodDonationManagementSystem.Models;
using BloodDonationManagementSystem.Models.Register;
using Microsoft.Data.SqlClient;

namespace BloodDonationManagementSystem.Repositories.Concrete
{
    public class BolumRepository : GenericRepository<Bolum>
    {
        public IEnumerable<Bolum> GetAll()
        {
            string query = "SELECT * FROM Bolum";
            var bolumler = new List<Bolum>();
            using (var connection = SqlHelper.GetSqlConnection())
            {
                SqlCommand command = new(query,connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Bolum bolum = BolumMapper.Map(reader);
                    bolumler.Add(bolum);
                }
            }
            return bolumler;
        }
    }
}
