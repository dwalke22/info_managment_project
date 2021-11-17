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
    public class AdminQueryDAL
    {
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
    }
}
