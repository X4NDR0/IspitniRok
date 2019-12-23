using System;
using System.Collections.Generic;
using System.Linq;

namespace Modul1Termin03.Primer6
{
    class IspitnaPrijava
    {
        public IspitnaPrijava(string numbers,List<Student> listaStudenata,List<Predmet> listaPredmeta,List<IspitniRok> listaIspitnihRokova)
        {
            string[] manyID = numbers.Split(',');

            if (manyID.Length != 5)
            {
                Console.WriteLine("You have error in file.I'm can't read that!");
                Environment.Exit(0);
            }
            else
            {
                StudentID = Int32.Parse(manyID[0]);
                PredmetID = Int32.Parse(manyID[1]);
                IspitniRokID = Int32.Parse(manyID[2]);
                BrojBodovaTeorija = Int32.Parse(manyID[3]);
                BrojBodovaZadaci = Int32.Parse(manyID[4]);

                Student FindMe = listaStudenata.Where(x => x.Id == StudentID).FirstOrDefault();
                Predmet FindMe2 = listaPredmeta.Where(x => x.Id == PredmetID).FirstOrDefault();
                IspitniRok FindMe3 = listaIspitnihRokova.Where(x => x.ID == IspitniRokID).FirstOrDefault();

                Student = FindMe;
                Predmet = FindMe2;
                IspitniRok = FindMe3;
            }
        }

        public Student Student;
        public Predmet Predmet;
        public IspitniRok IspitniRok;

        public int StudentID; 
        public int PredmetID;
        public int IspitniRokID;
        public int BrojBodovaTeorija;
        public int BrojBodovaZadaci;
        public int Ocena;

        public void IzracunajOcenu()
        {
            int zbirBodova = (BrojBodovaTeorija + BrojBodovaZadaci);
            if (zbirBodova <= 100 && zbirBodova > 1)
            {
                Ocena = 5;
            }
            else if (zbirBodova >= 100 && zbirBodova < 125)
            {
                Ocena = 6;
            }
            else if (zbirBodova >= 125 && zbirBodova < 135)
            {
                Ocena = 7;
            }
            else if (zbirBodova >= 135 && zbirBodova < 155)
            {
                Ocena = 8;
            }
            else if (zbirBodova >= 155 && zbirBodova < 174)
            {
                Ocena = 9;
            }
            else if (zbirBodova >= 175)
            {
                Ocena = 10;
            }
        }

    }
}
