using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS3230RentalSystemProject.Model
{
    /// <summary>
    /// The Furniture class
    /// </summary>
    public class Furniture
    {
        public int FurnitureID { get; set; }

        public string FurnitureName { get; set; }

        public string Style { get; set; }

        public string Category { get; set; }

        public decimal RentPrice { get; set; }

        public int rentQuantity = 0;

        public string fakeQuantity = "123456";

        public override string ToString()
        {
            return this.FurnitureName + "\n" + "< Style: " + this.Style + " Category: " + this.Category + " >";
        }
    }
}
