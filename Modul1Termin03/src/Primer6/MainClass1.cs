using Modul1Termin03.Primer6;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Modul1Termin03.Primer6
{
    class MainClass1
    {
        //ispis
        public static void IspisiStudente(List<Student> lista)
        {
            //ispis svih studenata I NACIN
            for (int i = 0; i < lista.Count; i++)
            {
                Student st = (Student)lista[i];
                Console.WriteLine(st.PreuzmiTekstualnuReprezentacijuKlase());
            }

            //ispis svih studenata II NACIN
            //foreach (Student st in lista)
            //{
            //    Console.WriteLine(st.PreuzmiTekstualnuReprezentacijuKlase());
            //}
        }

        public static void IspisiIspite(List<IspitniRok> lista)
        {
            foreach (IspitniRok ispitniRok in lista)
            {
                Console.WriteLine("ID:" + ispitniRok.id + " Naziv:" + ispitniRok.naziv + " Pocetak:" + ispitniRok.pocetak + " Kraj:" + ispitniRok.kraj);
            }
        }

        public static void IzracunajOcenu(int zadaci, int teorija)
        {
            int rezultat = (zadaci + teorija);
            if (rezultat <= 50)
            {
                Console.WriteLine("5");
                IspitnePrijave.ocenaHelp = 5;
            }
            else if (rezultat < 65 && rezultat > 50)
            {
                Console.WriteLine("6");
                IspitnePrijave.ocenaHelp = 6;
            }
            else if (rezultat < 75 && rezultat > 65)
            {
                Console.WriteLine("7");
                IspitnePrijave.ocenaHelp = 7;
            }
            else if (rezultat < 85 && rezultat > 75)
            {
                Console.WriteLine("8");
                IspitnePrijave.ocenaHelp = 8;
            }
            else if (rezultat < 95 && rezultat > 85)
            {
                Console.WriteLine("9");
                IspitnePrijave.ocenaHelp = 9;
            }
            else if (rezultat < 100 && rezultat > 95)
            {
                Console.WriteLine("10");
                IspitnePrijave.ocenaHelp = 10;
            }
        }

        public static void IzracunajProsek(int teorija, int zadaci)
        {
            double rezultat = teorija + zadaci;
            double help = rezultat / 2;
            Console.WriteLine("Prosecan broj bodova je:" + help);
        }

        public static List<Student> sviStudenti = new List<Student>();
        public static List<IspitniRok> listaIspitnihRokova = new List<IspitniRok>();
        public static List<IspitnePrijave> listaIspitnihPrijava = new List<IspitnePrijave>();
        public static List<Predmet> listaPredmeta = new List<Predmet>();

        public static void Main(String[] args)
        { 
            //Ispitni Rok
            StreamReader srIr = new StreamReader("C:\\Users\\XANDRO\\Desktop\\Modul1\\Termin03\\data\\ispitni_rokovi.csv");
            string ispitniRokovi = srIr.ReadToEnd();

            string[] ispitniRok = ispitniRokovi.Split('\n');
            IspitniRok ispitniRokObject = null;

            for (int i = 0; i < ispitniRok.Length; i++)
            {
                ispitniRokObject = new IspitniRok(ispitniRok[i]);
                listaIspitnihRokova.Add(ispitniRokObject);
            }

            //Student
            StreamReader srStudent = new StreamReader("C:\\Users\\XANDRO\\Desktop\\Modul1\\Termin03\\data\\studenti.csv");
            string studenti = srStudent.ReadToEnd();
            string[] studentSplit = studenti.Split('\n');

            Student student = null;

            for (int i = 0; i < studentSplit.Length; i++)
            {
                student = new Student(studentSplit[i]);
                sviStudenti.Add(student);
            }

            //Predmeti
            StreamReader sr = new StreamReader("C:\\Users\\XANDRO\\Desktop\\Modul1\\Termin03\\data\\predmeti.csv");
            string predmeti = sr.ReadToEnd();
            string[] predmetSplit = predmeti.Split('\n');

            Predmet predmet = null;

            for (int i = 0; i < predmetSplit.Length; i++)
            {
                predmet = new Predmet(predmetSplit[i]);
                listaPredmeta.Add(predmet);
            }

            //Ispitne Prijave
            StreamReader srip = new StreamReader("C:\\Users\\XANDRO\\Desktop\\Modul1\\Termin03\\data\\ispitne_prijave.csv");
            string ispitnePrijave = srip.ReadToEnd();
            string[] ispitnePrij = ispitnePrijave.Split('\n');

            IspitnePrijave ispitnePrijaveObject = null;

            for (int i = 0; i < ispitnePrij.Length; i++)
            {
                ispitnePrijaveObject = new IspitnePrijave(ispitnePrij[i]);
                listaIspitnihPrijava.Add(ispitnePrijaveObject);
            }

            //Ispitne prijave popunjavanje


            //4,E1 01/2016,Sekulić,Miloš,Beograd
            sviStudenti.Insert(0, new Student(4, "Miloš ", "Sekulić", "Beograd", "E1 01/2016"));

            IspisiStudente(sviStudenti);

            Console.WriteLine("Ispis ispitnih rokova:");

            IspisiIspite(listaIspitnihRokova);

            Console.WriteLine("Izracunavanje ocene");

            for (int i = 0; i < listaIspitnihPrijava.Count; i++)
            {
                IzracunajOcenu(listaIspitnihPrijava[i].brojBodovaTeorija,listaIspitnihPrijava[i].brojBodovaZadaci);
            }

            Console.WriteLine("Izracuvanja proseka");
            for (int i = 0; i < listaIspitnihPrijava.Count; i++)
            {
                IzracunajProsek(listaIspitnihPrijava[i].brojBodovaTeorija,listaIspitnihPrijava[i].brojBodovaZadaci);
            }

            Console.WriteLine("******************************");
            //uklanjanje elemenata iz liste, ne i brisanje
            sviStudenti.RemoveAt(2);
            Console.WriteLine("Broj studenata je:" + sviStudenti.Count);

            //uklanjanje svih elemenata iz liste
            sviStudenti.Clear();
            Console.WriteLine("Broj studenata je:" + sviStudenti.Count);

            Console.WriteLine("Zavrsen rad sa listom");

            //TO DO: Dodati predmete studentima i unutar svakog predmeta niz studenata koji pohađaju dati predmet

            Console.ReadKey();
        }

    }
}
