using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS3230RentalSystemProject.Model
{
    /// <summary>
    /// The Return Item class
    /// </summary>
    public class ReturnItem
    {
        /// <summary>
        /// The rental ID
        /// </summary>
        public int RentalID { get; set; }

        /// <summary>
        /// The return ID
        /// </summary>
        public int ReturnID { get; set; }

        /// <summary>
        /// The furniture ID
        /// </summary>
        public int FurnitureID { get; set; }

        /// <summary>
        /// The Furniture Name
        /// </summary>
        public string FurnitureName { get; set; }

        /// <summary>
        /// The quantity for the return item
        /// </summary>
        public int Quantity { get; set; }


        /// <summary>
        /// The reuturn date
        /// </summary>
        public DateTime ReturnDate { get; set; }
    }
}
