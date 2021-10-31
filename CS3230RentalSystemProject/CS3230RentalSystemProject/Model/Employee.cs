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
        /// <summary>
        /// The Employee Id
        /// </summary>
        public int EmployeeID { get; set; }

        /// <summary>
        /// The Employee's first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The Employee's last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// The Employee's phone number
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// The Employee's email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// The member that employee server for
        /// </summary>
        public Member Member { get; set; }

        /// <summary>
        /// Member list for the store
        /// </summary>
        public List<Member> MemberList { get; set; }

        /// <summary>
        /// Furniture list that rent for the memebr
        /// </summary>
        public List<Furniture> FurnitureListData { get; set; }

        /// <summary>
        /// Selected Furniture
        /// </summary>
        public Furniture SelectedFurniture { get; set; }

        /// <summary>
        /// Initialize constructor
        /// </summary>
        public Employee() 
        {
            this.FurnitureListData = new List<Furniture>();
        }

        /// <summary>
        /// Override tostring
        /// </summary>
        /// <returns>
        /// The employee's full name
        /// </returns>
        public override string ToString()
        {
            return this.FirstName + " " + this.LastName;
        }
    }
}
