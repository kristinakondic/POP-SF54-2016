using POP_SF54_2016.Modeli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF54_2016.Controller
{
    class EntityFinder
    {
        public static Namestaj findFurniture(int id)
        {
            var namestaj = Projekat.Instance.Namestaj;
            foreach (Namestaj n in namestaj)
            {
                if (n.ID == id)
                {
                    return n;
                }
            }
            return null;
        }

        public static TipNamestaja findFurnitureType(int id)
        {
            var tipoviNamstaja = Projekat.Instance.TipNamestaja;
            foreach (TipNamestaja n in tipoviNamstaja)
            {
                if (n.ID == id)
                {
                    return n;
                }
            }
            return null;
        }

        public static Akcija findSale(int id, List<Akcija> Akcije)
        {
            foreach (Akcija a in Akcije)
            {
                if (a.ID == id)
                {
                    return a;
                }
            }
            return null;
        }


    }
}
