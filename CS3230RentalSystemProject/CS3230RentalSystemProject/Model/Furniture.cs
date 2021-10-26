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

        public int rentQuantity { get; set; }

        public IList<int> fakeQuantity { get; set; }

        public Furniture()
        {
            this.fakeQuantity = new List<int>();
            this.fakeQuantity.Add(1);
            this.fakeQuantity.Add(2);
            this.fakeQuantity.Add(3);
            this.fakeQuantity.Add(4);
            this.rentQuantity = 0;
        }

        public override string ToString()
        {
            return this.FurnitureName + "\n" + "< Style: " + this.Style + " Category: " + this.Category + " >";
        }
    }
}
