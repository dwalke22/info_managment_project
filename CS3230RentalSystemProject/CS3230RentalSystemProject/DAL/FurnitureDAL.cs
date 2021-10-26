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
    /// the FurnitureDAL class
    /// </summary>
    public class FurnitureDAL
    {

        /// <summary>
        /// Get all the furnitures
        /// </summary>
        /// <returns> all the furnitures</returns>
        public List<Furniture> GetAllFurnitureList()
        {
            List<Furniture> FurnitureList = new List<Furniture>();
            using (MySqlConnection connection = new MySqlConnection(Connection.connectionString))
            {
                connection.Open();
                string query = "select f.furnitureID, f.furnitureName, f.rentPrice, s.styleName, c.categoryName from `furniture` f, `style` s, `category` c where f.styleID = s.styleId and f.categoryID = c.categoryId;";

                using MySqlCommand command = new MySqlCommand(query, connection);

                using MySqlDataReader reader = command.ExecuteReader();

                int idoridinal = reader.GetOrdinal("furnitureID");
                int fnameoridinal = reader.GetOrdinal("furnitureName");
                int styleoridinal = reader.GetOrdinal("styleName");

                int categoryoridinal = reader.GetOrdinal("categoryName");
                int priceoridinal = reader.GetOrdinal("rentPrice");

                while (reader.Read())
                {
                    FurnitureList.Add(new Furniture
                    {
                        FurnitureID = reader.GetFieldValueCheckNull<Int32>(idoridinal),
                        FurnitureName = reader.GetFieldValueCheckNull<string>(fnameoridinal),
                        Style = reader.GetFieldValueCheckNull<string>(styleoridinal),
                        Category = reader.GetFieldValueCheckNull<string>(categoryoridinal),
                        RentPrice = reader.GetFieldValueCheckNull<decimal>(priceoridinal),
                    });

                }

            }
            return FurnitureList;

        }
    }
}
