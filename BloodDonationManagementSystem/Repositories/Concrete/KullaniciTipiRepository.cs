using BloodDonationManagementSystem.Helpers;
using BloodDonationManagementSystem.Mappers;
using BloodDonationManagementSystem.Models.Register;
using Microsoft.Data.SqlClient;

namespace BloodDonationManagementSystem.Repositories.Concrete
{
    public class KullaniciTipiRepository : GenericRepository<KullaniciTipi>
    {
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
