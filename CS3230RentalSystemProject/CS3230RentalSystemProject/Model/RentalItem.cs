using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS3230RentalSystemProject.Model
{
    /// <summary>
    /// The Rental Item class
    /// </summary>
    public class RentalItem
    {
        /// <summary>
        /// The rental ID
        /// </summary>
        public int RentalID { get; set; }

        /// <summary>
        /// The furniture ID
        /// </summary>
        public int FurnitureID { get; set; }

        /// <summary>
        /// The Furniture Name
        /// </summary>
        public string FurnitureName { get; set; }

        /// <summary>
        /// The quantity for the rental item
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// The rental date
        /// </summary>
        public string RentalDate { get; set; }

        /// <summary>
        /// The Due date
        /// </summary>
        public string DueDate { get; set; }

        /// <summary>
        /// The rental info
        /// </summary>
        public string RentalInfo { get; set; }

        /// <summary>
        /// The Quantity list
        /// </summary>
        public IList<int> QuantityList { get; set; }

        /// <summary>
        /// Initialize constructor
        /// </summary>
        public RentalItem()
        {
            this.QuantityList = new List<int>();
        }

        /// <summary>
        /// Set rental info
        /// </summary>
        public void setRentalIDInfor()
        {
            this.RentalInfo = "" + this.RentalID + "," + this.FurnitureID;
        }

        /// <summary>
        /// Set up quantity list
        /// </summary>
        public void setQuantityList()
        {
            for (int i = 1; i <= this.Quantity; i++)
            {
                this.QuantityList.Add(i);
            }
        }
    }
}
