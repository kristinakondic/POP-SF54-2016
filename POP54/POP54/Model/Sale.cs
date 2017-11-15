using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP54.Model
{
    [Serializable]
    public class Sale
    {

        public int ID { get; set; }
        public int FurnitureOnSale { get; set; }
        public double Discount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Deleted { get; set; }

        /*public override string ToString()
        {
            return String.Format("{0,-5} {1,-15} {2,-5} {3,-15} {4,-15} {5,-5}", ID, Furniture.GetId(FurnitureOnSale), Discount, StartDate, EndDate, Deleted);
        }*/
    }
}
