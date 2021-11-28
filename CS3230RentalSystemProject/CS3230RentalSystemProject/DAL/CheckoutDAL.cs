using System;
using System.Collections.Generic;
using CS3230RentalSystemProject.Model;
using DBAccess.DAL;
using MySql.Data.MySqlClient;

namespace CS3230RentalSystemProject.DAL
{
    /// <summary>
    /// The CheckoutDAL class
    /// </summary>
    public class CheckoutDAL
    {
        /// <summary>
        /// Checkouts the cart.
        /// </summary>
        /// <param name="bag">The list of furniture to checkout.</param>
        /// <param name="employee">The employee creating the transaction.</param>
        /// <param name="total">The total cost of the transaction.</param>
        /// <param name="member">The employee who checked out for the transaction.</param>
        /// <return>
        /// True if the transaction is created successful, false otherwise.
        /// </return>
        public bool CheckoutCart(List<Furniture> bag, Employee employee, decimal total, Member member)
        {
            using (MySqlConnection connection = new MySqlConnection(Connection.connectionString))
            {
                connection.Open();
                MySqlTransaction myTrans = connection.BeginTransaction();

                try
                {
                    String createRentalTransaction = "insert into rentaltransaction (employeeID, memberID, totalPrice) values (@employeeID, @memberID, @total)";
                    using (MySqlCommand myCommand = new MySqlCommand(createRentalTransaction, connection))
                    {
                       
                        myCommand.Parameters.Add("@employeeID", MySqlDbType.Int32).Value = employee.EmployeeID;
                        myCommand.Parameters.Add("@memberID", MySqlDbType.Int32).Value = member.MemberID;
                        myCommand.Parameters.Add("@total", MySqlDbType.Decimal).Value = total;
                        myCommand.Transaction = myTrans;
                        myCommand.ExecuteNonQuery();
                    }
                    int transactionID = -1;
                    String getTransactionID = "select max(transactionID) from rentaltransaction";
                    using (MySqlCommand myCommand = new MySqlCommand(getTransactionID, connection))
                    {
                        transactionID = (int)myCommand.ExecuteScalar();
                    }

                    foreach (var furniture in bag)
                    {
                        String createRentalItem = "insert into rentalitem (rentalID, furnitureID, quantity, rentalDate, dueDate) values (@transactionID, @furnitureID, @quantity, @rentalDate, @dueDate)";
                        using (MySqlCommand myCommand = new MySqlCommand(createRentalItem, connection))
                        {
                            myCommand.Parameters.Add("@transactionID", MySqlDbType.Int32).Value = transactionID;
                            myCommand.Parameters.Add("@furnitureID", MySqlDbType.Int32).Value = furniture.FurnitureID;
                            myCommand.Parameters.Add("@quantity", MySqlDbType.Int32).Value = furniture.RentQuantity;
                            myCommand.Parameters.Add("@rentalDate", MySqlDbType.Date).Value = DateTime.Now.ToString("yyyy-MM-dd");
                            if (furniture.ReturnDate != null)
                                myCommand.Parameters.Add("@dueDate", MySqlDbType.Date).Value = furniture.ReturnDate.Value.Date;
                            myCommand.Transaction = myTrans;
                            myCommand.ExecuteNonQuery();
                        }


                        String updateFurniture = "update furniture set quantity= quantity - @rentquantity where furnitureID =@furnitureID";
                        using (MySqlCommand myCommand = new MySqlCommand(updateFurniture, connection))
                        {
                            myCommand.Parameters.Add("@rentquantity", MySqlDbType.Int32).Value = furniture.RentQuantity;
                            myCommand.Parameters.Add("@furnitureID", MySqlDbType.Int32).Value = furniture.FurnitureID;

                            myCommand.ExecuteNonQuery();
                        }
                        

                    }
                    myTrans.Commit();
                }
                catch
                {
                    myTrans.Rollback();
                    return false;
                }
                return true;
            }
        }
    }
}