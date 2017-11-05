using POP_SF54_2016.Controller;
using POP_SF54_2016.Modeli;
using POP_SF54_2016.Util;
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

            Console.WriteLine("~~~ Dobro dosli u salon namestaja ~~~");
            mainMenu(); }
        public static void mainMenu()
        {
            int izbor = 0;
            do
            {
                Console.WriteLine("Glavni meni:");
                Console.WriteLine("1. Rad sa namestajem");
                Console.WriteLine("2. Rad sa tipom namestaja");
                Console.WriteLine("3. Rad sa akcijama");
                Console.WriteLine("4. Rad sa dodatnim uslugama");
                Console.WriteLine("5. Rad sa prodajom");
                Console.WriteLine("6. Rad sa korisnicima");
                Console.WriteLine("0. Izlaz");

                izbor = int.Parse(Console.ReadLine());
            } while (izbor < 0 || izbor > 6);
            switch (izbor)
            {
                case 0:
                    Environment.Exit(0);
                    break;
                case 1:
                    FurnitureController.furnitureMenu();
                    break;
                case 2:
                    FurnitureTypeController.furnitureTypeMenu();
                    break;
                case 3:
                    SaleController.salesMenu();
                    break;
                default:
                    break;
            }
        }
    }
}
