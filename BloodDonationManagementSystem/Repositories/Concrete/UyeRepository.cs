using BloodDonationManagementSystem.Helpers;
using BloodDonationManagementSystem.Mappers;
using BloodDonationManagementSystem.Models;
using BloodDonationManagementSystem.Models.Register;
using Microsoft.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BloodDonationManagementSystem.Repositories.Concrete
{
    public class UyeRepository : GenericRepository<Uye>
    {
        public bool Add(Uye uye,int bolumId) 
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
                command.Parameters.AddWithValue("@Yas", (DateTime.Now.Year)-(uye.DogumTarihi.Value.Year));
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
    }
}
