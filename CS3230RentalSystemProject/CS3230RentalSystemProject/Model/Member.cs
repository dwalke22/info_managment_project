﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 
/// </summary>
namespace CS3230RentalSystemProject.Model
{
    /// <summary>
    /// The Member class
    /// </summary>
    public class Member
    {
        /// <summary>
        /// The Member ID
        /// </summary>
        public int? MemberID { get; set; }

        /// <summary>
        /// The Member first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The Member last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// The Member gender
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// The Member address1
        /// </summary>
        public string Address1 { get; set; }

        /// <summary>
        /// The Member address2
        /// </summary>
        public string Address2 { get; set; }

        /// <summary>
        /// The Member city
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// The Member state
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// The Member country
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// The Member zipcode
        /// </summary>
        public string Zipcode { get; set; }

        /// <summary>
        /// The Member phone number
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// The Member email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// The Member birthday
        /// </summary>
        public DateTime Birthday { get; set; }

        /// <summary>
        /// Override tostring
        /// </summary>
        /// <returns>
        /// The Member's full name
        /// </returns>
        public override string ToString()
        {
            return this.FirstName + " " + this.LastName;
        }
    }
}
