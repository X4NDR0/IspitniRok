using System;
using System.Collections.Generic;
using System.Linq;

namespace Modul1Termin03.Primer6
{
    class Predaje
    {
        public Predaje(string podaci,List<Nastavnik> listaNastavnika,List<Predmet> listaPredmeta)
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

                Nastavnik FindNastavnik = listaNastavnika.Where(x => x.NastavnikID == NastavnikID).FirstOrDefault();
                Predmet FindPredmet = listaPredmeta.Where(x => x.Id == PredmetID).FirstOrDefault();

                Nastavnik = FindNastavnik;
                Predmet = FindPredmet;
            }
        }

        public Nastavnik Nastavnik;
        public Predmet Predmet;

        public int NastavnikID;
        public int PredmetID;
    }
}
