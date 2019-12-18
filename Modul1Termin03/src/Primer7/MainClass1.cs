using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul1Termin03.Primer7
{
    class MainClass1
    {
        static void Main(string[] args)
        {
            List<Student> sviStudenti = new List<Student>();
            Student student1 = new Student(1, "Srđan", "Jevrić");
            Student student2 = new Student(2, "Ana", "Savić");
            Student student3 = new Student(3, "Branko", "Babić");
            Student student4 = new Student(3, "Branko", "Babić");

            //dodavanje studenata
            sviStudenti.Add(student1);
            sviStudenti.Add(student2);
            sviStudenti.Add(student3);
            sviStudenti.Add(student4);

            //deklaracija i inicijalizacija liste
            //List<Student> sviStudenti = new List<Student>()
            //{
            //    new Student(1, "Srđan", "Jevrić"),
            //    new Student(2, "Ana", "Savić"),
            //    new Student(3, "Branko", "Babić"),
            //    new Student(3, "Branko", "Babić")
            //};

            //nije potrebno cast-ovanje kao kod ArrayList
            Student stud = sviStudenti[0];
            Console.WriteLine("Prvi student u listi je: " + stud.Ime);

            //ipis objekata Student implicitnim pozivom metode ToString
            foreach (Student s in sviStudenti)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine("\nStandardna for petlja\n");

            for (int i = 0; i < sviStudenti.Count; i++)
            {
                Console.WriteLine(sviStudenti[i]);
            }

            if (student3 == student4)
            {
                Console.WriteLine("Dva ista objekta");
            }
            else
            {
                Console.WriteLine("Nisu isti objekti");
            }

            if (student3.Equals(student4))
            {
                Console.WriteLine("Dva ista objekta! Poređenje redefinisanom metodom Equals");
            }
            else
            {
                Console.WriteLine("Nisu isti objekti");
            }

            if (student3.GetHashCode() == student4.GetHashCode())
            {
                Console.WriteLine("Iste hash vrednosti dva objekta Studenta");
            }
            else
            {
                Console.WriteLine("Nisu iste hash vrednosti");
            }

            Console.ReadKey();
        }
    }
}
