using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul1Termin03.Primer6
{
    class Nastavnik
    {
        public Nastavnik(string podaci)
        {
            string[] splitter = podaci.Split(',');
            if (splitter.Length != 4)
            {
                Console.WriteLine("Error while reading!");
            }else
            {
                NastavnikID = Int32.Parse(splitter[0]);
                Ime = splitter[1];
                Prezime = splitter[2];
                Znanje = splitter[3];
            }
        }

        public int NastavnikID;
        public string Ime;
        public string Prezime;
        public string Znanje;
    }
}
