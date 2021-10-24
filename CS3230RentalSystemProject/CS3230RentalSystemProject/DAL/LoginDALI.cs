using CS3230RentalSystemProject.Model;
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
        public static int LoginValidation(string username, string password)
        {
            int id = -1;
            using (MySqlConnection connection = new MySqlConnection(Connection.connectionString))
            {
                connection.Open();
                string query = "select id from login where username = @username and password = @password;";
                using MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.Add("@username", MySqlDbType.VarChar).Value = username;
                command.Parameters.Add("@password", MySqlDbType.VarChar).Value = password;

                using MySqlDataReader reader = command.ExecuteReader();
                int idoridinal = reader.GetOrdinal("id");

                while (reader.Read())
                {
                    id = reader.GetFieldValueCheckNull<int>(idoridinal);
                }
            }
            return id;
        }

       
        
    }
}