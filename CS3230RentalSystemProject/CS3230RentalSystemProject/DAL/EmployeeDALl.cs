using CS3230RentalSystemProject.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Net.Sockets;


namespace DBAccess.DAL
{
    /// <summary>
    /// The EmployeeDAL class
    /// </summary>
    public class EmployeeDAL
    {
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

                int isAdminemailoridinal = reader.GetOrdinal("isAdmin");

                while (reader.Read())
                {
                    employee = new Employee
                    {
                        EmployeeID = reader.GetFieldValueCheckNull<int>(idoridinal),
                        FirstName = reader.GetFieldValueCheckNull<string>(fnameoridinal),
                        LastName = reader.GetFieldValueCheckNull<string>(lnameoridinal),
                        PhoneNumber = reader.GetFieldValueCheckNull<string>(phoneoridinal),
                        Email = reader.GetFieldValueCheckNull<string>(emailoridinal),
                        IsAdmin = reader.GetFieldValueCheckNull<bool>(isAdminemailoridinal)
                    };
                }
                return employee;
            }
        }

        /// <summary>
        /// Adds the employee.
        /// </summary>
        /// <param name="employee">The employee.</param>
        /// <param name="isAdmin">The is admin.</param>
        public void AddEmployee(Employee employee, int isAdmin)
        {
            using (MySqlConnection connection = new MySqlConnection(Connection.connectionString))
            {
                string query =
                    "insert into employee (firstName, lastName, phoneNumber, email, isAdmin) values(@firstname, @lastname, @phoneNumber, @email, @isAdmin";

                connection.Open();

                using MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.Add("@firstname", MySqlDbType.VarChar).Value = employee.FirstName;
                command.Parameters.Add("@lastname", MySqlDbType.VarChar).Value = employee.LastName;
                command.Parameters.Add("@email", MySqlDbType.VarChar).Value = employee.Email;
                command.Parameters.Add("@phoneNumber", MySqlDbType.VarChar).Value = employee.PhoneNumber;
                command.Parameters.Add("@isAdmin", MySqlDbType.Int32).Value = isAdmin;

                command.ExecuteNonQuery();

            }
        }

        /// <summary>
        /// Adds the employee username password.
        /// </summary>
        /// <param name="employeeid">The employeeid.</param>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        public void AddEmployeeUsernamePassword(int employeeid, string username, string password)
        {
            using (MySqlConnection connection = new MySqlConnection(Connection.connectionString))
            {
                string query = "insert into login(id, username, password) values (@employeeid, @username, @password)";

                connection.Open();
                using MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.Add("@employeeid", MySqlDbType.Int32).Value = employeeid;
                command.Parameters.Add("@username", MySqlDbType.VarChar).Value = username;
                command.Parameters.Add("@password", MySqlDbType.VarChar).Value = password;

                command.ExecuteNonQuery();
            }

        }

        /// <summary>
        /// Gets the newest employee identifier.
        /// </summary>
        /// <returns></returns>
        public int GetNewestEmployeeID()
        {
            int id = -1;
            using (MySqlConnection connection = new MySqlConnection(Connection.connectionString))
            {
                string query = "select max(employeeID) from employee";

                using MySqlCommand command = new MySqlCommand(query, connection);
                id = (int)command.ExecuteScalar();

                return id;
            }
        }
    }
}
