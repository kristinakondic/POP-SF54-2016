using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF54_2016.Modeli
{
    public enum TipKorisnika
    {
        Administrator,
        Prodavac
    }
    class Korisnik
    {
        public int ID { get; set; }
        public bool Obrisan { get; set; }
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public TipKorisnika TipKorisnika { get; set; }

    }
}
