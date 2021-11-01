using System.Collections.Generic;
using CS3230RentalSystemProject.Model;
using DBAccess.DAL;
using MySql.Data.MySqlClient;

namespace CS3230RentalSystemProject.DAL
{
    public class CheckoutDAL
    {
        /// <summary>
        /// Checkouts the cart.
        /// </summary>
        /// <param name="bag">The list of furniture to checkout.</param>
        /// <param name="employee">The employee creating the transaction.</param>
        /// <param name="transactionID">The transaction id.</param>
        public void CheckoutCart(List<Furniture> bag, Employee employee, int transactionID)
        {
            using (MySqlConnection connection = new MySqlConnection(Connection.connectionString))
            {
                connection.Open();

                foreach (var furniture in bag)
                {
                    string query = "insert into rentalitem (transactionID, furnitureID, quantity, rentalDate, dueDate) values (@transactionID, @furnitureID, @quantity, @rentalDate, @dueDate)";
                    using MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.Add("@transactionID", MySqlDbType.Int32).Value = transactionID;
                    command.Parameters.Add("@furnitureID", MySqlDbType.Int32).Value = furniture.FurnitureID;
                    command.Parameters.Add("@quantity", MySqlDbType.Int32).Value = furniture.RentQuantity;
                    command.Parameters.Add("@rentalDate", MySqlDbType.Date).Value = furniture.ReturnDate.Date;
                    command.Parameters.Add("@dueDate", MySqlDbType.Date).Value = furniture.ReturnDate.Date;

                    command.ExecuteNonQuery();

                    string updateQuery = "update furniture set quantity=@quantity where furnitureID =@furnitureID";
                    using MySqlCommand updateCommand = new MySqlCommand(updateQuery, connection);
                    command.Parameters.Add("@quantity", MySqlDbType.Int32).Value = furniture.Quantity - furniture.RentQuantity;
                    command.Parameters.Add("@furnitureID", MySqlDbType.Int32).Value = furniture.FurnitureID;

                    updateCommand.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Creates the transaction.
        /// </summary>
        /// <param name="employee">The employee creating the transaction.</param>
        /// <param name="total">The total of the transaction.</param>
        public void CreateTransaction(Employee employee, decimal total, Member member)
        {
            using (MySqlConnection connection = new MySqlConnection(Connection.connectionString))
            {
                connection.Open();

                string query = "insert into rentaltransaction (employeeID, memberID, totalPrice) output INSERTED.transactionID values (@employeeID, @memberID, @total)";
                
                using MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.Add("@employeeID", MySqlDbType.Int32).Value = employee.EmployeeID;
                command.Parameters.Add("@memberID", MySqlDbType.Int32).Value = member.MemberID;
                command.Parameters.Add("@total", MySqlDbType.Decimal).Value = total;

                command.ExecuteNonQuery();
            }
        }

        public int GetTransactionID()
        {
            int id = -1;
            using (MySqlConnection connection = new MySqlConnection(Connection.connectionString))
            {
                connection.Open();

                string query = "select top 1 transactionID from rentaltransaction order by transactionID desc";

                using MySqlCommand command = new MySqlCommand(query, connection);

                using MySqlDataReader reader = command.ExecuteReader();

                int idOrdinal = reader.GetOrdinal("transactionID");

                while (reader.Read())
                {
                    id = reader.GetFieldValueCheckNull<int>(idOrdinal);
                }

                return id;
            }
        }
    }
}