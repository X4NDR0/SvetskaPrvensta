using System;

namespace SvetskaPrvenstva.Utils
{
    /// <summary>
    /// Reperesenting class which check strings and int's
    /// </summary>
    public static class Helper
    {
        /// <summary>
        /// Representing method used for checking int
        /// </summary>
        /// <returns></returns>
        public static int CheckID()
        {
            int id;
            while (Int32.TryParse(Console.ReadLine(), out id) == false)
            {
                Console.Write("Wrong input,try again:");
            }
            return id;
        }

        /// <summary>
        /// Representing method used for checking strings
        /// </summary>
        /// <returns></returns>
        public static string CheckString()
        {
            string data = string.Empty;
            while (data == null || data.Equals("") || data.Equals(" "))
            {
                data = Console.ReadLine();
            }
            return data;
        }
    }
}
