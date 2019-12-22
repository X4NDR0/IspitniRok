using System;
using System.Linq;

namespace Modul1Termin03.Primer6
{
    class Pohadja
    {
        public Pohadja()
        {
            Student = new Student();
            Predmet = new Predmet();
        }

        public Pohadja(string podaci)
        {
            string[] text = podaci.Split(',');

            if (text.Length != 2)
            {
                Console.WriteLine("Error while reading!");
            }
            else
            {
                StudentID = Int32.Parse(text[0]);
                PredmetID = Int32.Parse(text[1]);

                Student FindStundent = MainClass1.sviStudenti.Where(x => x.Id == StudentID).FirstOrDefault();
                Predmet FindPredmet = MainClass1.listaPredmeta.Where(x => x.Id == PredmetID).FirstOrDefault();

                Student = FindStundent;
                Predmet = FindPredmet;
            }
        }

        public Pohadja(Student Student, Predmet Predmet)
        {
            this.Student = Student;
            this.Predmet = Predmet;
        }

        public Student Student;
        public Predmet Predmet;

        public int StudentID;
        public int PredmetID;
    }
}
