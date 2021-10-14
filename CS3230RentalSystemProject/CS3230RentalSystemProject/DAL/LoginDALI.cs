using MySql.Data.MySqlClient;

namespace DBAccess.DAL
{
    /// <summary>
    /// The LoginDALI class
    /// </summary>
    public class LoginDALI
    {
        /// <summary>
        /// Validates login credentials
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns>
        /// True if the username and password exist in the database
        /// </returns>
        public static bool LoginValidation(string username, string password)
        {
            using (MySqlConnection connection = new MySqlConnection(Connection.connectionString))
            {

                connection.Open();
                string query = "select username, password from login where username = @username and password = @password";

                using MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.Add("@username", MySqlDbType.VarChar);
                command.Parameters.Add("@password", MySqlDbType.VarChar);

                using MySqlDataReader reader = command.ExecuteReader();

                bool loginSuccess = reader.Read();
                connection.Close();
                return loginSuccess;


            }
        }
        
    }
}