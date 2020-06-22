using SvetskaPrvenstva.Utils;
using SvetskaPrvesntva.Enums;
using SvetskaPrvesntva.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SvetskaPrvesntva
{
    /// <summary>
    /// Representing class
    /// </summary>
    public class SvetskaPrvenstvaService
    {
        private static Dictionary<int, Drzava> listaDrzava = new Dictionary<int, Drzava>();
        private static Dictionary<int, SvetskoPrvenstvo> listaSvetskihPrvenstva = new Dictionary<int, SvetskoPrvenstvo>();
        private static string lokacija = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\"));
        Options opcije;
        /// <summary>
        /// Representing method for writing text(options)
        /// </summary>
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
            Console.WriteLine("9.Obrisi drzavu");
            Console.WriteLine("10.Obrisi svetsko prvenstvo");
            Console.WriteLine("0.Exit");
            Console.Write("Odgovor:");
        }
        /// <summary>
        /// Representing method of Menu
        /// </summary>
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
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadLine();
                        Console.Clear();
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

                    case Options.DeleteCountry:
                        Console.Clear();
                        DeleteCountry();
                        break;

                    case Options.DeleteWorldCup:
                        Console.Clear();
                        DeleteWorldCup();
                        break;

                    default:

                        break;
                }

            } while (opcije != Options.Exit);
        }

        /// <summary>
        /// Representing method which write all countrys
        /// </summary>
        public static void WriteAllCountrys()
        {
            foreach (KeyValuePair<int, Drzava> drzava in listaDrzava)
            {
                Drzava drzavaWrite = drzava.Value;
                Console.WriteLine(drzavaWrite.ID + " " + drzavaWrite.Naziv);
            }
        }

        /// <summary>
        /// Representing method which write all world cups
        /// </summary>
        public static void WriteAllWorldCups()
        {
            foreach (KeyValuePair<int, SvetskoPrvenstvo> svetskoPrvenstvo in listaSvetskihPrvenstva)
            {
                Console.WriteLine("ID:" + svetskoPrvenstvo.Value.ID + " Naziv:" + svetskoPrvenstvo.Value.Naziv + " Godina:" + svetskoPrvenstvo.Value.Godina + " Domacin:" + svetskoPrvenstvo.Value.Domacin.Naziv);
            }
        }

        /// <summary>
        /// Representing method for checking country name
        /// </summary>
        /// <returns></returns>
        public static bool CheckCountry(string name)
        {
            foreach (KeyValuePair<int, Drzava> drzava in listaDrzava)
            {
                if (drzava.Value.Naziv.Equals(name))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Representing method which allow user to add or change country
        /// </summary>
        public static void AddOrChangeCountry()
        {
            Console.WriteLine("1.Add");
            Console.WriteLine("2.Change");
            Console.Write("Option:");
            int option = Helper.CheckID();

            switch (option)
            {
                case 1:
                    Console.Clear();
                    int id = listaDrzava.Keys.Max() + 1;
                    Console.Write("Type the name of the country:");
                    string nameAdd = Helper.CheckString();

                    bool provera = CheckCountry(nameAdd);

                    if (provera)
                    {
                        Drzava drzavaAdd = new Drzava { ID = id, Naziv = nameAdd };
                        listaDrzava.Add(drzavaAdd.ID, drzavaAdd);

                        Console.Clear();
                        Console.WriteLine("Drzava je uspesno dodata!");
                    }
                    else
                    {
                        Console.WriteLine("That country name already exits!");
                    }

                    SaveCountry();

                    Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    break;

                case 2:
                    Console.Clear();
                    WriteAllCountrys();
                    Console.Write("Enter the id of the item which you want make changes:");
                    int idSelect = Helper.CheckID();

                    Console.Clear();

                    if (listaDrzava.ContainsKey(idSelect))
                    {
                        Drzava drzava = listaDrzava[idSelect];

                        Console.Write("Enter the name of the country:");
                        string nameChange = Helper.CheckString();

                        bool proveraNaziva = CheckCountry(nameChange);

                        if (proveraNaziva)
                        {
                            Console.Clear();

                            drzava = new Drzava { ID = idSelect, Naziv = nameChange };

                            listaDrzava[idSelect] = drzava;

                            SaveCountry();

                            Console.Clear();
                            Console.WriteLine("Drzava je uspesno izmenjena!");
                        }else
                        {
                            Console.WriteLine("That country name already exits!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("That ID does not exits!");
                    }

                    Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    break;


                default:
                    Console.WriteLine("That option does not exits!");
                    break;
            }
        }


        /// <summary>
        /// Representing method which allow user to add or change world cup
        /// </summary>
        public static void AddOrChangeWorldCup()
        {
            Console.WriteLine("1.Add");
            Console.WriteLine("2.Change");
            Console.Write("Options:");
            int option = Helper.CheckID();

            switch (option)
            {
                case 1:
                    Console.Clear();
                    Console.Write("Enter the name of the world cup:");
                    string naziv = Helper.CheckString();

                    Console.Clear();

                    Console.Write("Enter the year of the world cup:");
                    int yearAdd = Helper.CheckID();

                    Console.Clear();

                    WriteAllCountrys();
                    Console.Write("Enter the id of the \"Domacin\":");
                    int idDrzaveDomacina = Helper.CheckID();

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

                    SaveWorldCups();

                    Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    break;

                case 2:
                    Console.Clear();
                    WriteAllWorldCups();
                    Console.Write("Enter the ID of the world cup which you want edit:");
                    int idSelect = Helper.CheckID();

                    Console.Clear();

                    if (listaSvetskihPrvenstva.ContainsKey(idSelect))
                    {
                        SvetskoPrvenstvo svetskoPrvenstvo = listaSvetskihPrvenstva[idSelect];

                        Console.Write("Enter the name of the world cup:");
                        string nazivEdit = Helper.CheckString();

                        Console.Clear();

                        Console.Write("Enter the year of the world cup:");
                        int yearEdit = Helper.CheckID();

                        Console.Clear();

                        WriteAllCountrys();
                        Console.Write("Enter the ID of the \"Domacin\":");
                        int idDomacin = Helper.CheckID();

                        Console.Clear();

                        if (listaDrzava.ContainsKey(idDomacin))
                        {
                            Drzava drzavaDomacinEdit = listaDrzava[idDomacin];
                            svetskoPrvenstvo = new SvetskoPrvenstvo { ID = idSelect, Naziv = nazivEdit, Godina = yearEdit, Domacin = drzavaDomacinEdit };
                            listaSvetskihPrvenstva[idSelect] = svetskoPrvenstvo;

                            SaveWorldCups();

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

        /// <summary>
        /// Representing method which write sorted world cups
        /// </summary>
        /// <param name="svetskoPrvenstvo"></param>
        private static void WriteSortedWorldCups(Dictionary<int, SvetskoPrvenstvo> svetskoPrvenstvo)
        {
            foreach (KeyValuePair<int, SvetskoPrvenstvo> item in svetskoPrvenstvo)
            {
                Console.WriteLine("ID:" + item.Value.ID + " Naziv:" + item.Value.Naziv + " Godina:" + item.Value.Godina + " Domacin:" + item.Value.Domacin.Naziv);
            }
        }

        /// <summary>
        /// Representing method which write sorted countrys
        /// </summary>
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

        /// <summary>
        /// Representing method which write sorted world cups
        /// </summary>
        public static void SortWorldCup()
        {
            Console.WriteLine("1.Sortiraj po godini");
            Console.WriteLine("2.Sortiraj po nazivu države gde je održano svetsko prvenstvo");
            Console.Write("Options:");
            int idSelect = Helper.CheckID();

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

                    var sortedDictionaryByName = listaSvetskihPrvenstva.OrderBy(x => x.Value.Domacin.Naziv).ToDictionary(x => x.Key, x => x.Value);

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

        /// <summary>
        /// Representing method which write all world cups by range of year
        /// </summary>
        public static void WriteAllCountrysByRangeOfYears()
        {
            Console.Clear();
            Console.Write("Od:");
            int odGodine = Helper.CheckID();
            Console.Write("Do:");
            int doGodine = Helper.CheckID();

            Console.Clear();

            foreach (KeyValuePair<int, SvetskoPrvenstvo> svetskoPrvenstvo in listaSvetskihPrvenstva)
            {
                if (svetskoPrvenstvo.Value.Godina >= odGodine && svetskoPrvenstvo.Value.Godina <= doGodine)
                {
                    Console.WriteLine("ID:" + svetskoPrvenstvo.Value.ID + " Naziv:" + svetskoPrvenstvo.Value.Naziv + " Godina:" + svetskoPrvenstvo.Value.Godina + " Domacin:" + svetskoPrvenstvo.Value.Domacin.Naziv);
                }
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
            Console.Clear();
        }

        /// <summary>
        /// Representing method which write number of world cups countrys
        /// </summary>
        public static void NumberOfWorldCupsByCountry()
        {
            Console.Clear();
            var listaDrzava = listaSvetskihPrvenstva.Values.Select(x => x.Domacin.Naziv).Distinct().ToList();

            foreach (string name in listaDrzava)
            {
                int brojac = 0;

                foreach (KeyValuePair<int, SvetskoPrvenstvo> svetskoPrvenstvo in listaSvetskihPrvenstva)
                {
                    if (svetskoPrvenstvo.Value.Domacin.Naziv.Equals(name))
                    {
                        brojac++;
                    }
                }
                Console.WriteLine("Drzava:" + name + " " + brojac);
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
            Console.Clear();
        }

        /// <summary>
        /// Representing method which help software to don't crash when delete country
        /// </summary>
        /// <param name="countryID"></param>
        public void DeletingWorldCupWhenDeleteCountry(int countryID)
        {
            foreach (KeyValuePair<int,SvetskoPrvenstvo> svetskoPrvenstvo in listaSvetskihPrvenstva)
            {
                if (svetskoPrvenstvo.Value.Domacin.ID == countryID)
                {
                    listaSvetskihPrvenstva.Remove(svetskoPrvenstvo.Key);
                }
            }
        }

        /// <summary>
        /// Representing method for deleting country
        /// </summary>
        public void DeleteCountry()
        {
            WriteAllCountrys();
            Console.Write("Enter the ID of the country which you want delete:");
            int ID = Helper.CheckID();

            Console.Clear();

            if (listaDrzava.ContainsKey(ID))
            {
                listaDrzava.Remove(ID);

                DeletingWorldCupWhenDeleteCountry(ID);

                SaveCountry();
                SaveWorldCups();

                Console.WriteLine("Country has successfully deleted!");

                Console.ReadLine();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("That ID does not exits!");
            }
        }

        /// <summary>
        /// Representing method for deleting world cup
        /// </summary>
        public void DeleteWorldCup()
        {
            WriteAllWorldCups();
            Console.Write("Enter the ID of the world cup which you want delete:");
            int ID = Helper.CheckID();

            Console.Clear();

            if (listaSvetskihPrvenstva.ContainsKey(ID))
            {
                listaSvetskihPrvenstva.Remove(ID);

                SaveWorldCups();

                Console.WriteLine("World cup has successfully deleted!");

                Console.ReadLine();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("That ID does not exits!");
            }
        }

        /// <summary>
        /// Representing method used for load data
        /// </summary>
        public static void LoadData()
        {
            string lineDrzava;
            string lineWorldCup;

            StreamReader citacDrzava = File.OpenText(lokacija + "\\" + "data" + "\\" + "drzave.csv");

            while ((lineDrzava = citacDrzava.ReadLine()) != null)
            {
                Drzava drzava = new Drzava(lineDrzava);
                listaDrzava.Add(drzava.ID, drzava);
            }

            citacDrzava.Close();

            StreamReader citacSvetskihPrvenstava = File.OpenText(lokacija + "\\" + "data" + "\\" + "svetskaPrvenstva.csv");

            while ((lineWorldCup = citacSvetskihPrvenstava.ReadLine()) != null)
            {
                SvetskoPrvenstvo worldCup = new SvetskoPrvenstvo(lineWorldCup, listaDrzava);
                listaSvetskihPrvenstva.Add(worldCup.ID, worldCup);
            }

            citacSvetskihPrvenstava.Close();
        }

        /// <summary>
        /// Method used for saving data
        /// </summary>
        public static void SaveCountry()
        {
            if (File.Exists(lokacija + "\\" + "data" + "\\" + "drzave.csv"))
            {
                StreamWriter sw = new StreamWriter(lokacija + "\\" + "data" + "\\" + "drzave.csv");

                foreach (KeyValuePair<int, Drzava> drzava in listaDrzava)
                {
                    sw.WriteLine(drzava.Value.Save());
                }
                sw.Close();
            }
        }

        /// <summary>
        /// Method used for saving data
        /// </summary>
        public static void SaveWorldCups()
        {
            if (File.Exists(lokacija + "\\" + "data" + "\\" + "svetskaPrvenstva.csv"))
            {
                StreamWriter sw = new StreamWriter(lokacija + "\\" + "data" + "\\" + "svetskaPrvenstva.csv");

                foreach (KeyValuePair<int, SvetskoPrvenstvo> svetskoPrvenstvo in listaSvetskihPrvenstva)
                {
                    sw.WriteLine(svetskoPrvenstvo.Value.Save());
                }
                sw.Close();
            }
            else
            {
                Console.WriteLine("That file does not exits or destination is bad!");
            }
        }
    }
}