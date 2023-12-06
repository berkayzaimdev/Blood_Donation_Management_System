using BloodDonationManagementSystem.Models;
using BloodDonationManagementSystem.Repositories.Concrete;
using Microsoft.Data.SqlClient;

namespace BloodDonationManagementSystem.Mappers
{
    public class UyeMapper
    {
        public static Uye Map(SqlDataReader reader,KullaniciTipiRepository kullaniciTipiRepository)
        {
            return new Uye
            {
                TcKimlikNo = (string)reader["TcKimlikNo"],
                Isim = (string)reader["Isim"],
                Soyisim = (string)reader["Soyisim"],
                Telefon = (string)reader["Telefon"],
                KullaniciTipi = kullaniciTipiRepository.Get((int)reader["KullaniciTipiId"])
            };
        }
    }
}
