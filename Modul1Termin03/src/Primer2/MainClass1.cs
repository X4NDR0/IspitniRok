using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul1Termin03.Primer2
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
            //kreiranje pojedinacnih objekata za predmete

            //kreiramo objekat predmet koji je instanca klase Predmet
            Predmet[] predmeti = new Predmet[3];

            //predmet 1
            Predmet matematika = new Predmet();
            matematika.Id = 1;
            matematika.Naziv = "Matematika";                      
            predmeti[0] = matematika;
            //predmet 2
            predmeti[1] = new Predmet();
            predmeti[1].Id = 2;
            predmeti[1].Naziv = "Fizika";
            //predmet 3
            predmeti[2] = new Predmet();
            predmeti[2].Id = 3;
            predmeti[2].Naziv = "Elektrotehnika";
            stud.Predmeti = predmeti;


            //pozivamo metode
            Console.WriteLine("Ispis studenta " + stud.PreuzmiPotpunuTekstualnuReprezentacijuKlase());

            //STA DA SE RADI AKO DVA STUDENTA SLUŠAJU ISTI PREDMET???
            //DA LI KREIRATI NOVI OBJEKAT KOJI ĆE SADRŽATI ISTE PODATKE ILI...

            // jednostavnije kreiranje objekta i inicijalizacija
            //2,E2 02/2016,Savić,Ana,Novi Sad
            Student stud2 = new Student
            {
                Id = 2,
                Indeks = "E2 02/2016",
                Prezime = "Savić",
                Ime = "Ana",
                Grad = "Novi Sad"
            };
            //student pohađa predmete
            //kreiranje pojedinacnih objekata za predmete
            Predmet[] predmeti2 = new Predmet[1];
            //predmet 1
            predmeti2[0] = new Predmet();
            predmeti2[0].Id = 1;
            predmeti2[0].Naziv = "Matematika";
            //predmeti2[0] = matematika;

            //TO DO: Dodati unutar svakog predmeta niz studenata koji pohađaju dati predmet
            
            Console.ReadKey();
        }

    }
}
