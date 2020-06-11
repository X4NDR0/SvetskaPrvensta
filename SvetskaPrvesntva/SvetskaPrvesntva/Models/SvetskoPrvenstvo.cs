using System;
using System.Collections.Generic;

namespace SvetskaPrvesntva.Models
{
    /// <summary>
    /// Representing class of svetsko prvenstvo
    /// </summary>
    public class SvetskoPrvenstvo
    {
        /// <summary>
        /// Representing class constructor with parametar (string data)
        /// </summary>
        /// <param name="data"></param>
        /// <param name="listaDrzavaInput"></param>
        public SvetskoPrvenstvo(string data, Dictionary<int, Drzava> listaDrzavaInput)
        {
            string[] podaci = data.Split(";");
            ID = Convert.ToInt32(podaci[0]);
            Naziv = podaci[1];
            Godina = Convert.ToInt32(podaci[2]);
            Domacin = listaDrzavaInput[Convert.ToInt32(podaci[3])];
        }

        /// <summary>
        /// Representing empty constructor of class
        /// </summary>
        public SvetskoPrvenstvo()
        {

        }

        /// <summary>
        /// Representing property of ID
        /// </summary>
        public int ID;

        /// <summary>
        /// Representing property of name
        /// </summary>
        public string Naziv;

        /// <summary>
        /// Representing property of year
        /// </summary>
        public int Godina;

        /// <summary>
        /// Representing property of Domacin
        /// </summary>
        public Drzava Domacin;

        /// <summary>
        /// Method for saving
        /// </summary>
        /// <returns></returns>
        public string Save()
        {
            string podaci = ID + ";" + Naziv + ";" + Godina + ";" + Domacin.ID;
            return podaci;
        }
    }
}
