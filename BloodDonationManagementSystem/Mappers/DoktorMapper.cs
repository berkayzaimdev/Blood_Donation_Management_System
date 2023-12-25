using BloodDonationManagementSystem.Models.Doktor;
using Microsoft.Data.SqlClient;

namespace BloodDonationManagementSystem.Mappers
{
    public class DoktorMapper : UyeMapper
    {
        public static Doktor Map(SqlDataReader reader)
        {
            return new Doktor
            {
                Id = (int)reader["Id"],
                TcKimlikNo = (string)reader["TcKimlikNo"],
                Isim = (string)reader["Isim"],
                Soyisim = (string)reader["Soyisim"],
                Telefon = (string)reader["Telefon"],
                Yas = Convert.ToInt16((string)reader["Yas"])
            };
        }
    }
}
