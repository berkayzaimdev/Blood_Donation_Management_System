using BloodDonationManagementSystem.Helpers;
using BloodDonationManagementSystem.Mappers;
using BloodDonationManagementSystem.Models;
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

        public IEnumerable<Bolum> GetAllWithDoctors()
        {
            var bolumler = GetAll();
            foreach (var bolum in bolumler)
            {
                bolum.Doktorlar = GetDoctorsForBolum(bolum.Id);
            }
            return bolumler;
        }

        private IEnumerable<Doktor> GetDoctorsForBolum(int bolumId)
        {
            string query = "SELECT Uye.* FROM Uye " +
                           "JOIN DoktorBolum ON Uye.Id = DoktorBolum.DoktorId " +
                           "WHERE DoktorBolum.BolumId = @BolumId";

            var doctors = new List<Doktor>();
            using (var connection = SqlHelper.GetSqlConnection())
            {
                SqlCommand command = new(query, connection);
                command.Parameters.AddWithValue("@BolumId", bolumId);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Doktor doktor = DoktorMapper.Map(reader);
                    doctors.Add(doktor);
                }
            }

            return doctors;
        }
    }
}
