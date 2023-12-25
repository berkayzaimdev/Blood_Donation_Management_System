using BloodDonationManagementSystem.Models;
using BloodDonationManagementSystem.Repositories.Concrete;
using Microsoft.Data.SqlClient;

namespace BloodDonationManagementSystem.Mappers
{
    public class UyeMapper
    {
        public static Uye Map(SqlDataReader reader)
        {
            return new Uye
            {
                Id = (int)reader["Id"],
                TcKimlikNo = (string)reader["TcKimlikNo"],
                Isim = (string)reader["Isim"],
                Soyisim = (string)reader["Soyisim"],
                Telefon = (string)reader["Telefon"],
                Yas = (string)reader["Yas"]
            };
        }
    }
}
