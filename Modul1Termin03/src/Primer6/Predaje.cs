using System;

namespace Modul1Termin03.Primer6
{
    class Predaje
    {
        public Predaje(string podaci)
        {
            string[] text = podaci.Split(',');
            if (text.Length != 2)
            {
                Console.WriteLine("Error while reading!");
            }
            else
            {
                NastavnikID = Int32.Parse(text[0]);
                PredmetID = Int32.Parse(text[1]);
            }
        }

        public int NastavnikID;
        public int PredmetID;
    }
}
