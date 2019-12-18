using System;
using System.Collections.Generic;
using System.IO;

namespace Modul1Termin03.Primer6
{
    class MainClass1
    {
        public static List<Student> sviStudenti = new List<Student>();
        public static List<IspitniRok> listaIspitnihRokova = new List<IspitniRok>();
        public static List<IspitnaPrijava> listaIspitnihPrijava = new List<IspitnaPrijava>();
        public static List<Predmet> listaPredmeta = new List<Predmet>();
        public static void Main(String[] args)
        {
            LoadStudents();
            LoadPredmete();
            LoadIspitneRokove();
            LoadIspitnePrijave();

            sviStudenti.Insert(0, new Student(4, "Miloš ", "Sekulić", "Beograd", "E1 01/2016"));
            IspisiStudente(sviStudenti);

            Console.WriteLine("Ispis ispitnih rokova:");
            IspisiIspite(listaIspitnihRokova);

            Console.WriteLine("Izracunavanje ocene");

            foreach (IspitnaPrijava ispitnaPrijava in listaIspitnihPrijava)
            {
                ispitnaPrijava.IzracunajOcenu();
            }

            Console.WriteLine("Izracuvanja proseka");
            foreach (IspitnaPrijava ispitnePrijave2 in listaIspitnihPrijava)
            {
                IzracunajProsek(ispitnePrijave2.BrojBodovaZadaci,ispitnePrijave2.BrojBodovaTeorija);
            }

            Console.WriteLine("******************************");
            sviStudenti.RemoveAt(2);
            Console.WriteLine("Broj studenata je:" + sviStudenti.Count);

            sviStudenti.Clear();
            Console.WriteLine("Broj studenata je:" + sviStudenti.Count);

            Console.WriteLine("Zavrsen rad sa listom");

            Console.ReadKey();
        }

        public static void IzracunajProsek(int teorija, int zadaci)
        {
            double rezultat = teorija + zadaci;
            double help = rezultat / 2;
            Console.WriteLine("Prosecan broj bodova je:" + help);
        }

        public static void IspisiStudente(List<Student> lista)
        {
            foreach (Student student in lista)
            {
                Console.WriteLine(student.PreuzmiTekstualnuReprezentacijuKlase());
            }
        }

        public static void IspisiIspite(List<IspitniRok> lista)
        {
            foreach (IspitniRok ispitniRok in lista)
            {
                Console.WriteLine("ID:" + ispitniRok.ID + " Naziv:" + ispitniRok.Naziv + " Pocetak:" + ispitniRok.Pocetak + " Kraj:" + ispitniRok.Kraj);
            }
        }

        public static void IspisiPredmete(List<Predmet> lista)
        {
            foreach (Predmet predmet in lista)
            {
                Console.WriteLine("ID:" + predmet.Id + " Naziv:" + predmet.Naziv);
            }
        }

        public static void LoadStudents()
        {
            StreamReader srStudent = new StreamReader("C:\\Users\\XANDRO\\Desktop\\Modul1\\Termin03\\data\\studenti.csv");
            string studenti = srStudent.ReadToEnd();
            string[] studentSplit = studenti.Split('\n');

            Student student = null;

            for (int i = 0; i < studentSplit.Length; i++)
            {
                student = new Student(studentSplit[i]);
                sviStudenti.Add(student);
            }
        }

        public static void LoadPredmete()
        {
            StreamReader sr = new StreamReader("C:\\Users\\XANDRO\\Desktop\\Modul1\\Termin03\\data\\predmeti.csv");
            string predmeti = sr.ReadToEnd();
            string[] predmetSplit = predmeti.Split('\n');

            Predmet predmet = null;

            for (int i = 0; i < predmetSplit.Length; i++)
            {
                predmet = new Predmet(predmetSplit[i]);
                listaPredmeta.Add(predmet);
            }
        }

        public static void LoadIspitnePrijave()
        {
            StreamReader srip = new StreamReader("C:\\Users\\XANDRO\\Desktop\\Modul1\\Termin03\\data\\ispitne_prijave.csv");
            string ispitnePrijave = srip.ReadToEnd();
            string[] ispitnePrij = ispitnePrijave.Split('\n');

            IspitnaPrijava ispitnePrijaveObject = null;

            for (int i = 0; i < ispitnePrij.Length; i++)
            {
                ispitnePrijaveObject = new IspitnaPrijava(ispitnePrij[i]);
                listaIspitnihPrijava.Add(ispitnePrijaveObject);
            }
        }
        
        public static void LoadIspitneRokove()
        {
            StreamReader srIr = new StreamReader("C:\\Users\\XANDRO\\Desktop\\Modul1\\Termin03\\data\\ispitni_rokovi.csv");
            string ispitniRokovi = srIr.ReadToEnd();

            string[] ispitniRok = ispitniRokovi.Split('\n');
            IspitniRok ispitniRokObject = null;

            for (int i = 0; i < ispitniRok.Length; i++)
            {
                ispitniRokObject = new IspitniRok(ispitniRok[i]);
                listaIspitnihRokova.Add(ispitniRokObject);
            }
        }
    }
}
