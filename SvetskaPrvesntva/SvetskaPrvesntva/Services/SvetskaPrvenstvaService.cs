using SvetskaPrvesntva.Enums;
using SvetskaPrvesntva.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
            Console.WriteLine("7.Ispis svetskih prvenstava i drzava pomocu godina");
            Console.WriteLine("8.Broj svetskih prvenstava po drzavi");
            Console.WriteLine("0.Exit");
            Console.Write("Odgovor:");
        }
        public void Menu()
        {
            Console.OutputEncoding = Encoding.UTF8;

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
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case Options.WriteAllWorldCups:
                        Console.Clear();
                        WriteAllWorldCups();
                        break;

                    case Options.AddOrChangeCountry:
                        Console.Clear();
                        AddOrChangeCountry();
                        break;

                    case Options.AddOrChangeWorldCup:
                        Console.Clear();
                        AddOrChangeWorldCup();
                        break;

                    case Options.SortCountry:
                        Console.Clear();
                        SortCountry();
                        break;

                    case Options.SortWorldCups:
                        Console.Clear();
                        SortWorldCup();
                        break;

                    case Options.WriteCountrysByRangeOfYear:
                        Console.Clear();
                        WriteAllCountrysByRangeOfYears();
                        break;

                    case Options.NumberOfWorldCupsByCountry:
                        Console.Clear();
                        NumberOfWorldCupsByCountry();
                        break;

                    default:
                        Console.WriteLine("That options does not exits!");
                        break;
                }

            } while (opcije != Options.Exit);
        }

        public static void WriteAllCountrys()
        {
            var test = listaSvetskihPrvenstva.GroupBy(x => x.Value.Domacin.Naziv).Where(x => x.Count() > 2);

            foreach (KeyValuePair<int, Drzava> drzava in listaDrzava)
            {
                Drzava drzavaWrite = drzava.Value;
                Console.WriteLine(drzavaWrite.ID + " " + drzavaWrite.Naziv + test.Count());
            }
        }

        public static void WriteAllWorldCups()
        {
            foreach (KeyValuePair<int,SvetskoPrvenstvo> svetskoPrvenstvo in listaSvetskihPrvenstva)
            {
                Console.WriteLine("ID:" + svetskoPrvenstvo.Value.ID + " Naziv:" + svetskoPrvenstvo.Value.Naziv + " Godina:" + svetskoPrvenstvo.Value.Godina + " Domacin:" + svetskoPrvenstvo.Value.Domacin.Naziv);
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
            Console.Clear();
        }

        public static void AddOrChangeCountry()
        {
            Console.WriteLine("1.Add");
            Console.WriteLine("2.Change");
            Console.Write("Option:");
            Int32.TryParse(Console.ReadLine(), out int option);

            switch (option)
            {
                case 1:
                    Console.Clear();
                    int id = listaDrzava.Keys.Max() + 1;
                    Console.Write("Type the name of the country:");
                    string nameAdd = Console.ReadLine();


                    Drzava drzavaAdd = new Drzava { ID = id, Naziv = nameAdd };
                    listaDrzava.Add(drzavaAdd.ID, drzavaAdd);

                    Console.Clear();

                    Console.WriteLine("Drzava je uspesno dodata!");

                    Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    break;

                case 2:
                    Console.Clear();
                    Console.Write("Enter the id of the item which you want make changes:");
                    Int32.TryParse(Console.ReadLine(), out int idSelect);

                    Console.Clear();

                    if (listaDrzava.ContainsKey(idSelect))
                    {
                        Drzava drzava = listaDrzava[idSelect];

                        Console.Write("Enter the name of the country:");
                        string nameChange = Console.ReadLine();

                        Console.Clear();

                        drzava = new Drzava { ID = idSelect, Naziv = nameChange };

                        listaDrzava[idSelect] = drzava;
                    }
                    else
                    {
                        Console.WriteLine("That ID does not exits!");
                    }


                    Console.Clear();

                    Console.WriteLine("Drzava je uspesno izmenjena!");

                    Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    break;


                default:
                    Console.WriteLine("That option does not exits!");
                    break;
            }
        }

        public static void AddOrChangeWorldCup()
        {
            Console.WriteLine("1.Add");
            Console.WriteLine("2.Change");
            Console.Write("Options:");
            Int32.TryParse(Console.ReadLine(), out int option);

            switch (option)
            {
                case 1:
                    Console.Clear();
                    Console.Write("Enter the name of the world cup:");
                    string naziv = Console.ReadLine();

                    Console.Clear();

                    Console.Write("Enter the year of the world cup:");
                    Int32.TryParse(Console.ReadLine(), out int yearAdd);

                    Console.Clear();

                    WriteAllCountrys();
                    Console.Write("Enter the id of the \"Domacin\":");
                    Int32.TryParse(Console.ReadLine(), out int idDrzaveDomacina);

                    if (listaDrzava.ContainsKey(idDrzaveDomacina))
                    {
                        Drzava drzavaDomacin = listaDrzava[idDrzaveDomacina];
                        SvetskoPrvenstvo svetskoPrvenstvoAdd = new SvetskoPrvenstvo { ID = listaSvetskihPrvenstva.Keys.Max() + 1, Naziv = naziv, Domacin = drzavaDomacin, Godina = yearAdd };
                        listaSvetskihPrvenstva.Add(svetskoPrvenstvoAdd.ID, svetskoPrvenstvoAdd);

                        Console.Clear();
                        Console.WriteLine("Svetsko prvenstvo je uspesno dodato!");
                    }
                    else
                    {
                        Console.WriteLine("That ID does not exits!");
                    }

                    Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    break;

                case 2:
                    Console.Clear();
                    Console.Write("Enter the ID of the world cup which you want edit:");
                    Int32.TryParse(Console.ReadLine(), out int idSelect);

                    Console.Clear();

                    if (listaSvetskihPrvenstva.ContainsKey(idSelect))
                    {
                        SvetskoPrvenstvo svetskoPrvenstvo = listaSvetskihPrvenstva[idSelect];

                        Console.Write("Enter the name of the world cup:");
                        string nazivEdit = Console.ReadLine();

                        Console.Clear();

                        Console.Write("Enter the year of the world cup:");
                        Int32.TryParse(Console.ReadLine(), out int yearEdit);

                        Console.Clear();

                        WriteAllCountrys();
                        Console.Write("Enter the ID of the \"Domacin\":");
                        Int32.TryParse(Console.ReadLine(), out int idDomacin);

                        Console.Clear();

                        if (listaDrzava.ContainsKey(idDomacin))
                        {
                            Drzava drzavaDomacinEdit = listaDrzava[idDomacin];
                            svetskoPrvenstvo = new SvetskoPrvenstvo { ID = idSelect, Naziv = nazivEdit, Godina = yearEdit, Domacin = drzavaDomacinEdit };
                            listaSvetskihPrvenstva[idSelect] = svetskoPrvenstvo;

                            Console.Clear();
                            Console.WriteLine("Svetsko prvenstvo je uspesno dodato!");
                        }
                        else
                        {
                            Console.WriteLine("That ID of country does not exits!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("That ID does not exits!");
                    }

                    Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();

                    break;

                default:
                    Console.WriteLine("That options does not exits!");
                    break;
            }
        }

        private static void WriteSortedWorldCups(Dictionary<int,SvetskoPrvenstvo> svetskoPrvenstvo)
        {
            foreach (KeyValuePair<int,SvetskoPrvenstvo> item in svetskoPrvenstvo)
            {
                Console.WriteLine("ID:" + item.Value.ID + " Naziv:" + item.Value.Naziv + " Godina:" + item.Value.Godina + " Domacin:" + item.Value.Domacin.Naziv);
            }
        }

        public static void SortCountry()
        {
            Console.Clear();
            foreach (KeyValuePair<int, Drzava> drzava in listaDrzava.OrderBy(x => x.Value.Naziv))
            {
                Console.WriteLine("ID:" + drzava.Key + " Naziv:" + drzava.Value.Naziv);
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
            Console.Clear();
        }

        public static void SortWorldCup()
        {
            Console.WriteLine("1.Sortiraj po godini");
            Console.WriteLine("2.Sortiraj po nazivu države gde je održano svetsko prvenstvo");
            Console.Write("Options:");
            Int32.TryParse(Console.ReadLine(), out int idSelect);

            switch (idSelect)
            {
                case 1:
                    Console.Clear();

                    var sortedDictionaryByDate = listaSvetskihPrvenstva.OrderBy(x => x.Value.Godina).ToDictionary(x => x.Key, x => x.Value);

                    WriteSortedWorldCups(sortedDictionaryByDate);

                    Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    break;

                case 2:
                    Console.Clear();

                    var sortedDictionaryByName = listaSvetskihPrvenstva.OrderBy(x => x.Value.Domacin).ToDictionary(x => x.Key, x => x.Value);

                    WriteSortedWorldCups(sortedDictionaryByName);

                    Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    break;

                default:
                    Console.WriteLine("That ID does not exits!");
                    break;
            }
        }

        public static void WriteAllCountrysByRangeOfYears()
        {
            Console.Write("Od:");
            Int32.TryParse(Console.ReadLine(), out int odGodine);
            Console.Write("Do:");
            Int32.TryParse(Console.ReadLine(), out int doGodine);
            foreach (KeyValuePair<int,SvetskoPrvenstvo> svetskoPrvenstvo in listaSvetskihPrvenstva)
            {
                if (svetskoPrvenstvo.Value.Godina >= odGodine && svetskoPrvenstvo.Value.Godina <= doGodine)
                {
                    Console.WriteLine("ID:" + svetskoPrvenstvo.Value.ID + " Naziv:" + svetskoPrvenstvo.Value.Naziv + " Godina:" + svetskoPrvenstvo.Value.Godina + " Domacin:" + svetskoPrvenstvo.Value.Domacin.Naziv);
                }
            }
        }

        public static void NumberOfWorldCupsByCountry()
        {
            int brojac = 0;
            foreach (KeyValuePair<int,SvetskoPrvenstvo> svetskoPrvenstvo in listaSvetskihPrvenstva)
            {
                brojac = 0;
                foreach (KeyValuePair<int,SvetskoPrvenstvo> svetskoPrvenstvo2 in listaSvetskihPrvenstva)
                {
                    if (svetskoPrvenstvo.Value.Domacin.Naziv.Equals(svetskoPrvenstvo2.Value.Domacin.Naziv))
                    {
                        brojac++;
                    }
                }
                Console.WriteLine("Drzava:" + svetskoPrvenstvo.Value.Domacin.Naziv + brojac);
            }
        }

        public void LoadData()
        {
            Drzava drzava1 = new Drzava { ID = 1, Naziv = "Srbija" };
            Drzava drzava2 = new Drzava { ID = 2, Naziv = "Slovenija" };
            Drzava drzava3 = new Drzava { ID = 3, Naziv = "Hrvatska" };
            Drzava drzava4 = new Drzava { ID = 4, Naziv = "Francuska" };
            Drzava drzava5 = new Drzava { ID = 6, Naziv = "Holandija" };
            Drzava drzava6 = new Drzava { ID = 7, Naziv = "Holandija" };
            Drzava drzava7 = new Drzava { ID = 8, Naziv = "Holandija" };
            listaDrzava.Add(drzava1.ID, drzava1);
            listaDrzava.Add(drzava2.ID, drzava2);
            listaDrzava.Add(drzava3.ID, drzava3);
            listaDrzava.Add(drzava4.ID, drzava4);
            listaDrzava.Add(drzava5.ID, drzava5);
            listaDrzava.Add(drzava6.ID, drzava6);
            listaDrzava.Add(drzava7.ID, drzava7);

            SvetskoPrvenstvo svetskoPrvenstvo1 = new SvetskoPrvenstvo { ID = 1, Naziv = "prvenstvo1", Godina = 2010, Domacin = drzava2 };
            SvetskoPrvenstvo svetskoPrvenstvo2 = new SvetskoPrvenstvo { ID = 2, Naziv = "prvenstvo2", Godina = 2011, Domacin = drzava5 };
            SvetskoPrvenstvo svetskoPrvenstvo3 = new SvetskoPrvenstvo { ID = 3, Naziv = "prvenstvo3", Godina = 2013, Domacin = drzava3 };
            SvetskoPrvenstvo svetskoPrvenstvo4 = new SvetskoPrvenstvo { ID = 4, Naziv = "prvenstvo4", Godina = 2012, Domacin = drzava1 };
            SvetskoPrvenstvo svetskoPrvenstvo5 = new SvetskoPrvenstvo { ID = 5, Naziv = "prvenstvo5", Godina = 2015, Domacin = drzava4 };
            SvetskoPrvenstvo svetskoPrvenstvo6 = new SvetskoPrvenstvo { ID = 6, Naziv = "prvenstvo6", Godina = 2020, Domacin = drzava4 };
            listaSvetskihPrvenstva.Add(svetskoPrvenstvo1.ID, svetskoPrvenstvo1);
            listaSvetskihPrvenstva.Add(svetskoPrvenstvo2.ID, svetskoPrvenstvo2);
            listaSvetskihPrvenstva.Add(svetskoPrvenstvo3.ID, svetskoPrvenstvo3);
            listaSvetskihPrvenstva.Add(svetskoPrvenstvo4.ID, svetskoPrvenstvo4);
            listaSvetskihPrvenstva.Add(svetskoPrvenstvo5.ID, svetskoPrvenstvo5);
            listaSvetskihPrvenstva.Add(svetskoPrvenstvo6.ID, svetskoPrvenstvo6);
        }
    }
}
