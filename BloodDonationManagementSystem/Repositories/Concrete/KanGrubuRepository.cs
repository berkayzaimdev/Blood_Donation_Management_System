using BloodDonationManagementSystem.Helpers;
using BloodDonationManagementSystem.Mappers;
using BloodDonationManagementSystem.Models;
using Microsoft.Data.SqlClient;

namespace BloodDonationManagementSystem.Repositories.Concrete
{
    public class KanGrubuRepository : GenericRepository<KanGrubu>
    {
        public IEnumerable<KanGrubu> GetAll()
        {
            string query = "SELECT * FROM KanGrubu";
            var items = new List<KanGrubu>();
            using (var connection = SqlHelper.GetSqlConnection())
            {
                SqlCommand command = new(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    KanGrubu item = KanGrubuMapper.Map(reader);
                    items.Add(item);
                }
            }
            return items;
        }
    }
}
