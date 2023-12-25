using BloodDonationManagementSystem.Helpers;
using BloodDonationManagementSystem.Mappers;
using BloodDonationManagementSystem.Models.Hasta;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using static BloodDonationManagementSystem.Models.Hasta.HastaTalep;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BloodDonationManagementSystem.Repositories.Concrete
{
    public class HastaTalepRepository : GenericRepository<HastaTalep>
    {
        private readonly UyeRepository uyeRepository;
        public HastaTalepRepository(UyeRepository uyeRepository)
        {
            this.uyeRepository = uyeRepository;
        }

        public bool Add(int hastaId, int doktorId, string talepNedeni)
        {
            string query = "INSERT INTO HastaTalep(HastaId,DoktorId,TalepTarihi,TalepNedeni) " +
                    "VALUES(@HastaId,@DoktorId,@TalepTarihi,@TalepNedeni)";
            var items = new List<HastaTalep>();
            using (var connection = SqlHelper.GetSqlConnection())
            {
                SqlCommand command = new(query, connection);
                command.Parameters.AddWithValue("@HastaId", hastaId);
                command.Parameters.AddWithValue("@DoktorId", doktorId);
                command.Parameters.AddWithValue("@TalepTarihi", DateTime.Now);
                command.Parameters.AddWithValue("@TalepNedeni", talepNedeni);
                return command.ExecuteNonQuery() == 1 ? true : false;
            }
        }

        public IEnumerable<HastaTalep> GetAll()
        {
            string query = "SELECT * FROM HastaTalep";
            var items = new List<HastaTalep>();
            using (var connection = SqlHelper.GetSqlConnection())
            {
                SqlCommand command = new(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    HastaTalep item = HastaTalepMapper.Map(reader);
                    items.Add(item);
                }
            }
            return items;
        }


        public IEnumerable<HastaTalep> GetAllByHastaId(int hastaId)
        {
            string query = "SELECT * FROM HastaTalep WHERE HastaId = @HastaId";
            var items = new List<HastaTalep>();
            using (var connection = SqlHelper.GetSqlConnection())
            {
                SqlCommand command = new(query, connection);
                command.Parameters.AddWithValue("@HastaId", hastaId);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    HastaTalep item = HastaTalepMapper.Map(reader);
                    item.Doktor = uyeRepository.GetTalepDoktorById((int)reader["DoktorId"]);
                    item.TalepDurumu = GetTalepDurumuById((int)reader["Id"]);
                    items.Add(item);
                }
            }
            return items;
        }

        public IEnumerable<HastaTalep> GetAllByDoktorId(int doktorId)
        {
            string query = "SELECT * FROM HastaTalep WHERE DoktorId = @DoktorId";
            var items = new List<HastaTalep>();
            using (var connection = SqlHelper.GetSqlConnection())
            {
                SqlCommand command = new(query, connection);
                command.Parameters.AddWithValue("@DoktorId", doktorId);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    HastaTalep item = HastaTalepMapper.Map(reader);
                    item.Hasta = uyeRepository.GetHastaById((int)reader["HastaId"]);
                    item.TalepNedeni = (string)reader["TalepNedeni"];
                    item.Id = (int)reader["Id"];
                    items.Add(item);
                }
            }
            return items;
        }

        private static Durum GetTalepDurumuById(int Id)
        {
            string query =
                "SELECT * FROM HastaBekleyenTalep AS t1 " +
                "JOIN HastaTalep AS t2 ON t1.TalepId = t2.Id " +
                "WHERE t2.Id = @Id";
            using (var connection = SqlHelper.GetSqlConnection())
            {
                SqlCommand command = new(query, connection);
                command.Parameters.AddWithValue("@Id", Id);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Close();
                    string query2 =
                        "SELECT * FROM HastaKanTahlili AS t1 " +
                        "JOIN HastaTalep AS t2 ON t1.TalepId = t2.Id " +
                        "WHERE t2.Id = @Id";
                    SqlCommand command2 = new(query2, connection);
                    command2.Parameters.AddWithValue("@Id", Id);
                    SqlDataReader reader2 = command2.ExecuteReader();
                    if (reader2.HasRows)
                    {
                        reader2.Close();
                        string query3 =
                               "SELECT * FROM HastaTalepSonucu AS t1 " +
                               "JOIN HastaTalep AS t2 ON t1.TalepId = t2.Id " +
                               "WHERE t2.Id = @Id";
                        SqlCommand command3 = new(query3, connection);
                        command3.Parameters.AddWithValue("@Id", Id);
                        SqlDataReader reader3 = command3.ExecuteReader();
                        if (reader3.FieldCount>1)
                        {
                            
                            if (Convert.ToBoolean((int)reader3["Uygunluk"]))
                            {
                                reader3.Close();
                                string query4 =
                                    "SELECT * FROM HastaTalepSonucu AS t1 " +
                                    "JOIN HastaTalep AS t2 ON t1.TalepId = t2.Id " +
                                    "WHERE t2.Id = @Id";
                                SqlCommand command4 = new(query4, connection);
                                command4.Parameters.AddWithValue("@Id", Id);
                                SqlDataReader reader4 = command4.ExecuteReader();
                                if (reader4.HasRows)
                                {

                                }
                                return Durum.Donor;
                            }
                            return Durum.DoktorRed;
                        }
                        return Durum.DoktorOnay;
                    }
                    return Durum.Test;
                }
                return Durum.DoktorInceleme;
            }
        }
    }
}
