using CS3230RentalSystemProject.Model;
using DBAccess.DAL;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace CS3230RentalSystemProject.DAL
{
    /// <summary>
    /// The MemnerDAL class
    /// </summary>
    public class MemberDAL
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

                int idoridinal = reader.GetOrdinal("memberID");
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
                        MemberID = reader.GetFieldValueCheckNull<Int32>(idoridinal),
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

        /// <summary>
        /// Get the member tha match the id
        /// </summary>
        /// <param name="id">The member ID</param>
        /// <returns> the member that match the id</returns>
        public List<Member> GetMemberById(int id)
        {
            List<Member> MemberList = new List<Member>();
            using (MySqlConnection connection = new MySqlConnection(Connection.connectionString))
            {
                connection.Open();
                string query = "select * from member where memberID = @id;";

                using MySqlCommand command = new MySqlCommand(query, connection);

                command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

                using MySqlDataReader reader = command.ExecuteReader();

                int idoridinal = reader.GetOrdinal("memberID");
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
                        MemberID = reader.GetFieldValueCheckNull<Int32>(idoridinal),
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

        /// <summary>
        /// Get the member tha match the phone
        /// </summary>
        /// <param name="phone">The memebr's phone</param>
        /// <returns> the member that match the phone</returns>
        public List<Member> GetMemberByPhone(String phone)
        {
            List<Member> MemberList = new List<Member>();
            using (MySqlConnection connection = new MySqlConnection(Connection.connectionString))
            {
                connection.Open();
                string query = "select * from member where phoneNumber = @phone;";

                using MySqlCommand command = new MySqlCommand(query, connection);

                command.Parameters.Add("@phone", MySqlDbType.VarChar).Value = phone;

                using MySqlDataReader reader = command.ExecuteReader();

                int idoridinal = reader.GetOrdinal("memberID");
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
                        MemberID = reader.GetFieldValueCheckNull<Int32>(idoridinal),
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

        /// <summary>
        /// Get the member tha match the fullName
        /// </summary>
        /// <param name="fullName">The member's full name</param>
        /// <returns> the member that match the fullName</returns>
        public List<Member> GetMemberByFullName(String fullName)
        {
            List<Member> MemberList = new List<Member>();
            using (MySqlConnection connection = new MySqlConnection(Connection.connectionString))
            {
                connection.Open();
                string query = "select * from member where concat(firstName,' ',lastName) = @fullName;";

                using MySqlCommand command = new MySqlCommand(query, connection);

                command.Parameters.Add("@fullName", MySqlDbType.VarChar).Value = fullName;

                using MySqlDataReader reader = command.ExecuteReader();

                int idoridinal = reader.GetOrdinal("memberID");
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
                        MemberID = reader.GetFieldValueCheckNull<Int32>(idoridinal),
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

        /// <summary>
        /// Register ner member
        /// </summary>
        /// <param name="member">
        ///             The new member
        /// </param>
        public void RegisterMember(Member member)
        {
            string data = "INSERT into `member` (memberID, gender, firstName, lastName, address1, address2, city, state, country, zipcode, phoneNumber, email, birthday, registrationDate)"
                + "VALUES(@memberID, @gender, @firstName, @lastName, @address1, @address2, @city, @state, @country, @zipcode, @phoneNumber, @email, @birthday, @registrationDate)";

            using (MySqlConnection connection = new MySqlConnection(Connection.connectionString))
            {
                connection.Open();

                using MySqlCommand command = new MySqlCommand(data, connection);
                command.Parameters.Add("@memberID", MySqlDbType.Int32).Value = null;
                command.Parameters.Add("@gender", MySqlDbType.VarChar).Value = member.Gender;
                command.Parameters.Add("@firstName", MySqlDbType.VarChar).Value = member.FirstName;
                command.Parameters.Add("@lastName", MySqlDbType.VarChar).Value = member.LastName;
                command.Parameters.Add("@address1", MySqlDbType.VarChar).Value = member.Address1;
                command.Parameters.Add("@address2", MySqlDbType.VarChar).Value = member.Address2 == null ? null : member.Address2;
                command.Parameters.Add("@city", MySqlDbType.VarChar).Value = member.City;
                command.Parameters.Add("@state", MySqlDbType.VarChar).Value = member.State;
                command.Parameters.Add("@country", MySqlDbType.VarChar).Value = member.Country;
                command.Parameters.Add("@zipcode", MySqlDbType.VarChar).Value = member.Zipcode;
                command.Parameters.Add("@phoneNumber", MySqlDbType.VarChar).Value = member.PhoneNumber;
                command.Parameters.Add("@email", MySqlDbType.VarChar).Value = member.Email;
                command.Parameters.Add("@birthday", MySqlDbType.VarChar).Value = member.Birthday.Date.ToString("yyyy-MM-dd");
                command.Parameters.Add("@registrationDate", MySqlDbType.VarChar).Value = DateTime.Now.ToString("yyyy-MM-dd");
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Update member's general information
        /// </summary>
        /// <param name="member">The member who need to be updated</param>
        public void UpdateMemberInfo(Member member)
        {
            string data = "Update `member` set gender = @gender, firstName = @firstName, lastName = @lastName, address1 = @address1,"
                + " address2 = @address2, city = @city, state = @state, country = @country, zipcode = @zipcode, phoneNumber = @phoneNumber, email = @email, birthday = @birthday "
                + "where memberID = @memberID";

            using (MySqlConnection connection = new MySqlConnection(Connection.connectionString))
            {
                connection.Open();

                using MySqlCommand command = new MySqlCommand(data, connection);
                command.Parameters.Add("@memberID", MySqlDbType.Int32).Value = member.MemberID;
                command.Parameters.Add("@gender", MySqlDbType.VarChar).Value = member.Gender;
                command.Parameters.Add("@firstName", MySqlDbType.VarChar).Value = member.FirstName;
                command.Parameters.Add("@lastName", MySqlDbType.VarChar).Value = member.LastName;
                command.Parameters.Add("@address1", MySqlDbType.VarChar).Value = member.Address1;
                command.Parameters.Add("@address2", MySqlDbType.VarChar).Value = member.Address2 == null ? null : member.Address2;
                command.Parameters.Add("@city", MySqlDbType.VarChar).Value = member.City;
                command.Parameters.Add("@state", MySqlDbType.VarChar).Value = member.State;
                command.Parameters.Add("@country", MySqlDbType.VarChar).Value = member.Country;
                command.Parameters.Add("@zipcode", MySqlDbType.VarChar).Value = member.Zipcode;
                command.Parameters.Add("@phoneNumber", MySqlDbType.VarChar).Value = member.PhoneNumber;
                command.Parameters.Add("@email", MySqlDbType.VarChar).Value = member.Email;
                command.Parameters.Add("@birthday", MySqlDbType.VarChar).Value = member.Birthday.Date.ToString("yyyy-MM-dd");
                command.ExecuteNonQuery();
            }
        }
    }
}
