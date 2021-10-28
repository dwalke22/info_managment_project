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
                string query = "select f.furnitureID, f.furnitureName, f.rentPrice, f.quantity, s.styleName, c.categoryName from `furniture` f, `style` s, `category` c where f.styleID = s.styleId and f.categoryID = c.categoryId;";

                using MySqlCommand command = new MySqlCommand(query, connection);

                using MySqlDataReader reader = command.ExecuteReader();

                int idoridinal = reader.GetOrdinal("furnitureID");
                int fnameoridinal = reader.GetOrdinal("furnitureName");
                int styleoridinal = reader.GetOrdinal("styleName");
                int quantityoridinal = reader.GetOrdinal("quantity");

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
                        Quantity = reader.GetFieldValueCheckNull<Int32>(quantityoridinal),
                    });

                }

            }
            return FurnitureList;

        }

        /// <summary>
        /// Gets all furniture categories.
        /// </summary>
        /// <returns>
        /// List of all furniture categories.
        /// </returns>
        public List<string> GetAllFurnitureCategories()
        {
            List<string> categories = new List<string>();
            using (MySqlConnection connection = new MySqlConnection(Connection.connectionString))
            {
                connection.Open();
                string query = "select categoryName from category";

                using MySqlCommand command = new MySqlCommand(query, connection);

                using MySqlDataReader reader = command.ExecuteReader();
                int categoryOrdinal = reader.GetOrdinal("categoryName");

                while (reader.Read())
                {
                    categories.Add(reader.GetFieldValueCheckNull<string>(categoryOrdinal));
                }
            }
            return categories;
        }

        /// <summary>
        /// Gets all furniture styles.
        /// </summary>
        /// <returns>
        /// List of all furniture styles
        /// </returns>
        public List<string> GetAllFurnitureStyles()
        {
            List<string> styles = new List<string>();
            using (MySqlConnection connection = new MySqlConnection(Connection.connectionString))
            {
                connection.Open();
                string query = "select styleName from style";

                using MySqlCommand command = new MySqlCommand(query, connection);

                using MySqlDataReader reader = command.ExecuteReader();
                int styleOrdinal = reader.GetOrdinal("styleName");

                while (reader.Read())
                {
                    styles.Add(reader.GetFieldValueCheckNull<string>(styleOrdinal));
                }
            }

            return styles;
        }

        /// <summary>
        /// Gets all funiture by selected style.
        /// </summary>
        /// <param name="style">The style.</param>
        /// <returns>
        /// The list of furniture that match the style
        /// </returns>
        public List<Furniture> GetAllFunitureBySelectedStyle(string style)
        {
            List<Furniture> filteredFurniture = new List<Furniture>();
            using (MySqlConnection connection = new MySqlConnection(Connection.connectionString))
            {
                connection.Open();
                string query = "select f.furnitureID, f.furnitureName, f.rentPrice, f.quantity, s.styleName, c.categoryName from furniture f, style s, category c where f.styleID = s.styleId and f.categoryID = c.categoryId and s.styleName = @style";


                using MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.Add("@style", MySqlDbType.VarChar).Value = style;

                using MySqlDataReader reader = command.ExecuteReader();
                int idoridinal = reader.GetOrdinal("furnitureID");
                int fnameoridinal = reader.GetOrdinal("furnitureName");
                int styleoridinal = reader.GetOrdinal("styleName");
                int quantityoridinal = reader.GetOrdinal("quantity");

                int categoryoridinal = reader.GetOrdinal("categoryName");
                int priceoridinal = reader.GetOrdinal("rentPrice");

                while (reader.Read())
                {
                    filteredFurniture.Add(new Furniture
                    {
                        FurnitureID = reader.GetFieldValueCheckNull<Int32>(idoridinal),
                        FurnitureName = reader.GetFieldValueCheckNull<string>(fnameoridinal),
                        Style = reader.GetFieldValueCheckNull<string>(styleoridinal),
                        Category = reader.GetFieldValueCheckNull<string>(categoryoridinal),
                        RentPrice = reader.GetFieldValueCheckNull<decimal>(priceoridinal),
                        Quantity = reader.GetFieldValueCheckNull<Int32>(quantityoridinal),
                    });

                }
            }
            return filteredFurniture;
        }

        /// <summary>
        /// Gets all furniture by selected category.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <returns>
        /// The list of furniture that are in the category
        /// </returns>
        public List<Furniture> GetAllFurnitureBySelectedCategory(string category)
        {
            List<Furniture> filteredFurniture = new List<Furniture>();
            using (MySqlConnection connection = new MySqlConnection(Connection.connectionString))
            {
                connection.Open();
                string query =
                    "select f.furnitureID, f.furnitureName, f.rentPrice, f.quantity, s.styleName, c.categoryName from furniture f, style s, category c where f.styleID = s.styleId and f.categoryID = c.categoryId and c.categoryName = @category";

                using MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.Add("@category", MySqlDbType.VarChar).Value = category;

                using MySqlDataReader reader = command.ExecuteReader();
                int idoridinal = reader.GetOrdinal("furnitureID");
                int fnameoridinal = reader.GetOrdinal("furnitureName");
                int styleoridinal = reader.GetOrdinal("styleName");
                int quantityoridinal = reader.GetOrdinal("quantity");

                int categoryoridinal = reader.GetOrdinal("categoryName");
                int priceoridinal = reader.GetOrdinal("rentPrice");

                while (reader.Read())
                {
                    filteredFurniture.Add(new Furniture
                    {
                        FurnitureID = reader.GetFieldValueCheckNull<Int32>(idoridinal),
                        FurnitureName = reader.GetFieldValueCheckNull<string>(fnameoridinal),
                        Style = reader.GetFieldValueCheckNull<string>(styleoridinal),
                        Category = reader.GetFieldValueCheckNull<string>(categoryoridinal),
                        RentPrice = reader.GetFieldValueCheckNull<decimal>(priceoridinal),
                        Quantity = reader.GetFieldValueCheckNull<Int32>(quantityoridinal),
                    });

                }
            }
            return filteredFurniture;
        }
    }
}
