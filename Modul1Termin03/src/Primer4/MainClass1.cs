using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul1Termin03.Primer4
{
    class MainClass1
    {
        public static void IspisiStudente(Student[] niz)
        {
            for (int i = 0; i < niz.Length; i++)
            {
                //ispis vrednosti
                Console.WriteLine(niz[i].PreuzmiPotpunuTekstualnuReprezentacijuKlase());
            }
        }

        public static void Main(String[] args)
        {
            //predodredio da će biti baš 4 studenta
            //ŠTA JE LOŠE U OVOM PRISTUPU???
            Student[] nizStudentObjekata = new Student[4];

            //pozivanje konstruktora bez parametra
            Student student1 = new Student();
            //1,E2 01/2016,Jevrić,Srđan,Loznica
            student1.Id = 1;
            student1.Indeks = "E2 01/2016";
            student1.Prezime = "Jevrić";
            student1.Ime = "Srđan";
            student1.Grad = "Loznica";
            nizStudentObjekata[0] = student1;

            //pozivanje konstruktora sa vise parametara
            //2,E2 02/2016,Savić,Ana,Novi Sad
            Student student2 = new Student(2, "Savić", "Ana", "Novi Sad", "E2 02/2016");
            nizStudentObjekata[1] = student2;

            //pozivanje konstruktora sa 1 parametrom tipa String koji predstavlja očitani red iz csv fajla
            //3,E2 03/2016,Babić,Branko,Inđija
            Student student3 = new Student("3,E2 03/2016,Babić,Branko,Inđija");
            nizStudentObjekata[2] = student3;

            //pozivanje konstruktora sa vise parametara od kojih je jedan niz predmeta
            //4,E1 01/2016,Sekulić,Miloš,Beograd
            //Sekulić Miloš pohađa Matematiku,Elektrotehniku i Informatiku
            Predmet[] predmetiStudent4 = new Predmet[3];
            //predmet 1
            predmetiStudent4[0] = new Predmet();
            predmetiStudent4[0].Id = 1;
            predmetiStudent4[0].Naziv = "Matematika";
            //predmet 2
            predmetiStudent4[1] = new Predmet();
            predmetiStudent4[1].Id = 3;
            predmetiStudent4[1].Naziv = "Elektrotehniku";
            //predmet 3
            predmetiStudent4[2] = new Predmet();
            predmetiStudent4[2].Id = 4;
            predmetiStudent4[2].Naziv = "Informatiku";

            Student student4 = new Student(4, "Miloš", "Sekulić", "Beograd", "E1 01/2016", predmetiStudent4);
            nizStudentObjekata[3] = student4;

            IspisiStudente(nizStudentObjekata);

            Console.WriteLine("Zavrsen rad sa konstruktorima");
            Console.ReadKey();
        }

    }
}
