using System;
using System.Linq;

namespace Modul1Termin03.Primer6
{
    class Predaje
    {
        public Predaje()
        {
            Nastavnik = new Nastavnik();
            Predmet = new Predmet();
        }

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

                Nastavnik FindNastavnik = MainClass1.listaNastavnika.Where(x => x.NastavnikID == NastavnikID).FirstOrDefault();
                Predmet FindPredmet = MainClass1.listaPredmeta.Where(x => x.Id == PredmetID).FirstOrDefault();

                Nastavnik = FindNastavnik;
                Predmet = FindPredmet;
            }
        }

        public Predaje(Nastavnik Nastavnik,Predmet Predmet)
        {
            this.Nastavnik = Nastavnik;
            this.Predmet = Predmet;
        }

        public Nastavnik Nastavnik;
        public Predmet Predmet;

        public int NastavnikID;
        public int PredmetID;
    }
}
