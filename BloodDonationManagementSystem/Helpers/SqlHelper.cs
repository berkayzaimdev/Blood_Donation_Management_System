using Microsoft.Data.SqlClient;

namespace BloodDonationManagementSystem.Helpers
{
    public class SqlHelper
    {
        private const string CONNECTION_STRING = "Data Source=DESKTOP-M1UE4EP;Initial Catalog=BloodBank;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        public static SqlConnection GetSqlConnection()
        {
            var connection = new SqlConnection(CONNECTION_STRING);
            connection.Open();
            return connection;
        }
    }
}
