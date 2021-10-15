using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS3230RentalSystemProject.Model
{
    /// <summary>
    /// The Employee Class.
    /// </summary>
    public class Employee
    {
        public int EmployeeID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public Member Member { get; set; }

        public List<Member> MemberList { get; set; }

        public override string ToString()
        {
            return this.FirstName + " " + this.LastName;
        }
    }
}
