using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP54.Model
{
    public class AdditionalService
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public bool Deleted { get; set; }

        public override string ToString()
        {
            return String.Format("{0,-5}|{1,-15}|{2,-10}|{3,-6}", ID, Name, Price, Deleted);
        }
    }
}
