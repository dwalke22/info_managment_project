using System;
using MySql.Data.MySqlClient;

namespace DBAccess.DAL
{
    /// <summary>
    /// The LogInDALI class
    /// </summary>
    public class LogInDALI
    {
        /// <summary>
        /// Validates the login credentials
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns>
        ///     Returns true if the 
        /// </returns>
        public static bool LogInValidation(string username, string password)
        {
            using (MySqlConnection connection = new MySqlConnection(Connection.connectionString))
            {
                try
                {
                    connection.Open();
                    string query =
                        "select username, password from login where username = @username and password = @password";

                    using MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.Add("@username", MySqlDbType.VarChar);
                    command.Parameters.Add("@password", MySqlDbType.VarChar);

                    using MySqlDataReader reader = command.ExecuteReader();

                    bool loginSuccess = reader.Read();
                    connection.Close();
                    return loginSuccess;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Something went wrong");
                    return false;
                }
            }
        }
    }
}