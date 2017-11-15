using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP54.Model
{
    [Serializable]
    public class Furniture
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ProductCode { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public int FurnitureTypeId { get; set; }
        public bool Deleted { get; set; }

        public override string ToString()
        {
            return String.Format("{0,-5} {1,-15} {2,-15} {3,-10} {4,-5} {5,-5} {6,-5}", ID, Name, Price, ProductCode, Quantity, FurnitureType.GetId(FurnitureTypeId), Deleted);
        }

        public static Furniture GetId(int Id)
        {
            foreach (var furniture in Project.Instance.FurnitureList)
            {
                if (furniture.ID == Id)
                {
                    return furniture;
                }
            }
            return null;
        }
    }
}
