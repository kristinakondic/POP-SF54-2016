
using POP_SF54_2016.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF54_2016.Modeli
{
    public class Projekat
    {
        public static Projekat Instance { get; } = new Projekat();

        private List<Namestaj> namestaj;
        private List<TipNamestaja> tipNamestaja;
        private List<Akcija> akcija;

        public List<Namestaj> Namestaj
        {
            get
            {
                this.namestaj = GenericSerializer.Deserialize<Namestaj>("namestaj.xml");
                return this.namestaj;
            }
            set
            {
                this.namestaj = value;
                GenericSerializer.Serialize<Namestaj>("namestaj.xml", namestaj);
            }
        }

        public List<TipNamestaja> TipNamestaja
        {
            get
            {
                this.tipNamestaja = GenericSerializer.Deserialize<TipNamestaja>("tipNamestaja.xml");
                return this.tipNamestaja;
            }
            set
            {
                this.tipNamestaja = value;
                GenericSerializer.Serialize<TipNamestaja>("tipNamestaja.xml", tipNamestaja);
            }
        }

        public List<Akcija> Akcija
        {
            get { return this.akcija = GenericSerializer.Deserialize<Akcija>("akcije.xml"); }
            set
            {
                akcija = value;
                GenericSerializer.Serialize<Akcija>("akcije.xml", akcija);
            }
        }
    }
}
