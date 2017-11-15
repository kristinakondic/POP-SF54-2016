using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP54.Model
{
    [Serializable]
    public class FurnitureType
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool Deleted { get; set; }
        public override string ToString()
        {
            return String.Format("{0,-5}{1,-15}{2,-5}", ID, Name, Deleted);
        }

        public static FurnitureType GetId(int Id)
        {
            foreach (var furnitureType in Project.Instance.FurnitureTypesList)
            {
                if (furnitureType.ID == Id)
                {
                    return furnitureType;
                }
            }
            return null;
        }
    }
}
