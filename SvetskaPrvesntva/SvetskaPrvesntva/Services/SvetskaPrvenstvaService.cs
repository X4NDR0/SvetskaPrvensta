using SvetskaPrvesntva.Models;
using System;
using SvetskaPrvesntva.Enums;
using System.Collections.Generic;
using System.Text;

namespace SvetskaPrvesntva
{
    public class SvetskaPrvenstvaService
    {
        private static List<Drzava> listaDrzava = new List<Drzava>();
        Options opcije;
        public void MenuText()
        {
            Console.WriteLine("1.Prikaz svih drzava");
            Console.WriteLine("2.Prikaz svih svetskih prvenstava sa prikazom drzave u kome je organizovano");
            Console.WriteLine("3.Unos i izmena drzava");
            Console.WriteLine("4.Unos i izmena svetskih prvenstava");
            Console.WriteLine("5.Sortiranje drzava po nazivu i njihov prikaz");
            Console.WriteLine("6.Sortiranje svetskih prvenstava po nazivu ili godini odrzavanja");
            Console.WriteLine("7.Ispis svetskih prvensta i drzava pomocu godina");
            Console.WriteLine("0.Exit");
            Console.Write("Odgovor:");
        }
        public void Menu()
        {
            LoadData();
            do
            {
                MenuText();
                Enum.TryParse(Console.ReadLine(), out opcije);

                switch (opcije)
                {
                    case Options.WriteAllCountrys:
                        Console.Clear();
                        WriteAllCountrys();
                        break;

                    default:
                        Console.WriteLine("That options does not exits!");
                        break;
                }

            } while (opcije != Options.Exit);


            

        }

        public void WriteAllCountrys()
        {
            foreach (Drzava drzava in listaDrzava)
            {
                Console.WriteLine(drzava.Naziv);
            }
            Console.WriteLine("Press any key to continue!");
            Console.ReadLine();
            Console.Clear();
        }

        public void LoadData()
        {
            Drzava drzava1 = new Drzava {Naziv = "Srbija"};
            Drzava drzava2 = new Drzava {Naziv = "Slovenija"};
            Drzava drzava3 = new Drzava {Naziv = "Hrvatska"};
            Drzava drzava4 = new Drzava {Naziv = "Francuska"};
            Drzava drzava5 = new Drzava {Naziv = "Holandija"};
            listaDrzava.Add(drzava1);
            listaDrzava.Add(drzava2);
            listaDrzava.Add(drzava3);
            listaDrzava.Add(drzava4);
            listaDrzava.Add(drzava5);
        }
    }
}
