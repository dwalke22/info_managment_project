using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS3230RentalSystemProject.Model
{
    /// <summary>
    /// The repor class
    /// </summary>
    public class Report
    {
        /// <summary>
        /// The MemeberID
        /// </summary>
        public int MemeberID { get; set; }

        /// <summary>
        /// The Member FullName
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// The FunitureID
        /// </summary>
        public int FunitureID { get; set; }

        /// <summary>
        /// The FunitureName
        /// </summary>
        public string FunitureName { get; set; }

        /// <summary>
        /// The Furniture StyleName
        /// </summary>
        public string StyleName { get; set; }

        /// <summary>
        /// The Furniture CategoryName
        /// </summary>
        public string CategoryName { get; set; }

        /// <summary>
        /// The Rental Quantity
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// The Furniture RentalDate
        /// </summary>
        public string RentalDate { get; set; }

        /// <summary>
        /// The Furniture DueDate
        /// </summary>
        public string DueDate { get; set; }

        /// <summary>
        /// The Furniture ReturnDate
        /// </summary>
        public string ReturnDate { get; set; }
    }
}
