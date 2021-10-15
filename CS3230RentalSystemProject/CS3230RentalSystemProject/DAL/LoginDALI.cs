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

        /// <summary>
        /// Get Employee
        /// </summary>
        /// <param name="id">
        ///     The employee's id
        /// </param>
        /// <returns>
        ///     The employee associated with the id
        /// </returns>
        public static Employee GetEmployee(int id)
        {
            Employee employee = null;

            using (MySqlConnection connection = new MySqlConnection(Connection.connectionString))
            {
                connection.Open();
                string query = "select * from employee where employeeID = @id;";

                using MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

                using MySqlDataReader reader = command.ExecuteReader();

                int idoridinal = reader.GetOrdinal("employeeID");

                int fnameoridinal = reader.GetOrdinal("firstName");
                int lnameoridinal = reader.GetOrdinal("lastName");

                int phoneoridinal = reader.GetOrdinal("phoneNumber");
                int emailoridinal = reader.GetOrdinal("email");

                while (reader.Read())
                {
                    employee = new Employee
                    {
                        EmployeeID = reader.GetFieldValueCheckNull<int>(idoridinal),
                        FirstName = reader.GetFieldValueCheckNull<string>(fnameoridinal),
                        LastName = reader.GetFieldValueCheckNull<string>(lnameoridinal),
                        PhoneNumber = reader.GetFieldValueCheckNull<string>(phoneoridinal),
                        Email = reader.GetFieldValueCheckNull<string>(emailoridinal)
                    };
                }
                return employee;
            }
        }
        
    }
}