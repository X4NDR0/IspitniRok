using System;
using System.Linq;

namespace Modul1Termin03.Primer6
{
    class IspitnaPrijava
    {
        public Student student;
        public Predmet predmet;
        public IspitniRok ispitniRok;

        public int studentID;
        public int predmetID;
        public int ispitniRokID;
        public int brojBodovaTeorija;
        public int brojBodovaZadaci;
        public int ocena;

        public IspitnaPrijava()
        {
            student = new Student();
            predmet = new Predmet();
            ispitniRok = new IspitniRok();
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
                studentID = Int32.Parse(manyID[0]);
                predmetID = Int32.Parse(manyID[1]);
                ispitniRokID = Int32.Parse(manyID[2]);
                brojBodovaTeorija = Int32.Parse(manyID[3]);
                brojBodovaZadaci = Int32.Parse(manyID[4]);

                Student FindMe = MainClass1.sviStudenti.Where(x => x.Id == studentID).FirstOrDefault();
                Predmet FindMe2 = MainClass1.listaPredmeta.Where(x => x.Id == predmetID).FirstOrDefault();
                IspitniRok FindMe3 = MainClass1.listaIspitnihRokova.Where(x => x.id == ispitniRokID).FirstOrDefault();

                student = FindMe;
                predmet = FindMe2;
                ispitniRok = FindMe3;
            }
        }

        public IspitnaPrijava(Student student, Predmet predmet, IspitniRok ispitniRok, int brojBodovaZadaci, int brojBodovaTeorija)
        {
            this.student = student;
            this.predmet = predmet;
            this.ispitniRok = ispitniRok;
            this.brojBodovaTeorija = brojBodovaTeorija;
            this.brojBodovaZadaci = brojBodovaZadaci;
        }

        public void IzracunajOcenu()
        {
            int zbirBodova = (brojBodovaTeorija + brojBodovaZadaci);
            if (zbirBodova <= 50)
            {
                ocena = 5;
            }
            else if (zbirBodova < 65 && zbirBodova > 50)
            {
                ocena = 6;
            }
            else if (zbirBodova < 75 && zbirBodova > 65)
            {
                ocena = 7;
            }
            else if (zbirBodova < 85 && zbirBodova > 75)
            {
                ocena = 8;
            }
            else if (zbirBodova < 95 && zbirBodova > 85)
            {
                ocena = 9;
            }
            else if (zbirBodova < 100 && zbirBodova > 95)
            {
                ocena = 10;
            }
        }

    }
}
