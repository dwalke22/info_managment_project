using CS3230RentalSystemProject.Model;
using DBAccess.DAL;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS3230RentalSystemProject.DAL
{
    /// <summary>
    /// The TransactionDAL class
    /// </summary>
    public class TransanctionDAL
    {
        /// <summary>
        /// Get all rental items
        /// </summary>
        /// <returns>all rental items</returns>
        public List<RentalItem> getAllRentalItems(int id)
        {
            List<RentalItem> list = new List<RentalItem>();
            using (MySqlConnection connection = new MySqlConnection(Connection.connectionString))
            {
                connection.Open();
                using (var cmd = new MySqlCommand("uspGetMemberRentalItems", connection))
                {
                    
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        int rentalIDoridinal = reader.GetOrdinal("rentalID");
                        int furnitureIDoridinal = reader.GetOrdinal("furnitureID");
                        int funitureNameoridinal = reader.GetOrdinal("furnitureName");
                        int quantityoridinal = reader.GetOrdinal("quantity");

                        int rentalDateoridinal = reader.GetOrdinal("rentalDate");
                        int dueDateoridinal = reader.GetOrdinal("dueDate");

                        while (reader.Read())
                        {
                            list.Add(new RentalItem
                            {
                                RentalID = reader.GetFieldValueCheckNull<Int32>(rentalIDoridinal),
                                FurnitureID = reader.GetFieldValueCheckNull<Int32>(furnitureIDoridinal),
                                FurnitureName = reader.GetFieldValueCheckNull<string>(funitureNameoridinal),
                                Quantity = reader.GetFieldValueCheckNull<Int32>(quantityoridinal),
                                RentalDate = reader.GetFieldValueCheckNull<DateTime>(rentalDateoridinal).Date.ToString("yyyy-MM-dd"),
                                DueDate = reader.GetFieldValueCheckNull<DateTime>(dueDateoridinal).Date.ToString("yyyy-MM-dd"),
                            });

                        }
                    }
                }
            }
            return list;
        }

        /// <summary>
        /// Get all rental items
        /// </summary>
        /// <returns>all rental items</returns>
        public List<RentalItem> getRentalItem(int renttalID, int furnitureID)
        {
            List<RentalItem> list = new List<RentalItem>();
            using (MySqlConnection connection = new MySqlConnection(Connection.connectionString))
            {
                connection.Open();
                using (var cmd = new MySqlCommand("uspGetRentalItem", connection))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@rentalID", MySqlDbType.Int32).Value = renttalID;
                    cmd.Parameters.Add("@furnitureID", MySqlDbType.Int32).Value = furnitureID;
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        int rentalIDoridinal = reader.GetOrdinal("rentalID");
                        int furnitureIDoridinal = reader.GetOrdinal("furnitureID");
                        int furnitureNameoridinal = reader.GetOrdinal("furnitureName");
                        int quantityoridinal = reader.GetOrdinal("quantity");

                        int rentalDateoridinal = reader.GetOrdinal("rentalDate");
                        int dueDateoridinal = reader.GetOrdinal("dueDate");

                        while (reader.Read())
                        {
                            list.Add(new RentalItem
                            {
                                RentalID = reader.GetFieldValueCheckNull<Int32>(rentalIDoridinal),
                                FurnitureID = reader.GetFieldValueCheckNull<Int32>(furnitureIDoridinal),
                                FurnitureName = reader.GetFieldValueCheckNull<string>(furnitureNameoridinal),
                                Quantity = reader.GetFieldValueCheckNull<Int32>(quantityoridinal),
                                RentalDate = reader.GetFieldValueCheckNull<DateTime>(rentalDateoridinal).Date.ToString("yyyy-MM-dd"),
                                DueDate = reader.GetFieldValueCheckNull<DateTime>(dueDateoridinal).Date.ToString("yyyy-MM-dd"),
                            });

                        }
                    }
                }
            }
            return list;
        }

        /// <summary>
        /// Get all current rentaled items
        /// </summary>
        /// <returns>all current rentaled items</returns>
        public List<RentalItem> getAllCurrentRentaledItems(int id)
        {
            List<RentalItem> list = new List<RentalItem>();
            using (MySqlConnection connection = new MySqlConnection(Connection.connectionString))
            {
                connection.Open();
                using (var cmd = new MySqlCommand("uspGetMemberCurrentRentaledItems", connection))
                {

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        int rentalIDoridinal = reader.GetOrdinal("rentalID");
                        int furnitureIDoridinal = reader.GetOrdinal("furnitureID");
                        int funitureNameoridinal = reader.GetOrdinal("furnitureName");
                        int quantityoridinal = reader.GetOrdinal("quantity");

                        int rentalDateoridinal = reader.GetOrdinal("rentalDate");
                        int dueDateoridinal = reader.GetOrdinal("dueDate");

                        while (reader.Read())
                        {
                            list.Add(new RentalItem
                            {
                                RentalID = reader.GetFieldValueCheckNull<Int32>(rentalIDoridinal),
                                FurnitureID = reader.GetFieldValueCheckNull<Int32>(furnitureIDoridinal),
                                FurnitureName = reader.GetFieldValueCheckNull<string>(funitureNameoridinal),
                                Quantity = reader.GetFieldValueCheckNull<Int32>(quantityoridinal),
                                RentalDate = reader.GetFieldValueCheckNull<DateTime>(rentalDateoridinal).Date.ToString("yyyy-MM-dd"),
                                DueDate = reader.GetFieldValueCheckNull<DateTime>(dueDateoridinal).Date.ToString("yyyy-MM-dd"),
                            });

                        }
                    }
                }
            }
            return list;
        }

        /// <summary>
        /// Get all rental items
        /// </summary>
        /// <returns>all rental items</returns>
        public List<Int32> getMemberTansactionsNumber(int id)
        {
            List<Int32> list = new List<Int32>();
            using (MySqlConnection connection = new MySqlConnection(Connection.connectionString))
            {
                connection.Open();
                using (var cmd = new MySqlCommand("uspGetMemberTransactionsNumber", connection))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        int iDoridinal = reader.GetOrdinal("transactionID");

                        while (reader.Read())
                        {
                            int transactionID = reader.GetFieldValueCheckNull<Int32>(iDoridinal);
                            list.Add(transactionID);

                        }
                    }
                }
            }
            return list;
        }

        /// <summary>
        /// Get all rental items with specified rentalID
        /// </summary>
        /// <returns>all rental items with specified rentalID</returns>
        public List<RentalItem> getAllRentalItemsByRentalID(int id)
        {
            List<RentalItem> list = new List<RentalItem>();
            using (MySqlConnection connection = new MySqlConnection(Connection.connectionString))
            {
                connection.Open();
                using (var cmd = new MySqlCommand("uspGetMemberRentalItemsByTransactionID", connection))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        int rentalIDoridinal = reader.GetOrdinal("rentalID");
                        int furnitureIDoridinal = reader.GetOrdinal("furnitureID");
                        int funitureNameoridinal = reader.GetOrdinal("furnitureName");
                        int quantityoridinal = reader.GetOrdinal("quantity");

                        int rentalDateoridinal = reader.GetOrdinal("rentalDate");
                        int dueDateoridinal = reader.GetOrdinal("dueDate");

                        while (reader.Read())
                        {
                            list.Add(new RentalItem
                            {
                                RentalID = reader.GetFieldValueCheckNull<Int32>(rentalIDoridinal),
                                FurnitureID = reader.GetFieldValueCheckNull<Int32>(furnitureIDoridinal),
                                FurnitureName = reader.GetFieldValueCheckNull<string>(funitureNameoridinal),
                                Quantity = reader.GetFieldValueCheckNull<Int32>(quantityoridinal),
                                RentalDate = reader.GetFieldValueCheckNull<DateTime>(rentalDateoridinal).Date.ToString("yyyy-MM-dd"),
                                DueDate = reader.GetFieldValueCheckNull<DateTime>(dueDateoridinal).Date.ToString("yyyy-MM-dd"),
                            });

                        }
                    }
                }
            }
            return list;
        }

        /// <summary>
        /// Get all return items
        /// </summary>
        /// <returns>all return items</returns>
        public List<ReturnItem> getAllReturnItems(int id)
        {
            List<ReturnItem> list = new List<ReturnItem>();
            using (MySqlConnection connection = new MySqlConnection(Connection.connectionString))
            {
                connection.Open();
                using (var cmd = new MySqlCommand("uspGetMemberReturnItems", connection))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        int rentalIDoridinal = reader.GetOrdinal("rentalID");
                        int furnitureIDoridinal = reader.GetOrdinal("furnitureID");
                        int funitureNameoridinal = reader.GetOrdinal("furnitureName");
                        int quantityoridinal = reader.GetOrdinal("quantity");
                        int returnIDoridinal = reader.GetOrdinal("returnID");
                        int returnDateoridinal = reader.GetOrdinal("returnDate");

                        while (reader.Read())
                        {
                            list.Add(new ReturnItem
                            {
                                RentalID = reader.GetFieldValueCheckNull<Int32>(rentalIDoridinal),
                                FurnitureID = reader.GetFieldValueCheckNull<Int32>(furnitureIDoridinal),
                                FurnitureName = reader.GetFieldValueCheckNull<string>(funitureNameoridinal),
                                Quantity = reader.GetFieldValueCheckNull<Int32>(quantityoridinal),
                                ReturnDate = reader.GetFieldValueCheckNull<DateTime>(returnDateoridinal).Date.ToString("yyyy-MM-dd"),
                                ReturnID = reader.GetFieldValueCheckNull<Int32>(returnIDoridinal),
                            });

                        }
                    }
                }
            }
            return list;
        }

        /// <summary>
        /// Return items
        /// </summary>
        /// <param name="items"> item to return </param>
        /// <param name="employee"> the employee</param>
        /// <param name="member"> the member </param>
        /// <param name="fine">the fine if any </param>
        public bool returnItems(List<RentalItem> items, Employee employee, Member member, decimal fine)
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
                    myCommand.CommandText = "insert into returntransaction (fine, employeeID, memberID) values (@fine, @employeeID, @memberID)";

                    myCommand.Parameters.Add("@fine", MySqlDbType.Decimal).Value = fine;
                    myCommand.Parameters.Add("@employeeID", MySqlDbType.Int32).Value = employee.EmployeeID;
                    myCommand.Parameters.Add("@memberID", MySqlDbType.Int32).Value = member.MemberID;

                    myCommand.ExecuteNonQuery();

                    int transactionID = -1;
                    myCommand.CommandText = "select max(transactionID) from returntransaction";

                    transactionID = (int)myCommand.ExecuteScalar();

                    foreach (var rentalItem in items)
                    {
                        myCommand.CommandText = "insert into returnitem (rentalID, furnitureID, returnID, quantity, returnDate) values (@rentalID, @furnitureID, @returnID, @quantity, @returnDate)";
                        myCommand.Parameters.Add("@rentalID", MySqlDbType.Int32).Value = rentalItem.RentalID;
                        myCommand.Parameters.Add("@furnitureID", MySqlDbType.Int32).Value = rentalItem.FurnitureID;
                        myCommand.Parameters.Add("@returnID", MySqlDbType.Int32).Value = transactionID;
                        myCommand.Parameters.Add("@quantity", MySqlDbType.Int32).Value = rentalItem.Quantity;
                        myCommand.Parameters.Add("@returnDate", MySqlDbType.Date).Value = DateTime.Now.ToString("yyyy-MM-dd");

                        myCommand.ExecuteNonQuery();

                        myCommand.CommandText = "update furniture set quantity= quantity + @returnquantity where furnitureID = @furnitureID";

                        myCommand.Parameters.Add("@returnquantity", MySqlDbType.Int32).Value = rentalItem.Quantity;
                        myCommand.Parameters.Add("@furnitureID", MySqlDbType.Int32).Value = rentalItem.FurnitureID;

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
                return true;
            }
        }

        /// <summary>
        /// Get return transaction ID
        /// </summary>
        /// <returns></returns>
        public int GetReturnTransactionID()
        {
            int id = -1;
            using (MySqlConnection connection = new MySqlConnection(Connection.connectionString))
            {
                connection.Open();

                string query = "select max(transactionID) from returntransaction";

                using MySqlCommand command = new MySqlCommand(query, connection);

                id = (int)command.ExecuteScalar();

                return id;
            }
        }
    }
}
