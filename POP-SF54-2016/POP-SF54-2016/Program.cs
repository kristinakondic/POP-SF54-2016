using POP_SF54_2016.Modeli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF54_2016
{
    class Program
    {
        static List<Namestaj> Namestaj { get; set; } = new List<Namestaj>();
        static List<TipNamestaja> TipoviNamestaja { get; set; } = new List<TipNamestaja>();
        static void Main(string[] args)
        {
            var tn1 = new TipNamestaja()
            {
                ID = 1,
                Naziv = "Garnitura",
            };

            var s1 = new Modeli.Salon()
            {
                ID = 1,
                Naziv = "Zika prom",
                Adresa = "Mise Dimitrijevica 1",
                BrojZiroRacuna = "852-28-2-82992",
                Email = "zika_prom@gmail.com",
                PIB = 484125,
                AdresaInternetSajta = "www.zika_prom.com",
                MaticniBroj = 5216262
            };
            var tn2 = new Modeli.TipNamestaja()
            {
                ID = 1,
                Naziv = "Garnitura"
            };

            var n1 = new Modeli.Namestaj() {
                ID = 1,
                Naziv = "Garnitura Sanja",
                Sifra = "fdsf454",
                TipNamestaja = tn1,
                KolicinaUMagacinu = 5,
            };
            Namestaj.Add(n1);
            
            Console.WriteLine("~~~ Dobro dosli u salon namestaja ~~~");
            IspisGlavnogMenija(); }
        private static void IspisGlavnogMenija()
        {
            int izbor = 0;
            do
            {
                Console.WriteLine("Glavni meni:");
                Console.WriteLine("1. Rad sa namestajem");
                Console.WriteLine("2. Rad sa tipom namestaja");
                Console.WriteLine("0. Izlaz");

                izbor = int.Parse(Console.ReadLine());
            } while (izbor < 0 || izbor > 2);
            switch (izbor)
            {
                case 0:
                    Environment.Exit(0);
                    break;
                case 1:
                    IspisiMeniNamestaja();
                    break;
                case 2:
                    break;
                default:
                    break;
            }
        }

        private static void IspisiMeniNamestaja()
        {
            int izbor = 0;

            do
            {
                Console.WriteLine("~~~ Meni namestaja ~~~");
                Console.WriteLine("1. Izlistaj namestaj");
                Console.WriteLine("2. Dodaj novi namestaj");
                Console.WriteLine("3. Izmeni postojeci namestaj");
                Console.WriteLine("4. Obrisi postojeci");
                Console.WriteLine("0. Povratak na glavni meni");
                izbor = int.Parse(Console.ReadLine());
            } while (izbor < 0 || izbor > 4);

            switch (izbor)
            {
                case 0:
                    IspisGlavnogMenija();
                    break;
                case 1:
                    IzlistajNamstaj();
                    break;
                default:
                    break;
            }
        }

        private static void IzlistajNamstaj()
        {
            Console.WriteLine("~~~ Izlistavanje namestaja ~~~");
            for (int i = 0; i < Namestaj.Count; ++i)
            {

                Console.WriteLine($"{i + 1}. {Namestaj[i].Naziv}, cena: {Namestaj[i].JedinicnaCena}");
            }
            IspisiMeniNamestaja();
        }
        private static void DodavanjeNamestaja()
        {
            Console.WriteLine("Izabrali ste dodavanje namestaja,molimo da unesete odgovarajuce podatke:");
            Console.WriteLine("Unesite naziv namestaja: ");
            string naziv = Console.ReadLine();
            Console.WriteLine("Unesite siftu namestaja: ");
            string sifra = Console.ReadLine();
            Console.WriteLine("Unesite cenu namestaja: ");
            double cena = double.Parse(Console.ReadLine());
            Console.WriteLine("Izaberite tip namestaja\n");
            for (int i = 0; i < TipoviNamestaja.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {TipoviNamestaja[i].Naziv}");

            }
            int tipID = int.Parse(Console.ReadLine());
            TipNamestaja t2 = new TipNamestaja();
            foreach (TipNamestaja t in TipoviNamestaja)
            {
                if (t.ID == tipID)
                {
                    t2 = t;
                    break;
                }
            }
        }
        }
}
