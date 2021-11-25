using CS3230RentalSystemProject.Model;
using DBAccess.DAL;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS3230RentalSystemProject.DAL
{
	/// <summary>
	/// The AdminQureyDAL class
	/// </summary>
    public class AdminQueryDAL
    {
		/// <summary>
		/// Get date table for specific admin query
		/// </summary>
		/// <param name="query">
		///		The admin query statement
		/// </param>
		/// <returns>
		///		The date table for that admin query statement
		/// </returns>
		public static DataTable AdminQuery(String query)
        {

			DataTable data = new DataTable();
			try
            {
				using (MySqlConnection con = new MySqlConnection(Connection.connectionString))
				{
					MySqlCommand myQuery = con.CreateCommand();
					myQuery.CommandText = query;
					MySqlDataReader myReader;
					con.Open();
					myReader = myQuery.ExecuteReader();
					data.Load(myReader);

				}
			}
            catch(Exception)
            {
				data = null;
				return data;
            }
			
			return data;
        }

        /// <summary>
        /// Get all rental items
        /// </summary>
        /// <returns>all rental items</returns>
        public static List<Report> getReportByDates(DateTime date1, DateTime date2)
        {
            List<Report> list = new List<Report>();
            using (MySqlConnection connection = new MySqlConnection(Connection.connectionString))
            {
                connection.Open();
                using (var cmd = new MySqlCommand("uspGetReportByDates", connection))
                {

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@date1", MySqlDbType.Date).Value = date1.Date;
                    cmd.Parameters.Add("@date2", MySqlDbType.Date).Value = date2.Date;
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        int memberIDoridinal = reader.GetOrdinal("memberID");
                        int fullNameoridinal = reader.GetOrdinal("fullName");
                        int furnitureIDoridinal = reader.GetOrdinal("furnitureID");
                        int furnitureNameoridinal = reader.GetOrdinal("furnitureName");

                        int styleNameoridinal = reader.GetOrdinal("styleName");
                        int categoryNameoridinal = reader.GetOrdinal("categoryName");
                        int quantityoridinal = reader.GetOrdinal("quantity");
                        int rentalDateoridinal = reader.GetOrdinal("rentalDate");
                        int dueDateoridinal = reader.GetOrdinal("dueDate");
                        int returnDateoridinal = reader.GetOrdinal("returnDate");

                        while (reader.Read())
                        {
                            list.Add(new Report
                            {
                                MemeberID = reader.GetFieldValueCheckNull<Int32>(memberIDoridinal),
                                FullName = reader.GetFieldValueCheckNull<string>(fullNameoridinal),
                                FunitureID = reader.GetFieldValueCheckNull<Int32>(furnitureIDoridinal),
                                FunitureName = reader.GetFieldValueCheckNull<string>(furnitureNameoridinal),
                                StyleName = reader.GetFieldValueCheckNull<string>(styleNameoridinal),
                                CategoryName = reader.GetFieldValueCheckNull<string>(categoryNameoridinal),
                                Quantity = reader.GetFieldValueCheckNull<Int32>(quantityoridinal),
                                RentalDate = reader.GetFieldValueCheckNull<DateTime>(rentalDateoridinal).Date.ToString("yyyy-MM-dd"),
                                DueDate = reader.GetFieldValueCheckNull<DateTime>(dueDateoridinal).Date.ToString("yyyy-MM-dd"),
                                ReturnDate = reader.GetFieldValueCheckNull<DateTime>(returnDateoridinal).Date.ToString("yyyy-MM-dd"),
                            });

                        }
                    }
                }
            }
            return list;
        }
    }
}
