using SvetskaPrvesntva.Models;
using System;
using SvetskaPrvesntva.Enums;
using System.Collections.Generic;
using System.Text;

namespace SvetskaPrvesntva
{
    public class SvetskaPrvenstvaService
    {
        private static Dictionary<int, Drzava> listaDrzava = new Dictionary<int, Drzava>();
        private static Dictionary<int, SvetskoPrvenstvo> listaSvetskihPrvenstva = new Dictionary<int, SvetskoPrvenstvo>();
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

                    case Options.WriteAllWorldCups:
                        Console.Clear();
                        WriteAllWorldCups();
                        break;

                    default:
                        Console.WriteLine("That options does not exits!");
                        break;
                }

            } while (opcije != Options.Exit);
        }

        public void WriteAllCountrys()
        {
            foreach (KeyValuePair<int, Drzava> drzava in listaDrzava)
            {
                Drzava drzavaWrite = drzava.Value;
                Console.WriteLine(drzavaWrite.Naziv);
            }
            Console.WriteLine("Press any key to continue!");
            Console.ReadLine();
            Console.Clear();
        }

        public void WriteAllWorldCups()
        {
            foreach (KeyValuePair<int,SvetskoPrvenstvo> svetskoPrvenstvo in listaSvetskihPrvenstva)
            {
                SvetskoPrvenstvo svetskoPrvenstvoWrite = svetskoPrvenstvo.Value;
                Console.WriteLine(svetskoPrvenstvoWrite.ID + " " + svetskoPrvenstvoWrite.Naziv + " " + svetskoPrvenstvoWrite.Godina + " " + svetskoPrvenstvoWrite.Domacin.Naziv);
            }
            Console.WriteLine("Press any key to continue!");
            Console.ReadLine();
            Console.Clear();
        }

        public void LoadData()
        {
            Drzava drzava1 = new Drzava { Naziv = "Srbija" };
            Drzava drzava2 = new Drzava { Naziv = "Slovenija" };
            Drzava drzava3 = new Drzava { Naziv = "Hrvatska" };
            Drzava drzava4 = new Drzava { Naziv = "Francuska" };
            Drzava drzava5 = new Drzava { Naziv = "Holandija" };
            listaDrzava.Add(drzava1.ID, drzava1);
            listaDrzava.Add(drzava2.ID, drzava2);
            listaDrzava.Add(drzava3.ID, drzava3);
            listaDrzava.Add(drzava4.ID, drzava4);
            listaDrzava.Add(drzava5.ID, drzava5);

            SvetskoPrvenstvo svetskoPrvenstvo1 = new SvetskoPrvenstvo { ID = 1, Naziv = "prvenstvo1", Godina = 2018, Domacin = drzava2 };
            SvetskoPrvenstvo svetskoPrvenstvo2 = new SvetskoPrvenstvo { ID = 2, Naziv = "prvenstvo2", Godina = 2013, Domacin = drzava5 };
            SvetskoPrvenstvo svetskoPrvenstvo3 = new SvetskoPrvenstvo { ID = 3, Naziv = "prvenstvo3", Godina = 2015, Domacin = drzava3 };
            SvetskoPrvenstvo svetskoPrvenstvo4 = new SvetskoPrvenstvo { ID = 4, Naziv = "prvenstvo4", Godina = 2019, Domacin = drzava1 };
            SvetskoPrvenstvo svetskoPrvenstvo5 = new SvetskoPrvenstvo { ID = 5, Naziv = "prvenstvo5", Godina = 2020, Domacin = drzava4 };
            listaSvetskihPrvenstva.Add(svetskoPrvenstvo1.ID, svetskoPrvenstvo1);
            listaSvetskihPrvenstva.Add(svetskoPrvenstvo2.ID, svetskoPrvenstvo2);
            listaSvetskihPrvenstva.Add(svetskoPrvenstvo3.ID, svetskoPrvenstvo3);
            listaSvetskihPrvenstva.Add(svetskoPrvenstvo4.ID, svetskoPrvenstvo4);
            listaSvetskihPrvenstva.Add(svetskoPrvenstvo5.ID, svetskoPrvenstvo5);
        }
    }
}
