﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF54_2016.Modeli
{
    class Akcija
    {
        public int ID { get; set; }
        public bool Obrisana { get; set; }
        public DateTime PocetakAkcije { get; set; }
        public DateTime KrajAkcije { get; set; }
        public double Popust { get; set; }
        public List<Namestaj> NamestajNaPopustu { get; set; }
    }
}
