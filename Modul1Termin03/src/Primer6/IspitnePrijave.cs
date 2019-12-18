using System;
using System.Linq;

namespace Modul1Termin03.Primer6
{
    class IspitnePrijave
    {
        public IspitnePrijave()
        {
            student = new Student();
            predmet = new Predmet();
            ispitniRok = new IspitniRok();
        }

        public IspitnePrijave(string numbers)
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

                //Adding
                student = FindMe;
                predmet = FindMe2;
                ispitniRok = FindMe3;
            }
        }

        public IspitnePrijave(Student student, Predmet predmet, IspitniRok ispitniRok, int brojBodovaZadaci, int brojBodovaTeorija,int ocena)
        {
            this.student = student;
            this.predmet = predmet;
            this.ispitniRok = ispitniRok;
            this.brojBodovaTeorija = brojBodovaTeorija;
            this.brojBodovaZadaci = brojBodovaZadaci;
            this.ocena = ocenaHelp;
        }

        public Student student;
        public Predmet predmet;
        public IspitniRok ispitniRok;

        public int studentID;
        public int predmetID;
        public int ispitniRokID;
        public int brojBodovaTeorija;
        public int brojBodovaZadaci;
        public int ocena;
        public static int ocenaHelp;
    }
}
