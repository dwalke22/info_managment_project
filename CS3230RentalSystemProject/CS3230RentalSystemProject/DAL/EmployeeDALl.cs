using CS3230RentalSystemProject.Model;
using MySqlConnector;
using System.Collections.Generic;


namespace DBAccess.DAL
{
    /// <summary>
    /// The EmployeeDAL class
    /// </summary>
    public class EmployeeDAL
    {
        /// <summary>
        /// Get all the members
        /// </summary>
        /// <returns> all the members</returns>
        public List<Member> GetAllMemberst(int dno)
        {
            List<Member> MemberList = new List<Member>();
            using (MySqlConnection connection = new MySqlConnection(Connection.connectionString))
            {
                connection.Open();
                string query = "select * from member;";

                using MySqlCommand command = new MySqlCommand(query, connection);

                using MySqlDataReader reader = command.ExecuteReader();
                int fnameoridinal = reader.GetOrdinal("fname");
                int doboridinal = reader.GetOrdinal("bdate");

                while (reader.Read())
                {
                    MemberList.Add(new Member
                    {
                    });

                }

            }
            return MemberList;

        }

    }
}
