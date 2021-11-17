using System;
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
        public bool CheckoutCart(List<Furniture> bag, Employee employee, decimal total, Member member)
        {
            using (MySqlConnection connection = new MySqlConnection(Connection.connectionString))
            {
                connection.Open();
                MySqlCommand myCommand = connection.CreateCommand();
                MySqlTransaction myTrans;

                myTrans = connection.BeginTransaction();
                myCommand.Connection = connection;
                myCommand.Transaction = myTrans;

                try
                {
                    myCommand.CommandText = "insert into rentaltransaction (employeeID, memberID, totalPrice) values (@employeeID, @memberID, @total)";
                    myCommand.Parameters.Add("@employeeID", MySqlDbType.Int32).Value = employee.EmployeeID;
                    myCommand.Parameters.Add("@memberID", MySqlDbType.Int32).Value = member.MemberID;
                    myCommand.Parameters.Add("@total", MySqlDbType.Decimal).Value = total;

                    myCommand.ExecuteNonQuery();

                    int transactionID = -1;

                    myCommand.CommandText = "select max(transactionID) from rentaltransaction";

                    transactionID = (int)myCommand.ExecuteScalar();

                    foreach (var furniture in bag)
                    {
                        myCommand.CommandText = "insert into rentalitem (rentalID, furnitureID, quantity, rentalDate, dueDate) values (@transactionID, @furnitureID, @quantity, @rentalDate, @dueDate)";
                        myCommand.Parameters.Add("@transactionID", MySqlDbType.Int32).Value = transactionID;
                        myCommand.Parameters.Add("@furnitureID", MySqlDbType.Int32).Value = furniture.FurnitureID;
                        myCommand.Parameters.Add("@quantity", MySqlDbType.Int32).Value = furniture.RentQuantity;
                        myCommand.Parameters.Add("@rentalDate", MySqlDbType.Date).Value = DateTime.Now.ToString("yyyy-MM-dd");
                        if (furniture.ReturnDate != null)
                            myCommand.Parameters.Add("@dueDate", MySqlDbType.Date).Value = furniture.ReturnDate.Value.Date;

                        myCommand.ExecuteNonQuery();

                        myCommand.CommandText = "update furniture set quantity= quantity - @rentquantity where furnitureID =@furnitureID";

                        myCommand.Parameters.Add("@rentquantity", MySqlDbType.Int32).Value = furniture.RentQuantity;
                        myCommand.Parameters.Add("@furnitureID", MySqlDbType.Int32).Value = furniture.FurnitureID;

                        myCommand.ExecuteNonQuery();
                        myTrans.Commit();
                    }
                }
                catch (Exception)
                {
                    try
                    {
                        myTrans.Rollback();
                        return false;
                    }
                    catch (MySqlException)
                    {
                        return false;
                    }
                }
                finally
                {
                    connection.Close();
                }
                return true;


            }
        }
    }
}