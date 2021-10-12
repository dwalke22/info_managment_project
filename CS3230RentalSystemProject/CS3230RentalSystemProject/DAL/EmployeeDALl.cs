using CS3230RentalSystemProject.Model;
using MySql.Data.MySqlClient;
using System;
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
        public List<Member> GetAllMemberList()
        {
            List<Member> MemberList = new List<Member>();
            using (MySqlConnection connection = new MySqlConnection(Connection.connectionString))
            {
                connection.Open();
                string query = "select * from member;";

                using MySqlCommand command = new MySqlCommand(query, connection);

                using MySqlDataReader reader = command.ExecuteReader();
                int fnameoridinal = reader.GetOrdinal("firstName");
                int lnameoridinal = reader.GetOrdinal("lastName");

                int genderoridinal = reader.GetOrdinal("gender");
                int address1oridinal = reader.GetOrdinal("address1");

                int address2oridinal = reader.GetOrdinal("address2");

                int cityoridinal = reader.GetOrdinal("city");
                int stateoridinal = reader.GetOrdinal("state");

                int countryoridinal = reader.GetOrdinal("country");
                int zipcodeoridinal = reader.GetOrdinal("zipcode");

                int phoneoridinal = reader.GetOrdinal("phoneNumber");
                int emailoridinal = reader.GetOrdinal("email");

                int birthdatoridinal = reader.GetOrdinal("birthday");

                while (reader.Read())
                {
                    MemberList.Add(new Member
                    {
                        FirstName = reader.GetFieldValueCheckNull<string>(fnameoridinal),
                        LastName = reader.GetFieldValueCheckNull<string>(lnameoridinal),
                        Gender = reader.GetFieldValueCheckNull<string>(genderoridinal),
                        Address1 = reader.GetFieldValueCheckNull<string>(address1oridinal),
                        Address2 = reader.GetFieldValueCheckNull<string>(address2oridinal),
                        City = reader.GetFieldValueCheckNull<string>(cityoridinal),
                        State = reader.GetFieldValueCheckNull<string>(stateoridinal),
                        Country = reader.GetFieldValueCheckNull<string>(countryoridinal),
                        Zipcode = reader.GetFieldValueCheckNull<string>(zipcodeoridinal),
                        PhoneNumber = reader.GetFieldValueCheckNull<string>(phoneoridinal),
                        Email = reader.GetFieldValueCheckNull<string>(emailoridinal),
                        Birthday = reader.GetFieldValueCheckNull<DateTime>(birthdatoridinal)
                    });

                }

            }
            return MemberList;

        }

    }
}
