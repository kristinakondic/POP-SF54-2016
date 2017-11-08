using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP54.Model
{
    public class Store
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public int CompanyNo { get; set; }
        public string AccountNo { get; set; }
        public int PIB { get; set; }
        public bool Deleted { get; set; }
    }
}
