using System;

namespace SvetskaPrvesntva.Models
{
    /// <summary>
    /// Representing class of country
    /// </summary>
    /// 

    public class Drzava
    {
        /// <summary>
        /// Preresentign empty class constructor
        /// </summary>
        public Drzava()
        {

        }

        /// <summary>
        /// Representing class constructor with parametar(string data)
        /// </summary>
        /// <param name="data"></param>
        public Drzava(string data)
        {
            string[] podaci = data.Split(";");
            ID = Convert.ToInt32(podaci[0]);
            Naziv = podaci[1];
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
        /// Method used for saving data
        /// </summary>
        /// <returns></returns>
        public string Save()
        {
            string text = ID + ";" + Naziv;
            return text;
        }
    }
}
