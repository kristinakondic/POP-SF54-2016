using POP_SF54_2016.Modeli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF54_2016.Controller
{
    class FurnitureTypeController
    {
        public static void furnitureTypeMenu()
        {
            int izbor = 0;

            do
            {
                Console.WriteLine("~~~ Meni tipa namestaja ~~~");
                Console.WriteLine("1. Izlistaj tipove namestaj");
                Console.WriteLine("2. Dodaj novi tip namestaj");
                Console.WriteLine("3. Izmeni postojeci tip namestaj");
                Console.WriteLine("4. Obrisi postojeci tip namestaja ");
                Console.WriteLine("0. Povratak u glavni meni ");
                izbor = int.Parse(Console.ReadLine());
            }
            while (izbor < 0 || izbor > 4);

            switch (izbor)
            {
                case 0:
                    Program.mainMenu();
                    break;
                case 1:
                    showFurnitureType();
                    break;
                case 2:
                    addFurnitureType();
                    break;
                case 3:
                    editFurnitureType();
                    break;
                case 4:
                    deleteFurnitureType();
                    break;
                default:
                    break;
            }
        }
        private static void showFurnitureType()
        {
            var tipNamestaja = Projekat.Instance.TipNamestaja;
            Console.WriteLine("~~~ Izlistavanje namestaja ~~~");
            for (int i = 0; i < tipNamestaja.Count; ++i)
            {

                Console.WriteLine($"{i + 1}. {tipNamestaja[i].Naziv}");
            }
            furnitureTypeMenu();
        }

        public static void addFurnitureType()
        {
            var tipNamestaja = Projekat.Instance.TipNamestaja;
            Console.WriteLine("Izabrali ste dodavanje tipa namestaja,molimo Vas da unesete odgovarajuce podatke:\n");
            Console.WriteLine("Unesite naziv tipa namestaja: ");
            string naziv = Console.ReadLine();
            var tn = new TipNamestaja()
            {
                ID = tipNamestaja.Count + 1,
                Naziv = naziv
            };
            tipNamestaja.Add(tn);
            Console.WriteLine("sve ok ");
            Projekat.Instance.TipNamestaja = tipNamestaja;
        }
        public static void editFurnitureType()
        {
            var tipoviNamestaja = Projekat.Instance.TipNamestaja;
            Console.WriteLine("Izaberite Tip namestaja za izmenu:\n");
            int Id = int.Parse(Console.ReadLine());
            foreach (TipNamestaja tn in tipoviNamestaja)
            {
                if (tn.ID == Id)
                {
                    Console.WriteLine(Id);
                    Console.WriteLine("Unesite naziv za izmenu:");
                    string noviNaziv = Console.ReadLine();
                    tn.Naziv = noviNaziv;

                }
            }

            
            Projekat.Instance.TipNamestaja = tipoviNamestaja;
        }
        public static void deleteFurnitureType()
        {
            var tipoviNamestaja = Projekat.Instance.TipNamestaja;
            Console.WriteLine("\nIzaberite tip namestaja za brisanje: ");
            int izbor = int.Parse(Console.ReadLine());
            foreach (TipNamestaja n in tipoviNamestaja)
            {
                if (n.ID == izbor)
                {
                    n.Obrisan = true;
                    Console.WriteLine("Uspesno ste obrisali tip namestaja");
                    break;
                }
            }
            Projekat.Instance.TipNamestaja = tipoviNamestaja;
        }

    }
}
