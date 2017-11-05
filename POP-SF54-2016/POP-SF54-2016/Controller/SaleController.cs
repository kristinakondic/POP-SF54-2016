using POP_SF54_2016.Modeli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF54_2016.Controller
{
    class SaleController
    {
        public static void salesMenu()
        {
            int izbor = 0;

            do
            {
                Console.WriteLine("~~~ Meni akcija ~~~");
                Console.WriteLine("1. Izlistaj Akcije");
                Console.WriteLine("2. Dodaj novu Akciju");
                Console.WriteLine("3. Izmeni postojecu Akciju");
                Console.WriteLine("4. Obrisi postojecu Akciju ");
                Console.WriteLine("0. Povratak u glavni meni\n ");
                izbor = int.Parse(Console.ReadLine());
            }
            while (izbor < 0 || izbor > 4);

            switch (izbor)
            {
                case 0:
                    Program.mainMenu();
                    break;
                case 1:
                    showSales();
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                default:
                    break;
            }
        }
        private static void showSales()
        {
            var akcije = Projekat.Instance.Akcija;
            Console.WriteLine("~~~ Izlistavanje akcija ~~~");
            for (int i = 0; i < akcije.Count; i++)
            {
                if (!akcije[i].Obrisan)
                {
                    string ispis = $"{akcije[i].ID}. Pocetak akcije:  {akcije[i].PocetakAkcije}  Kraj akcije: {akcije[i].KrajAkcije}  Namestaj na akciji:";

                    for (int j = 0; j < akcije[i].NamestajNaPopustu.Count; j++)
                    {
                        ispis += $"{EntityFinder.findFurniture(akcije[i].NamestajNaPopustu[j].ID)},";
                    }
                    Console.WriteLine(ispis + $" Popust: {akcije[i].Popust}");
                }
            }
        }

    }
}
