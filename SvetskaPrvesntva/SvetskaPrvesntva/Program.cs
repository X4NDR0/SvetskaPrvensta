using System;

namespace SvetskaPrvesntva
{
    class Program
    {
        static void Main(string[] args)
        {
            SvetskaPrvenstvaService serviceStart = new SvetskaPrvenstvaService();
            serviceStart.Menu();
        }
    }
}
