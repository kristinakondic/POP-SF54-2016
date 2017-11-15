using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP54.Model
{
    [Serializable]
    public class FurnitureSelling
    {
        public int ID { get; set; }
        public int IdFurnitureForSale { get; set; }
        public DateTime DateOfSale { get; set; }
        public int BillNo { get; set; }
        public String Buyer { get; set; }
        public double PDV { get; set; }
        public int IdAdditionalServices { get; set; }
        public double FullPrice { get; set; }


    }
}
