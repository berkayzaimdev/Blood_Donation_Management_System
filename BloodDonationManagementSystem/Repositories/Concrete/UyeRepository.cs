using BloodDonationManagementSystem.Helpers;
using BloodDonationManagementSystem.Mappers;
using BloodDonationManagementSystem.Models;
using BloodDonationManagementSystem.Models.Doktor;
using BloodDonationManagementSystem.Models.Login;
using BloodDonationManagementSystem.Models.Register;
using Microsoft.Data.SqlClient;
using System.Reflection.PortableExecutable;

namespace BloodDonationManagementSystem.Repositories.Concrete
{
    public class UyeRepository : GenericRepository<Uye>
    {
        private readonly KullaniciTipiRepository kullaniciTipiRepository;
        private readonly BolumRepository bolumRepository;
        public UyeRepository(KullaniciTipiRepository kullaniciTipiRepository, BolumRepository bolumRepository)
        {
            this.kullaniciTipiRepository = kullaniciTipiRepository;
            this.bolumRepository = bolumRepository;
        }

        public bool Add(RegisterUyeViewModel uye,int bolumId) 
        {
            using (var connection = SqlHelper.GetSqlConnection())
            {
                string query = 
                    "INSERT INTO Uye(TcKimlikNo,Isim,Soyisim,Yas,Sifre,Telefon) " +
                    "VALUES(@TcKimlikNo,@Isim,@Soyisim,@Yas,@Sifre,@Telefon)"+
                    "SELECT SCOPE_IDENTITY();";

                SqlCommand command = new(query, connection);
                command.Parameters.AddWithValue("@TcKimlikNo", uye.TcKimlikNo);
                command.Parameters.AddWithValue("@Isim", uye.Isim);
                command.Parameters.AddWithValue("@Soyisim", uye.Soyisim);
                command.Parameters.AddWithValue("@Yas", (DateTime.Now.Year)-(uye.DogumTarihi.Year));
                command.Parameters.AddWithValue("@Sifre", uye.TcKimlikNo);
                command.Parameters.AddWithValue("@Telefon", uye.Isim);
                int uyeId = Convert.ToInt32(command.ExecuteScalar());
                if (Convert.ToBoolean(bolumId))
                {
                    string query2 =
                    "INSERT INTO DoktorBolum(DoktorId,BolumId) " +
                    "VALUES(@DoktorId,@BolumId)";

                    SqlCommand command2 = new(query2, connection);
                    command2.Parameters.AddWithValue("@DoktorId", uyeId);
                    command2.Parameters.AddWithValue("@BolumId", bolumId);
                    command2.ExecuteNonQuery();
                }
            }
            return true;
        }

        public Uye Get(LoginUyeViewModel uye)
        {
            using (var connection = SqlHelper.GetSqlConnection())
            {
                string query =
                    "SELECT * FROM Uye " +
                    "WHERE TcKimlikNo = @TcKimlikNo AND Sifre = @Sifre AND KullaniciTipiId = @KullaniciTipiId";

                SqlCommand command = new(query, connection);
                command.Parameters.AddWithValue("@TcKimlikNo", uye.TcKimlikNo);
                command.Parameters.AddWithValue("@Sifre", uye.Sifre);
                command.Parameters.AddWithValue("@KullaniciTipiId", uye.KullaniciTipiId);
                SqlDataReader reader = command.ExecuteReader();
                Uye loggerUye = new();
                if (reader.Read())
                { 
                    loggerUye = UyeMapper.Map(reader);
                    loggerUye.KullaniciTipi = kullaniciTipiRepository.Get((int)reader["KullaniciTipiId"]);
                }
                return loggerUye;
            }
        }

        public SqlDataReader GetUyeById(int Id)
        {
            using (var connection = SqlHelper.GetSqlConnection())
            {
                string query =
                    "SELECT * FROM Uye " +
                    "WHERE Id = @Id";

                SqlCommand command = new(query, connection);
                command.Parameters.AddWithValue("@Id", Id);
                SqlDataReader test = command.ExecuteReader();
                return test;
            }
        }

        public TalepDoktor GetTalepDoktorById(int Id)
        {
            using (var connection = SqlHelper.GetSqlConnection())
            {
                string query =
                   "SELECT * FROM Uye " +
                   "WHERE Id = @Id";

                SqlCommand command = new(query, connection);
                command.Parameters.AddWithValue("@Id", Id);
                SqlDataReader reader = command.ExecuteReader();
                TalepDoktor talepDoktor = new();
                if (reader.Read())
                    talepDoktor = TalepDoktorMapper.Map(reader, bolumRepository);
                return talepDoktor;
            }
        }
    }
}
