using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul1Termin03.Primer1
{
    class MainClass1
    {
        public static void Main(String[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            //kreiramo objekat student koji je instanca klase Student
            Student stud = new Student();
            //postavimo atribute na odredjene vrednosti
            //1,E2 01/2016,Jevrić,Srđan,Loznica
            stud.Id = 1;
            stud.Indeks = "E2 01/2016";
            stud.Prezime = "Jevrić";
            stud.Ime = "Srđan";
            stud.Grad = "Loznica";
            //student pohađa predmete
            String[] predmeti = { "Matematika", "Fizika", "Elektrotehnika" };
            stud.Predmeti = predmeti;

            Console.WriteLine("Student sa id " + stud.Id + " čije je ime i prezime "
                    + stud.Ime + " " + stud.Prezime + " ima indeks "
                    + stud.Indeks + " i zivi u gradu " + stud.Grad);
            //pozivamo metode
            //Console.WriteLine("Ispis studenta " + stud.PreuzmiTekstualnuReprezentacijuKlase());

            Student stud2 = new Student();
            //2,E2 02/2016,Savić,Ana,Novi Sad
            stud2.Id = 2;
            stud2.Indeks = "E2 02/2016";
            stud2.Prezime = "Savić";
            stud2.Ime = "Ana";
            stud2.Grad = "Novi Sad";
            //student pohađa predmete
            String[] predmeti2 = { "Matematika", "Elektrotehnika" };
            stud2.Predmeti = predmeti2;
            stud2.PostaviNovoIme("Ivana");

            //stud2 = stud;
            //stud = null;
            //stud2 = null;
            Console.WriteLine("Ispis studenta " + stud2.PreuzmiPotpunuTekstualnuReprezentacijuKlase());
            Console.ReadKey();
        }
    }
}
