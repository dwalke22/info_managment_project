using System;
using System.Collections.Generic;

namespace CS3230RentalSystemProject.Model
{
    /// <summary>
    /// The Furniture class
    /// </summary>
    public class Furniture
    {
        /// <summary>
        /// The Furniture ID
        /// </summary>
        public int FurnitureID { get; set; }

        /// <summary>
        /// The Furniture name
        /// </summary>
        public string FurnitureName { get; set; }

        /// <summary>
        /// The Furniture Style
        /// </summary>
        public string Style { get; set; }

        /// <summary>
        /// The Furniture Category
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// The Furniture Rent price
        /// </summary>
        public decimal RentPrice { get; set; }

        /// <summary>
        /// The Furniture Current rent price
        /// </summary>
        public decimal CurrentToalPrice { get; set; }

        /// <summary>
        /// The Furniture Quantity
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// The Furniture Rental quantity
        /// </summary>
        public int RentQuantity { get; set; }

        /// <summary>
        /// The Quantity list
        /// </summary>
        public IList<int> QuantityList { get; set; }

        /// <summary>
        /// The Furniture return date
        /// </summary>
        public DateTimeOffset? ReturnDate { get; set; }

        /// <summary>
        /// The Furniture return availability
        /// </summary>
        public DateTime Availability { get; set; }

        /// <summary>
        /// Gets or sets the rental days.
        /// </summary>
        /// <value>
        /// The rental days.
        /// </value>
        public int RentalDays { get; set; }

        /// <summary>
        /// Initialize constructor
        /// </summary>
        public Furniture()
        {
            this.QuantityList = new List<int>();
            this.RentQuantity = 0;
            this.ReturnDate = DateTime.Now.AddDays(1);
            this.RentalDays = 1;
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

        /// <summary>
        /// Set current total price
        /// </summary>
        public void setCurentTotalPrice()
        {
            
            this.CurrentToalPrice = this.RentPrice * this.RentQuantity * RentalDays;
        }

        /// <summary>
        /// Override tostring
        /// </summary>
        /// <returns>
        /// The Furniture's full information
        /// </returns>
        public override string ToString()
        {
            return this.FurnitureName + "\n" + "< Style: " + this.Style + " Category: " + this.Category + " >";
        }
    }
}
