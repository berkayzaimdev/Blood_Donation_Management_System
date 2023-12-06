using BloodDonationManagementSystem.Helpers;
using BloodDonationManagementSystem.Mappers;
using BloodDonationManagementSystem.Models;
using BloodDonationManagementSystem.Models.Login;
using Microsoft.Data.SqlClient;

namespace BloodDonationManagementSystem.Repositories.Concrete
{
    public class KullaniciTipiRepository : GenericRepository<KullaniciTipi>
    {
        public KullaniciTipi Get(int Id)
        {
            using (var connection = SqlHelper.GetSqlConnection())
            {
                string query =
                    "SELECT * FROM KullaniciTipi " +
                    "WHERE Id = @id";

                SqlCommand command = new(query, connection);
                command.Parameters.AddWithValue("@Id", Id);
                SqlDataReader reader = command.ExecuteReader();
                KullaniciTipi kulaniciTipi = new();
                if (reader.Read())
                    kulaniciTipi = KullaniciTipiMapper.Map(reader);
                return kulaniciTipi;
            }
        }

        public IEnumerable<KullaniciTipi> GetAll()
        {
            string query = "SELECT * FROM KullaniciTipi";
            var kullaniciTipleri = new List<KullaniciTipi>();
            using (var connection = SqlHelper.GetSqlConnection())
            {
                SqlCommand command = new(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    KullaniciTipi kullaniciTipi = KullaniciTipiMapper.Map(reader);
                    kullaniciTipleri.Add(kullaniciTipi);
                }
            }
            return kullaniciTipleri;
        }
    }
}
