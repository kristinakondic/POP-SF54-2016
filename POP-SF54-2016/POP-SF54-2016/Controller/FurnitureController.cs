
using POP_SF54_2016.Modeli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF54_2016.Controller
{
    class FurnitureController
    {

        public static void furnitureMenu()
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
                    Program.mainMenu();
                    break;
                case 1:
                    showFurniture();
                    break;
                case 2:
                    addFurniture();
                    break;
                case 3:
                    editFurniture();
                    break;
                case 4:
                    deleteFurniture();
                    break;
                default:
                    break;
            }
        }


        public static void showFurniture()
        {
            var namestaj = Projekat.Instance.Namestaj;
            Console.WriteLine("~~~ Izlistavanje namestaja ~~~");
            for (int i = 0; i < namestaj.Count; ++i)
            {

                Console.WriteLine($"{i + 1}. {namestaj[i].Naziv}, cena: {namestaj[i].JedinicnaCena}");
            }
            furnitureMenu();
        }
        private static void addFurniture()
        {
            var tipoviNamestaja = Projekat.Instance.TipNamestaja;
            var namestaj = Projekat.Instance.Namestaj;

            Console.WriteLine("Izabrali ste dodavanje namestaja,molimo Vas da unesete odgovarajuce podatke:");
            Console.WriteLine("Unesite naziv namestaja: ");
            string naziv = Console.ReadLine();
            Console.WriteLine("Unesite siftu namestaja: ");
            string sifra = Console.ReadLine();
            Console.WriteLine("Unesite cenu namestaja: ");
            double cena = double.Parse(Console.ReadLine());
            Console.WriteLine("Izaberite tip namestaja\n");
            for (int i = 0; i < tipoviNamestaja.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tipoviNamestaja[i].Naziv}");

            }
            int tipID = int.Parse(Console.ReadLine());
            TipNamestaja tip = new TipNamestaja();
            foreach (TipNamestaja t in tipoviNamestaja)
            {
                if (t.ID == tipID)
                {
                    tip = t;
                    break;
                }
            }

            var n = new Namestaj()
            {
                ID = namestaj.Count + 1,
                Naziv = naziv,
                Sifra = sifra,
                JedinicnaCena = cena,
                TipNamestaja = tip
            };
            namestaj.Add(n);
            Projekat.Instance.Namestaj = namestaj;

        }

        public static void editFurniture()
        {
            var namestaj = Projekat.Instance.Namestaj;
            var tipoviNamestaja = Projekat.Instance.TipNamestaja;

            Console.WriteLine("Unesite id namestaja koji zelite da izmenite: ");
            int id = int.Parse(Console.ReadLine());
            Namestaj nIzmena = new Namestaj();
            foreach (Namestaj n in namestaj)
            {
                if (n.ID == id)
                {
                    nIzmena = n;
                }
            }
            Console.WriteLine("Sta zelite da izmenite? ");
            Console.WriteLine(" 1. Izmena cene\n " +
                "2.Izmena naziva\n " +
                "3.Izmena sifre\n " +
                "4.Izmena kolicine\n " +
                "5.Izmena tipa namestaja");
            int izbor = int.Parse(Console.ReadLine());
            while (izbor < 0 || izbor > 5) ;
            switch (izbor)
            {
                case 1:
                    Console.WriteLine("Nova cena: ");
                    nIzmena.JedinicnaCena = double.Parse(Console.ReadLine());
                    break;
                case 2:
                    Console.WriteLine("Nov naziv: ");
                    nIzmena.Naziv = Console.ReadLine();
                    break;
                case 3:
                    Console.WriteLine("Nova sifra: ");
                    nIzmena.Sifra = Console.ReadLine();
                    break;
                case 4:
                    Console.WriteLine("Nova kolicina: ");
                    nIzmena.KolicinaUMagacinu = int.Parse(Console.ReadLine());
                    break;
                case 5:
                    Console.WriteLine("Izaberite nov tip namestaja: ");
                    for (int i = 0; i < tipoviNamestaja.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {tipoviNamestaja[i].Naziv}");

                    }
                    int tipID = int.Parse(Console.ReadLine());
                    TipNamestaja tip = new TipNamestaja();
                    foreach (TipNamestaja t in tipoviNamestaja)
                    {
                        if (t.ID == tipID)
                        {
                            tip = t;
                            nIzmena.TipNamestaja = tip;
                            break;
                        }
                    }
                    break;
                default:
                    break;
            }
            Projekat.Instance.Namestaj = namestaj;
        }

        public static void deleteFurniture()
        {
            var namestaj = Projekat.Instance.Namestaj;
            Console.WriteLine("\nIzaberite namestaj za brisanje: ");
            int izbor = int.Parse(Console.ReadLine());
            foreach (Namestaj n in namestaj)
            {
                if (n.ID == izbor)
                {
                    n.Obrisan = true;
                    Console.WriteLine("Uspesno ste obrisali namestaj");
                    break;
                }
            }
            Projekat.Instance.Namestaj = namestaj;
        }
    }
}
