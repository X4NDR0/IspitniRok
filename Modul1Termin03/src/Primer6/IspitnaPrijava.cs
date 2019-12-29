using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Modul1Termin03.Primer6
{
    class IspitnaPrijava
    {
        public IspitnaPrijava()
        {

        }

        public IspitnaPrijava(string numbers, List<Student> listaStudenata, List<Predmet> listaPredmeta, List<IspitniRok> listaIspitnihRokova)
        {
            string[] manyID = numbers.Split(',');

            if (manyID.Length != 5)
            {
                Console.WriteLine("You have error in file.I'm can't read that!");
                Environment.Exit(0);
            }
            else
            {
                int studentId = Int32.Parse(manyID[0]);
                int predmetId = Int32.Parse(manyID[1]);
                int ispitniRokId = Int32.Parse(manyID[2]);
                BrojBodovaTeorija = Int32.Parse(manyID[3]);
                BrojBodovaZadaci = Int32.Parse(manyID[4]);

                Student = listaStudenata.Where(x => x.Id == studentId).FirstOrDefault();
                Predmet = listaPredmeta.Where(x => x.Id == predmetId).FirstOrDefault();
                IspitniRok = listaIspitnihRokova.Where(x => x.ID == ispitniRokId).FirstOrDefault();
            }
        }

        public Student Student;
        public Predmet Predmet;
        public IspitniRok IspitniRok;

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

        public string PreuzmiTekstualnuReprezentacijuKlase()
        {
            string text = Student.Id + "," + Predmet.Id + "," + IspitniRok.ID + "," + BrojBodovaTeorija + "," + BrojBodovaZadaci;
            return text;
        }

        public void ToFileString(List<IspitnaPrijava> lista)
        {
            StreamWriter recorder = new StreamWriter("C:\\Users\\XANDRO\\Desktop\\IspitnePrijave.csv");
            foreach (IspitnaPrijava ispitnaPrijava in lista)
            {
                recorder.WriteLine(ispitnaPrijava.PreuzmiTekstualnuReprezentacijuKlase());
            }
            recorder.Close();
        }

    }
}
