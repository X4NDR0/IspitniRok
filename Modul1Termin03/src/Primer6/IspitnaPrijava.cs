using System;
using System.Linq;

namespace Modul1Termin03.Primer6
{
    class IspitnaPrijava
    {
        public Student Student;
        public Predmet Predmet;
        public IspitniRok IspitniRok;

        public int StudentID;
        public int PredmetID;
        public int IspitniRokID;
        public int BrojBodovaTeorija;
        public int BrojBodovaZadaci;
        public int Ocena;

        public IspitnaPrijava()
        {
            Student = new Student();
            Predmet = new Predmet();
            IspitniRok = new IspitniRok();
        }

        public IspitnaPrijava(string numbers)
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

                Student FindMe = MainClass1.sviStudenti.Where(x => x.Id == StudentID).FirstOrDefault();
                Predmet FindMe2 = MainClass1.listaPredmeta.Where(x => x.Id == PredmetID).FirstOrDefault();
                IspitniRok FindMe3 = MainClass1.listaIspitnihRokova.Where(x => x.ID == IspitniRokID).FirstOrDefault();

                Student = FindMe;
                Predmet = FindMe2;
                IspitniRok = FindMe3;
            }
        }

        public IspitnaPrijava(Student student, Predmet predmet, IspitniRok ispitniRok, int brojBodovaZadaci, int brojBodovaTeorija)
        {
            this.Student = student;
            this.Predmet = predmet;
            this.IspitniRok = ispitniRok;
            this.BrojBodovaTeorija = brojBodovaTeorija;
            this.BrojBodovaZadaci = brojBodovaZadaci;
        }

        public void IzracunajOcenu()
        {
            int zbirBodova = (BrojBodovaTeorija + BrojBodovaZadaci);
            if (zbirBodova < 100)
            {
                Ocena = 5;
            }
            else if (zbirBodova < 125 && zbirBodova > 100)
            {
                Ocena = 6;
            }
            else if (zbirBodova < 130 && zbirBodova > 125)
            {
                Ocena = 7;
            }
            else if (zbirBodova < 155 && zbirBodova > 145)
            {
                Ocena = 8;
            }
            else if (zbirBodova < 170 && zbirBodova > 155)
            {
                Ocena = 9;
            }
            else if (zbirBodova < 175)
            {
                Ocena = 10;
            }
        }

    }
}
