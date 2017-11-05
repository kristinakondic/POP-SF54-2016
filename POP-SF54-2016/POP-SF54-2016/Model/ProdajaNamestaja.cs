using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF54_2016.Modeli
{
    class ProdajaNamestaja
    {
        
        public int ID { get; set; }
        public List<Namestaj> NamestajZaProdaju { get; set; }
        public DateTime DatumProdaje { get; set; }
        public int BrojRacuna { get; set; }
        public String Kupac { get; set; }
        public double PDV { get; set; }
        public List<DodatnaUsluga> DodatneUsluge { get; set; }
        public double UkupanIznos { get; set; }

    
}
}
