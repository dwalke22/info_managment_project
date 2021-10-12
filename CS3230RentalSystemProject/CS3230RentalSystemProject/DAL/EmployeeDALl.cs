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

        public void RegisterMember(Member member)
        {
            string data = "";
            if (member.Address2 == null)
            {
                data = "INSERT into `member` (memberID, gender, firstName, lastName, address1, address2, city, state, country, zipcode, phoneNumber, email, birthday, registrationDate)"
                + "VALUES(null, '" + member.Gender + "', '" + member.FirstName + "', '" + member.LastName + "', '" + member.Address1 + "', null, '" + member.City + "', '" + member.State + "', '" + member.Country + "', '" + member.Zipcode + "', '" + member.PhoneNumber + "', '" + member.Email + "', '" + member.Birthday.Date.ToString("yyyy-MM-dd") + "', '" + DateTime.Now.ToString("yyyy-MM-dd") + "')";
            }
            else
            {
                data = "INSERT into `member` (memberID, gender, firstName, lastName, address1, address2, city, state, country, zipcode, phoneNumber, email, birthday, registrationDate)"
                + "VALUES(null, '" + member.Gender + "', '" + member.FirstName + "', '" + member.LastName + "', '" + member.Address1 + "', " + member.Address2 + ", '" + member.City + "', '" + member.State + "', '" + member.Country + "', '" + member.Zipcode + "', '" + member.PhoneNumber + "', '" + member.Email + "', '" + member.Birthday.Date.ToString("yyyy-MM-dd") + "', '" + DateTime.Now.ToString("yyyy-MM-dd") + "')";

            }
            using (MySqlConnection connection = new MySqlConnection(Connection.connectionString))
            {
                connection.Open();

                using MySqlCommand command = new MySqlCommand(data, connection);

                command.ExecuteNonQuery();
            }
        }

    }
}
